<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLoggedIn.aspx.cs" Inherits="webTasarimProje.adminLoggedIn" %>

<!DOCTYPE html>
<html>
<head>
<title>ABB BANK - ADMİN - HOŞGELDİNİZ</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="style.css">
    <style type="text/css">
        .auto-style1 {
            margin-left: 1414px;
            margin-top: 217px;
        }
    </style>
</head>
<body style="background-color: black">
    <!-- Sidebar -->
    <div class="w3-sidebar w3-bar-block w3-border-right" style="display: none" id="mySidebar">
        <button onclick="w3_close()" class="w3-bar-item w3-large">Close &times;</button>
        <a href="adminTransfer.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-top: 25px; margin-bottom: 25px;">Transferleri Görüntüle</a>
        <a href="adminAddBalance.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-bottom: 25px;">Bakiye Ekle</a>
        <a href="adminApplyed.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-bottom: 25px;">Başvuru Görüntüle</a>
        <a href="adminCoin.aspx" target="_blank" class="w3-bar-item w3-button" style="margin-bottom: 25px;">Coin İşlemleri</a>
    </div>

    <!-- Page Content -->
    <div class="w3-teal">
        <button class="w3-button w3-teal w3-xlarge" onclick="w3_open()">☰ ADMİN MENÜ</button>
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
        <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="50pt" ForeColor="Green" Text="ABB BANK - ADMİN PANEL - İYİ ÇALIŞMALAR"></asp:Label></marquee>
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
        <div class="auto-style1">
            <asp:Button ID="Button1" runat="server" Text="Güvenli Çıkış" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
