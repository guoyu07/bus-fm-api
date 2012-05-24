<%@ page language="C#" autoeventwireup="true" inherits="apply, App_Web_1sqrhzug" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register src="sidebar.ascx" tagname="sidebar" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="ft" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API申请</title>
<!-- CSS -->
<link href="style/css/transdmin.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie6.css" /><![endif]-->
<!--[if IE 7]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie7.css" /><![endif]-->

<!-- JavaScripts-->
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
<script type="text/javascript" src="style/js/jNice.js"></script>
</head>
<body>
    <skm:form id="form1" runat="server" method="post">

	<div id="wrapper">
    	<!-- h1 tag stays for the logo, you can use the a tag for linking the index page -->
    	<h1><a href="#"><span>Bus.Fm</span></a></h1>
        
        <!-- You can name the links with lowercase, they will be transformed to uppercase by CSS, we prefered to name them with uppercase to have the same effect with disabled stylesheet -->
        <ul id="mainNav">
        	<li><a href="#" class="active">巴士电台API</a></li> <!-- Use the "active" class for the active menu item  -->
        	<%--<li><a href="#">ADMINISTRATION</a></li>
        	<li><a href="#">DESIGN</a></li>
        	<li><a href="#">OPTION</a></li>--%>
        	<%--<li class="logout"><a href="#">LOGOUT</a></li>--%>
        </ul>
        <!-- // #end mainNav -->
        
        <div id="containerHolder">
			<div id="container">
    <uc1:sidebar ID="sidebar1" runat="server" index="3" />
                
                <!-- h2 stays for breadcrumbs -->
                <h2><a href="#">Dashboard</a> &raquo; <a href="#" class="active">API申请</a></h2>
                
                <div id="main">
					<h3>请填写如下资料</h3>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    	<fieldset id="fd" runat="server">
                        	<p><label>申请人邮箱：</label><asp:TextBox runat="server" ID="txtemail" MaxLength="50" CssClass="text-long"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valicon1" runat="server" ControlToValidate="txtemail" Text="请填写邮箱" Display="Dynamic" CssClass="warnspan"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="valicon2" runat="server" ControlToValidate="txtemail" Text="邮箱格式不正确" Display="Dynamic" CssClass="warnspan" ValidationExpression="^\w+[\.\+]?\w+@\w+\.\w+$"></asp:RegularExpressionValidator>
                            </p>
                        	<p><label>应用网址：</label><asp:TextBox runat="server" ID="txturl" MaxLength="50" CssClass="text-long">http://</asp:TextBox></p>
                        	<p><label>应用描述：</label><asp:TextBox runat="server" ID="txtdesc" MaxLength="50" TextMode="MultiLine"></asp:TextBox></p>
                            <asp:Button runat="server" ID="btnsubmit" OnClick="applykey" Text="提交" />
                            <input type="reset" value="清空" onclick="$('.warnspan').hide();" />
                        </fieldset>
                </div>
                <!-- // #main -->
                
                <div class="clear"></div>
            </div>
            <!-- // #container -->
        </div>	
        <!-- // #containerHolder -->
        
    <uc1:ft ID="footer" runat="server" />
    </div>
    <!-- // #wrapper -->
    </skm:form>
</body>
</html>
