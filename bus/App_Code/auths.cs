using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
///auths 的摘要说明
/// </summary>
[WebService(Namespace = "http://api.bus.fm/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class auths : System.Web.Services.WebService {

    public auths () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string About()
    {
        return "非.net程序请在此Web Service地址后加?wsdl";
    }

    [WebMethod]
    public string login(string usermail, string userpwd)
    {
        common.visitorRecord();
        try
        {
            return new Bus.DAL.account().login(usermail, userpwd).ToJson("userinfo","member_id","member_mail","member_nickname");
        }
        catch (Exception ex)
        {
            return "{\"error\":"+ex.Message+"}";
        }
        
    }

    [WebMethod]
    public string reg(string usermail, string userpwd, string nickname)
    {
        common.visitorRecord();
        try
        {
            Bus.Model.Member model = new Bus.Model.Member();
            model.member_join_time = (int)common.ConvertDateTimeInt(DateTime.Now);
            model.member_last_ip = Context.Request.UserHostAddress;
            model.member_mail = usermail;
            model.member_nickname = nickname;
            model.member_password = userpwd;

            new Bus.DAL.account().add(model);
            return "1|注册成功";
        }
        catch (Exception ex)
        {
            return "0|" + ex.Message;
        }
    }

    [WebMethod]
    public string resetPassword(string usermail)
    {
        common.visitorRecord();
        try
        {
            new Bus.DAL.account().resetPwd(usermail);
            return "1|密码已发至邮箱，1小时内有效";
        }
        catch (Exception ex)
        {
            return "0|" + ex.Message;
        }
    }

    [WebMethod]
    public string changePassword(string userid, string oldpwd, string newpwd)
    {
        common.visitorRecord();
        try
        {
            new Bus.DAL.account().changePwd(userid, oldpwd, newpwd);
            return "1|密码修改成功";
        }
        catch (Exception ex)
        {
            return "0|" + ex.Message;
        }
    }

    [WebMethod]
    public string checkUsermail(string usermail)
    {
        common.visitorRecord();
        try
        {
            if (new Bus.DAL.account().isAccountExist(usermail))
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
    public string checkNickname(string nickname)
    {
        common.visitorRecord();
        try
        {
            if (new Bus.DAL.account().isNicknameExist(nickname))
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
}
