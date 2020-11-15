<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mainpage.aspx.cs" Inherits="CollegeManagementSystem.Mainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
        
    <style type="text/css">
        .auto-style2 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <br />   
           <center> <asp:Label ID="Label1" runat="server" Text="College Management System" Font-Bold="True" Font-Size="XX-Large" ForeColor="Green"></asp:Label></center>
              <br />
            <table class="table table-hover table-responsive">
            

            <tr>
                <td>

        <p id="lblContact">
            StudentId<asp:TextBox ID="txtContact" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                    </td>
                </tr>
                 <tr>
                    <td>

        <p id="lblname">
            FirstName<asp:TextBox ID="txtName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                </td>
            </tr>

                <tr>
                    <td>

        <p id="lblname2">
            LastName<asp:TextBox ID="txtName2" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                </td>
            </tr>

                <tr>
                    <td>

        <p id="lblbirth">
            BirthDate<asp:TextBox ID="txtbirth" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                </td>
            </tr>

                <tr>
                    <td>

        <p id="lblEmail">
            EmailAddr<asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                 </td>
                    </tr>
                 <tr>
                    <td>

        <p id="lblcountry">
            Country<asp:TextBox ID="txtcountry" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                     </td>
                  </tr>
                <tr>
                   
            <p>
                 <td class="auto-style2">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Cssclass="btn btn-default btn-success"/>
                </td>

                <td class="auto-style2">
                <asp:Button ID="btnUpdate" runat="server" Enabled="false" OnClick="btnEdid_Click" Text="Update" CssClass=" btn-danger btn-default" />
                </td>
            </p>  
                  </tr>

               

          </table>
            <br />

             <asp:GridView ID="gridBook" runat="server" class="table table-hover table-responsive">
                 <Columns>
                     <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Mainpage.aspx?id={0}&amp;action=1" HeaderText="Delete" Text="Delete">
                     <FooterStyle ForeColor="Red" />
                     </asp:HyperLinkField>
                     <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Mainpage.aspx?id={0}&amp;action=2" HeaderText="Update" Text="Update">
                     <FooterStyle ForeColor="Green" />
                     </asp:HyperLinkField>
                 </Columns>
            </asp:GridView>
            <br />
            <td>
                <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
            </td>
            <br />
            <td class="auto-style2">
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" Cssclass="btn btn-default btn-danger"/>
            </td>
   </div>     
    </form>
</body>
</html>
