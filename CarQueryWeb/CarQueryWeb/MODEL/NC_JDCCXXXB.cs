using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQueryWeb.MODEL
{
    public class NC_JDCCXXXB
    {
        public string VID;
        public string VEHICLEMODEL;
        public string CLLB;//车辆类别     字符(30)
        public string QCFL;// 汽车分类      字符(2)   N1、N2、N3、M1、M2、M3
        public string SCQYMC;// 生产企业      字符(200)
        public string Standard;//          排放标准    字符(1)   0-国〇、1-国Ⅰ、2-国Ⅱ、3-国Ⅲ、4-国Ⅳ、5-国Ⅴ、6-国Ⅵ
        public string SB;//     商标  字符(40)
        public string SNAME;//       市场用名    字符(50)  如凯美瑞、雅阁
        public string FuelType;//    燃料种类    字符(3)
        public string XXGKBH;//       信息公开编号  字符(50)
        public string GKDATE;//       信息公开日期  字符(20)  车型信息公开日期YYYYMMDD
        public string FDJXH;//      发动机型号   字符(15)
        public string FDJSCC;//       发动厂家    字符(30)
        public decimal FDJPL;//      发动机排量   数值(1,3) L
        public decimal FDJQGS;//       发动机缸数   数值(2)
        public string BSQXS;//      变速器型式   字符(20)  1-手动、2-自动、3-手自一体
        public decimal DWS;//    档位数 数值(2)
        public string CLWXCC;//       车辆外形尺寸  字符(30)
        public string DriveMode;//          驱动方式    字符(3)   1-前驱、2-后驱、3-四驱、4-全时四驱
        public decimal QDLTQY;//       驱动轮胎气压  数值(3)   kPa
        public decimal ZKS;//    载客数 数值(2)
        public decimal JZZL;//     基准质量    数值(5)   Kg
        public decimal ZDZZL;//      最大总质量   数值(6)   kg
        public string EGR;//    是否有EGR  字符(1)   Y/N
        public string TG;//   是否有燃油蒸发控制装置 字符(1)   Y/N
        public string DK;//   V 是否电控    字符(1)   Y/N
        public string OBD;//    是否有OBD  字符(1)   Y/N
        public string RLGGXS;//       燃料供给系统型式    字符(20)  1-化油器、2-化油器改造、3-开环电喷、4-闭环电喷、5-高压共轨、6-泵喷嘴、7-单体泵、8-直列泵、9-机械泵10-其他
        public string PQHCL;//      是否有后处理装置    字符 Y/N
        public string PQHCLXS;//        后处理种类   字符	1-三元催化、2-DPF、3-SCR、4-DOC、5-POC、6-其他（如适用）
        public string JQFS;//     进气方式    字符(20)
        public decimal EDGL;//     额定功率    数值(4,1) Kw
        public decimal EDGLZS;//       额定功率转速  数值(4)   r/min
        public string SCCDZ;//      生产厂地址   字符(200)
        public string VINWZ;//      VIN所在位置 字符(50)
        public string CXBSWZ;//       车型标识位置  字符(100)
        public string OBDWZ;      //OBD通讯接口位置   字符(100)
    }
}