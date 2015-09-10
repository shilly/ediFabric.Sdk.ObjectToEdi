using System;
using System.Linq;
using EdiFabric.Sdk.ObjectToEdi.ConsoleApplication.Helpers;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            var ediFactInterchange = EdifactHelper.CreateInterchange(EdifactHelper.CreateSampleCustomInvoic());
            var ediFactSegments = ediFactInterchange.ToEdi();
            var ediFactInvoice = ediFactSegments.Aggregate("", (current, segment) => current + segment + Environment.NewLine);

            var x12Interchange = X12Helper.CreateInterchange(X12Helper.CreateSampleCustom810());
            var x12Segments = x12Interchange.ToEdi();
            var x12Invoice = x12Segments.Aggregate("", (current, segment) => current + segment + Environment.NewLine);
        }
    }
}
