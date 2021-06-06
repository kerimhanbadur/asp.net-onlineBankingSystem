<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminAddBalance.aspx.cs" Inherits="webTasarimProje.adminBakiye" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<head runat="server">
    <title>ABB BANK - ADMİN - BAKİYE ONAY</title>
</head>
<body style="background-color: black">
    <form id="form1" runat="server">
        <p>
            <marquee scrolldelay="1">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - ADMİN PANEL - BAKİYE EKLE"></asp:Label></marquee>
        </p>

        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 23px; color: green">
                <tr>
                    <th>BAKİYE EKLEME ID</th>
                    <th>EKLENECEK HESAP</th>
                    <th>TUTAR</th>
                    <th>BANKA KAZANCI</th>
                    <th>İŞLEM</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("hesapNo") %></td>
                            <td><%# Eval("tutar") %></td>
                            <td><%# Eval("kazanc") %></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id") %>' CommandName="Onayla" runat="server" ForeColor="White">Onayla</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("id") %>' CommandName="İptal Et" runat="server" ForeColor="White">İptal Et</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
