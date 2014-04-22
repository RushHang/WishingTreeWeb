using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibraries;
using System.Reflection;
using System.Web;

namespace WishingTree.Model
{
    public class Factory
    {
        private static DataAccess da;

        //static HttpServerUtility server = new HttpServerUtility();

        public static string ConnString { get; set; }

        public static DataAccess Da
        {
            get
            {
                if (da == null)
                {
                    da = new DataAccess();
                    da.DataType = DBTypes.SqlLite;
                    da.Connstring = @"Data Source=" + ConnString + @";Version=3;Pooling=true;Max Pool Size=200;FailIfMessing=false";
                    da.AddModels(Assembly.GetExecutingAssembly().GetTypes());
                    da.ConnCount = 20;
                }
                return da;
            }
        }

    }
}
