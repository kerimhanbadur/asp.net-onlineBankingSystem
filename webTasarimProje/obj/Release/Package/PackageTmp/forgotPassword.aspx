<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="webTasarimProje.forgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="adminApplyedCss.css" rel="stylesheet" />
<head runat="server">
    <title>ABB BANK - ŞİFREMİ UNUTTUM</title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
            margin-left: 520px;
            margin-top: 139px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 249px;
        }
        .auto-style5 {
            margin-left: 600px;
        }
        .auto-style18 {
            margin-left: 228px;
            margin-top: 118px;
        }
        </style>
</head>
<body style="background-color:grey">
    <form id="form1" runat="server">

        <p class="auto-style18">
            <asp:Label ID="lblBankGiris" runat="server" Font-Bold="True" Font-Size="50pt" Text="ABB BANK - ŞİFREMİ UNUTTUM"></asp:Label>
        </p>

        <table class="auto-style1">
            <tr>
                <td class="auto-style3">TC KİMLİK NO</td>
                <td>
                    <asp:TextBox ID="txtKimlik" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">ŞİFRE</td>
                <td>
                    <asp:TextBox ID="txtSifre" runat="server" CssClass="auto-style2" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox><input type="checkbox" onchange="document.getElementById('txtSifre').type = this.checked ? 'text' : 'password'" />Şifremi Göster
                </td>
            </tr>
            <tr>
                <td class="auto-style3">ŞİFRE TEKRAR</td>
                <td>
                    <asp:TextBox ID="txtSifreOnay" runat="server" TextMode="Password"></asp:TextBox><input type="checkbox" onchange="document.getElementById('txtSifreOnay').type = this.checked ? 'text' : 'password'" />Şifremi Göster
                </td>
            </tr>
            <tr>
                <td class="auto-style3">MAİL ONAY KODU</td>
                <td>
                    <asp:TextBox ID="txtMailOnay" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p class="auto-style5">
            <asp:Button ID="btnSifreYenile" runat="server" Height="43px" OnClick="btnSifreYenile_Click" Text="Şifremi Güncelle" Width="239px" />
        </p>

    </form>
</body>
</html>
