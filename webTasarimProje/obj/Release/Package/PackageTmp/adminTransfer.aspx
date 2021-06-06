<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminTransfer.aspx.cs" Inherits="webTasarimProje.adminTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - ADMİN - TRANSFER DURUM</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background-color: black">
    <form id="form1" runat="server">
        <p>
            <marquee scrolldelay="1">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - ADMİN PANEL - TRANSFERLER"></asp:Label>
            </marquee>
        </p>

        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 23px; color: green">
                <tr>
                    <th>TRANSFER ID</th>
                    <th>NEREDEN</th>
                    <th>NEREYE</th>
                    <th>TUTAR</th>
                    <th>TARİH</th>
                    <th>BANKA KAZANCI</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("nereden") %></td>
                            <td><%# Eval("nereye") %></td>
                            <td><%# Eval("tutar") %></td>
                            <td><%# Eval("tarih") %></td>
                            <td><%# Eval("kazanc") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>


    </form>
</body>
</html>
