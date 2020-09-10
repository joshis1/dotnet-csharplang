using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace SchoolMgmtSystem
{
    public partial class MessageSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["UserId"] != null && Request.QueryString["RoleId"] != null)
            {
                String userId = Request.QueryString["UserId"];
                String roleId = Request.QueryString["RoleId"];

                /** Except Admin no one should have previlege to Create Account or Manage Account**/
                if( roleId != "1")
                {
                    DivCreateAccounts.Visible = false;
                    DivManageAccounts.Visible = false;
                }

                LiteraluserName.Text = AdminBizz.GetFnameAccount(userId, roleId);

                List<String> emails = AdminBizz.GetEmails(roleId);

                foreach(var item in emails)
                {
                    DropDownListSelectNames.Items.Add(new ListItem(item));
                }
            }
          
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListSelectNames.Items.Clear();
            string roleId = DropDownListRole.SelectedValue;
         

                List<String> emails = AdminBizz.GetEmails(roleId);

                foreach (var item in emails)
                {
                    DropDownListSelectNames.Items.Add(new ListItem(item));
                }
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {

            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }

            UserMessageData userData = new UserMessageData();
           
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            userData.SenderEmailID = AdminBizz.GetEmailId(userId, roleId);

            userData.SendereRoleID = roleId;
            userData.ReceipentEmailID = DropDownListSelectNames.SelectedItem.Text;
            userData.ReceipentRoleID = DropDownListRole.SelectedItem.Text;
            userData.Message = TextBoxMessage.Text.Trim();
            if (AdminBizz.SaveMessageData(userData) > 0)
            {
                TextBoxMessage.Text = "";
                Response.Write("Message sent successfully");
            }
            else
            {
                Response.Write("Failed to send Message");
            }
        }

        protected void ButtonInbox_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            Response.Redirect("MessageView.aspx?UserId=" + userId + "&RoleId=" + roleId);
        }

        protected void ButtonManageAccounts_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            Response.Redirect("ShowAdminData.aspx?UserId=" + userId + "&RoleId=" + roleId);
        }

        protected void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            Response.Redirect("CreateAccount.aspx?UserId=" + userId + "&RoleId=" + roleId);
        }
    }
}