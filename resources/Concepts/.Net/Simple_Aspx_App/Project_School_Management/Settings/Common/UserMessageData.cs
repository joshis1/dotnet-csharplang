using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserMessageData
    {
        public string ReceipentEmailID { get; set; }
        public string SenderEmailID { get; set; }
        public string Message { get; set; }
        public string ReceipentRoleID { get; set; }
        public string SendereRoleID { get; set; }
    }
}
