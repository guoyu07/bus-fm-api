<%@ page language="C#" autoeventwireup="true" inherits="test, App_Web_12nix3eg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView runat="server" ID="gv" AllowPaging="true" PageSize="10"></asp:GridView>
        <br />
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <asp:Button ID="btn1" runat="server" onclick="Button1_Click" Text="添加用户" />
    <asp:Button ID="btn2" runat="server" onclick="Button2_Click" Text="发送邮件" />
    <asp:Button ID="btnlogin" runat="server" onclick="btnlogin_Click" Text="登录" />
    <asp:Button ID="btnchangepwd" runat="server" onclick="btnchangepwd_Click" 
        Text="修改密码" />
    <asp:Button ID="btnresetpwd" runat="server" Text="重设密码" 
        onclick="btnresetpwd_Click" />
    <asp:Button ID="btn_getlistbychannel" runat="server" 
        onclick="btn_getlistbychannel_Click" Text="频道" />
    <asp:Button ID="btn_getlistbyid" runat="server" onclick="btn_getlistbyid_Click" 
        Text="收藏列表" />
    <asp:Button ID="btn_isfave" runat="server" onclick="btn_isfave_Click" 
        Text="是否收藏" />
    <asp:Button ID="btn_favorcancel" runat="server" onclick="btn_favorcancel_Click" 
        Text="收藏/取消" />
    <asp:TextBox runat="server" ID="txtformdt" Width="80"></asp:TextBox> <asp:Button ID="Button9" runat="server" Text="MD5" OnClick="getmd5" />
    <asp:Button ID="Button11" runat="server" Text="APPKey" 
        onclick="Button11_Click" />
    <asp:Button ID="Button10" runat="server" Text="updatekey" onclick="Button10_Click" />
    <asp:Button ID="channelid" runat="server" Text="channelid" 
        onclick="channelid_Click" />
    <asp:Button ID="visit" runat="server" Text="visit" onclick="visit_Click" />
    <asp:Button ID="Button3" runat="server" Text="createtable" 
        onclick="Button3_Click" />
        <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
        Text="神曲" />
        <a href="url.aspx" target="_blank">url</a>
        <a href="/pt/getchannellist" target="_blank">url2</a>
        <asp:Button runat="server" ID="btna" OnClick="btnaclick" Text="申请key后发短信" />
    <br />
    <asp:TextBox ID="txtresult" runat="server" Columns="100" Rows="20" 
        TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>
