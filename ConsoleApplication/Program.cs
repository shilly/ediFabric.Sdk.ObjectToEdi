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
            X12Samples.GenerateWithValidation();
            X12Samples.ConvertToXml();
            X12Samples.GenerateToString();
            X12Samples.GenerateToStringWithCrLfPostfix();
        }

        private static void Edifact()
        {
            EdifactSamples.Generate();
            EdifactSamples.GenerateWithCustomSeparators();
            EdifactSamples.GenerateWithValidation();
            EdifactSamples.ConvertToXml();
            EdifactSamples.GenerateToString();
            EdifactSamples.GenerateToStringWithCrLfPostfix();
        }
    }
}
