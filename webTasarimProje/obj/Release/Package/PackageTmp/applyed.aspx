<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applyed.aspx.cs" Inherits="webTasarimProje.applyed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - BAŞVURULARIM</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
            margin-left: 316px;
        }

        .auto-style2 {
            margin-left: 640px;
        }

        .auto-style4 {
            height: 24px;
        }
        .auto-style5 {
            margin-left: 436px;
            margin-top: 31px;
        }
    </style>
</head>
<body style="background-color: grey; margin-top: 85;">
    <form id="form1" runat="server">
        <p class="auto-style1" style="color: black">
            <asp:Label ID="lblBankKayit" runat="server" Font-Bold="True" Font-Size="30pt" Text="ABB BANK - Hoşgeldiniz Sn. "></asp:Label>
            <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
        </p>
        <div style="margin-top: 15px">
            <table class="table table-bordered" style="margin-top: 140px">
                <tr>
                    <th>BAŞVURU NO</th>
                    <th>HESAP NO</th>
                    <th>ÇALIŞMA DURUMU</th>
                    <th>GELİR BİLGİSİ</th>
                    <th>BAŞVURU DURUMU</th>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblBasvuruNo" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblHesapNo" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblCalisma" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblGelir" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblSonuc" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="auto-style2" style="margin-top:50px">
            <asp:Button ID="btnIptal" runat="server" Text="İPTAL ET" Width="150px" CssClass="col-xs-offset-0" OnClick="btnIptal_Click"/>
        </div>
        <asp:Panel ID="kartBilgileri" runat="server" Visible="false">
            <table class="table table-bordered" style="margin-top: 50px">
                <tr>
                    <th>HESAP NO</th>
                    <th>KART NO</th>
                    <th>SON KULLANMA TARİHİ (AY)</th>
                    <th>SON KULLANMA TARİHİ (YIL)</th>
                    <th>CVV</th>
                    <th>LİMİT</th>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblBagliHesap" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblKartNo" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblSkAy" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblSkYil" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblCvv" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblBakiye" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div class="auto-style5">
            <asp:Label ID="lblKartUyari" runat="server" Font-Bold="True" Text="KREDİ KARTINIZI İPTAL ETMEK İSTİYORSANIZ LÜTFEN MÜŞTERİ HİZMETLERİNİ ARAYIN." Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
