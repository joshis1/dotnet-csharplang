using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using Common;


namespace BAL
{
   public  class RoleBizz
    {
       public static DataTable GetRoles(int roleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@ROLEID", roleId.ToString());
            return db.Getdata("sp_get_role", dict);

        }

        public static DataTable GetAdminInfo()
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            return db.Getdata("sp_show_admin_info", dict);

        }

        public static DataTable GetUserMessages(string userEmailId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@ReceipentEmailID", userEmailId);
            return db.Getdata("sp_get_usr_message_details", dict);
        }

        public static DataTable GetFacultyInfo()
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            return db.Getdata("sp_show_faculty_info", dict);

        }

        public static DataTable GetStudentInfo()
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            return db.Getdata("sp_show_student_info", dict);
        }

        public static DataTable GetParentInfo()
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            return db.Getdata("sp_show_parent_info", dict);
        }

        public static bool SetAccountStatus(string id, string roleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@Id", id);
            dict.Add("@RoleID", roleId);
            return db.SaveData("sp_update_statusaccount", dict);
        }



        public static bool GetAccountStatus(string hId, string RoleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@RoleID", RoleId);
            dict.Add("@ID", hId);
            return db.SaveData("sp_get_status", dict);

        }
    }
}
