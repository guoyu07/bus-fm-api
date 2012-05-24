<%@ page language="C#" autoeventwireup="true" inherits="api_Default, App_Web_1sqrhzug" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register src="sidebar.ascx" tagname="sidebar" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="ft" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API概述</title>
<!-- CSS -->
<link href="style/css/transdmin.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie6.css" /><![endif]-->
<!--[if IE 7]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie7.css" /><![endif]-->
<style type="text/css">
#main p{ text-indent:2em; margin-bottom:20px; line-height:1.5;}
</style>
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
    <uc1:sidebar ID="sidebar1" runat="server" index="1" />
                
                <!-- h2 stays for breadcrumbs -->
                <h2><a href="#">Dashboard</a> &raquo; <a href="#" class="active">API概述</a></h2>
                
                <div id="main">
					<h3>关于巴士电台开放接口的说明</h3>
                    <p>
                        巴士电台是一个非商业站点，也没有足够的资金来提供足够强大的开放接口服务，所以很抱歉我们暂时不能提供无限制的电台曲库数据开放接口服务，我们有限的带宽和服务器资源目前只能优先保证试听的需要，以后会怎么样，我们也只能静静地观察。
                    </p>
                    <p>
                        同时，我们仍然有开放这个接口的必要，假如您有足够的热情和技术，能为巴士电台制作任何应用，比如桌面客户端(C++,AIR,Python，C#等)，手机客户端（iOS, Android等），或者各大网站开放应用平台的应用，我们相当欢迎，并且非常感谢，您只需要在<a href="/apply">这里</a>提交申请，我们会与您取得联系。
                    </p>
                    <p style="text-align:right;"><br />巴士电台<br /><br />2011/3/26</p>
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
