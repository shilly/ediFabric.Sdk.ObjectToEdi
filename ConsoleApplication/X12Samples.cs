using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EdiFabric.Framework;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.X12002040810;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class X12Samples
    {
        /// <summary>
        /// Generates a collection of segments.
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
        }

        /// <summary>
        /// Generates EDI string.
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
        /// Generates EDI string with a postfix (CRLF in this example)
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
        /// ISA D_701_16 and D_726_11 are automatically set.
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
        /// Validates the object before generating EDI.
        /// </summary>
        public static void GenerateWithValidation()
        {
            var m810 = X12Helper.CreateMessage();
            var xsd =
                Assembly.Load("EdiFabric.Sdk.ObjectToEdi.Xsd")
                    .GetManifestResourceStream("EdiFabric.Sdk.ObjectToEdi.Xsd.EF_X12_002040_810.xsd");
            var errors = m810.ValidateX12(xsd);
            if (errors.Any())
            {
                // Inspect errors
            }

            var groupHeader = X12Helper.CreateGs();
            var interchangeHeader = X12Helper.CreateIsa();

            var ediGroup = new X12Group<M_810>(groupHeader);
            ediGroup.AddItem(m810);
            var ediInterchange = new X12Interchange(interchangeHeader);
            ediInterchange.AddItem(ediGroup);

            IEnumerable<string> ediSegments = ediInterchange.GenerateEdi();
        }

        /// <summary>
        /// Converts object to XML.
        /// </summary>
        public static void ConvertToXml()
        {
            var m810 = X12Helper.CreateMessage();
            XDocument xml = m810.SerializeX12();
        }
    }
}
