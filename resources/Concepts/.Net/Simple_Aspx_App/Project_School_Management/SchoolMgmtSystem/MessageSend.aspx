<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.Master" AutoEventWireup="true" CodeBehind="MessageSend.aspx.cs" Inherits="SchoolMgmtSystem.MessageSend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src='https://www.google.com/recaptcha/api.js'></script>
      <div class="jumbotron text-center">
          <h1>Welcome </h1>
          <div class="h1">
          <asp:Literal ID="LiteraluserName" runat="server" Text="" ></asp:Literal>      
         </div>
      </div>      

        <div class="form-group" style="display:block" id="DivCreateAccounts" runat="server" >
        <asp:Button ID="ButtonCreateAccount" runat="server" Text="Create Account"  CssClass="btn-primary btn-block" OnClick="ButtonCreateAccount_Click"/>
        </div>

       <div class="form-group" style="display:block" id="DivManageAccounts" runat="server" >
        <asp:Button ID="ButtonManageAccounts" runat="server" Text="Manage Accounts"  CssClass="btn-primary btn-block" OnClick="ButtonManageAccounts_Click"/>
        </div>

       <div class="form-group" style="display:block">
        <asp:Button ID="ButtonInbox" runat="server" Text="Inbox"  CssClass="btn-primary btn-block" OnClick="ButtonInbox_Click"/>
    </div>

       <div>
          <asp:Label ID="LabelRole" runat="server" Text="Message to Send RoleID:"></asp:Label>
            <asp:DropDownList ID="DropDownListRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Faculty</asp:ListItem>
                <asp:ListItem Value="3">Student</asp:ListItem>
                <asp:ListItem Value="4">Parents</asp:ListItem>
            </asp:DropDownList>
      </div>

     <div>
         <asp:Label ID="LabelSelectName" runat="server" Text="Select Recipient EmailId"></asp:Label>
         <asp:DropDownList ID="DropDownListSelectNames" runat="server"></asp:DropDownList>
     </div>

    <div>
    
        <asp:TextBox ID="TextBoxMessage" runat="server" TextMode="MultiLine" Height="141px" Width="743px"></asp:TextBox>
    </div>

    <div class="form-group" style="display:block">
        <asp:Button ID="ButtonSend" runat="server" Text="Send"  CssClass="btn-primary center-block" OnClick="ButtonSend_Click"/>
    </div>

 <div class="g-recaptcha" data-sitekey="6LeRohgUAAAAAMg1QUctEuGFy9Gco9-TMrFRB9Le"></div>
</asp:Content>
