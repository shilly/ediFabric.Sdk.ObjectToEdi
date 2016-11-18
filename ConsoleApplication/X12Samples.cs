using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdiFabric.Framework;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.X12002040810;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    /// <summary>
    /// ISA D_701_16 and D_726_11 are automatically set.
    /// All trailers are set automatically and do not need to be populated.
    /// </summary>
    class X12Samples
    {
        /// <summary>
        /// Generate an interchange as a collection of segments.
        /// This is a valid EDI message.
        /// </summary>
        public static void Generate()
        {
            var m810 = X12Helper.CreateMessage();
            var groupHeader = X12Helper.CreateGs();
            var interchangeHeader = X12Helper.CreateIsa();

            var ediGroup = new X12Group<M_810>(groupHeader);
            ediGroup.AddItem(m810);
            var ediInterchange = new X12Interchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
            // The segments can be concatenated with postfix (new line, etc.)
        }

        /// <summary>
        /// Generate EDI message with no postfix.
        /// </summary>
        public static void GenerateToString()
        {
            var m810 = X12Helper.CreateMessage();
            var groupHeader = X12Helper.CreateGs();
            var interchangeHeader = X12Helper.CreateIsa();

            var ediGroup = new X12Group<M_810>(groupHeader);
            ediGroup.AddItem(m810);
            var ediInterchange = new X12Interchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
            string edi = ediSegments.Aggregate("",
                (current, segment) => current + segment);
        }

        /// <summary>
        /// Generates EDI string with a postfix (CRLF in this example).
        /// </summary>
        public static void GenerateToStringWithCrLfPostfix()
        {
            var m810 = X12Helper.CreateMessage();
            var groupHeader = X12Helper.CreateGs();
            var interchangeHeader = X12Helper.CreateIsa();

            var ediGroup = new X12Group<M_810>(groupHeader);
            ediGroup.AddItem(m810);
            var ediInterchange = new X12Interchange(interchangeHeader);
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
            var m810 = X12Helper.CreateMessage();
            var groupHeader = X12Helper.CreateGs();
            var interchangeHeader = X12Helper.CreateIsa();

            var ediGroup = new X12Group<M_810>(groupHeader);
            ediGroup.AddItem(m810);
            var ediInterchange = new X12Interchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            var defaultSep = Separators.DefaultSeparatorsX12();
            var newSep = Separators.SeparatorsX12('>', ':',
                defaultSep.DataElement,
                defaultSep.RepetitionDataElement);
            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi(newSep);
        }

        /// <summary>
        /// Validates a message object.
        /// </summary>
        public static void Validation()
        {
            var m810 = X12Helper.CreateMessage();
            List<string> errors = m810.Validate().Flatten().ToList();
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
            var m810 = X12Helper.CreateMessage();
            XDocument xml = m810.Serialize();
        }
    }
}
