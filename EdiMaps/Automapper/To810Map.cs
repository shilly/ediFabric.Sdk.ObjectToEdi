using AutoMapper;
using EdiFabric.Definitions.X12_002040_810;
using EdiFabric.Sdk.ObjectToEdi.CustomClasses.X12;

namespace EdiFabric.Sdk.ObjectToEdi.EdiMaps.Automapper
{
    internal class To810Map
    {
        public static void CreateMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Custom810, M_810>();
                cfg.CreateMap<CustomClasses.X12.G_IT1, Definitions.X12_002040_810.G_IT1>();
                cfg.CreateMap<CustomClasses.X12.G_ITA, Definitions.X12_002040_810.G_ITA>();
                cfg.CreateMap<CustomClasses.X12.G_ITA_2, Definitions.X12_002040_810.G_ITA_2>();
                cfg.CreateMap<CustomClasses.X12.G_N1, Definitions.X12_002040_810.G_N1>();
                cfg.CreateMap<CustomClasses.X12.G_N1_2, Definitions.X12_002040_810.G_N1_2>();
                cfg.CreateMap<CustomClasses.X12.G_SLN, Definitions.X12_002040_810.G_SLN>();
                cfg.CreateMap<CustomClasses.X12.S_BIG, Definitions.X12_002040_810.S_BIG>();
                cfg.CreateMap<CustomClasses.X12.S_CAD, Definitions.X12_002040_810.S_CAD>();
                cfg.CreateMap<CustomClasses.X12.S_CAD_2, Definitions.X12_002040_810.S_CAD_2>();
                cfg.CreateMap<CustomClasses.X12.S_CTP, Definitions.X12_002040_810.S_CTP>();
                cfg.CreateMap<CustomClasses.X12.S_CTT, Definitions.X12_002040_810.S_CTT>();
                cfg.CreateMap<CustomClasses.X12.S_CUR, Definitions.X12_002040_810.S_CUR>();
                cfg.CreateMap<CustomClasses.X12.S_CUR_2, Definitions.X12_002040_810.S_CUR_2>();
                cfg.CreateMap<CustomClasses.X12.S_DTM, Definitions.X12_002040_810.S_DTM>();
                cfg.CreateMap<CustomClasses.X12.S_DTM_2, Definitions.X12_002040_810.S_DTM_2>();
                cfg.CreateMap<CustomClasses.X12.S_FOB, Definitions.X12_002040_810.S_FOB>();
                cfg.CreateMap<CustomClasses.X12.S_ISS, Definitions.X12_002040_810.S_ISS>();
                cfg.CreateMap<CustomClasses.X12.S_IT1, Definitions.X12_002040_810.S_IT1>();
                cfg.CreateMap<CustomClasses.X12.S_IT3, Definitions.X12_002040_810.S_IT3>();
                cfg.CreateMap<CustomClasses.X12.S_ITA, Definitions.X12_002040_810.S_ITA>();
                cfg.CreateMap<CustomClasses.X12.S_ITA_2, Definitions.X12_002040_810.S_ITA_2>();
                cfg.CreateMap<CustomClasses.X12.S_ITA_3, Definitions.X12_002040_810.S_ITA_3>();
                cfg.CreateMap<CustomClasses.X12.S_ITD, Definitions.X12_002040_810.S_ITD>();
                cfg.CreateMap<CustomClasses.X12.S_ITD_2, Definitions.X12_002040_810.S_ITD_2>();
                cfg.CreateMap<CustomClasses.X12.S_L7, Definitions.X12_002040_810.S_L7>();
                cfg.CreateMap<CustomClasses.X12.S_L7_2, Definitions.X12_002040_810.S_L7_2>();
                cfg.CreateMap<CustomClasses.X12.S_MEA, Definitions.X12_002040_810.S_MEA>();
                cfg.CreateMap<CustomClasses.X12.S_MEA_2, Definitions.X12_002040_810.S_MEA_2>();
                cfg.CreateMap<CustomClasses.X12.S_N1, Definitions.X12_002040_810.S_N1>();
                cfg.CreateMap<CustomClasses.X12.S_N1_2, Definitions.X12_002040_810.S_N1_2>();
                cfg.CreateMap<CustomClasses.X12.S_N2, Definitions.X12_002040_810.S_N2>();
                cfg.CreateMap<CustomClasses.X12.S_N2_2, Definitions.X12_002040_810.S_N2_2>();
                cfg.CreateMap<CustomClasses.X12.S_N3, Definitions.X12_002040_810.S_N3>();
                cfg.CreateMap<CustomClasses.X12.S_N3_2, Definitions.X12_002040_810.S_N3_2>();
                cfg.CreateMap<CustomClasses.X12.S_N4, Definitions.X12_002040_810.S_N4>();
                cfg.CreateMap<CustomClasses.X12.S_N4_2, Definitions.X12_002040_810.S_N4_2>();
                cfg.CreateMap<CustomClasses.X12.S_NTE, Definitions.X12_002040_810.S_NTE>();
                cfg.CreateMap<CustomClasses.X12.S_PER, Definitions.X12_002040_810.S_PER>();
                cfg.CreateMap<CustomClasses.X12.S_PER_2, Definitions.X12_002040_810.S_PER_2>();
                cfg.CreateMap<CustomClasses.X12.S_PER_3, Definitions.X12_002040_810.S_PER_3>();
                cfg.CreateMap<CustomClasses.X12.S_PER_4, Definitions.X12_002040_810.S_PER_4>();
                cfg.CreateMap<CustomClasses.X12.S_PID, Definitions.X12_002040_810.S_PID>();
                cfg.CreateMap<CustomClasses.X12.S_PID_2, Definitions.X12_002040_810.S_PID_2>();
                cfg.CreateMap<CustomClasses.X12.S_PID_3, Definitions.X12_002040_810.S_PID_3>();
                cfg.CreateMap<CustomClasses.X12.S_PKG, Definitions.X12_002040_810.S_PKG>();
                cfg.CreateMap<CustomClasses.X12.S_PKG_2, Definitions.X12_002040_810.S_PKG_2>();
                cfg.CreateMap<CustomClasses.X12.S_PO4, Definitions.X12_002040_810.S_PO4>();
                cfg.CreateMap<CustomClasses.X12.S_PWK, Definitions.X12_002040_810.S_PWK>();
                cfg.CreateMap<CustomClasses.X12.S_PWK_2, Definitions.X12_002040_810.S_PWK_2>();
                cfg.CreateMap<CustomClasses.X12.S_REF, Definitions.X12_002040_810.S_REF>();
                cfg.CreateMap<CustomClasses.X12.S_REF_2, Definitions.X12_002040_810.S_REF_2>();
                cfg.CreateMap<CustomClasses.X12.S_REF_3, Definitions.X12_002040_810.S_REF_3>();
                cfg.CreateMap<CustomClasses.X12.S_REF_4, Definitions.X12_002040_810.S_REF_4>();
                cfg.CreateMap<CustomClasses.X12.S_REF_5, Definitions.X12_002040_810.S_REF_5>();
                cfg.CreateMap<CustomClasses.X12.S_SDQ, Definitions.X12_002040_810.S_SDQ>();
                cfg.CreateMap<CustomClasses.X12.S_SE, Definitions.X12_002040_810.S_SE>();
                cfg.CreateMap<CustomClasses.X12.S_SLN, Definitions.X12_002040_810.S_SLN>();
                cfg.CreateMap<CustomClasses.X12.S_ST, Definitions.X12_002040_810.S_ST>();
                cfg.CreateMap<CustomClasses.X12.S_TDS, Definitions.X12_002040_810.S_TDS>();
                cfg.CreateMap<CustomClasses.X12.S_TXI, Definitions.X12_002040_810.S_TXI>();
                cfg.CreateMap<CustomClasses.X12.S_TXI_2, Definitions.X12_002040_810.S_TXI_2>();
                cfg.CreateMap<CustomClasses.X12.S_TXI_3, Definitions.X12_002040_810.S_TXI_3>();
                cfg.CreateMap<CustomClasses.X12.S_TXI_4, Definitions.X12_002040_810.S_TXI_4>();                
            });
        }
    }
}
