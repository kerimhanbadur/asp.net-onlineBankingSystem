<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webTasarimProje.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABB BANK - İNTERNET BANKACILIĞI</title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 91px;
        }

        .dropbtn {
            background-color: black;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
        }

        .dropdown {
            margin-left: 1360px;
            position: relative;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: white;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }

                .dropdown-content a:hover {
                    background-color: #ddd;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }
    </style>
</head>
<body style="height: 522px; background-color: grey">
    <form id="form1" runat="server">
        <div class="dropdown">
            <button class="dropbtn">Yetkili</button>
            <div class="dropdown-content">
                <a href="adminLogIn.aspx">admin</a>
                <a href="superAdminLogIn.aspx">superAdmin</a>
            </div>
        </div>
        <div style="margin-left: 600px">
        </div>
        <p style="margin-left: 600px">
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <p style="margin-left: 640px">
            &nbsp;
        </p>
        <div style="margin-left: 600px">
        </div>
        <p style="margin-left: 680px">
            &nbsp;
        </p>
        <div style="margin-left: 680px">
        </div>
        <p style="margin-left: 520px" class="auto-style1">
            <asp:Label ID="lblBank" runat="server" Font-Bold="True" Font-Size="90px" Text="ABB BANK"></asp:Label>
        </p>
        <p style="margin-left: 680px">
            <asp:Button ID="btnGiris" runat="server" Text="GİRİŞ YAP" Width="124px" OnClick="btnGiris_Click" />
        </p>
        <div style="margin-left: 680px">
            <asp:Button ID="btnKayit" runat="server" Text="KAYIT OL" Width="124px" OnClick="btnKayit_Click" />
        </div>
    </form>
</body>
</html>
