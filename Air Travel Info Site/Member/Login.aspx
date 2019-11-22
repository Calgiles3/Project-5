<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Air_Travel_Info_Site.Member.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Login Page</h1>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><asp:TextBox ID="Username" TextMode="SingleLine" runat="server" /></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="Password" TextMode="Password" runat="server" /></td>
                </tr>
                <tr>
                    <td />
                    <td><asp:Button ID="Submit" Text="Submit" OnClick="Submit_Clicked" runat="server" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
