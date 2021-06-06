<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coin.aspx.cs" Inherits="webTasarimProje.coin" %>


<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>ABB BANK - COIN BORSA</title>
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
            margin-left: 317px;
            margin-top: 8px;
        }

        .auto-style2 {
            margin-left: 379px;
        }

        .auto-style3 {
            margin-left: 173px;
        }

        </style>
</head>
<body style="background-color: grey">

    <div class="topnav">
        <a href="loggedIn.aspx" target="_blank">HESAP</a>
        <a href="transfer.aspx" target="_blank">TRANSFER</a>
        <a href="apply.aspx" target="_blank">KART BAŞVURU</a>
        <a class="active" href="coin.aspx" target="_blank">ABB BANK COİN BORSASI</a>
    </div>

    <form runat="server">
        <p class="auto-style1" style="color: black; margin-top:50px;">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB
                BANK - Hoşgeldiniz Sn. "></asp:Label>
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
        </p>
        <p class="auto-style3" style="margin-top:25px;">
            <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="COIN ALIM/SATIM İŞLEMLERİNE BTC VE ALT COIN PİYASALARINDAKİ DALGALANMALAR NEDENİYLE GEÇİCİ BİR SÜRELİĞİNE ARA VERİLMİŞTİR." Font-Bold="True" Font-Size="12pt"></asp:Label>
        </p>
        <p class="auto-style2" style="margin-top:25px;">
            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="AŞAĞIDAKİ TABLODAN MEVCUT COINLERİMİZİN GÜNCEL FİYATLARINA GÖZ ATABİLİRSİN..." Font-Bold="True" Font-Size="12pt"></asp:Label>
        </p>
        <div style="margin-top:50px">
            <table class="table table-bordered" style="height: 168px;">
                <tr>
                    <th>Coin ID</th>
                    <th>Coin Adı</th>
                    <th>Coin Birim Fiyatı</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("coinAdi") %></td>
                            <td><%# Eval("coinFiyati") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>

