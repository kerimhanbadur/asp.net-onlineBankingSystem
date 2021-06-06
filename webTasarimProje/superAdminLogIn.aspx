<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="superAdminLogIn.aspx.cs" Inherits="webTasarimProje.superAdminLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - MASTER ADMİN - GİRİŞ</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 276px;
            margin-top: 127px;
            width: 1152px;
        }
        .auto-style2 {
            width: 65%;
            margin-left: 280px;
            margin-top: 114px;
        }
        .auto-style4 {
            width: 445px;
        }
        .auto-style5 {
            width: 80px;
        }
        .auto-style6 {
            margin-left: 357px;
        }
    </style>
</head>
<body style="background-color:black">
    <form id="form1" runat="server" class="auto-style1">
        <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="40pt" ForeColor="Green" Text="ABB BANK - MASTER YETKİLİ GİRİŞ"></asp:Label>
    <table class="auto-style2">
        <tr>
            <td style="color:white" class="auto-style5">ID</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtId" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="color:white" class="auto-style5">PW</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPw" runat="server" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" ForeColor="White" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Şifremi Göster" />
            </td>
        </tr>
    </table>
        <p class="auto-style6">
            <asp:Button ID="Button1" runat="server" BackColor="White" Text="GİRİŞ" Width="134px" OnClick="Button1_Click" />
        </p>
    </form>
    </body>
</html>
