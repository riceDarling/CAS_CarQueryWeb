using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using CarQueryWeb.MODEL;
using System.Web;

namespace CarQueryWeb.Common
{
    public class XMLHelper
    {
         private static readonly string FilePath = Constant.XMLPATH;
        private static readonly string DefaultPath = Constant.DefaultPath;

        private static string LoginLogXMLPath = HttpContext.Current.Server.MapPath(@"~/xml");
        public static string WriteLoginLog(string filename, List<LoginLog> results)
        {
            string fullFilePath = LoginLogXMLPath + filename;
            if (!System.IO.Directory.Exists(LoginLogXMLPath))
            {
                System.IO.Directory.CreateDirectory(LoginLogXMLPath);
            }
            System.Diagnostics.Debug.WriteLine(fullFilePath);
            XmlDocument xmlDoc = new XmlDocument();
            //声明根节点
            XmlElement rootNode;
            //判断文件是否存在
            if (File.Exists(fullFilePath))
            {
                
                //加载文件
                xmlDoc.Load(fullFilePath);
                //获得根节点
                rootNode = xmlDoc.DocumentElement;

            }
            else//该文件不存在
            {
                XmlDeclaration decl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");//创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>
                xmlDoc.AppendChild(decl);
                //创建根节点
                rootNode = xmlDoc.CreateElement("root");
                xmlDoc.AppendChild(rootNode);
            }
            foreach (LoginLog result in results)
            {
                XmlNode check = xmlDoc.CreateElement("log");
                XmlAttribute IDAttribute = xmlDoc.CreateAttribute("ID");
                IDAttribute.Value = result.ID;
                check.Attributes.Append(IDAttribute);
                XmlAttribute LoginDateAttribute = xmlDoc.CreateAttribute("LoginDate");
                LoginDateAttribute.Value = result.LoginDate;
                check.Attributes.Append(LoginDateAttribute);//追加属性
                XmlAttribute LogoutDateAttribute = xmlDoc.CreateAttribute("LogoutDate");
                LogoutDateAttribute.Value = result.LogoutDate;
                check.Attributes.Append(LogoutDateAttribute);//追加属性
                XmlAttribute DateAttribute = xmlDoc.CreateAttribute("Date");
                DateAttribute.Value = result.Date;
                check.Attributes.Append(DateAttribute);//追加属性
                XmlAttribute StateAttribute = xmlDoc.CreateAttribute("State");
                StateAttribute.Value = result.State;
                check.Attributes.Append(StateAttribute);//追加属性
                XmlAttribute AddressTypeAttribute = xmlDoc.CreateAttribute("Address");
                AddressTypeAttribute.Value = result.Address;
                check.Attributes.Append(AddressTypeAttribute);//追加属性
                XmlAttribute IPAddressAttribute = xmlDoc.CreateAttribute("IPAddress");
                IPAddressAttribute.Value = result.IPAddress;
                check.Attributes.Append(IPAddressAttribute);//追加属性
                rootNode.AppendChild(check);
            }
            xmlDoc.AppendChild(rootNode);
            try
            {
                xmlDoc.Save(fullFilePath);
                return fullFilePath;
            }
            catch (Exception e)
            {
                return "0:" + e.ToString();
            }
        }

        
    

        public static bool CanRead(string filename)
        {
            try
            {
                string fullFilePath = FilePath + filename;
                XmlDocument doc = new XmlDocument();
                doc.Load(fullFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<CheckResult> ReadXML(string filename, params string[] condition)
        {
            List<CheckResult> results = new List<CheckResult>();
            string fullFilePath = FilePath + filename;
            if (!File.Exists(fullFilePath))
            {
                fullFilePath = FilePath + DefaultPath;
                if (!File.Exists(fullFilePath))
                    return results;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(fullFilePath);
            StringBuilder sb = new StringBuilder();
            sb.Append("/root/*");
            if (condition.Length != 0)
            {
                sb.Append("[");
                sb.Append("1=1");
                foreach (string item in condition)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        sb.Append(" and " + item);
                    }

                }
                sb.Append("]");
            }
            XmlNodeList checknodes = doc.SelectNodes(sb.ToString());
            foreach (XmlNode node in checknodes)
            {
                results.Add(GetModelByNode(node));
            }
            return results;
        }

        public static CheckResult GetModelByNode(XmlNode node)
        {

            XmlElement element = (XmlElement)node;
            string AreaCode = element.GetAttribute("AreaCode");
            string UnitCode = element.GetAttribute("UnitCode");
            string UnitName = element.GetAttribute("UnitName");
            string OutLookId = element.GetAttribute("OutLookId");
            string License = element.GetAttribute("License");
            string LicenseType = element.GetAttribute("LicenseType");
            string User = element.GetAttribute("User");
            string Address = element.GetAttribute("Address");
            string Phone = element.GetAttribute("Phone");
            string CheckMethod = element.GetAttribute("CheckMethod");
            string CheckDate = element.GetAttribute("CheckDate");
            string CheckResult = element.GetAttribute("CheckResult");
            string VehicleModel = element.GetAttribute("VehicleModel");
            string IPAddress = element.GetAttribute("IPAddress");
            string V1 = element.GetAttribute("V1");
            string V2 = element.GetAttribute("V2");
            string V3 = element.GetAttribute("V3");
            string V4 = element.GetAttribute("V4");
            string V5 = element.GetAttribute("V5");
            string V6 = element.GetAttribute("V6");
            CheckResult result = new CheckResult()
            {
                //CheckMethod
                //VehicleModel
                V1 = V1,
                V2 = V2,
                V3 = V3,
                V4 = V4,
                V5 = V5,
                V6 = V6,
                CISPASS = CheckResult,
                CNUMBERPLATE = License,
                CUSER = User,
                CADDRESS = Address,
                CFACECHECKID = OutLookId,
                LicenseType = LicenseType,
                Phone = Phone,
                CheckMethod = CheckMethod,
                CheckDate = CheckDate,
                AreaCode = AreaCode,
                UnitCode = UnitCode,
                VehicleModel = VehicleModel,
                UnitName = UnitName,
                IPAddress = IPAddress
            };

            return result;
        }

    }

}

