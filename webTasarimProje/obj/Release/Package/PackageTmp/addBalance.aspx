<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addBalance.aspx.cs" Inherits="webTasarimProje.addBalance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - BAKİYE EKLE</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 160px;
            margin-top: 50px;
        }

        .auto-style2 {
            margin-left: 320px;
        }

        .auto-style5 {
            margin-left: 200px;
            margin-top: 50px;
        }

        .auto-style6 {
            margin-left: 320px;
            margin-top: 104px;
        }

        .auto-style8 {
            margin-left: 40px;
        }

        .auto-style9 {
            margin-left: 80px;
        }

        .auto-style11 {
            margin-left: 88px;
        }

        .auto-style12 {
            margin-left: 0px;
        }

        .auto-style14 {
            margin-left: 480px;
            margin-top: 50px;
        }

        .auto-style15 {
            margin-left: 252px;
        }
        .auto-style16 {
            margin-left: 639px;
            margin-top: 15px;
        }
        .auto-style17 {
            margin-left: 648px;
        }
        .auto-style18 {
            margin-left: 480px;
            margin-top: 22px;
        }
        .auto-style19 {
            margin-left: 480px;
            margin-top: 23px;
        }
        .auto-style20 {
            margin-left: 209px;
            font-weight: bold;
        }
    </style>
</head>
<body style="background-color: grey">
    <form id="form1" runat="server">
        <div>
            <p class="auto-style6">
                <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB BANK - Hoşgeldiniz Sn. "></asp:Label>
                <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
            </p>
        </div>
        <p class="auto-style1">
            <asp:Label ID="lblIban" runat="server" Text="TR270006701000000095963264 NUMARALI İBANA BAKİYENİZE EKLEMEK İSTEDİĞİNİZ TUTARI HAVALE/EFT YAPIP ONAYA GÖNDER BUTONUNA TIKLAYINIZ." Font-Bold="True"></asp:Label>
        </p>
        <p class="auto-style2">
            <asp:Label ID="lblUyari" runat="server" Text="EKLEMEK İSTEDİĞİNİZ TUTAR ADMİN TARAFINDAN KONTROL EDİLİP HESABINIZA AKTARILACAKTIR..." Font-Bold="True"></asp:Label>
        </p>
        <p class="auto-style20">
            AYNI GÜN İÇERİSİNDE TAMAMLANMAYAN İŞLEMLER ADMİN TARAFINDAN İPTAL EDİLECEKTİR, ANLAYIŞINIZ İÇİN TEŞEKKÜRLER...</p>
        <table class="auto-style14">
            <tr>
                <td class="auto-style8">EKLEMEK İSTEDİĞİNİZ BAKİYE</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtTutar" runat="server" Width="243px" CssClass="auto-style9" Style="margin-left: 79px" AutoCompleteType="Disabled" AutoPostBack="True" OnTextChanged="txtTutar_TextChanged"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="auto-style18">
            <tr>
                <td class="auto-style8">MASRAF</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtKazanc" runat="server" Width="243px" CssClass="auto-style15" Enabled="False" AutoCompleteType="Disabled">5</asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="auto-style19">
            <tr>
                <td class="auto-style8">HESABINIZA GEÇECEK TUTAR</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNet" runat="server" Width="243px" CssClass="auto-style11" Enabled="False" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="auto-style16">
            <asp:CheckBox ID="cB" runat="server" AutoPostBack="True" OnCheckedChanged="cB_CheckedChanged" Text="Yasal Sorumluluğu Kabul Ediyorum" />
        </div>
        <p class="auto-style17">
            <asp:Button ID="btnOnay" runat="server" CssClass="auto-style12" OnClick="btnOnay_Click" Text="ONAYA GÖNDER" Width="240px" Enabled="False" />
        </p>
    </form>
</body>
</html>
