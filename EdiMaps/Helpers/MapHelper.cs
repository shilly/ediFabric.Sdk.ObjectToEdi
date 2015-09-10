using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using AutoMapper;
using EdiFabric.Sdk.ObjectToEdi.EdiMaps.Automapper;

namespace EdiFabric.Sdk.ObjectToEdi.EdiMaps.Helpers
{
    public static class MapHelper
    {
        public static Definitions.X12_002040_810.M_810 Map(this CustomClasses.X12.Custom810 custom810)
        {
            Debug.Assert(custom810 != null);

            To810Map.CreateMap();

            return Mapper.Map<CustomClasses.X12.Custom810, Definitions.X12_002040_810.M_810>(custom810);
        }

        /// <summary>
        /// To recompile it use:
        /// Open cmd console
        /// Go to \EdiFabric.Sdk.ObjectToEdi\CustomMaps\Xslt
        /// Run xsltc /out:ToEdifabricInvoic.dll /settings:script+ CustomInvoic_To_EdiFabricInvoic.xslt
        /// Replace the reference to ToCustomInvoic.dll and rebuild
        /// </summary>    
        public static Definitions.Edifact_D00A_INVOIC.M_INVOIC Map(this XElement customInvoic)
        {
            Debug.Assert(customInvoic != null);

            var from = XslHelper.ToByte(customInvoic);

            if (from == null)
                throw new InvalidOperationException(
                    "Expected valid input stream before transform in pre-compiled map ToEdifabricInvoic");

            var to = XslHelper.ExecuteCompiledXslMap(typeof(CustomInvoic_To_EdiFabricInvoic), from);

            if (to == null || to.Length == 0)
                throw new InvalidOperationException("Expected valid output stream after transform for map ToEdifabricInvoic precompiled map");

            var mapped = XElement.Load(new MemoryStream(to));

            var result = XslHelper.Deserialize<Definitions.Edifact_D00A_INVOIC.M_INVOIC>(mapped, "www.edifabric.com/edifact");

            return result;
        }
    }
}
