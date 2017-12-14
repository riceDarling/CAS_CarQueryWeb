using System;
namespace CarQueryWeb.MODEL
{
	/// <summary>
	/// TFACECHECK:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TFACECHECK
	{
        public TFACECHECK()
        { }
        #region Model
        private string _cfacecheckid;
        private string _cvehiclecode;
        private string _cvin;
        private string _cvehicleid;
        private string _cnumberplate;
        private string _cplatetype;
        private string _cvehiclekind;
        private DateTime? _dregister;
        private string _caddress;
        private string _cuser;
        private string _cphone;
        private string _bissendmoney;
        private string _biscansendsign;
        private string _ccannotsendreason;
        private DateTime? _dcheckdate;
        private string _csignpersoncode;
        private decimal? _nsigntypeid;
        private decimal? _nlimitvalueid;
        private string _ncheckperiodid;
        private string _cissendcard;
        private decimal? _nodometer;
        private string _bisavoidcheck;
        private string _bchkt;
        private string _bchkef;
        private string _bchkwo;
        private string _bchkpe;
        private string _bchkel;
        private string _bchkcldll;
        private string _bchkqssq;
        private string _bchktaaf;
        private string _bchkaaae;
        private string _bishaveobd;
        private string _bfindobdinterface;
        private string _bisobdcomm;
        private string _cobdcode;
        private string _nvehiclemodelid;
        private string _cname;
        private string _bisdianpen;
        private string _cvehiclestyle;
        private decimal? _nstdweight;
        private decimal? _nmaxweight;
        private string _cdriveform;
        private string _cgearboxtype;
        private string _cfueltype;
        private string _csupplymode;
        private string _ccarortruck;
        private decimal? _nseatorweight;
        private decimal? _nordainrev;
        private decimal? _nletout;
        private decimal? _nordainpower;
        private string _cadmission;
        private decimal? _ncylinder;
        private string _bhaspurge;
        private string _bfacecheck;
        private string _bischeckbypda;
        private string _bhavequestionsitems;
        private string _bischeckout;
        private string _bisauditing;
        private string _bunauditingreason;
        private string _bissendsign;
        private string _biswritecard;
        private string _cpersoncode;
        private DateTime? _dfacedate;
        private string _cunitcode;
        private string _cauditingpersoncode;
        private string _cchfaceno;
        private string _bchkobd;
        private string _cchkdevicecode = "0000000662";
        private DateTime? _dwqcheckdate;
        private string _biscancheckonline;
        private string _bisrecheck;
        private string _cengineno;
        private decimal? _nweight;
        private string _cchecktype;
        private string _ext_col1;
        private string _ext_col2;
        private string _ext_col3;
        private decimal? _ext_col4;
        private string _csimplemore;
        private string _nsigntypefb;
        private string _bissendverifycard;
        private decimal? _periodchecks;
        private decimal? _periodchecktimes;
        private string _bisdelete;
        private decimal? _nflimitvalueid;
        private string _ext_col5;
        private string _ext_col6;
        private string _ext_col7;
        private string _ext_col8;
        private string _ext_col9;
        private string _bisprintreport;
        private string _isoriginalischeckout;
        private DateTime? _exchange = DateTime.Now;
        private string _checkmethod;
        public string _checkmedthreason;
        public string _nophotoreason;
        public string _isrebuild, _cpersonname, _cunitname, _cchkdevicename, _cmanufacturer, _nsigntypename, _nlimitvalue;
        public string _ext_col1_str, _ext_col2_str;//底盘测功机，排气分析仪
        public string _deviceverifycode, _devicename, _devicetype;//设备认证编码,设备名称，型号
        public string _CheckDeviceMadeFactory;
        public string _CheckOperator;
        public string _CheckDriver;
        public string _CheckName;
        public string CheckName
        {
            get { return _CheckName; }
            set { _CheckName = value; }
        }
        public string CheckDeviceMadeFactory
        {
            get { return _CheckDeviceMadeFactory; }
            set { _CheckDeviceMadeFactory = value; }
        }
        public string CheckOperator
        {
            get { return _CheckOperator; }
            set { _CheckOperator = value; }
        }
        public string CheckDriver
        {
            get { return _CheckDriver; }
            set { _CheckDriver = value; }
        }
        public string DEVICEVERIFYCODE
        {
            get { return _deviceverifycode; }
            set { _deviceverifycode = value; }
        }

        public string DEVICENAME
        {
            get { return _devicename; }
            set { _devicename = value; }
        }
        public string DEVICETYPE
        {
            get { return _devicetype; }
            set { _devicetype = value; }
        }
        public string EXT_COL1_STR
        {
            get { return _ext_col1_str; }
            set { _ext_col1_str = value; }
        }
        public string EXT_COL2_STR
        {
            get { return _ext_col2_str; }
            set { _ext_col2_str = value; }
        }
        public string NLIMITVALUE
        {
            get { return _nlimitvalue; }
            set { _nlimitvalue = value; }
        }
        public string NSIGNTYPENAME
        {
            get { return _nsigntypename; }
            set { _nsigntypename = value; }
        }
        public string ISREBUILD
        {
            get { return _isrebuild; }
            set { _isrebuild = value; }
        }
        public string CPERSONNAME
        {
            get { return _cpersonname; }
            set { _cpersonname = value; }
        }
        public string CUNITNAME
        {
            get { return _cunitname; }
            set { _cunitname = value; }
        }
        public string CCHKDEVICENAME
        {
            get { return _cchkdevicename; }
            set { _cchkdevicename = value; }
        }
        public string CMANUFACTURER
        {
            get { return _cmanufacturer; }
            set { _cmanufacturer = value; }
        }

        /// <summary>
        /// 检测方法为1,3的原因
        /// </summary>
        public string CHECKMEDTHREASON
        {
            set { _checkmedthreason = value; }
            get { return _checkmedthreason; }
        }
        /// <summary>
        /// 没有图片的原因
        /// </summary>
        public string NOPHOTOREASON
        {
            set { _nophotoreason = value; }
            get { return _nophotoreason; }
        }
        /// <summary>
        /// 外观检查编码
        /// </summary>
        public string CFACECHECKID
        {
            set { _cfacecheckid = value; }
            get { return _cfacecheckid; }
        }
        /// <summary>
        /// 车辆编码
        /// </summary>
        public string CVEHICLECODE
        {
            set { _cvehiclecode = value; }
            get { return _cvehiclecode; }
        }
        /// <summary>
        /// 车架号/VIN
        /// </summary>
        public string CVIN
        {
            set { _cvin = value; }
            get { return _cvin; }
        }
        /// <summary>
        /// 环保信息卡号
        /// </summary>
        public string CVEHICLEID
        {
            set { _cvehicleid = value; }
            get { return _cvehicleid; }
        }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CNUMBERPLATE
        {
            set { _cnumberplate = value; }
            get { return _cnumberplate; }
        }
        /// <summary>
        /// 车牌类型
        /// </summary>
        public string CPLATETYPE
        {
            set { _cplatetype = value; }
            get { return _cplatetype; }
        }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CVEHICLEKIND
        {
            set { _cvehiclekind = value; }
            get { return _cvehiclekind; }
        }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? DREGISTER
        {
            set { _dregister = value; }
            get { return _dregister; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string CADDRESS
        {
            set { _caddress = value; }
            get { return _caddress; }
        }
        /// <summary>
        /// 车主/单位
        /// </summary>
        public string CUSER
        {
            set { _cuser = value; }
            get { return _cuser; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CPHONE
        {
            set { _cphone = value; }
            get { return _cphone; }
        }
        /// <summary>
        /// 是否交费
        /// </summary>
        public string BISSENDMONEY
        {
            set { _bissendmoney = value; }
            get { return _bissendmoney; }
        }
        /// <summary>
        /// 是否允许发标
        /// </summary>
        public string BISCANSENDSIGN
        {
            set { _biscansendsign = value; }
            get { return _biscansendsign; }
        }
        /// <summary>
        /// 不允许发标原因
        /// </summary>
        public string CCANNOTSENDREASON
        {
            set { _ccannotsendreason = value; }
            get { return _ccannotsendreason; }
        }
        /// <summary>
        /// 检测登记日期
        /// </summary>
        public DateTime? DCHECKDATE
        {
            set { _dcheckdate = value; }
            get { return _dcheckdate; }
        }
        /// <summary>
        /// 登记员编码
        /// </summary>
        public string CSIGNPERSONCODE
        {
            set { _csignpersoncode = value; }
            get { return _csignpersoncode; }
        }
        /// <summary>
        /// 标志类型编码
        /// </summary>
        public decimal? NSIGNTYPEID
        {
            set { _nsigntypeid = value; }
            get { return _nsigntypeid; }
        }
        /// <summary>
        /// 限值编码
        /// </summary>
        public decimal? NLIMITVALUEID
        {
            set { _nlimitvalueid = value; }
            get { return _nlimitvalueid; }
        }
        /// <summary>
        /// 检测周期编码
        /// </summary>
        public string NCHECKPERIODID
        {
            set { _ncheckperiodid = value; }
            get { return _ncheckperiodid; }
        }
        /// <summary>
        /// 是否发卡
        /// </summary>
        public string CISSENDCARD
        {
            set { _cissendcard = value; }
            get { return _cissendcard; }
        }
        /// <summary>
        /// 里程表读数
        /// </summary>
        public decimal? NODOMETER
        {
            set { _nodometer = value; }
            get { return _nodometer; }
        }
        /// <summary>
        /// 是否为免检车
        /// </summary>
        public string BISAVOIDCHECK
        {
            set { _bisavoidcheck = value; }
            get { return _bisavoidcheck; }
        }
        /// <summary>
        /// 检查转向系统机械运转
        /// </summary>
        public string BCHKT
        {
            set { _bchkt = value; }
            get { return _bchkt; }
        }
        /// <summary>
        /// 检查烧机油/严重冒黑烟
        /// </summary>
        public string BCHKEF
        {
            set { _bchkef = value; }
            get { return _bchkef; }
        }
        /// <summary>
        /// 检查水温表/油温表
        /// </summary>
        public string BCHKWO
        {
            set { _bchkwo = value; }
            get { return _bchkwo; }
        }
        /// <summary>
        /// 检查机外净化器/电控系统
        /// </summary>
        public string BCHKPE
        {
            set { _bchkpe = value; }
            get { return _bchkpe; }
        }
        /// <summary>
        /// 检查双排气系统/泄露
        /// </summary>
        public string BCHKEL
        {
            set { _bchkel = value; }
            get { return _bchkel; }
        }
        /// <summary>
        /// 检查冷却系
        /// </summary>
        public string BCHKCLDLL
        {
            set { _bchkcldll = value; }
            get { return _bchkcldll; }
        }
        /// <summary>
        /// 是否为全时四驱车
        /// </summary>
        public string BCHKQSSQ
        {
            set { _bchkqssq = value; }
            get { return _bchkqssq; }
        }
        /// <summary>
        /// 检查轮胎压力/潮湿存水/磨损/夹带硬物
        /// </summary>
        public string BCHKTAAF
        {
            set { _bchktaaf = value; }
            get { return _bchktaaf; }
        }
        /// <summary>
        /// 检查关闭空调暖风/ABS/ASR (TRAC)/ESP
        /// </summary>
        public string BCHKAAAE
        {
            set { _bchkaaae = value; }
            get { return _bchkaaae; }
        }
        /// <summary>
        /// 是否有OBD
        /// </summary>
        public string BISHAVEOBD
        {
            set { _bishaveobd = value; }
            get { return _bishaveobd; }
        }
        /// <summary>
        /// 能否找到OBD接口
        /// </summary>
        public string BFINDOBDINTERFACE
        {
            set { _bfindobdinterface = value; }
            get { return _bfindobdinterface; }
        }
        /// <summary>
        /// OBD通信是否正常
        /// </summary>
        public string BISOBDCOMM
        {
            set { _bisobdcomm = value; }
            get { return _bisobdcomm; }
        }
        /// <summary>
        /// OBD故障码
        /// </summary>
        public string COBDCODE
        {
            set { _cobdcode = value; }
            get { return _cobdcode; }
        }
        /// <summary>
        /// 车型号
        /// </summary>
        public string NVEHICLEMODELID
        {
            set { _nvehiclemodelid = value; }
            get { return _nvehiclemodelid; }
        }
        /// <summary>
        /// 厂牌
        /// </summary>
        public string CNAME
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 是否电控
        /// </summary>
        public string BISDIANPEN
        {
            set { _bisdianpen = value; }
            get { return _bisdianpen; }
        }
        /// <summary>
        /// 车辆类别
        /// </summary>
        public string CVEHICLESTYLE
        {
            set { _cvehiclestyle = value; }
            get { return _cvehiclestyle; }
        }
        /// <summary>
        /// 基准质量(kg)
        /// </summary>
        public decimal? NSTDWEIGHT
        {
            set { _nstdweight = value; }
            get { return _nstdweight; }
        }
        /// <summary>
        /// 最大质量(kg)
        /// </summary>
        public decimal? NMAXWEIGHT
        {
            set { _nmaxweight = value; }
            get { return _nmaxweight; }
        }
        /// <summary>
        /// 驱动形式
        /// </summary>
        public string CDRIVEFORM
        {
            set { _cdriveform = value; }
            get { return _cdriveform; }
        }
        /// <summary>
        /// 变速器形式
        /// </summary>
        public string CGEARBOXTYPE
        {
            set { _cgearboxtype = value; }
            get { return _cgearboxtype; }
        }
        /// <summary>
        /// 燃油种类
        /// </summary>
        public string CFUELTYPE
        {
            set { _cfueltype = value; }
            get { return _cfueltype; }
        }
        /// <summary>
        /// 供油方式
        /// </summary>
        public string CSUPPLYMODE
        {
            set { _csupplymode = value; }
            get { return _csupplymode; }
        }
        /// <summary>
        /// 客货
        /// </summary>
        public string CCARORTRUCK
        {
            set { _ccarortruck = value; }
            get { return _ccarortruck; }
        }
        /// <summary>
        /// 座位
        /// </summary>
        public decimal? NSEATORWEIGHT
        {
            set { _nseatorweight = value; }
            get { return _nseatorweight; }
        }
        /// <summary>
        /// 发动机额定转速
        /// </summary>
        public decimal? NORDAINREV
        {
            set { _nordainrev = value; }
            get { return _nordainrev; }
        }
        /// <summary>
        /// 发动机排量
        /// </summary>
        public decimal? NLETOUT
        {
            set { _nletout = value; }
            get { return _nletout; }
        }
        /// <summary>
        /// 发动机额定功率
        /// </summary>
        public decimal? NORDAINPOWER
        {
            set { _nordainpower = value; }
            get { return _nordainpower; }
        }
        /// <summary>
        /// 进气方式
        /// </summary>
        public string CADMISSION
        {
            set { _cadmission = value; }
            get { return _cadmission; }
        }
        /// <summary>
        /// 气缸数量
        /// </summary>
        public decimal? NCYLINDER
        {
            set { _ncylinder = value; }
            get { return _ncylinder; }
        }
        /// <summary>
        /// 是否有净化装置
        /// </summary>
        public string BHASPURGE
        {
            set { _bhaspurge = value; }
            get { return _bhaspurge; }
        }
        /// <summary>
        /// 外观检查结果
        /// </summary>
        public string BFACECHECK
        {
            set { _bfacecheck = value; }
            get { return _bfacecheck; }
        }
        /// <summary>
        /// 是否采用手持设备检测
        /// </summary>
        public string BISCHECKBYPDA
        {
            set { _bischeckbypda = value; }
            get { return _bischeckbypda; }
        }
        /// <summary>
        /// 登记数据有问题数据项
        /// </summary>
        public string BHAVEQUESTIONSITEMS
        {
            set { _bhavequestionsitems = value; }
            get { return _bhavequestionsitems; }
        }
        /// <summary>
        /// 尾气检测是否合格
        /// </summary>
        public string BISCHECKOUT
        {
            set { _bischeckout = value; }
            get { return _bischeckout; }
        }
        /// <summary>
        /// 审核是否通过
        /// </summary>
        public string BISAUDITING
        {
            set { _bisauditing = value; }
            get { return _bisauditing; }
        }
        /// <summary>
        /// 审核未通过原因
        /// </summary>
        public string BUNAUDITINGREASON
        {
            set { _bunauditingreason = value; }
            get { return _bunauditingreason; }
        }
        /// <summary>
        /// 是否已经发标
        /// </summary>
        public string BISSENDSIGN
        {
            set { _bissendsign = value; }
            get { return _bissendsign; }
        }
        /// <summary>
        /// 是否成功写卡
        /// </summary>
        public string BISWRITECARD
        {
            set { _biswritecard = value; }
            get { return _biswritecard; }
        }
        /// <summary>
        /// 外观员编码
        /// </summary>
        public string CPERSONCODE
        {
            set { _cpersoncode = value; }
            get { return _cpersoncode; }
        }
        /// <summary>
        /// 外观检查日期
        /// </summary>
        public DateTime? DFACEDATE
        {
            set { _dfacedate = value; }
            get { return _dfacedate; }
        }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string CUNITCODE
        {
            set { _cunitcode = value; }
            get { return _cunitcode; }
        }
        /// <summary>
        /// 审核员编码
        /// </summary>
        public string CAUDITINGPERSONCODE
        {
            set { _cauditingpersoncode = value; }
            get { return _cauditingpersoncode; }
        }
        /// <summary>
        /// 催化器外观号
        /// </summary>
        public string CCHFACENO
        {
            set { _cchfaceno = value; }
            get { return _cchfaceno; }
        }
        /// <summary>
        /// OBD检测是否有故障
        /// </summary>
        public string BCHKOBD
        {
            set { _bchkobd = value; }
            get { return _bchkobd; }
        }
        /// <summary>
        /// 检测线编码
        /// </summary>
        public string CCHKDEVICECODE
        {
            set { _cchkdevicecode = value; }
            get { return _cchkdevicecode; }
        }
        /// <summary>
        /// 尾气检查日期
        /// </summary>
        public DateTime? DWQCHECKDATE
        {
            set { _dwqcheckdate = value; }
            get { return _dwqcheckdate; }
        }
        /// <summary>
        /// 是否允许上线检测
        /// </summary>
        public string BISCANCHECKONLINE
        {
            set { _biscancheckonline = value; }
            get { return _biscancheckonline; }
        }
        /// <summary>
        /// 是否重检
        /// </summary>
        public string BISRECHECK
        {
            set { _bisrecheck = value; }
            get { return _bisrecheck; }
        }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string CENGINENO
        {
            set { _cengineno = value; }
            get { return _cengineno; }
        }
        /// <summary>
        /// 载重
        /// </summary>
        public decimal? NWEIGHT
        {
            set { _nweight = value; }
            get { return _nweight; }
        }
        /// <summary>
        /// 检测类型
        /// </summary>
        public string CCHECKTYPE
        {
            set { _cchecktype = value; }
            get { return _cchecktype; }
        }
        /// <summary>
        /// 满足标准编码
        /// </summary>
        public string EXT_COL1
        {
            set { _ext_col1 = value; }
            get { return _ext_col1; }
        }
        /// <summary>
        /// 此次外观检查是否发卡或补卡
        /// </summary>
        public string EXT_COL2
        {
            set { _ext_col2 = value; }
            get { return _ext_col2; }
        }
        /// <summary>
        /// 车辆用途标示一
        /// </summary>
        public string EXT_COL3
        {
            set { _ext_col3 = value; }
            get { return _ext_col3; }
        }
        /// <summary>
        /// 改造车设置
        /// </summary>
        public decimal? EXT_COL4
        {
            set { _ext_col4 = value; }
            get { return _ext_col4; }
        }
        /// <summary>
        /// 电喷方式
        /// </summary>
        public string CSIMPLEMORE
        {
            set { _csimplemore = value; }
            get { return _csimplemore; }
        }
        /// <summary>
        /// 环保标志副本是否打印
        /// </summary>
        public string NSIGNTYPEFB
        {
            set { _nsigntypefb = value; }
            get { return _nsigntypefb; }
        }
        /// <summary>
        /// 是否打印合格证
        /// </summary>
        public string BISSENDVERIFYCARD
        {
            set { _bissendverifycard = value; }
            get { return _bissendverifycard; }
        }
        /// <summary>
        /// 检测周期数
        /// </summary>
        public decimal? PERIODCHECKS
        {
            set { _periodchecks = value; }
            get { return _periodchecks; }
        }
        /// <summary>
        /// 本周期内检测次数
        /// </summary>
        public decimal? PERIODCHECKTIMES
        {
            set { _periodchecktimes = value; }
            get { return _periodchecktimes; }
        }
        /// <summary>
        /// 是否修改或删除
        /// </summary>
        public string BISDELETE
        {
            set { _bisdelete = value; }
            get { return _bisdelete; }
        }
        /// <summary>
        /// 非工况限值编号
        /// </summary>
        public decimal? NFLIMITVALUEID
        {
            set { _nflimitvalueid = value; }
            get { return _nflimitvalueid; }
        }
        /// <summary>
        /// 发动机型号
        /// </summary>
        public string EXT_COL5
        {
            set { _ext_col5 = value; }
            get { return _ext_col5; }
        }
        /// <summary>
        /// 区县
        /// </summary>
        public string EXT_COL6
        {
            set { _ext_col6 = value; }
            get { return _ext_col6; }
        }
        /// <summary>
        /// 快速工况检测通过标识：1：快速工况通过；其他：不是。
        /// </summary>
        public string EXT_COL7
        {
            set { _ext_col7 = value; }
            get { return _ext_col7; }
        }
        /// <summary>
        /// EXT_COL8
        /// </summary>
        public string EXT_COL8
        {
            set { _ext_col8 = value; }
            get { return _ext_col8; }
        }
        /// <summary>
        /// 是否新车（0：否，1：是）
        /// </summary>
        public string EXT_COL9
        {
            set { _ext_col9 = value; }
            get { return _ext_col9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BISPRINTREPORT
        {
            set { _bisprintreport = value; }
            get { return _bisprintreport; }
        }
        /// <summary>
        /// 原标准检测结果
        /// </summary>
        public string ISORIGINALISCHECKOUT
        {
            set { _isoriginalischeckout = value; }
            get { return _isoriginalischeckout; }
        }
        /// <summary>
        /// 数据交换使用
        /// </summary>
        public DateTime? EXCHANGE
        {
            set { _exchange = value; }
            get { return _exchange; }
        }
        /// <summary>
        /// 检测方法跟车辆表里的ext_col10一致
        /// </summary> 
        public string CHECKMETHOD
        {
            set { _checkmethod = value; }
            get { return _checkmethod; }
        }
        #endregion Model

	}
}

