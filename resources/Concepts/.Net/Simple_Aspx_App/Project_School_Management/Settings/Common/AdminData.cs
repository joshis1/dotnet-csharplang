using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AdminData
    {
        public string AdminID { get; set; }
        public string Fname { get ; set; }
        public string Lname { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public char Gender { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string ClassID { get; set; }
        public string StudentID { get; set; }
        public string ClassValue { get; set; }
    }

}
