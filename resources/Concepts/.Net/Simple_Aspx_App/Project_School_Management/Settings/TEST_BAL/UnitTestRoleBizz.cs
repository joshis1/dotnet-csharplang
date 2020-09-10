using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAL;
using System.Data;

namespace TEST_BAL
{
    [TestClass]
    public class UnitTestRoleBizz
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable results = BAL.RoleBizz.GetRoles();
            Console.WriteLine("Results = {0}", results.ToString());
            
        }
    }
}
