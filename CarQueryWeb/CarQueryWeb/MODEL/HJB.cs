using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQueryWeb.MODEL
{
    public class HJB
    {
        public string JYZMC;
        public string JCSJ;
        public string BLLX;
        public string SZ;

    }
    public class HJBALL
    {
        public List<HJB> rows;
        public int total;
    }
}