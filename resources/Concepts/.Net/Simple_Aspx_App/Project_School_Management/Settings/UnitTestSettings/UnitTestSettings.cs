using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Settings;
using System.Collections.Generic;
using System.Data;
using DAL;
using System.Configuration;
namespace UnitTestSettings
{
    [TestClass]
    public class UnitTestSettings
    {
        [TestMethod]
        public void TestMethod1()
        {
            string con = Settings.Settings.ConnectionString();
            Console.WriteLine(con);
            //DAL.DbManager db = new DbManager();
            //Dictionary<String, String> dict = new Dictionary<string, string>();
            //dict.Add("@ROLEID", "1");
            //Console.WriteLine(db.Getdata("sp_get_role", dict));
        }
    }
}
