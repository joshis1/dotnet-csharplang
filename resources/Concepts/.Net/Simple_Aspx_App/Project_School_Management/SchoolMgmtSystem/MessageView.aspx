<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.Master" AutoEventWireup="true" CodeBehind="MessageView.aspx.cs" Inherits="SchoolMgmtSystem.MessageView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="jumbotron">
            <h1>Inbox</h1>
      </div>          

        <asp:ListView ID="lvgetMessages" runat="server" OnSelectedIndexChanged="lvgetMessages_SelectedIndexChanged">


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
                        <th> Sender Email ID</th>
                        <th> Sender Role </th>
                        <th> Message</th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                                                
                    <td>
                        <asp:Label ID="emailIDLabel" runat="server" Text='<%# Eval("[SenderEmailID]") %>' />

                    </td>

                    <td>
                        <asp:Label ID="SenderRoleLabel" runat="server" Text='<%# Eval("RoleName") %>' />
                    </td>
    
                    <td>
                        <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("[Message]") %>' />
                    </td>

                     <td>   
                         <asp:Button ID="ButtonDelete" runat="server" Text="Delete" onclick="ButtonDelete_Click" UseSubmitBehavior="False" />
                    </td>

                </tr>
            </ItemTemplate>
            
        </asp:ListView>

          <div class="form-group" runat="server" style="display:block">
            <asp:Button ID="ButtonBack" runat="server" Text="Back" CssClass="btn-primary center-block" OnClick="ButtonBack_Click" />
        </div>
</asp:Content>
