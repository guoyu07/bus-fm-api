using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Web;
using System.Net;

public static class common
{
    public static string pre = ConfigurationManager.AppSettings["pre"];
    /// <summary>
    /// 将Unix时间戳转换为DateTime类型时间
    /// </summary>
    /// <param name="d">double 型数字</param>
    /// <returns>DateTime</returns>
    public static DateTime ConvertIntDateTime(double d)
    {
        DateTime time = DateTime.MinValue;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        time = startTime.AddSeconds(d);
        return time;
    }

    /// <summary>
    /// 将c# DateTime时间格式转换为Unix时间戳格式
    /// </summary>
    /// <param name="time">时间</param>
    /// <returns>double</returns>
    public static double ConvertDateTimeInt(DateTime time)
    {
        double intResult = 0;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        intResult = (time - startTime).TotalSeconds;
        return intResult;
    }

    public static string md5(string str)
    {
        MD5 m = new MD5CryptoServiceProvider();
        byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
        return BitConverter.ToString(s);
    }

    public static string toMD5(this string str)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
    }

    public static string tosha1(this string str)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");
    }

    public static void email(string mailbody, string toaddress, string subject)
    {
        MailMessage msg = new MailMessage(ConfigurationManager.AppSettings["email"], toaddress, subject, mailbody);
        msg.BodyEncoding = Encoding.UTF8;
        msg.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.EnableSsl = smtp.Port != 25;
        smtp.Send(msg);
    }

    public static string ToBase64(this string srcStr)
    {
        byte[] b = System.Text.Encoding.UTF8.GetBytes(srcStr);
        return Convert.ToBase64String(b);
    }

    public static string FromBase64(this string base64str)
    {
        byte[] b = Convert.FromBase64String(base64str);
        return System.Text.Encoding.UTF8.GetString(b);
    }

    //验证appkey值
    private static bool verifyKey(string appkey)
    {
        try
        {

            DataTable dt = null;
            if (HttpRuntime.Cache["keymap"] == null)
            {
                dt = new Bus.DAL.appkey().GetList("app_status=1").Tables[0];
                string dbpath = HttpContext.Current.Server.MapPath("~/app_data/bus_api.sqlite");
                HttpRuntime.Cache.Insert("keymap", dt, new System.Web.Caching.CacheDependency(dbpath), System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                dt = HttpRuntime.Cache["keymap"] as DataTable;
            }
            if (dt.Rows.Count < 1) return false;
            DataRow[] drs = dt.Select("app_key='" + appkey + "'");
            if (drs.Count() < 1) return false;
            else return true;
        }
        catch(Exception ex)
        {
            log.error("验证授权key失败", ex.Message, "appkey=" + appkey);
            return false;
        }
    }

    public static void isKeyValid(string appkey)
    {
        if (!verifyKey(appkey)) throw new Exception("未授权应用");
    }


    public static string[] GetAuthenticatedUserData(string split)
    {
        string[] role = null;

        try
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            role = authTicket.UserData.Split(split.ToCharArray());
        }
        catch
        {
            role = new string[1];
        }
        return role;
    }

    public static string cutString(this string sourceStr, int length)
    {
        if (sourceStr.Length <= length)
            return sourceStr;
        else
        {
            return sourceStr.Substring(0, length) + "...";
        }
    }

    public static int visitorRecord()
    {
        HttpRequest request = HttpContext.Current.Request;
        Bus.Model.Vistor model = new Bus.Model.Vistor();
        model.ip = request.UserHostAddress;
        model.ref_url = request.UrlReferrer == null ? "direct access" : request.UrlReferrer.ToString();
        model.time = DateTime.Now;
        model.UA = request.UserAgent;
        model.url = request.Url.ToString();
        model.appkey = "";
        int r = new Bus.DAL.appkey().record(model);
        return r;
    }
    public static int visitorRecord(string appkey)
    {
        HttpRequest request = HttpContext.Current.Request;
        Bus.Model.Vistor model = new Bus.Model.Vistor();
        model.ip = request.UserHostAddress;
        model.ref_url = request.UrlReferrer == null ? "direct access" : request.UrlReferrer.ToString();
        model.time = DateTime.Now;
        model.UA = request.UserAgent;
        model.url = request.Url.ToString();
        model.appkey = appkey;
        int r = new Bus.DAL.appkey().record(model);
        return r;
    }
}
