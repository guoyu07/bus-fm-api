<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jsInvoke.aspx.cs" Inherits="jsInvoke" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html;charset=utf-8" http-equiv="Content-Type" />
    <title>Ajax调用WebService演示</title>
    <style type="text/css">
        .button
        {
            width: 150px;
            float: left;
            text-align: center;
            margin: 10px;
            padding: 10px;
            border: 1px solid #888;
        }
        .button:hover
        {
            cursor: pointer; /*小手*/
            background: #ffc; /*背景*/
        }
        #dictionary
        {
            text-align: center;
            font-size: 18px;
            clear: both;
            border-top: 3px solid #888;
        }
        #loading
        {
            border: 1px #000 solid;
            background-color: #eee;
            padding: 20px;
            margin: 100px 0 0 200px;
            position: absolute;
            display: none;
        }
        #switcher
        {
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script type="text/javascript">
    //无参数调用
        $(document).ready(function () {
            $('#btn1').click(function () {
                $.ajax({
                    type: "POST",  //访问WebService使用Post方式请求
                    contentType: "application/json", //WebService 会返回Json类型
                    url: "sample.asmx/HelloWorld", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                    data: "{}",        //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到      
                    dataType: 'json',
                    success: function (result) {    //回调函数，result，返回值
                        $('#dictionary').append(result.d);
                    }
                });
            });
            $("#btn6").click(function () {
                $.ajax({
                    type: "POST",  //访问WebService使用Post方式请求
                    contentType: "application/json", //WebService 会返回Json类型
                    url: "sample.asmx/getJsonStr", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                    data: "{}",        //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到      
                    dataType: 'json',
                    success: function (result) {    //回调函数，result，返回值
                        var dic = $('#dictionary').append(result.d).append("<br/>使用json对象:<br/>");
                        var t = eval("(" + result.d + ")");
                        $(t.jsname).each(function (i, m) {
                            for (var name in m) {
                                dic.append(name + ":" + m[name]+"&nbsp;|&nbsp;");
                            }
                            dic.append("<br/>");
                        });
                    }
                });
            });
            //有参数调用
            $("#btn2").click(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "sample.asmx/GetWish",
                    data: "{value1:'参数1',value2:'参数2',value3:'参数3',value4:2009}",
                    dataType: 'json',
                    success: function (result) {
                        $('#dictionary').append(result.d);
                    }
                });
            });

            $("#btn3").click(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "sample.asmx/GetArray",
                    data: "{i:10}",
                    dataType: 'json',
                    success: function (result) {
                        $(result.d).each(function () {
                            $('#dictionary').append(this.toString() + " ");
                        });
                    }
                });
            });
            //返回复合类型
            $('#btn4').click(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "sample.asmx/GetClass",
                    data: "{}",
                    dataType: 'json',
                    success: function (result) {
                        $(result.d).each(function () {
                            $('#dictionary').append(this['ID'] + " " + this['Value']);
                        });
                    }
                });
            });

            //返回DataSet(XML)
            $('#btn5').click(function () {
                $.ajax({
                    type: "POST",
                    url: "sample.asmx/GetDataSet",
                    data: "{}",
                    dataType: 'xml', //返回的类型为XML ，和前面的Json，不一样了
                    success: function (result) {
                        //演示一下捕获
                        try {
                            $(result).find("Table1").each(function () {
                                $('#dictionary').append($(this).find("ID").text() + " " + $(this).find("Value").text());
                            });
                        }
                        catch (e) {
                            alert(e.Message);
                            return;
                        }
                    },
                    error: function (result, status) { //如果没有上面的捕获出错会执行这里的回调函数
                        if (status == 'error') {
                            alert(status);
                        }
                    }
                });
            });

            //Ajax 为用户提供反馈，利用ajaxStart和ajaxStop 方法，演示ajax跟踪相关事件的回调，他们两个方法可以添加给jQuery对象在Ajax前后回调
            //但对与Ajax的监控，本身是全局性的
            $('#loading').ajaxStart(function () {
                $('#dictionary').html("");
                $(this).show();
            }).ajaxStop(function () {
                $(this).hide();
            });

            $('div.button').hover(function () {
                $(this).addClass('hover');
            }, function () {
                $(this).removeClass('hover');
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="switcher">
        <h2>
            jQuery 的WebServices 调用</h2>
        <div class="button" id="btn1">
            HelloWorld</div>
        <div class="button" id="btn2">
            传入参数</div>
        <div class="button" id="btn3">
            返回集合</div>
        <div class="button" id="btn4">
            返回复合类型</div>
        <div class="button" id="btn5">
            返回DataSet(XML)</div>
            <div class="button" id="btn6">返回json形式字符串</div>
    </div>
    <div id="loading">
        服务器处理中，请稍后。
    </div>
    <div id="dictionary">
    </div>
    </form>
</body>
</html>