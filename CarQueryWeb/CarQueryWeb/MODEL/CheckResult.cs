using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQueryWeb.MODEL
{
    public class CheckResult
    {
        public int id;
        public string XMLID;
        public string CheckMethod;
        public string VehicleModel;
        public string V1;
        public string V2;
        public string V3;
        public string V4;
        public string V5;
        public string V6;
        public string CISPASS;
        public string CNUMBERPLATE;
        public string CUSER;
        public string CADDRESS;
        public string CFACECHECKID;
        public string LicenseType;
        public string Phone;
        public string CheckDate;
        public string AreaCode;
        public string UnitCode;
        public string UnitName;
        public string IPAddress;

    }

    public class CheckResultAll
    {
        public List<CheckResult> rows;
        public int total;
    }
}