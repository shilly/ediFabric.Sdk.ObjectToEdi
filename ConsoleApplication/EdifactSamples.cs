using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EdiFabric.Framework;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.EdifactD00AINVOIC;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class EdifactSamples
    {
        /// <summary>
        /// Generates a collection of segments.
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
        }

        /// <summary>
        /// Generates EDI string.
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
        /// ISA D_701_16 and D_726_11 are automatically set.
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
        /// Validates the object before generating EDI.
        /// </summary>
        public static void GenerateWithValidation()
        {
            var mInvoic = EdifactHelper.CreateMessage();
            var errors = mInvoic.Validate();
            if (errors.Any())
            {
                // Inspect errors
            }

            var interchangeHeader = EdifactHelper.CreateUnb();
            var ediGroup = new EdifactGroup<M_INVOIC>(null);
            ediGroup.AddItem(mInvoic);
            var ediInterchange = new EdifactInterchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
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
