<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="webTasarimProje.transfer" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>ABB BANK - PARA TRANSFERİ</title>
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
                padding-right: 225px;;
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
    
        .auto-style3 {
            height: 68px;
            margin-left: 332px;
            margin-top: 70px;
            width: 957px;
        }

        .auto-style1 {
            width: 97%;
            height: 246px;
            margin-left: 41px;
            margin-top: 50px;
        }

        .auto-style5 {
            height: 70px;
            margin-left: 40px;
        }

        .auto-style6 {
            margin-left: 80px;
        }
        .auto-style7 {
            margin-left: 1080px;
        }
        .auto-style8 {
            height: 70px;
            margin-left: 280px;
        }

        .auto-style9 {
            margin-left: 280px;
        }

        </style>
</head>
<body style="background-color: grey">

    <form id="form1" runat="server">

    <div class="topnav">
        <a href="loggedIn.aspx" target="_blank">HESAP</a>
        <a class="active" href="transfer.aspx" target="_blank">TRANSFER</a>
        <a href="apply.aspx" target="_blank">KART BAŞVURU</a>
        <a href="coin.aspx" target="_blank">ABB BANK COİN BORSASI</a>
    </div>


        <p class="auto-style3">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB BANK - Hoşgeldiniz Sn. "></asp:Label>
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
        </p>
        <table class="auto-style1">
            <tr>
                <td style="margin-left: 120px">KULLANILABİLİR BAKİYE</td>
                <td>
                    <asp:TextBox ID="txtBakiye" runat="server" Width="243px" Enabled="False" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:LinkButton ID="lbBakiye" runat="server" OnClick="lbBakiye_Click" ForeColor="Black">Hesabıma Bakiye Eklemek İstiyorum</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">TRANSFER YAPILACAK HESAP NO</td>
                <td>
                    <asp:TextBox ID="txtHesapNo" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblHesapUyari" runat="server" Font-Size="12pt" Text="Girilen Hesap No Geçerli Değil" Visible="False" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">GÖNDERİLECEK TUTAR</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtTutar" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblBakiyeUyari" runat="server" Font-Size="12pt" Text="Gönderilecek Tutar Bakiyenizden Fazla Olamaz" Visible="False" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">TRANSFER ÜCRETİ</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtUcret" runat="server" Width="243px" Enabled="False" AutoCompleteType="Disabled">5</asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Font-Size="12pt" Text="Bu Tutar Bankamız Vergi Politikasınca Belirlenmiş Olan İşlem Ücretidir. Bu Tutar, Gönderilecek Olan Tutardan Düşülecektir." Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <p class="auto-style9">
            <asp:Button ID="Button1" runat="server" Height="42px" Text="GÖNDER" Width="964px" OnClick="Button1_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p class="auto-style7">
            &nbsp;</p>
        </form>
</body>
</html>


