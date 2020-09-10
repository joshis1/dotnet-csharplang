<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="SchoolMgmtSystem.Admin.SaveAdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src='https://www.google.com/recaptcha/api.js'></script>
    <div class="container-fluid">

        <div class="jumbotron" id="divCreateAccount" runat="server" style="display:block">
            <h1>Create Account</h1>
        </div>

        <div class="jumbotron" id="divUpdateAccount" runat="server" style="display:none">
            <h1> Update Account </h1>
        </div>

        <div class="form-group" id="DivRoleUpdate" runat="server" style="display:block">
            <asp:Label ID="LabelRole" runat="server" Text="Role:" CssClass="col-sm-2"></asp:Label>
            <asp:DropDownList ID="DropDownListRoles" runat="server" OnSelectedIndexChanged="DropDownListRoles_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Faculty</asp:ListItem>
                <asp:ListItem Value="3">Student</asp:ListItem>
                <asp:ListItem Value="4">Parents</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoles" runat="server" ErrorMessage="Please select Role ID" ControlToValidate="DropDownListRoles"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <asp:Label ID="LabelFName" runat="server" Text="First Name:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxFName" runat="server" CssClass="col-sm-3" placeholder="Enter your First Name" AutoPostBack="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFname" runat="server" ErrorMessage="Missing First Name" ControlToValidate="TextBoxFName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelLName" runat="server" Text="Last Name:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxLName" runat="server" CssClass="col-sm-3" placeholder="Enter your Last Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLname" runat="server" ErrorMessage="Missing Last Name" ControlToValidate="TextBoxLName" ForeColor="#FF3300"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <asp:Label ID="LabelGender" runat="server" Text="Gender:" CssClass="col-sm-2"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListGender" runat="server" CssClass="col-sm-3" RepeatDirection="Horizontal">
                <asp:ListItem Value="M">MALE</asp:ListItem>
                <asp:ListItem Value="F">FEMALE</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Select Gender" ControlToValidate="RadioButtonListGender" ForeColor="#FF3300"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group" id="DivFacultyClass" runat="server" style="display:none">
            <asp:Label ID="LabelFacultyClass" runat="server" Text="Class Name:" CssClass="col-sm-2"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxListClasses" runat="server" RepeatDirection="Horizontal" CellPadding="4" CellSpacing="4" ValidateRequestMode="Disabled">
                <asp:ListItem Value="1">Class 1 </asp:ListItem>
                <asp:ListItem Value="2">Class 2 </asp:ListItem>
                <asp:ListItem Value="3">Class 3 </asp:ListItem>
                <asp:ListItem Value="4">Class 4 </asp:ListItem>
                <asp:ListItem Value="5">Class 5 </asp:ListItem>
                <asp:ListItem Value="6">Class 6 </asp:ListItem>
            </asp:CheckBoxList>
            <asp:CustomValidator ID="RequiredFieldValidatorFacultyClass" runat="server" ErrorMessage="Add faculty to atleast 1 class"  onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        </div>

          <div class="form-group" id="DivStudentClass" runat="server" style="display:none">
            <asp:Label ID="LabelStudentClass" runat="server" Text="Class Name:" CssClass="col-sm-2"></asp:Label>
              <asp:DropDownList ID="DropDownListClass" runat="server">
                  <asp:ListItem Value="1">Class 1</asp:ListItem>
                  <asp:ListItem Value="2">Class 2</asp:ListItem>
                  <asp:ListItem Value="3">Class 3</asp:ListItem>
                  <asp:ListItem Value="4">Class 4</asp:ListItem>
                  <asp:ListItem Value="5">Class 5</asp:ListItem>
                  <asp:ListItem Value="6">Class 6</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentClass" runat="server" ErrorMessage="Add Student to a class" ControlToValidate="DropDownListClass"></asp:RequiredFieldValidator>
        </div>

          <div class="form-group" id="DivParentStudentId" runat="server" style="display:none">
            <asp:Label ID="Label1" runat="server" Text="Student ID:" CssClass="col-sm-2"></asp:Label>
              <asp:TextBox ID="TextBoxStudentID" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentID" runat="server" ErrorMessage="Enter Student ID" ControlToValidate="TextBoxStudentID"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelEmailId" runat="server" Text="Email ID:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxEmailId" runat="server" CssClass="col-sm-3" placeholder="Enter your Email-id" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Missing Email Id" ControlToValidate="TextBoxEmailId" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBoxEmailId" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group" id="DivPassword" runat="server" style="display:block">
            <asp:Label ID="LabelPassword" runat="server" Text="Password:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="col-sm-3" placeholder="Enter password" TextMode="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Missing Password" ControlToValidate="TextBoxPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <ajaxToolkit:PasswordStrength ID="PasswordStrength1"  runat="server" ViewStateMode="Inherit" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1" MinimumNumericCharacters="4" MinimumSymbolCharacters="1" PreferredPasswordLength="6" TargetControlID="TextBoxPassword" />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             
        </div>

        <div class="form-group" id="DivConfirmPassword" runat="server" style="display:block">
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" CssClass="col-sm-3" placeholder="Confirm password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" ErrorMessage="Missing Confirm Password" ControlToValidate="TextBoxConfirmPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Confirm Password doesn't match" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword"></asp:CompareValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelMobileNumber" runat="server" Text="Mobile Number:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxMobileNumber" runat="server" CssClass="col-sm-3" placeholder="Enter Mobile Number" TextMode="Phone"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMobileNumber" runat="server" ErrorMessage="Missing Mobile Number" ControlToValidate="TextBoxMobileNumber" ForeColor="#FF3300"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Mobile Number" ForeColor="Red" ControlToValidate="TextBoxMobileNumber" ValidationExpression="^[0-9]{12}$"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelAddress" runat="server" Text="Address:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="col-sm-3" placeholder="Enter Address" AutoCompleteType="None" TextMode="MultiLine"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ErrorMessage="Missing Address" ControlToValidate="TextBoxAddress" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group" id ="DivSignUpBtn" runat="server" style="display:block">
            <asp:Button ID="ButtonSignUpAdmin" runat="server" Text="Sign Up" CssClass="btn-primary center-block" OnClick="ButtonSignUpAdmin_Click" />
        </div>
        <div class="form-group" id ="DivUpdateBtn" runat="server" style="display:block">
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn-primary center-block" OnClick="ButtonUpdate_Click" />
        </div>

        <div class="form-group" id ="Div1" runat="server" style="display:block">
            <asp:Button ID="ButtonBack" runat="server" Text="Back" CssClass="btn-primary center-block" CausesValidation="False" OnClick="ButtonBack_Click" />
        </div>

       
    </div>

     <div class="g-recaptcha" data-sitekey="6LeRohgUAAAAAMg1QUctEuGFy9Gco9-TMrFRB9Le"></div>
</asp:Content>

