using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace SchoolMgmtSystem
{
    public partial class MessageView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lvgetMessages.DataSource = null;
            lvgetMessages.DataBind();
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            String userEmailId = AdminBizz.GetEmailId(userId, roleId);

            DataTable dtMessageInfo = RoleBizz.GetUserMessages(userEmailId);

            if (dtMessageInfo.Rows.Count > 0)
            {
                lvgetMessages.DataSource = dtMessageInfo;
                lvgetMessages.DataBind();
            }
        }

        protected void lvgetMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            Response.Redirect("MessageSend.aspx?UserId=" + userId + "&RoleId=" + roleId);
        }
    }
}