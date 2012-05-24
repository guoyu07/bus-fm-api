<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sidebar.ascx.cs" Inherits="api_sidebar" %>

        		<div id="sidebar">
                	<ul class="sideNav">
                    	<li><a href="/about" <%= index==1?"class='active'":"" %>>API概述</a></li>
                    	<li><a href="/docs" <%= index==2?"class='active'":"" %>>开发文档</a></li>
                    	<li><a href="/apply" <%= index==3?"class='active'":"" %>>API申请</a></li>
                        <% if (index == 4)
                           { %>
                           <li><a href="/audit" class="active">管理</a></li>
                        <%} %>
                    </ul>
                    <!-- // .sideNav -->
                </div>    
                <!-- // #sidebar -->