<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="Laboras1.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Data" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <asp:Table ID="DataTable" runat="server" Height="300px" Width="350px" BackColor="#999999" CellPadding="30" GridLines="Both" BorderColor="Black" BorderWidth="2px">
            </asp:Table>
            <br />
            <asp:Label ID="ResultsLabel" runat="server" Text="Rezultatas"></asp:Label>
            <br />
            <asp:Table ID="ResultsTable" runat="server" Height="300px" Width="350px" BackColor="#999999" CellPadding="30" GridLines="Both" BorderColor="Black" BorderWidth="2px">
            </asp:Table>
            <br />
            <asp:Button ID="Results" runat="server" OnClick="Results_Click" Text="Gauti rezultatą" />
        </div>
    </form>
</body>
</html>
