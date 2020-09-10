using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class Settings
    {
        public static string ConnectionString()
        {
            try
            {
                string Con = ConfigurationManager.ConnectionStrings["SqlCon"].ToString();
                return Con;
              
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
