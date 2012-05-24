<%@ page language="C#" autoeventwireup="true" inherits="apiaudit, App_Web_1sqrhzug" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register src="sidebar.ascx" tagname="sidebar" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="ft" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API申请审核</title>
<!-- CSS -->
<link href="style/css/transdmin.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie6.css" /><![endif]-->
<!--[if IE 7]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie7.css" /><![endif]-->
<style type="text/css">
    #logbg{ position:fixed; width:100%; height:100%; filter:alpha(opacity=60); opacity:0.6; background:#fff; top:0; left:0; display:none;}
    #loginbox{ width:400px; height:240px; border:5px solid #bbb; position:fixed; top:50%; left:50%; margin-top:-140px; margin-left:-200px; background:#fff; display:none;}
    #loginbox ul{ margin:60px auto; width:250px;}
    #loginbox li{ height:34px; line-height:34px;}
    #loginbox li .txtinp{ width:180px; border:1px solid #aaa;}
    #loginbox span{ display:inline-block; text-align:left; width:60px;}
    th{ height:24px; line-height:24px; text-align:center; border-bottom:1px solid #ddd; border-right:1px solid #ddd;}
    #gv{ margin-bottom:20px;}
    #main #gv td{ padding:0 5px 0 0;}
    #gv td table{width:auto;}
    #gv td table td{ width:15px;}
</style>
<!-- JavaScripts-->
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
<script type="text/javascript" src="style/js/jNice.js"></script>
</head>
<body>
    <skm:form id="form1" runat="server" method="post">
    <asp:HiddenField runat="server" ID="hidisloged" Value="" />
	<div id="wrapper">
    	<!-- h1 tag stays for the logo, you can use the a tag for linking the index page -->
    	<h1><a href="#"><span>Bus.Fm</span></a></h1>
        
        <!-- You can name the links with lowercase, they will be transformed to uppercase by CSS, we prefered to name them with uppercase to have the same effect with disabled stylesheet -->
        <ul id="mainNav">
        	<li><a href="#" class="active">巴士电台API</a></li> <!-- Use the "active" class for the active menu item  -->
        	<%--<li><a href="#">ADMINISTRATION</a></li>
        	<li><a href="#">DESIGN</a></li>
        	<li><a href="#">OPTION</a></li>--%>
        	<li class="logout">
            <asp:LinkButton ID="logout" runat="server" Text="LOGOUT" OnClick="logoutclick"></asp:LinkButton>
            <a href="javascript:void(0);" id="login" runat="server">LOGIN</a></li>
        </ul>
        <!-- // #end mainNav -->
        
        <div id="containerHolder">
			<div id="container">
    <uc1:sidebar ID="sidebar1" runat="server" index="4" />
                
                <!-- h2 stays for breadcrumbs -->
                <h2><a href="#">Dashboard</a> &raquo; <a href="#" class="active">管理</a></h2>
                
                <div id="main">
                <h3>申请列表</h3>
                <p>
                    <asp:CheckBox ID="cbxshowdeny" Text="包含审核未通过的" runat="server" AutoPostBack="true" OnCheckedChanged="cbxchange" />
                    <asp:CheckBox ID="cbxshowpass" Text="包含审核通过的" runat="server" AutoPostBack="true" OnCheckedChanged="cbxchange" />
                </p><br />
                <asp:Label runat="server" ID="lblmsg" ForeColor="Red"></asp:Label>
                        <asp:GridView runat="server" ID="gv" AllowPaging="true" PageSize="20" AllowSorting="true" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="databind">
                        <AlternatingRowStyle CssClass="odd" />
                            <Columns>
                                <%--<asp:BoundField HeaderText="key" HeaderStyle-Width="140px" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Left" DataField="app_key" />--%>
                                <asp:BoundField HeaderText="申请时间" HeaderStyle-Width="110px" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Left" DataField="app_applytime" />
                                <asp:BoundField HeaderText="申请人" HeaderStyle-Width="130px" ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Left" DataField="app_owner" />
                                <asp:BoundField HeaderText="网址" HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left" DataField="app_url" />
                                <asp:BoundField HeaderText="描述" HeaderStyle-Width="140px" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Left" DataField="app_usage" />
                                <asp:TemplateField HeaderText="状态" HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <%# parseStatus(Eval("app_status").ToString()) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="85px" ItemStyle-Width="85px" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnpass" runat="server" OnCommand="passthis" CommandArgument='<%# Eval("app_key") %>' CssClass="view" Visible='<%# Eval("app_status").ToString()!="1" %>'>pass</asp:LinkButton>
                                        <asp:LinkButton ID="lbtndeny" runat="server" OnCommand="denythis" CommandArgument='<%# Eval("app_key") %>' CssClass="edit" Visible='<%# Eval("app_status").ToString()=="1" %>'>deny</asp:LinkButton>
                                        <asp:LinkButton ID="lbtndelete" runat="server" OnCommand="delthis" CommandArgument='<%# Eval("app_key") %>' CssClass="delete">delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="GetList" TypeName="Bus.DAL.appkey">
                            <SelectParameters>
                                <asp:Parameter Name="strWhere" DefaultValue="" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </div>
                <!-- // #main -->
                
                <div class="clear"></div>
            </div>
            <!-- // #container -->
        </div>	
        <!-- // #containerHolder -->
        
    <uc1:ft ID="footer" runat="server" />
    </div>
    <div id="logbg">&nbsp;</div>
    <div id="loginbox">
        <ul>
            <li><span>用户名：</span><asp:TextBox ID="txtuname" runat="server" MaxLength="20" CssClass="txtinp"></asp:TextBox></li>
            <li><span>密码：</span><asp:TextBox ID="txtpwd" runat="server" MaxLength="20" CssClass="txtinp" TextMode="Password"></asp:TextBox></li>
            <li><asp:Button runat="server" ID="btnlogin" OnClick="loginclick" Text="登录" />
                <%--<input type="button" value="取消" onclick="closebox();" />--%>
            </li>
        </ul>
    </div>
    <!-- // #wrapper -->
    </skm:form>
</body>
<script type="text/javascript">
    $(function () {
        $("#login").click(function () { openbox(); });
        if ($("#hidisloged").val() == "0") openbox();
    });
    function openbox() {
        $("#logbg").show();
        $("#loginbox").show();
    }
    function closebox() {
        $("#logbg").hide();
        $("#loginbox").hide();
    }
</script>
</html>
