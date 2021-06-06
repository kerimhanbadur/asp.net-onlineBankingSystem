<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="incomeCalculate.aspx.cs" Inherits="webTasarimProje.incomeCalculate" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register assembly="WebChart" namespace="WebChart" tagprefix="Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - MASTER ADMİN - KAZANÇ</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 440px;
        }
        .auto-style2 {
            margin-top: 34px;
        }
        .auto-style3 {
            margin-left: 285px;
        }
        .auto-style4 {
            margin-left: 0px;
            margin-top: 12px;
        }
        .auto-style5 {
            height: 37px;
            margin-left: 320px;
            margin-top: 0px;
        }
        .auto-style6 {
            margin-top: 0px;
        }
    </style>
</head>
<body style="background-color: black">
    <form id="form1" runat="server">
        <p style="margin-top:25px">
            <marquee scrolldelay="1" class="auto-style6">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - MASTER ADMİN PANEL - KAZANÇ"></asp:Label></marquee>
        </p>

        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 0px; color: green">
                <tr>
                    <th>İŞLEM TÜRÜ</th>
                    <th>TOPLAM İŞLEM ADEDİ</th>
                    <th>TOPLAM KAZANÇ</th>
                </tr>
                <tr>
                    <td>PARA TRANSFERİ</td>
                    <td>

                        <asp:Label ID="lblTransferCount" runat="server"></asp:Label>

                    </td>
                    <td>

                        <asp:Label ID="lblTransferIncome" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>BAKİYE EKLEME</td>
                    <td>

                        <asp:Label ID="lblBalanceCount" runat="server"></asp:Label>

                    </td>
                    <td>

                        <asp:Label ID="lblBalanceIncome" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>
        <div class="auto-style5">

            <asp:Label ID="Label2" runat="server" Font-Size="18pt" ForeColor="Green" Text="KART KULLANIM ÜCRETİ VE VERGİLER HARİÇ TOPLAM GELİR : "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Font-Size="18pt" ForeColor="Green"></asp:Label>

        </div>
        <div class="auto-style1">
            <Web:ChartControl ID="ChartControl1" runat="server" BorderStyle="Outset" BorderWidth="5px" Width="586px" CssClass="auto-style4" Height="273px"></Web:ChartControl>
        </div>
        <div class="auto-style3">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="KART KULLANIM ÜCRETLERİ VE VERGİLER DEĞİŞİKLİK GÖSTEREBİLECEĞİNDEN SADECE GRAFİKTE GÖSTERİLMİŞ OLUP TEMSİLİDİR."></asp:Label>
        </div>
    </form>
</body>
</html>

