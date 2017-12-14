using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarQueryWeb.MODEL
{
    public class TGasResult
    {

        public string cFaceCheckID ; //外观检查编码

        public string nTemperature ; //温度(℃)

        public string nAtmosphere ; //大气压(kPa)

        public string nHumidity ; //相对湿度(%)

        public string nCO_5024 ; //CO测量值5024(%)

        public string nHC_5024 ; //HC测量值5024(*10-6)

        public string nNO_5024 ; //NO测量值5024(*10-6)

        public string nRev_5024 ; //转速(5024)

        public string nλ_5024 ; //λ值(5024)

        public string nPower_5024 ; //测功机设定功率(kw)(5024)

        public string nDCF_5024 ; //稀释修正系数（DCF）(5024)

        public string nKh_5024 ; //湿度修正系数（kH）(5024)

        public string nCO_2540 ; //CO测量值2540(%)

        public string nHC_2540 ; //HC测量值2540(*10-6)

        public string nNO_2540 ; //NO测量值2540(*10-6)

        public string nRev_2540 ; //转速(2540)

        public string nPower_2540 ; //测功机设定功率(kw)(2540)

        public string nDCF_2540 ; //稀释修正系数（DCF）(2540)

        public string nKh_2540 ; //湿度修正系数（kH）(2540)

        public string nλ_2540 ; //λ值(2540)

        public string nRev_dai ; //转速(怠速)

        public string nλ_dai ; //λ值(怠速)

        public string nDCF_dai ; //稀释修正系数（DCF）(怠速)

        public string nKh_dai ; //湿度修正系数（kH）(怠速)

        public string nCO_dai ; //CO测量值 怠速(%)

        public string nHC_dai ; //HC测量值 怠速(*10-6)

        public string cOBD ; //OBD故障码

        public string bImage ; //检测图片

        public string cChkDevice ; //检测线

        public string bDataTypeid ; //数据类型

        public string bDataType ; //数据类型

        public string cDeviceNo ; //检测设备编号

        public string cPersonCode ; //检测人员编号

        public string cPersonName ; //检测人员姓名

        public string dCheckBeginDate ; //检测开始日期

        public string dCheckEndDate ; //检测结束日期

        public string cIsPass ; //是否合格

        public string bCancelReasonType ; //中止或无效原因类型

        public string cCheckCode ; //检测结果编号

        public string EXT_COL2 ; //服务器程序计算检测结果

        public string EXT_COL3 ; //EIS上传检测结果

        public string nCO_5024_limit ; //CO限值5024(%)

        public string nHC_5024_limit ; //HC限值5024(%)

        public string nNO_5024_limit ; //NO限值5024(%)

        public string nCO_2540_limit ; //CO限值2540(%)

        public string nHC_2540_limit ; //HC限值2540(%)

        public string nNO_2540_limit ; //NO限值2540(%)

        public string nIdleCO ; //CO限值怠速(%)

        public string nIdleHC ; //HC限值怠速(%)

        public string nBackHC ; //背景空气HC

        public string nBackCO ; //背景空气CO

        public string nBackCO2 ; //背景空气CO2

        public string nBackNO ; //背景空气NO

        public string nBackO2 ; //背景空气O2

        public string nEnvironHC ; //环境空气HC

        public string nEnvironCO ; //环境空气CO

        public string nEnvironCO2 ; //环境空气CO2

        public string nEnvironNO ; //环境空气NO

        public string nEnvironO2 ; //环境空气O2

        public string nStubHC ; //残留HC

        public string cExceptionTypeID ; //影响检测结果异常类型编码

        public string CEXCEPTIONTYPE ; //影响检测结果异常类型

        public string CHECKTYPE ;//检测类型 见字典表46


        public string nCO_2540_isPass;
        public string nHC_2540_isPass;
        public string nNO_2540_isPass;
        public string nCO_5024_isPass;
        public string nHC_5024_isPass;
        public string nNO_5024_isPass;


        public string vmashc_limit;//vmas hc限值
        public string vmasno_limit;//vmas no限值
        public string vmashcno_limit;//vmas hcno限值

        public string vmasambiento2;//流量分析仪环境O2（%）
        public string vmasresidualhc;//残留HC（10-6）
        public string vmastesttime;//有效测试时间(s)
        public string vmasairflowall;//流量分析仪稀释排放气体总流量(m3/min)
        public string vmasco;//VMAS  CO测量结果（g/km）
        public string vmashc;//VMAS  HC测量结果(g/km)
        public string vmasnox;//VMAS  NO测量结果(g/km)
        public string vmasco2;//VMAS  CO2测量结果（g/km）
        public string vmashcnox;//VMAS  HC+NOx测量结果(g/km)
        public string vmaspower;//测功机设定功率(kW)
        public string vmasnstubhc;//残留HC





        //汽油车非工况
        public string cchecktype ;//怠速检测类型

        public string nhighidleco ;//CO测量值 高怠速(%)

        public string nhighidlehc ;//HC测量值 高怠速(*10-6)

        public string nhignidleno ;//NO测量值 高怠速(*10-6)

        public string nhighidlerev ;//转速（高怠速）

        public string Λvalue ;//λ值

        public string nlowidleco ;//CO测量值 低怠速(%)

        public string nlowidlehc ;//HC测量值 低怠速(*10-6)

        public string nhignidleno2 ;//NO测量值 低怠速(*10-6)

        public string nlowidlerev ;//转速（低怠速）

        public string cpersoncode ;//检测员

        public string cchkdevicecode ;//检测设备编码

        public string ntemperature ;//温度(℃)

        public string natmosphere ;//大气压(kPa)

        public string nhumidity ;//相对湿度(%)

        public string begindate ;//开始时间

        public string enddate ;//结束时间

        public string psn_id ;//人员编码

        public string psn_name ;//人员姓名

        public string nserial ;//检测线名称

        public string nHighIdleCO ;//CO限值 高怠速(%)

        public string nHighIdleHC ;//HC限值 高怠速(*10-6)

        public string nLowIdleCO ;//CO限值 低怠速(%)

        public string nLowIdleHC ;//HC限值 低怠速(*10-6)

        public string cfacecheckid ;//外观编号

        public string nlowCOisPass;//
        public string nlowHCisPass;//
        public string nhighCOisPass;//
        public string nhighHCisPass;//
        public string lamudaisPass;
        public string limitValue;
    }

}

