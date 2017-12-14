using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarQueryWeb.MODEL
{
   /// <summary>
   /// 柴油车检测结果vo
   /// </summary>
    public class TDieselOilResultVO
    {

        public String cFaceCheckID = ""; //外观检查编码

        public String nTemperature = ""; //温度(℃)

        public String nAtmosphere = ""; //大气压(kPa)

        public String nHumidity = ""; //相对湿度(%)

        public String nK100 = ""; //100%点烟度K(m-1)

        public String nK90 = ""; //90%点烟度K(m-1)

        public String nK80 = ""; //80%点烟度K(m-1)

        public String nRev = ""; //转速

        public String nPower = ""; //最大轮边功率

        public String nHSU100 = ""; //100%点烟度(%)

        public String nHSU90 = ""; //90%点烟度(%)

        public String nHSU80 = ""; //80%点烟度(%)

        public String bImage = ""; //检测图片

        public String cChkDevice = ""; //检测线

        public String cPerson = ""; //检测员

        public String cPersonName = "";//检测员名称

        public String cDeviceNo = ""; //检测设备编号

        public String cIsPass = "";//是否合格

        public String dCheckDate = "";//检测日期

        public String bCancelReasonType = "";//中止或无效原因类型

        public String cCheckCode = "";//检测结果编号

        public String EXT_COL2 = "";//服务器程序计算检测结果

        public String EXT_COL3 = "";//EIS上传检测结果

        public String cExceptionType = "";//影响检测结果异常类型

        public String nOrdainRev = "";//发动机额定转速

        public String nOrdainPower = "";//发动机额定转速

        public String limitValue = "";//限值







        //柴油车非工况
        public String nid = "";//流水号

        public String cfacecheckid = "";//外观检查编码

        public String nfreedomsmokerb = "";//自由加速烟度Rb(%)

        public String nfreedomsmokerb2 = "";//自由加速烟度2Rb(%)

        public String nfreedomsmokerb3 = "";//自由加速烟度3Rb(%)

        public String nfreedomsmokerb4 = "";//自由加速烟度4Rb(%)

        public String nfreedomrev1 = "";//转速1

        public String nfreedomrev2 = "";//转速2

        public String nfreedomrev3 = "";//转速3

        public String average = "";

        public String limitvalue = "";

        public String cpersoncode = "";//检测员

        public String cispass = "";//是否合格

        public String cchkdevicecode = "";//检测设备编码

        public String ntemperature = "";//温度(℃)

        public String natmosphere = "";//大气压(kPa)

        public String nhumidity = "";//相对湿度(%)

        public String begindate = "";//检测开始时间

        public String enddate = "";//检测结束时间

        public String bcancelreasontype = "";//中止或无效原因类型

        public String nfreedomsmokeavg = "";//

        public String idlerev = "";//怠速/转速

        public String isflag = "";//判定烟度法（空：不透光,非空：滤纸）

        public String psn_name = "";//

        public String psn_id = "";//

        public String nFreedomRev = "";//自由加速转速限值

        public String fasmokek = ""; //自由加速法光吸收系数(m-1)
        public String bImage2 = ""; //检测图片2
        public String bImage3 = ""; //检测图片3



    }
}