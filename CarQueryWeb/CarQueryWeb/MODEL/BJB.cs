using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQueryWeb.MODEL
{
    public class BJB
    {
        public string JYZMC;
        public string DATE;
        public string BJLX;
        public string BJSJ;
    }
    public class BJBALL
    {
        public List<BJB> rows;
        public int total;
    }
}