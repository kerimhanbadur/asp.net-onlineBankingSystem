<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loggedIn.aspx.cs" Inherits="webTasarimProje.loggedIn" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>ABB BANK - HOŞGELDİNİZ</title>
    <style>
        body {
            margin: 0;
            font-family: Arial, Helvetica, sans-serif;
        }

        .topnav {
            overflow: hidden;
            background-color: #333;
        }

            .topnav a {
                float: left;
                color: #f2f2f2;
                text-align: center;
                padding: 30px;
                padding-right: 225px;
                text-decoration: none;
                font-size: 17px;
            }

                .topnav a:hover {
                    background-color: #ddd;
                    color: black;
                }

                .topnav a.active {
                    background-color: #04AA6D;
                    color: white;
                }

        .auto-style1 {
            width: 67%;
            height: 354px;
            margin-left: 440px;
            margin-top: 19px;
        }

        .auto-style2 {
            height: 51px;
        }

        .auto-style3 {
            height: 68px;
            margin-left: 255px;
            margin-top: 62px;
        }

        .auto-style4 {
            margin-left: 245px;
        }

        .auto-style5 {
            margin-left: 600px;
        }
        .auto-style6 {
            margin-left: 1424px;
            margin-top: 23px;
        }
    </style>
</head>
<body style="background-color: grey">
    <form id="form1" runat="server">
        <div class="topnav">
            <a class="active" href="#home">HESAP</a>
            <a href="transfer.aspx" target="_blank">TRANSFER</a>
            <a href="apply.aspx" target="_blank">KART BAŞVURU</a>
            <a href="coin.aspx" target="_blank">ABB BANK COİN BORSASI</a>
        </div>
        <p class="auto-style3">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB BANK - Hoşgeldiniz Sn. "></asp:Label>
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
        </p>
        <table class="auto-style1">
            <tr>
                <td style="margin-left: 120px">TC KİMLİK NO</td>
                <td>
                    <asp:TextBox ID="txtKimlik" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>HESAP NO</td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 160px">AD</td>
                <td>
                    <asp:TextBox ID="txtAd" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">SOYAD</td>
                <td>
                    <asp:TextBox ID="txtSoyad" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>E-POSTA</td>
                <td style="margin-left: 120px">
                    <asp:TextBox ID="txtPosta" runat="server" Width="243px" TextMode="Email" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">ŞİFRE</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtSifre" runat="server" Width="243px" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox><input type="checkbox" onchange="document.getElementById('txtSifre').type = this.checked ? 'text' : 'password'" />Şifremi Göster
                </td>
            </tr>
        </table>
        <div class="auto-style4">
            <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Underline="True" Text="İnternet Bankacılığından Yalnızca Şifre Güncelleme İşlemi Yapılmaktadır, Kişisel Bilgilerinizi Güncellemek İçin Müşteri Hizmetlerini Arayınız."></asp:Label>
        </div>
        <p class="auto-style5">
            <asp:Button ID="btnGuncelle" runat="server" Height="42px" Text="GÜNCELLE" Width="195px" OnClick="btnGuncelle_Click" />
        </p>
        <div class="auto-style6">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Güvenli Çıkış" />
        </div>
    </form>
</body>
</html>
