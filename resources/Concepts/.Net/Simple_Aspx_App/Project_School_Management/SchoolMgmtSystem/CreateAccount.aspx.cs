using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BAL;

namespace SchoolMgmtSystem.Admin
{
    public partial class SaveAdminInfo : System.Web.UI.Page
    {

       static String GetRoleIdFromRoleName(String Rolename)
        {
           switch(Rolename)
            {
                case "Admin":
                     return "1";

                case "Faculty":
                    return "2";

                case "Student":
                    return "3";

                case "Parent":
                    return "4";

                default:
                    return "0";

            }
        
        }

        static String GetClassIdFromClasName(String ClassName)
        {
            switch (ClassName)
            {
                case "Class 1":
                    return "1";

                case "Class 2":
                    return "2";

                case "Class 3":
                    return "3";

                case "Class 4":
                    return "4";

                case "Class 5":
                    return "5";
                case "Class 6":
                    return "6";
                default:
                        return "0";

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DivUpdateBtn.Style.Add("display", "none");
                String RoleId;

                if (Request.QueryString["RoleName"] != null)
                {
                    DivPassword.Style.Add("display", "none");
                    DivConfirmPassword.Style.Add("display", "none");
                    DivSignUpBtn.Style.Add("display", "none");
                    RequiredFieldValidatorPassword.Enabled = false;
                    RequiredFieldValidatorConfirmPassword.Enabled = false;
                    String AdminId = Request.QueryString["Id"];
                    RoleId = GetRoleIdFromRoleName(Request.QueryString["RoleName"].ToString());

                    Common.AdminData AdminData = BAL.AdminBizz.GetFormData(AdminId, RoleId);
                    AdminData.AdminID = AdminId;
                    /** File the update Data **/
                    DropDownListRoles.SelectedValue = AdminData.RoleId.ToString();
                    TextBoxFName.Text = AdminData.Fname;
                    TextBoxLName.Text = AdminData.Lname;
                    TextBoxEmailId.Text = AdminData.EmailId;
                    TextBoxMobileNumber.Text = AdminData.MobileNumber;
                    TextBoxAddress.Text = AdminData.Address;
                    RadioButtonListGender.SelectedValue = AdminData.Gender.ToString();
                    if(RoleId == "2" && AdminData.ClassValue != "")
                    {
                        DivFacultyClass.Style.Add("display", "block");
                        byte classval = Convert.ToByte(AdminData.ClassValue);
                        for (int i = 0; i < 6; i++)
                        {
                            int x = Convert.ToInt32(classval);
                            int statbit = (x >> i) & 1;
                            if (statbit == 1)
                            {
                                ListItem item = CheckBoxListClasses.Items.FindByValue((i + 1).ToString());
                                item.Selected = true;
                            }
                        }

                    }
                    DivSignUpBtn.Style.Add("display", "none");
                    DivUpdateBtn.Style.Add("display", "block");
                    DivRoleUpdate.Style.Add("display", "none");
                    divCreateAccount.Style.Add("display", "none");
                    divUpdateAccount.Style.Add("display", "block");

                    if (RoleId == "1")
                    {
                        RequiredFieldValidatorFacultyClass.Enabled = false;
                        RequiredFieldValidatorStudentClass.Enabled = false;
                        RequiredFieldValidatorStudentID.Enabled = false;
                    }

                    else if (RoleId == "2")
                    {
                        RequiredFieldValidatorStudentClass.Enabled = false;
                        RequiredFieldValidatorStudentID.Enabled = false;
                
                    }

                    else if (RoleId == "3" && AdminData.ClassID!=null)
                    {
                        RequiredFieldValidatorFacultyClass.Enabled = false;
                        RequiredFieldValidatorStudentID.Enabled = false;
                        DivStudentClass.Style.Add("display", "block");
                        ListItem item = DropDownListClass.Items.FindByValue(GetClassIdFromClasName(AdminData.ClassID.Trim()));
                        item.Selected = true;

                    }
                   
                    else if(RoleId == "4")
                    {
                        RequiredFieldValidatorFacultyClass.Enabled = false;
                        RequiredFieldValidatorStudentClass.Enabled = false;
                        DivParentStudentId.Style.Add("display", "block");

                    }
                }

                // by default Admin ID is selected
                else
                {

                    RequiredFieldValidatorFacultyClass.Enabled = false;
                    RequiredFieldValidatorStudentClass.Enabled = false;
                    RequiredFieldValidatorStudentID.Enabled = false;
                }

            }

        }

        private void ResetControls(Control parent)
        {
            foreach (Control val in parent.Controls)
            {
                if (val.GetType() == typeof(TextBox))
                {
                    ((TextBox)(val)).Text = "";
                }
                if(val.HasControls())
                {
                    ResetControls(val);
                }
            }
        }

        protected void ButtonSignUpAdmin_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }
            Common.AdminData newAdmin = new AdminData();
            /** prepare the data from the Admin Sign-Up form **/
            newAdmin.Fname = TextBoxFName.Text.Trim();
            newAdmin.Lname = TextBoxLName.Text.Trim();
            newAdmin.PasswordHash = Common.Encryption.Encrypt(TextBoxPassword.Text.Trim());
            newAdmin.RoleId = Int32.Parse(DropDownListRoles.SelectedValue);
            newAdmin.Gender = Convert.ToChar(RadioButtonListGender.SelectedValue);
            newAdmin.EmailId = TextBoxEmailId.Text.Trim();
            newAdmin.MobileNumber = TextBoxMobileNumber.Text.Trim();
            newAdmin.Address = TextBoxAddress.Text.Trim();

            // for Faculty
            if(newAdmin.RoleId == 2 )
            {
                byte classVal = 0;
                int index = 0;
                foreach(ListItem item in CheckBoxListClasses.Items)
                {
                    
                    if(item.Selected)
                    {
                        int x = Convert.ToInt32(classVal);
                        int val = x | (1 << index);
                        classVal = Convert.ToByte(val);
                    }
                    index++;
                }
                newAdmin.ClassValue = Convert.ToByte(classVal).ToString();
            }           

            // for student
            if(newAdmin.RoleId == 3)
            {
                newAdmin.ClassID = DropDownListClass.SelectedValue;
            }

            // for parent 
            if( newAdmin.RoleId == 4)
            {
                newAdmin.StudentID = TextBoxStudentID.Text.Trim();
            }

            /*** Save the data to Admin Table **/
            if(BAL.AdminBizz.SaveAdminData(newAdmin) == 0)
            {
                Response.Write("Failed to Add new Admin");
            }
            //else
            //{
            //    ResetControls(this);
            //}

            else
            {
                TextBoxFName.Text = "";
                TextBoxLName.Text = "";
                RadioButtonListGender.ClearSelection();
                TextBoxEmailId.Text = "";
                TextBoxMobileNumber.Text = "";
                TextBoxAddress.Text = "";

            }

           
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
                return;
            }

            Common.AdminData newAdmin = new AdminData();
            /** prepare the data from the Admin Sign-Up form **/
            newAdmin.Fname = TextBoxFName.Text.Trim();
            newAdmin.Lname = TextBoxLName.Text.Trim();
            newAdmin.RoleId = Int32.Parse(GetRoleIdFromRoleName(Request.QueryString["RoleName"]));
            newAdmin.Gender = Convert.ToChar(RadioButtonListGender.SelectedValue);
            newAdmin.EmailId = TextBoxEmailId.Text.Trim();
            newAdmin.MobileNumber = TextBoxMobileNumber.Text.Trim();
            newAdmin.Address = TextBoxAddress.Text.Trim();
            newAdmin.AdminID = Request.QueryString["Id"].Trim();
            newAdmin.ClassID = DropDownListClass.SelectedValue.Trim();
            newAdmin.StudentID = TextBoxStudentID.Text.Trim();

            if (newAdmin.RoleId == 2)
            {
                byte classVal = 0;
                int index = 0;
                foreach (ListItem item in CheckBoxListClasses.Items)
                {

                    if (item.Selected)
                    {
                        int x = Convert.ToInt32(classVal);
                        int val = x | (1 << index);
                        classVal = Convert.ToByte(val);
                    }
                    index++;
                }
                newAdmin.ClassValue = Convert.ToByte(classVal).ToString();
            }

            /*** Save the data to Admin Table **/
            if (BAL.AdminBizz.UpdateAdminData(newAdmin) != 0)
            {
                Response.Write("Failed to Add new Admin");
            }
            else
            {
                Response.Redirect("ShowAdminData.aspx");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CheckBoxListClasses.SelectedIndex == -1 || DropDownListRoles.SelectedValue != "2"? false : true;
        }

        protected void DropDownListRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Admin selected
            if(DropDownListRoles.SelectedValue == "1")
            {
                DivStudentClass.Style.Add("display", "none");
                DivFacultyClass.Style.Add("display", "none");
                DivParentStudentId.Style.Add("display", "none");
                RequiredFieldValidatorFacultyClass.Enabled = false;
                RequiredFieldValidatorStudentClass.Enabled = false;
                RequiredFieldValidatorStudentID.Enabled = false;
                

            }
            //Faculty selected
            else if(DropDownListRoles.SelectedValue == "2")
            {
                DivStudentClass.Style.Add("display", "none");
                DivFacultyClass.Style.Add("display", "block");
                DivParentStudentId.Style.Add("display", "none");
                DivFacultyClass.Style.Add("display", "block");
            }
            //Student selected
            else if (DropDownListRoles.SelectedValue == "3")
            {
                DivStudentClass.Style.Add("display", "block");
                DivFacultyClass.Style.Add("display", "none");
                DivParentStudentId.Style.Add("display", "none");
               
            }
            //Parent selected
            else
            {
                DivStudentClass.Style.Add("display", "none");
                DivFacultyClass.Style.Add("display", "none");
                DivParentStudentId.Style.Add("display", "block");
            }

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
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