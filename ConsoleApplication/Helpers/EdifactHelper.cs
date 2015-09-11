using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using EdiFabric.Framework.Envelopes.Edifact;
using EdiFabric.Framework.Messages;
using EdiFabric.Sdk.ObjectToEdi.CustomClasses.Edifact;
using EdiFabric.Sdk.ObjectToEdi.EdiMaps.Helpers;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication.Helpers
{
    static class EdifactHelper
    {
        private static Message GenerateInvoicMessageWithCompiledXsltMap(CustomInvoic customInvoic)
        {
            // Map the custom EDI into ediFabric EDI (the instance of the class that represents the transaction set & version)
            var serializedCustomInvoic = XslHelper.Serialize(customInvoic, "customedifact");
            // This uses a precompiled xslt, therefore needs to serialize to XML first
            // You can generate an xsd for the custom object using xsd.exe or xsd2code
            var ediFabricInvoic = serializedCustomInvoic.Map();

            // Create ediFabric message (this serializes the instance and passes the xml + context (transaction set, version, format))
            var msg = new Message(ediFabricInvoic);

            // Set the UNT segment count
            SetSegmentsCount(ref msg);

            // Validate to ensure it's a valid EDI message
            var brokenRules = msg.Validate().ToList();

            if (brokenRules.Any())
            {
                // Do something if the message is invalid
                foreach (var br in brokenRules)
                    Debug.WriteLine(br);
            }

            return msg;
        }

        private static S_UNB CreateUnb()
        {
            return new S_UNB
            {
                C_S001 = new C_S001
                {
                    // Syntax Identifier
                    D_0001_1 = "UNOB",
                    // Syntax Version Number
                    D_0002_2 = "1"
                },
                C_S002 = new C_S002
                {
                    // Interchange sender identification
                    D_0004_1 = "SENDERID",
                    // Identification code qualifier
                    D_0007_2 = "01",
                    // Interchange sender internal identification
                    D_0008_3 = "ZZUK"
                },
                C_S003 = new C_S003
                {
                    // Interchange recipient identification
                    D_0010_1 = "PARTNERID",
                    // Identification code qualifier
                    D_0007_2 = "02",
                    // Interchange recipient internal identification
                    D_0014_3 = "ZZUK"
                },
                C_S004 = new C_S004
                {
                    // Date
                    D_0017_1 = DateTime.Now.Date.ToString("YYMMdd"),
                    // Time
                    D_0019_2 = DateTime.Now.TimeOfDay.ToString("hhmm")
                },
                // Interchange control reference
                // Must be incremented with every interchange
                D_0020_5 = "1",
                // Application reference
                D_0026_7 = "INVOIC"
            };
        }

        private static S_UNZ CreateUnz()
        {
            return new S_UNZ
            {
                // Interchange control count
                D_0036_1 = "1",
                // Interchange control reference
                D_0020_2 = "1"
            };
        }

        private static Group CreateGroup(Message message)
        {
            return new Group
            {
                Messages = new List<Message> {message}
            };
        }

        private static void SetSegmentsCount(ref Message msg)
        {
            // Set the UNT segment count
            var segCount =
                msg.Item.Descendants()
                    .Count(
                        d =>
                            d.Name.LocalName.StartsWith("S_") && !string.IsNullOrEmpty(d.Value) &&
                            !string.IsNullOrWhiteSpace(d.Value));

            var nmn = new XmlNamespaceManager(new NameTable());
            nmn.AddNamespace("p", "www.edifabric.com/edifact");

            var untSegCount = msg.Item.XPathSelectElement("./p:S_UNT/p:D_0074_1", nmn);
            untSegCount.SetValue(segCount);
        }

        internal static Interchange CreateInterchange(CustomInvoic customInvoic)
        {
            var message = GenerateInvoicMessageWithCompiledXsltMap(customInvoic);
            return new Interchange
            {
                Unb = CreateUnb(),
                Unz = CreateUnz(),
                Groups = new List<Group> {CreateGroup(message)}
            };
        }

        internal static CustomInvoic CreateSampleCustomInvoic()
        {
            // Create a sample instance of a custom type
            // This will be your message(s) that have to be converted into EDI
            const string sampleEdi = "EdiFabric.Sdk.ObjectToEdi.ConsoleApplication.TestFiles.CustomEdifact.xml";
            var xEl = XElement.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(sampleEdi));
            return XslHelper.Deserialize<CustomInvoic>(xEl, "customedifact");
        }
    }
}
