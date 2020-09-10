using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace SchoolMgmtSystem.Admin
{


    public partial class GetRolesInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAdminRows();
        }

        public void getAdminRows()
        {
            DataTable dt = BAL.RoleBizz.GetRoles(RoleId.Admin);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
    }
}