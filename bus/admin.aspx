<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnllog" runat="server">
        <asp:TextBox ID="txtuid" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnsub" runat="server" Text="submit" OnClick="validate" CausesValidation="false" />
    </asp:Panel>
    <asp:Panel ID="pnlconf" runat="server" Visible="false">
        <asp:Button ID="btnencode" runat="server" Text="encrypt" OnClick="encode" CausesValidation="false" />
        <asp:Button ID="btndecode" runat="server" Text="decrypt" OnClick="decode" CausesValidation="false" />
        <br />
        <asp:DropDownList runat="server" ID="ddltype">
            <asp:ListItem Value="error/er_">Error</asp:ListItem>
            <asp:ListItem Value="warnning/wa_">Warn</asp:ListItem>
            <asp:ListItem Value="debug/db_">Debug</asp:ListItem>
            <asp:ListItem Value="trace/tc_">Trace</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="txtmonth" MaxLength="6" Width="80"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="regtss" Text="must have a date" Display="Dynamic" ControlToValidate="txtmonth"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ID="regts" Text="Format:yyyymm" ControlToValidate="txtmonth" Display="Dynamic" ValidationExpression="^20[1,2]\d\d\d$"></asp:RegularExpressionValidator>
        <asp:Button ID="btnlog" runat="server" Text="log" OnClick="getlog" />
        <p><asp:Label runat="server" ID="lblmsg" ForeColor="Red"></asp:Label></p>
        <p><asp:Label runat="server" ID="lbllog"></asp:Label></p>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
