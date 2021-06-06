<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="webTasarimProje.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - GİRİŞ</title>
    <style type="text/css">
        .auto-style1 {
            width: 76%;
            margin-left: 371px;
        }
        .auto-style3 {
            margin-left: 810px;
        }
        .auto-style4 {
            height: 29px;
            margin-left: 400px;
            width: 28px;
        }
        .auto-style5 {
            height: 29px;
            margin-left: 80px;
            width: 28px;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        .auto-style7 {
            margin-left: 658px;
        }
        .auto-style8 {
            margin-left: 0px;
            margin-bottom: 30px;
        }
        .auto-style9 {
            margin-left: 566px;
            height: 35px;
        }
        .auto-style10 {
            margin-left: 10px;
            margin-top: 0px;
        }
        .auto-style11 {
            margin-left: 400px;
        }
        .auto-style12 {
            margin-left: 658px;
            height: 37px;
        }
        .auto-style15 {
            height: 29px;
            width: 140px;
            margin-left: 240px;
        }
        .auto-style16 {
            height: 29px;
            width: 140px;
            margin-left: 320px;
        }
        .auto-style17 {
            margin-left: 533px;
        }
        .auto-style18 {
            margin-left: 349px;
        }
        .auto-style19 {
            margin-left: 1440px;
            margin-top: -75px;
        }
        </style>
</head>
<body style = "background-color: grey; margin-top: 80px;">
    <form id="form1" runat="server">
        <div class="auto-style19">

            <asp:Button ID="Button1" runat="server" Text="Ana Sayfa" OnClick="Button1_Click" />

        </div>
        <p class="auto-style18">
            <asp:Label ID="lblBankGiris" runat="server" Font-Bold="True" Font-Size="50pt" Text="ABB BANK - GİRİŞ YAP"></asp:Label>
        </p>
        <p class="auto-style11">
&nbsp;&nbsp;&nbsp;
        </p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style16" aria-hidden="False">
                    <asp:Label ID="lblKimlik" runat="server" Font-Bold="True" Text="TC KİMLİK NO"></asp:Label>
                    <br />
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtKimlik" runat="server" Width="220px" CssClass="auto-style6" AutoCompleteType="Disabled"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="lblSifre" runat="server" Font-Bold="True" Text="ŞİFRE"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtSifre" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                    <asp:CheckBox ID="cB" runat="server" AutoPostBack="True" OnCheckedChanged="cB_CheckedChanged" Text="Şifremi Göster" />
                </td>
            </tr>
        </table>
        <p class="auto-style3">
            <asp:LinkButton ID="linkBtnSifre" runat="server" ForeColor="Black" Font-Size="12pt" OnClick="LinkButton2_Click">Şifremi Unuttum</asp:LinkButton>
            <asp:Button ID="btnGiris" runat="server" Text="GİRİŞ YAP" Width="118px" OnClick="btnGiris_Click" Height="30px" />
        </p>
        <p class="auto-style9">
            <asp:Label ID="lblBankGirisOnay" runat="server" Font-Bold="True" Font-Size="20pt" Text="ABB BANK - GİRİŞ ONAY" Visible="False"></asp:Label>
        </p>
        <p class="auto-style17">
            <asp:Label ID="lblUyari" runat="server" Text="Mail Adresinize Gönderilen 6 Haneli Onay Kodunu Giriniz" Visible="False"></asp:Label>
        </p>
        <p class="auto-style12">
            <asp:TextBox ID="txtMail" runat="server" CssClass="auto-style8" Height="34px" Width="128px" Font-Size="28pt" Visible="False" AutoCompleteType="Disabled"></asp:TextBox>
        </p>
        <p class="auto-style7">
            <asp:Button ID="btnOnay" runat="server" Text="ONAYLA" Width="108px" OnClick="btnOnay_Click" CssClass="auto-style10" Height="31px" Visible="False" />
        </p>
    </form>
</body>
</html>
