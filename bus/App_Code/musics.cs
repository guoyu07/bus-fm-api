using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;

/// <summary>
///musics 的摘要说明
/// </summary>
[WebService(Namespace = "http://api.bus.fm/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class musics : System.Web.Services.WebService
{

    public musics()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string About()
    {
        common.visitorRecord();
        return "非.net程序请在此Web Service地址后加?wsdl";
    }

    [WebMethod]
    public string getListByChannel(int id, string appkey)
    {
        common.visitorRecord(appkey);
        DataTable dt = new DataTable();
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
        return dt.ToJson("Channels");
    }

    [WebMethod]
    public string getListByUserID(int userid, string appkey)
    {
        common.visitorRecord(appkey);
        DataTable dt = new DataTable();
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
        return dt.ToJson("Tracks");
    }

    [WebMethod]
    public string isFaved(int userid, int songid)
    {
        common.visitorRecord();
        try
        {
            bool r = new Bus.DAL.music().isFaved(userid, songid);
            if (r)
            {
                return "1";
            }
            return "0";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    [WebMethod]
    public string FaveThis(int userid, int songid)
    {
        common.visitorRecord();
        try
        {
            if (new Bus.DAL.music().FaveThis(userid, songid))
            {
                return "1|收藏成功";
            }
            return "1|取消收藏成功";
        }
        catch (Exception ex)
        {
            return "0|" + ex.Message;
        }
    }

    [WebMethod]
    public string GetChannelList()
    {
        common.visitorRecord();
        DataTable dt = new DataTable();
        try
        {
            dt = new Bus.DAL.appkey().GetChannelList().Tables[0];
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        return dt.ToJson("Tracks");
    }

    [WebMethod]
    public string GetShengQu()
    {
        //common.visitorRecord();
        DataTable dt = new DataTable();
        try
        {
            dt = new Bus.DAL.music().getShengQu();
        }
        catch (Exception ex)
        {
            dt.Columns.Add("ErrMessage", typeof(string));
            dt.Rows.Add(ex.Message);
        }
        StringBuilder r = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            if (dt.Columns.Count < 5)
            {
                return "no data, "+dt.Rows[0][0].ToString();
            }
            foreach (DataRow dr in dt.Rows)
            {
                r.Append("[");
                r.Append("\"" + dr["id"].ToString() + "\",");
                r.Append("\"" + dr["title"].ToString() + "\",");
                r.Append("\"" + dr["url"].ToString() + "\",");
                r.Append("\"" + dr["album"].ToString() + "\",");
                r.Append("\"" + dr["thumb"].ToString() + "\"");
                r.Append("],");
            }
        }
        string rs = r.ToString().TrimEnd(',');
        return "[" + rs + "]";
    }
}
