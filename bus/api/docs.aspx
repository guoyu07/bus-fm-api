<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docs.aspx.cs" Inherits="docs" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register src="sidebar.ascx" tagname="sidebar" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="ft" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>API开发文档</title>
<!-- CSS -->
<link href="style/css/transdmin.css" rel="stylesheet" type="text/css" media="screen" />
<!--[if IE 6]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie6.css" /><![endif]-->
<!--[if IE 7]><link rel="stylesheet" type="text/css" media="screen" href="style/css/ie7.css" /><![endif]-->
<style type="text/css">
    .changelog{ border-top:1px dashed #666; padding-top:10px;}
    #main li{ line-height:24px;}
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
    <uc1:sidebar ID="sidebar1" runat="server" index="2" />
                
                <!-- h2 stays for breadcrumbs -->
                <h2><a href="#">Dashboard</a> &raquo; <a href="#" class="active">API文档</a></h2>
                <div id="main">
                    <fieldset>
					<h3>Documentation:</h3>
                    <ul>
                        <li><a href="http://goo.gl/ob6Ju" target="_blank">Web Service</a></li>
                        <li><a href="http://code.google.com/p/bus-fm-api/wiki/HTTP" target="_blank">HTTP</a></li>
                    </ul>
                    <p class="changelog">
                        <h3>Development Log:</h3>
                    </p>
                    <ul>
                        <li>2011-4-7 添加统计功能</li>
                        <li>2011-4-7  添加取频道数据接口</li>
                        <li>2011-4-6 实现应用授权功能</li>
                        <li>2011-4-5 发布REST版接口</li>
                        <li>2011-3-20 发布Web Service版接口</li>
                    </ul>
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
