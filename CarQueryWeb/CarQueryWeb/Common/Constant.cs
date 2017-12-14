using System;
using System.Configuration;


public class Constant
{
    public static readonly string UnitCode= ConfigurationManager.AppSettings["UnitCode"];
    public static readonly string XMLPATH = ConfigurationManager.AppSettings["XMLPATH"];
    public static readonly string IpAddress = ConfigurationManager.AppSettings["IpAddress"];
    public static readonly string Title = ConfigurationManager.AppSettings["TITLE"];
    public static readonly string Log = ConfigurationManager.AppSettings["Log"];
    public static readonly string SteadyStateStandardGB = ConfigurationManager.AppSettings["SteadyStateStandardGB"];
    public static readonly string SteadyStateStandardDB = ConfigurationManager.AppSettings["SteadyStateStandardDB"];
    public static readonly string DoubleIdleStandardGB = ConfigurationManager.AppSettings["DoubleIdleStandardGB"];
    public static readonly string DoubleIdleStandardDB = ConfigurationManager.AppSettings["DoubleIdleStandardDB"];
    public static readonly string LugDownGB = ConfigurationManager.AppSettings["LugDownGB"];
    public static readonly string LugDownDB = ConfigurationManager.AppSettings["LugDownDB"];
    public static readonly string FreeSpendGB = ConfigurationManager.AppSettings["FreeSpendGB"];
    public static readonly string FreeSpendDB = ConfigurationManager.AppSettings["FreeSpendDB"];
    public static readonly string MAPosition = ConfigurationManager.AppSettings["MAPosition"];
    public static readonly string MANo = ConfigurationManager.AppSettings["MANo"];
    public static readonly int MATop = Convert.ToInt16(MAPosition.Split(',')[0]);
    public static readonly int MALeft = Convert.ToInt16(MAPosition.Split(',')[1]);
    public static readonly int StrLen = Convert.ToInt16(ConfigurationManager.AppSettings["StrLen"]);
    public static readonly string DefaultPath = ConfigurationManager.AppSettings["DefaultPath"];
    public static readonly string VideoUrl = ConfigurationManager.AppSettings["VideoUrl"];
}
