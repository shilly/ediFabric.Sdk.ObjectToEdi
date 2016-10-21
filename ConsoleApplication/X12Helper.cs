using System;
using System.Collections.Generic;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.X12002040810;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    class X12Helper
    {
        internal static S_GS CreateGs()
        {
            return new S_GS
            {
                // Functional ID Code
                D_479_1 = "IN",
                // Application Senders Code
                D_142_2 = "SENDERID",
                // Application Receivers Code
                D_124_3 = "PARTNERID",
                // Date
                D_29_4 = DateTime.Now.Date.ToString("YYMMdd"),
                // Time
                D_30_5 = DateTime.Now.TimeOfDay.ToString("hhmm"),
                // Group Control Number
                // Must be unique to both partners for this interchange
                D_28_6 = "111111111",
                // Responsible Agency Code
                D_455_7 = "X",
                // Version/Release/Industry id code
                D_480_8 = "002040"
            };
        }

        internal static S_ISA CreateIsa()
        {
            return new S_ISA
            {
                // Authorization Information Qualifier
                D_744_1 = "00",
                // Authorization Information
                D_745_2 = "          ",
                // Security Information Qualifier
                D_746_3 = "00",
                // Security Information
                D_747_4 = "          ",
                // Interchange ID Qualifier
                D_704_5 = "01",
                // Interchange Sender
                D_705_6 = "SENDERID",
                // Interchange ID Qualifier
                D_704_7 = "02",
                // Interchange Receiver
                D_706_8 = "PARTNERID",
                // Date
                D_373_9 = DateTime.Now.Date.ToString("YYMMdd"),
                // Time
                D_337_10 = DateTime.Now.TimeOfDay.ToString("hhmm"),
                // Standard identifier
                D_726_11 = "U",
                // Interchange Version ID
                // This is the ISA version and not the transaction sets versions
                D_703_12 = "00204",
                // Interchange Control Number
                D_709_13 = "111111111",
                // Acknowledgment Requested (0 or 1)
                D_749_14 = "1",
                // Test Indicator
                D_748_15 = "T",
             };
        }

        internal static M_810 CreateMessage()
        {
            var result = new M_810 {G_IT1 = new List<G_IT1>()};
            
            var gIt1 = new G_IT1();
            var sIt1 = new S_IT1
            {
                D_350_1 = "A",
                D_358_2 = "B",
                D_355_3 = "C",
                D_212_4 = "D",
                D_639_5 = "E",
                D_234_7 = "F"
            };
            gIt1.S_IT1 = sIt1;

            result.G_IT1.Add(gIt1);

            var st = new S_ST {D_143_1 = "810", D_329_2 = "001"};

            result.S_ST = st;
            result.S_SE = new S_SE();

            return result;
        }
    }
}
