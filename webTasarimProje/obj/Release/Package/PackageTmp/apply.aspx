<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apply.aspx.cs" Inherits="webTasarimProje.apply" %>

<!DOCTYPE html>
<html>
<head>
    <title>ABB BANK - BAŞVURU</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
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

        .auto-style1 {
            width: 49%;
            height: 246px;
            margin-left: 470px;
            margin-top: 82px;
        }

        .auto-style6 {
            margin-left: 80px;
            height: 120px;
            width: 186px;
        }

        .auto-style8 {
            height: 70px;
            margin-left: 280px;
            width: 186px;
        }

        .auto-style5 {
            height: 70px;
            margin-left: 40px;
        }
        .auto-style9 {
            margin-left: 313px;
            width: 1017px;
            margin-top: 89px;
        }
        .auto-style10 {
            margin-left: 511px;
            width: 871px;
            margin-top: 40px;
        }
        .auto-style11 {
            height: 120px;
        }
        .auto-style12 {
            width: 186px;
        }
    </style>
</head>
<body style="background-color: grey">

    <form id="form1" runat="server">

        <div class="topnav">
            <a href="loggedIn.aspx" target="_blank">HESAP</a>
            <a href="transfer.aspx" target="_blank">TRANSFER</a>
            <a class="active" href="apply.aspx" target="_blank">KART BAŞVURU</a>
            <a href="coin.aspx" target="_blank">ABB BANK COİN BORSASI</a>
        </div>

        <p class="auto-style9">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB BANK - Hoşgeldiniz Sn. "></asp:Label>
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
        </p>

        <table class="auto-style1">
            <tr>
                <td style="margin-left: 120px" class="auto-style12">HESAP NO</td>
                <td>
                    <asp:TextBox ID="txtHesapNo" runat="server" Width="243px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">ÇALIŞMA DURUMU</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="ddCalisma" runat="server" Width="243px">
                        <asp:ListItem>Emekli</asp:ListItem>
                        <asp:ListItem>Memur</asp:ListItem>
                        <asp:ListItem>İşçi</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="cB" runat="server" OnCheckedChanged="cB_CheckedChanged" AutoPostBack="true" Text="Farklı Çalışma Durumu" />
                    <asp:TextBox ID="txtCalisma" runat="server" Width="243px" Visible="False" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">GELİR BİLGİSİ</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtGelir" runat="server" Width="243px" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p class="auto-style10">
            <asp:Button ID="Button1" runat="server" Text="BAŞVUR" Height="42px" Width="429px" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
