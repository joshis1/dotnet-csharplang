using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Web.UI.HtmlControls;
using Common;

namespace SchoolMgmtSystem
{
    public partial class AccountUpdate_Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAccountsInfo(Convert.ToUInt16(DropDownListRole.SelectedValue));

        }

        protected void getAccountsInfo(UInt16 roleId)
        {

            lvgetadmininfo.DataSource = null;
            lvgetadmininfo.DataBind();

            switch (roleId)
            {
                /** Get Admin Data **/
                case 1:
                    DataTable dtAdmin = RoleBizz.GetAdminInfo();

                    if (dtAdmin.Rows.Count > 0)
                    {
                        lvgetadmininfo.DataSource = dtAdmin;
                        lvgetadmininfo.DataBind();
                    }
                    break;

                /** Get Faculty Data **/
                case 2:
                    DataTable dtFaculty = RoleBizz.GetFacultyInfo();
                    if (dtFaculty.Rows.Count > 0)
                    {
                        lvgetadmininfo.DataSource = dtFaculty;
                        lvgetadmininfo.DataBind();
                    }
                    break;

                /** Get Student Data **/
                case 3:
                    DataTable dtStudent = RoleBizz.GetStudentInfo();
                    if (dtStudent.Rows.Count > 0)
                    {
                        lvgetadmininfo.DataSource = dtStudent;
                        lvgetadmininfo.DataBind();
                    }
                    break;

                /** Get Parents Data **/
                case 4:
                    DataTable dtParent = RoleBizz.GetParentInfo();
                    if (dtParent.Rows.Count > 0)
                    {
                        lvgetadmininfo.DataSource = dtParent;
                        lvgetadmininfo.DataBind();
                    }
                    break;
            }


        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAccountsInfo(Convert.ToUInt16(DropDownListRole.SelectedValue));
        }

        protected void lvgetadmininfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            String id = hfId.Value;
            int roleId = Convert.ToUInt16(DropDownListRole.SelectedValue);
            bool ret =  RoleBizz.SetAccountStatus(id, roleId.ToString());

            getAccountsInfo(Convert.ToUInt16(DropDownListRole.SelectedValue));

        }

        protected void lvgetadmininfo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //determine if the row type is an Item
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                int roleId = Convert.ToUInt16(DropDownListRole.SelectedValue);
                // you would use your actual data item type here, not "object"
                HyperLink anchor = (HyperLink)e.Item.FindControl("btn_status_toggle");
                HiddenField hId = (HiddenField)e.Item.FindControl("hiddenfieldID");
                bool ret = RoleBizz.GetAccountStatus(hId.Value, roleId.ToString());
                if (ret == true)
                {
                    anchor.Attributes.Add("class", "btn btn-success");

                }
                else
                {
                    anchor.Attributes.Add("class", "btn btn-danger");
                  
                }
            }
        }

        protected void ButtonMessageSend_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            String roleId = Request.QueryString["RoleId"];
            String userId = Request.QueryString["UserId"];
            Response.Redirect("MessageSend.aspx?UserId=" + userId + "&RoleId=" + roleId);
        }
    }
}