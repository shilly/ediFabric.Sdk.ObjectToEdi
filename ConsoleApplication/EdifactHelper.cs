using System;
using System.Collections.Generic;
using EdiFabric.Framework.Controls;
using EdiFabric.Rules.EdifactD00AINVOIC;

namespace EdiFabric.Sdk.ObjectToEdi.ConsoleApplication
{
    static class EdifactHelper
    {
        internal static S_UNB CreateUnb()
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

        internal static M_INVOIC CreateMessage()
        {
            var result = new M_INVOIC {G_LIN = new List<G_LIN>()};

            var gLin = new G_LIN();
            var sLin = new S_LIN
            {
                D_1082_1 = "1",
                D_1229_2 = "A",
                C_C212 = new C_C212 {D_7140_1 = "B", D_7143_2 = "C", D_1131_3 = "D"},
                C_C829 = new C_C829 {D_5495_1 = "E", D_1082_2 = "F"},
                D_7083_6 = "G"
            };
            gLin.S_LIN = sLin;

            result.G_LIN.Add(gLin);

            var unh = new S_UNH
            {
                D_0062_1 = "001",
                C_S009 = new C_S009 {D_0065_1 = "INVOIC", D_0052_2 = "D", D_0054_3 = "00A", D_0051_4 = "UN"}
            };

            result.S_UNH = unh;
            result.S_UNT = new S_UNT();

            return result;
        }       
    }
}
