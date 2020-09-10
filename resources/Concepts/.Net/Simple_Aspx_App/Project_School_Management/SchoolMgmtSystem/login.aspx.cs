using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace SchoolMgmtSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonlogin_Click(object sender, EventArgs e)
        {

            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }


            String userId = TextBoxUserId.Text;
            String RoleId = DropDownSelListRoles.SelectedValue;
            String passwd;
            passwd = BAL.AdminBizz.VerifyAccount(userId, RoleId);
            if(passwd == null)
            {
               Response.Write("Invalid password");
                return;
            }
            String unencryptpasswd = Common.Encryption.Decrypt(passwd);

            if( unencryptpasswd == TextBoxPassword.Text.Trim())
            {
                Response.Redirect("MessageSend.aspx?UserId=" + userId + "&RoleId=" + RoleId);
                return;
            }
            else
            {
              Response.Write("Invalid password");
                return;
            }
        }


    }
}