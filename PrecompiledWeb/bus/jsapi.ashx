<%@ WebHandler Language="C#" Class="jsapi" %>

using System;
using System.Web;

public class jsapi : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        common.visitorRecord();
        string act = context.Request["act"].ToLower();
        switch (act.ToLower())
        {
            case "login":
                login(context);
                break;
            case "reg":
                reg(context);
                break;
            case "resetpwd":
                resetpwd(context);
                break;
            case "changepwd":
                changepwd(context);
                break;
            case "checkusermail":
                checkusermail(context);
                break;
            case "checknickname":
                checknickname(context);
                break;
            case "getlistbychannel":
                getlistbychannel(context);
                break;
            case "getlistbyuserid":
                getlistbyuserid(context);
                break;
            case "isfaved":
                isfaved(context);
                break;
            case "favethis":
                favethis(context);
                break;
            case "getchannellist":
                getchannellist(context);
                break;
            case "getshengqu":
                getshengqu(context);
                break;
            default:
                context.Response.ContentType = "text/html";
                context.Response.Write("<h3>Hello World</h3>");
                break;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


    private void login(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string usermail = c.Request["usermail"];
        string userpwd = c.Request["userpwd"];
        string str = "";

        if (string.IsNullOrEmpty(usermail))
        {
            r.Write("empty userid");
            r.End();
        }
        if (string.IsNullOrEmpty(userpwd))
        {
            r.Write("empty password");
            r.End();
        }
        try
        {
            str = new Bus.DAL.account().login(usermail, userpwd).ToJson("userinfo", "member_id", "member_mail", "member_nickname");
        }
        catch (Exception ex)
        {
            str = "{\"error\":\"" + ex.Message + "\"}";
        }
        r.Write(str);
        r.End();
    }
    private void reg(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string usermail = c.Request["usermail"];
        string userpwd = c.Request["userpwd"];
        string nickname = c.Request["nickname"];
        string str = "";

        if (string.IsNullOrEmpty(usermail))
        {
            r.Write("empty userid");
            r.End();
        }
        if (string.IsNullOrEmpty(userpwd))
        {
            r.Write("empty password");
            r.End();
        }
        if (string.IsNullOrEmpty(nickname))
        {
            r.Write("empty nickname");
            r.End();
        }
        try
        {
            Bus.Model.Member model = new Bus.Model.Member();
            model.member_join_time = (int)common.ConvertDateTimeInt(DateTime.Now);
            model.member_last_ip = c.Request.UserHostAddress;
            model.member_mail = usermail;
            model.member_nickname = nickname;
            model.member_password = userpwd;

            new Bus.DAL.account().add(model);
            str = "1|注册成功";
        }
        catch (Exception ex)
        {
            str = "0|" + ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void resetpwd(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string usermail = c.Request["usermail"];
        string str = "";

        if (string.IsNullOrEmpty(usermail))
        {
            r.Write("empty userid");
            r.End();
        }
        try
        {
            new Bus.DAL.account().resetPwd(usermail);
            str = "1|密码已发至邮箱，1小时内有效";
        }
        catch (Exception ex)
        {
            str = "0|" + ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void changepwd(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string userid = c.Request["userid"];
        string oldpwd = c.Request["oldpwd"];
        string newpwd = c.Request["newpwd"];
        string str = "";

        if (string.IsNullOrEmpty(userid))
        {
            r.Write("empty userid");
            r.End();
        }
        if (string.IsNullOrEmpty(oldpwd))
        {
            r.Write("empty orginal password");
            r.End();
        }
        if (string.IsNullOrEmpty(newpwd))
        {
            r.Write("empty new password");
            r.End();
        }
        try
        {
            new Bus.DAL.account().changePwd(userid, oldpwd, newpwd);
            str = "1|密码修改成功";
        }
        catch (Exception ex)
        {
            str = "0|" + ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void checkusermail(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string usermail = c.Request["usermail"];
        string str = "";

        if (string.IsNullOrEmpty(usermail))
        {
            r.Write("empty userid");
            r.End();
        }
        try
        {
            if (new Bus.DAL.account().isAccountExist(usermail))
            {
                str = "1";
            }
            else str = "0";
        }
        catch (Exception ex)
        {
            str = ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void checknickname(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string nickname = c.Request["nickname"];
        string str = "";

        if (string.IsNullOrEmpty(nickname))
        {
            r.Write("empty nickname");
            r.End();
        }
        try
        {
            if (new Bus.DAL.account().isNicknameExist(nickname))
            {
                str = "1";
            }
            else str = "0";
        }
        catch (Exception ex)
        {
            str = ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void getlistbychannel(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string sid = c.Request["channelid"];
        string appkey = c.Request["appkey"];
        string uid = c.Request["uid"];
        int id = 0;
        string str = "";

        if (string.IsNullOrEmpty(sid))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"empty channelid\"}]}");
            r.End();
        }
        else if (!int.TryParse(sid, out id))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"invalid channelid\"}]}");
            r.End();
        }
        if (string.IsNullOrEmpty(appkey))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"empty appkey\"}]}");
            r.End();
        }
        System.Data.DataTable dt = new System.Data.DataTable();
        try
        {
            common.isKeyValid(appkey);
            dt = new Bus.DAL.music().getListByChannel(id);
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        str = dt.ToJson("Tracks");
        r.Write(str);
        r.End();
    }
    private void getlistbyuserid(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string suserid = c.Request["userid"];
        string appkey = c.Request["appkey"];
        int userid = 0;
        string str = "";

        if (string.IsNullOrEmpty(suserid))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"empty userid\"}]}");
            r.End();
        }
        else if (!int.TryParse(suserid, out userid))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"invalid userid\"}]}");
            r.End();
        }
        if (string.IsNullOrEmpty(appkey))
        {
            r.Write("{\"Tracks\":[{\"ErrMessage\":\"empty appkey\"}]}");
            r.End();
        }
        System.Data.DataTable dt = new System.Data.DataTable();
        try
        {
            common.isKeyValid(appkey);
            dt = new Bus.DAL.music().getListByUserID(userid);
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        str = dt.ToJson("Tracks");
        r.Write(str);
        r.End();
    }
    private void isfaved(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string suserid = c.Request["userid"];
        string ssongid = c.Request["songid"];
        int userid = 0, songid = 0;
        string str = "";

        if (string.IsNullOrEmpty(suserid))
        {
            r.Write("empty userid");
            r.End();
        }
        else if (!int.TryParse(suserid, out userid))
        {
            r.Write("invalid userid");
            r.End();
        }
        if (string.IsNullOrEmpty(ssongid))
        {
            r.Write("empty songid");
            r.End();
        }
        else if (!int.TryParse(ssongid, out songid))
        {
            r.Write("invalid songid");
            r.End();
        }
        try
        {
            bool re = new Bus.DAL.music().isFaved(userid, songid);
            if (re)
            {
                str = "1";
            }
            else str = "0";
        }
        catch (Exception ex)
        {
            str = ex.Message;
        }
        r.Write(str);
        r.End();
    }
    private void favethis(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();

        string suserid = c.Request["userid"];
        string ssongid = c.Request["songid"];
        int userid = 0, songid = 0;
        string str = "";

        if (string.IsNullOrEmpty(suserid))
        {
            r.Write("empty userid");
            r.End();
        }
        else if (!int.TryParse(suserid, out userid))
        {
            r.Write("invalid userid");
            r.End();
        }
        if (string.IsNullOrEmpty(ssongid))
        {
            r.Write("empty songid");
            r.End();
        }
        else if (!int.TryParse(ssongid, out songid))
        {
            r.Write("invalid songid");
            r.End();
        }
        try
        {
            if (new Bus.DAL.music().FaveThis(userid, songid))
            {
                str = "1|收藏成功";
            }
            else str = "1|取消收藏成功";
        }
        catch (Exception ex)
        {
            str = "0|" + ex.Message;
        }
        r.Write(str);
        r.End();
    }

    public void getchannellist(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();
        string str;

        System.Data.DataTable dt = new System.Data.DataTable();
        try
        {
            dt = new Bus.DAL.appkey().GetChannelList().Tables[0];
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        str = dt.ToJson("Channels");
        r.Write(str);
        r.End();
    }

    public void getshengqu(HttpContext c)
    {
        HttpResponse r = c.Response;
        r.ContentType = "text/plain";
        r.Clear();
        string str;
        try
        {
            str = genShengqu();
        }
        catch (Exception ex)
        {
            str = ex.Message;
        }
        r.Write(str);
        r.End();
    }

    private string genShengqu()
    {
        //common.visitorRecord();
        System.Data.DataTable dt = new System.Data.DataTable();
        try
        {
            dt = new Bus.DAL.music().getShengQu();
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        System.Text.StringBuilder r = new System.Text.StringBuilder();
        if (dt.Rows.Count > 0)
        {
            if (dt.Columns.Count < 5)
            {
                return "no data, " + dt.Rows[0][0].ToString();
            }
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                r.Append("[");
                r.Append("\"" + dr["id"].ToString() + "\",");
                r.Append("\"" + dr["title"].ToString() + "\",");
                r.Append("\"" + dr["url"].ToString() + "\",");
                r.Append("\"" + dr["artist"].ToString() + "\",");
                r.Append("\"" + dr["album"].ToString() + "\",");
                r.Append("\"" + dr["thumb"].ToString() + "\"");
                r.Append("],");
            }
        }
        string rs = r.ToString().TrimEnd(',');
        return "[" + rs + "]";
    }
}