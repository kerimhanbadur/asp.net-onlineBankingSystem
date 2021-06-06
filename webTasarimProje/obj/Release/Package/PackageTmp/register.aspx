<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="webTasarimProje.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - KAYIT OL</title>
    <style type="text/css">
        .auto-style1 {
            width: 89%;
            height: 354px;
            margin-left: 0px;
        }
        .auto-style2 {
            height: 51px;
        }
        .auto-style3 {
            width: 319px;
        }
        .auto-style4 {
            width: 977px;
            margin-top: 97px;
        }
    </style>
</head>
<body style="background-color: grey; margin-left: 440px;">
    <form id="form1" runat="server">
        <p style="margin-left: -25px" class="auto-style4">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="50pt" Text="ABB BANK - KAYIT OL"></asp:Label>
        </p>
    <table class="auto-style1">
        <tr>
            <td style="margin-left: 120px">TC KİMLİK NO</td>
            <td>
                <asp:TextBox ID="txtKimlik" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>AD</td>
            <td>
                <asp:TextBox ID="txtAd" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="margin-left: 160px">SOYAD</td>
            <td>
                <asp:TextBox ID="txtSoyad" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="margin-left: 120px">EPOSTA</td>
            <td>
                <asp:TextBox ID="txtPosta" runat="server" TextMode="Email" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ŞİFRE</td>
            <td style="margin-left: 120px">
                <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">ŞİFRE TEKRAR</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtSifreKontrol" runat="server" TextMode="Password" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
    </table>
        <p style="margin-left: 200px" class="auto-style3">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="KAYIT OL" Width="214px" />
        </p>
    </form>
</body>
</html>
