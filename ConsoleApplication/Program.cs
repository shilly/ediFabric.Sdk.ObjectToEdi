namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class Program
    {
        private static void Main()
        {
            X12();
            Edifact();
        }

        private static void X12()
        {
            X12Samples.Generate();
            X12Samples.GenerateWithCustomSeparators();
            X12Samples.Validation();
            X12Samples.ConvertToXml();
            X12Samples.GenerateToString();
            X12Samples.GenerateToStringWithCrLfPostfix();
        }

        private static void Edifact()
        {
            EdifactSamples.Generate();
            EdifactSamples.GenerateWithCustomSeparators();
            EdifactSamples.Validation();
            EdifactSamples.ConvertToXml();
            EdifactSamples.GenerateToString();
            EdifactSamples.GenerateToStringWithCrLfPostfix();
        }
    }
}
