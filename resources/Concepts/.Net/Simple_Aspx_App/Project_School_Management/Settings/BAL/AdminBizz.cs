using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using System.Data;

namespace BAL
{
    public class AdminBizz
    {
        public static int SaveAdminData(Common.AdminData adminVal)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();

            dict.Add("@Fname", adminVal.Fname);
            dict.Add("@Lname", adminVal.Lname);
            dict.Add("@PasswordHash", adminVal.PasswordHash);
            dict.Add("@RoleId", Convert.ToString(adminVal.RoleId));
            dict.Add("@Gender", Convert.ToString(adminVal.Gender));
            dict.Add("@EmailId", adminVal.EmailId);
            dict.Add("@MobileNumber", adminVal.MobileNumber);
            dict.Add("@Address", adminVal.Address);
            dict.Add("@ClassId", adminVal.ClassID);
            dict.Add("@StudentId", adminVal.StudentID);
            dict.Add("@ClassVal", adminVal.ClassValue);


            //dict.Add("@ClassID", adminVal.ClassID);
            //dict.Add("@StudentID", adminVal.StudentID);

            return db.insertData("sp_save_admin_data", dict);


        }

        public static Common.AdminData GetFormData(String adminId, String RoleId)
        {
            DAL.DbManager db = new DbManager();
            Common.AdminData adminData = new AdminData();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@Id", adminId);
            dict.Add("@RoleId", RoleId);
            DataTable dtAdminFormInfo = db.Getdata("sp_get_admin_data_byID", dict);

            adminData.Fname = dtAdminFormInfo.Rows[0]["Fname"].ToString();
            adminData.Lname = dtAdminFormInfo.Rows[0]["Lname"].ToString();
            adminData.RoleId = Convert.ToInt32(dtAdminFormInfo.Rows[0]["RoleId"]);
            adminData.Gender = Convert.ToChar(dtAdminFormInfo.Rows[0]["Gender"]);
            adminData.EmailId = dtAdminFormInfo.Rows[0]["EmailId"].ToString();
            adminData.MobileNumber = dtAdminFormInfo.Rows[0]["MobileNumber"].ToString();
            adminData.Address = dtAdminFormInfo.Rows[0]["Address"].ToString();
            if (RoleId == "2")
            {
                adminData.ClassValue = dtAdminFormInfo.Rows[0]["ClassVal"].ToString();
            }
            else if (RoleId == "3")
            {
                adminData.ClassID = dtAdminFormInfo.Rows[0]["ClassName"].ToString();
            }

            return adminData;

        }



        public static int UpdateAdminData(Common.AdminData adminVal)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();

            dict.Add("@Id", adminVal.AdminID);
            dict.Add("@Fname", adminVal.Fname);
            dict.Add("@Lname", adminVal.Lname);
            dict.Add("@RoleId", Convert.ToString(adminVal.RoleId));
            dict.Add("@Gender", Convert.ToString(adminVal.Gender));
            dict.Add("@EmailId", adminVal.EmailId);
            dict.Add("@MobileNumber", adminVal.MobileNumber);
            dict.Add("@Address", adminVal.Address);
            if (adminVal.RoleId == 2)
            {
                dict.Add("@ClassVal", adminVal.ClassValue);
            }
            else if (adminVal.RoleId == 3)
            {
                dict.Add("@ClassId", adminVal.ClassID);
            }

            return db.insertData("sp_update_admin_data", dict);


        }

        public static string VerifyAccount(String UserId, String RoleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@Id", UserId);
            dict.Add("@RoleId", RoleId);
            return db.verifyAccount("sp_verify_account", dict);
        }

        public static string GetFnameAccount(String UserId, String RoleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@ID", UserId);
            dict.Add("@RoleId", RoleId);
            return db.verifyAccount("sp_get_userName", dict);
        }

        public static string GetEmailId(String UserId, String RoleId)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@ID", UserId);
            dict.Add("@RoleId", RoleId);
            return db.verifyAccount("sp_get_emailID", dict);
        }


        public static List<String> GetEmails(String RoleId)
        {
            DAL.DbManager db = new DbManager();
            List<String> emailIds = new List<string>();
            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("@RoleId", RoleId);
            DataTable dtAdminFormInfo = db.Getdata("sp_get_all_user_ids", dict);

            foreach (DataRow row in dtAdminFormInfo.Rows)
            {
                emailIds.Add(row["EmailID"].ToString());
            }
         
            return emailIds;
        }

        public static int SaveMessageData(Common.UserMessageData userData)
        {
            DAL.DbManager db = new DbManager();
            Dictionary<String, String> dict = new Dictionary<string, string>();

            dict.Add("@ReceipentEmailID", userData.ReceipentEmailID);
            dict.Add("@SenderEmailID", userData.SenderEmailID);
            dict.Add("@Message", userData.Message);
            dict.Add("@ReceipentRoleID", userData.ReceipentRoleID);
            dict.Add("@SendereRoleID", userData.SendereRoleID);

            return db.insertData("sp_insert_message", dict);

        }

    }
}
