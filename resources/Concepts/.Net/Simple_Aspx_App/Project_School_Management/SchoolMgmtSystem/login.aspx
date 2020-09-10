<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SchoolMgmtSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src='https://www.google.com/recaptcha/api.js'></script>

  <div class="container-fluid">

        <div class="jumbotron" id="divLoginAccount" runat="server" style="display:block">
            <h1>Please login into your account</h1>
        </div>


        <div class="form-group" id="DivRoleSelect" runat="server" style="display:block">
            <asp:Label ID="LabelRole" runat="server" Text="Role:" CssClass="col-sm-2"></asp:Label>
            <asp:DropDownList ID="DropDownSelListRoles" runat="server">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Faculty</asp:ListItem>
                <asp:ListItem Value="3">Student</asp:ListItem>
                <asp:ListItem Value="4">Parents</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoles" runat="server" ErrorMessage="Please select Role ID" ControlToValidate="DropDownSelListRoles"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <asp:Label ID="LabelUserId" runat="server" Text="UserId:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxUserId" runat="server" CssClass="col-sm-3" placeholder="Enter your UserId"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserId" runat="server" ErrorMessage="Enter your UserId" ControlToValidate="TextBoxUserId" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserId" runat="server" ErrorMessage="Enter valid user Id" ControlToValidate="TextBoxUserId" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
        </div>

      <div class="form-group">
            <asp:Label ID="LabelPassword" runat="server" Text="Password:" CssClass="col-sm-2"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="col-sm-3" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Enter your Password" ControlToValidate="TextBoxPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

      <div class="form-group">
            <div class="form-group" id ="DivLogin" runat="server" style="display:block">
            <asp:Button ID="Buttonlogin" runat="server" Text="Login" CssClass="btn-primary center-block" OnClick="Buttonlogin_Click" />
        </div>
        </div>

      </div>

 <div class="g-recaptcha" data-sitekey="6LeRohgUAAAAAMg1QUctEuGFy9Gco9-TMrFRB9Le"></div>
  

</asp:Content>
