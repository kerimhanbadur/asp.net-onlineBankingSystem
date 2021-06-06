<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminCoin.aspx.cs" Inherits="webTasarimProje.adminCoin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
<head runat="server">
    <title>ABB BANK - ADMİN - COIN</title>
</head>
<body style="background-color:black">
    <form id="form1" runat="server">
        <p>
            <marquee scrolldelay="1">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - ADMİN PANEL - COIN"></asp:Label>
            </marquee>
        </p>
        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 23px; color: green">
                <tr>
                    <th>COIN ID</th>
                    <th>COIN ADI</th>
                    <th>COIN FIYAT</th>
                    <th>İŞLEM</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("coinAdi") %></td>
                            <td><%# Eval("coinFiyati") %></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" CommandArgument='<%# Eval("id") %>' CommandName="Sil">Sil</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>

                    </td>
                    <td>
                        <asp:TextBox ID="txtCoinAdi" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoinFiyati" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="white" OnClick="LinkButton3_Click">Ekle</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
