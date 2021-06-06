<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminApplyed.aspx.cs" Inherits="webTasarimProje.adminApplyed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="adminApplyedCss.css" rel="stylesheet" />
<head runat="server">
    <title>ABB BANK - ADMİN - BAŞVURU ONAY</title>
</head>
<body style="background-color: black">
    <form id="form1" runat="server">
        <p>
            <marquee scrolldelay="1">
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - ADMİN PANEL - BAŞVURU"></asp:Label></marquee>
        </p>

        <div class="auto-style2">
            <table class="table table-bordered" style="height: 168px; margin-top: 23px; color: green">
                <tr>
                    <th>BAŞVURU ID</th>
                    <th>BAŞVURULAN HESAP NO</th>
                    <th>ÇALIŞMA DURUMU</th>
                    <th>GELİR BİLGİSİ</th>
                    <th>DURUM</th>
                    <th>KART LİMİT</th>
                    <th>İŞLEM</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("hesapNo") %></td>
                            <td><%# Eval("calismaDurumu") %></td>
                            <td><%# Eval("gelirBilgisi") %></td>
                            <td><%# Eval("basvuruDurumu") %></td>
                            <td>
                                <asp:TextBox ID="TextBox1" CssClass="adminApplyedCss" runat="server" Enabled="false" Text='<%# (int)Eval("gelirBilgisi") / 2 %>' Width="75px"></asp:TextBox></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id") %>' CommandName="Onayla" runat="server" ForeColor="White">Onayla</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" CommandArgument='<%# Eval("id") %>' CommandName="Onaylama" runat="server" ForeColor="White">Onaylama</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("id") %>' CommandName="İptal Et" runat="server" ForeColor="White">İptal</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
