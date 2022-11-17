using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace sample.Controller
{
    class ConnectionString
    {
        public static string  ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["sample.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
