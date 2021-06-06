<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminAccInfo.aspx.cs" Inherits="webTasarimProje.adminAccInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<head runat="server">
    <title>ABB BANK - MASTER ADMİN - ADMİN İŞLEMLERİ</title>
</head>
<body style="background-color: black">
    <form id="form1" runat="server">
        <p>
            <marquee scrolldelay="1">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - MASTER ADMİN PANEL - ADMİN İŞLEMLERİ"></asp:Label></marquee>
        </p>

        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 23px; color: green">
                <tr>
                    <th>ADMİN ID</th>
                    <th>ADMİN KULLANICI ADI</th>
                    <th>ADMİN ŞİFRE</th>
                    <th>KULLANILACAK CİHAZ MAC ADRESİ</th>
                    <th>İŞLEM</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("kullaniciAdi") %></td>
                            <td><%# Eval("sifre") %></td>
                            <td><%# Eval("macAdresi") %></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id") %>' CommandName="Sil" runat="server" ForeColor="White">Sil</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>

                    </td>
                    <td>
                        <asp:TextBox ID="txtKullaniciAdi" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSifre" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMacAdresi" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="White" OnClick="LinkButton2_Click">Ekle</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>