using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQueryWeb.MODEL
{
    [Serializable]
    public class ReportCheckResult
    {
        public string CheckDate;
        public string AreaCode;
        public string UnitName;
        public int CheckCount;
        public int Gas1Count;
        public int Gas1OKCount;
        public int Gas2Count;
        public int Gas2OKCount;
        public int GasCount;
        public int GasOKCount;
        public int Diesel1Count;
        public int Diesel1OKCount;
        public int Diesel2Count;
        public int Diesel2OKCount;
        public int DieselCount;
        public int DieselOKCount;
    }
    public class ReportCheckResultALL
    {
        public List<ReportCheckResult> rows;
        public int total;
    }
}