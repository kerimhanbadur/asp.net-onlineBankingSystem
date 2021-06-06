<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="superAdminLoggedIn.aspx.cs" Inherits="webTasarimProje.superAdminLoggedIn" %>

<!DOCTYPE html>
<html>
<head>
    <title>ABB BANK - MASTER ADMİN - HOŞGELDİNİZ</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="style.css">
    <style type="text/css">
        .auto-style2 {
            margin-left: 1409px;
            margin-top: 216px;
        }
        .auto-style3 {
            margin-left: 0;
        }
    </style>
</head>
<body style="background-color: black">

    <!-- Sidebar -->
    <div class="w3-sidebar w3-bar-block w3-border-right" style="display: none" id="mySidebar">
        <button onclick="w3_close()" class="w3-bar-item w3-large">Close &times;</button>
        <a href="adminAccInfo.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-top: 25px; margin-bottom: 25px;">Admin Görüntüle</a>
        <a href="incomeCalculate.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-bottom: 25px;">Banka Kazanç Bilgisi</a>
    </div>

    <!-- Page Content -->
    <div class="w3-teal">
        <button class="w3-button w3-teal w3-xlarge" onclick="w3_open()">☰ MASTER ADMİN MENÜ</button>
    </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <p>
        <marquee scrolldelay="1">
            <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - MASTER ADMİN PANEL - İYİ ÇALIŞMALAR"></asp:Label></marquee>
    </p>
    <script>
        function w3_open() {
            document.getElementById("mySidebar").style.display = "block";
        }

        function w3_close() {
            document.getElementById("mySidebar").style.display = "none";
        }
    </script>
    <form runat="server">
        <div class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Güvenli Çıkış" OnClick="Button1_Click" CssClass="auto-style3" />
        </div>
    </form>
</body>
</html>
