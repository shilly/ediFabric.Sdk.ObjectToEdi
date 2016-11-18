using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdiFabric.Framework;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.EdifactD00AINVOIC;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    /// <summary>
    /// All trailers are set automatically and do not need to be populated.
    /// </summary>
    class EdifactSamples
    {
        /// <summary>
        /// Generate an interchange as a collection of segments.
        /// This is a valid EDI message.
        /// </summary>
        public static void Generate()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            var interchangeHeader = EdifactHelper.CreateUnb();

            var ediGroup = new EdifactGroup<M_INVOIC>(null);
            ediGroup.AddItem(mInvoic);
            var ediInterchange = new EdifactInterchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
            // The segments can be concatenated with postfix (new line, etc.)
        }

        /// <summary>
        /// Generate EDI message with no postfix.
        /// </summary>
        public static void GenerateToString()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            var interchangeHeader = EdifactHelper.CreateUnb();

            var ediGroup = new EdifactGroup<M_INVOIC>(null);
            ediGroup.AddItem(mInvoic);
            var ediInterchange = new EdifactInterchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
            string edi = ediSegments.Aggregate("",
                (current, segment) => current + segment);
        }

        /// <summary>
        /// Generates EDI string with a postfix (CRLF in this example)
        /// </summary>
        public static void GenerateToStringWithCrLfPostfix()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            var interchangeHeader = EdifactHelper.CreateUnb();

            var ediGroup = new EdifactGroup<M_INVOIC>(null);
            ediGroup.AddItem(mInvoic);
            var ediInterchange = new EdifactInterchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
            string edi = ediSegments.Aggregate("",
                (current, segment) =>
                    current + segment + Environment.NewLine);
        }

        /// <summary>
        /// Generates EDI with custom separators.
        /// </summary>
        public static void GenerateWithCustomSeparators()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            var interchangeHeader = EdifactHelper.CreateUnb();

            var ediGroup = new EdifactGroup<M_INVOIC>(null);
            ediGroup.AddItem(mInvoic);
            var ediInterchange = new EdifactInterchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            var defaultSep = Separators.DefaultSeparatorsEdifact();
            var newSep = Separators.SeparatorsEdifact('>', ':',
                defaultSep.DataElement,
                defaultSep.RepetitionDataElement,
                defaultSep.Escape);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi(newSep);
        }

        /// <summary>
        /// Validates a message object.
        /// </summary>
        public static void Validation()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            List<string> errors = mInvoic.Validate().Flatten().ToList();
            if (errors.Any())
            {
                // Inspect errors
                foreach (var error in errors)
                {
                    // Log error, etc.
                }
            }
        }

        /// <summary>
        /// Converts object to XML.
        /// </summary>
        public static void ConvertToXml()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            XDocument xml = mInvoic.Serialize();
        }
    }
}
