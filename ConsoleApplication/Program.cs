using System;
using System.Linq;
using EdiFabric.Sdk.ObjectToEdi.ConsoleApplication.Helpers;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            // This sample will generate an EDI message from a custom object. The steps are:
            // 1. It creates an Interchange out of a single custom object. 
            // For simplicity the custom object bears the same structure as the ediFabric object. The only difference being the root element and the namespace
            // 2. Validates the Message object to ensure it adheres to the EDI rules for this transaction and version
            // 3. Converts the Interchange into a list of segments. This way any preference on postfixes can be attached at the end of each segment.
            // 4. Converts the list of segments into a real EDI message with CRLF postfix
            // The default locations for the transaction set classes and validation XSD are set in the app.config

            // This sample is for Edifact and uses a compiled XSLT map to convert from custom object to ediFabric object
            var ediFactInterchange = EdifactHelper.CreateInterchange(EdifactHelper.CreateSampleCustomInvoic());
            var ediFactSegments = ediFactInterchange.ToEdi();
            var ediFactInvoice = ediFactSegments.Aggregate("", (current, segment) => current + segment + Environment.NewLine);

            // This sample is for X12 and uses a code map (I used Automapper, but could be any custom code\mapper) to convert from custom object to ediFabric object
            var x12Interchange = X12Helper.CreateInterchange(X12Helper.CreateSampleCustom810());
            var x12Segments = x12Interchange.ToEdi();
            var x12Invoice = x12Segments.Aggregate("", (current, segment) => current + segment + Environment.NewLine);
        }
    }
}
