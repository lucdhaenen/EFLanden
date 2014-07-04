<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LINQ_LandenStedenTalen_MySql.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="landenListBox" runat="server" Height="130px" AutoPostBack="true" Width="125px" OnSelectedIndexChanged="landenListBox_SelectedIndexChanged1"></asp:ListBox>
        <br />
        <br />
        <asp:ListBox ID="stedenListBox" runat="server" Height="139px" Width="255px"></asp:ListBox>
        <br />
        <br />
        <asp:ListBox ID="talenListBox" runat="server" Height="395px" Width="262px"></asp:ListBox>
        <br />
        <br />
        <asp:TextBox ID="stadTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="Verplicht stad in te vullen" ControlToValidate="stadTextBox"></asp:RequiredFieldValidator>
        <asp:Button ID="ToevoegenButton" runat="server" Text="Stad toevoegen" OnClick="ToevoegenButton_Click" />
    </div>
    </form>
</body>
</html>
