<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.Master" AutoEventWireup="true" CodeBehind="ShowAdminData.aspx.cs" Inherits="SchoolMgmtSystem.AccountUpdate_Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src='https://www.google.com/recaptcha/api.js'></script>

    <div class="container">

         <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Account Status</h4>
        </div>
        <div class="modal-body">
             <asp:HiddenField ID="hfId" runat="server" />

          <p>Do you want to update the Status?</p>
        </div>
        <div class="modal-footer">
          <asp:Button ID="BtnChangeStatus" runat="server" Text="Change Status" OnClick="BtnChangeStatus_Click" />

          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

        </div>
      </div>
      
    </div>
  </div>
        <div class="jumbotron">
            <h1>Show Accounts</h1>
            <asp:Label ID="LabelRole" runat="server" Text="Select Role  "></asp:Label>
            <asp:DropDownList ID="DropDownListRole" runat="server" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Faculty</asp:ListItem>
                <asp:ListItem Value="3">Student</asp:ListItem>
                <asp:ListItem Value="4">Parents</asp:ListItem>
            </asp:DropDownList>
          </div>          

               <div class="form-group" style="display:block">
        <asp:Button ID="ButtonMessageSend" runat="server" Text="BacktoUserPage"  CssClass="btn-primary btn-block" OnClick="ButtonMessageSend_Click"/>
    </div>

        <asp:ListView ID="lvgetadmininfo" runat="server" OnSelectedIndexChanged="lvgetadmininfo_SelectedIndexChanged" OnItemDataBound="lvgetadmininfo_ItemDataBound">


            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
 
            <LayoutTemplate>
                <table class="table table-border">
                    <tr>
                        <th> First Name</th>
                        <th> Last Name</th>
                        <th> Role</th>
                        <th> Gender</th>
                        <th> EmailID</th>
                        <th> MobileNumber</th>
                        <th> Actions</th> 
                      
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    
                                          
                    <td>
                        <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                        <asp:HiddenField ID="hiddenfieldID" runat="server" Value='<%# Eval("ID") %>' />

                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RoleIDLabel" runat="server" Text='<%# Eval("RoleName") %>' />
                    </td>
                    
                    <td>
                        <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmailIDLabel" runat="server" Text='<%# Eval("EmailID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Eval("MobileNumber") %>' />
                    </td>
                    <td>   
                        <a class="btn btn-success" href='CreateAccount.aspx?Id=<%# Eval("ID")%>&RoleName=<%# Eval("RoleName")%>'>Edit</a>
                        <asp:HyperLink href="#" runat="server" ID="btn_status_toggle" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick='<%# "fun("+ Eval("ID") + ")" %>'>Status</asp:HyperLink>
                    </td>

                    
                </tr>
            </ItemTemplate>
            
        </asp:ListView>
    </div>
    <script>
        function fun(id)
        {
            document.getElementById('<%= hfId.ClientID%>').value = id;          
        }
    </script>

 <div class="g-recaptcha" data-sitekey="6LeRohgUAAAAAMg1QUctEuGFy9Gco9-TMrFRB9Le"></div>
</asp:Content>
