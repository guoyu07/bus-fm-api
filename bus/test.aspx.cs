using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Data;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        //gv.DataSource = new Bus.DAL.music().getListByUserID(4);
        //gv.DataBind();
    }

    #region 权限

    //添加用户
    protected void Button1_Click(object sender, EventArgs e)
    {
        Bus.Model.Member m = new Bus.Model.Member();
        m.member_password = "333444";
        m.member_nickname = "walker" + DateTime.Now.Millisecond;
        m.member_mail = "mail";
        m.member_join_time = (int)common.ConvertDateTimeInt(DateTime.Now);
        m.member_last_ip = Request.UserHostAddress;
        try
        {
            int n = new Bus.DAL.account().add(m);
            lblmsg.Text = "add user successful<br/>";
            new Bus.DAL.account().Delete(n);
            lblmsg.Text += "new member " + n + " has been deleted";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //md5
    protected void getmd5(object sender, EventArgs e)
    {
        lblmsg.Text = txtformdt.Text.Trim().tosha1();
    }


    //邮件
    protected void Button2_Click(object sender, EventArgs e)
    {
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("admin@bus.fm", "43191993@qq.com", "sub", "hey");
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Send(msg);
        Response.Write("<script>alert('done');</script>");
    }

    //登录
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string uid = "404error@163.com";
        string pwd = "aaaaaa";
        try
        {
            new Bus.DAL.account().login(uid, FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5"));
            lblmsg.Text = "login success";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //改密码
    protected void btnchangepwd_Click(object sender, EventArgs e)
    {
        string uid = "1586";
        string oldpwd = "aaaaaa";
        string pwd = "aa";
        try
        {
            new Bus.DAL.account().changePwd(uid, oldpwd, pwd);
            lblmsg.Text = "change pwd success";
            if (oldpwd == "aaaaaa")
                new Bus.DAL.account().changePwd(uid, pwd, oldpwd);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //重设密码
    protected void btnresetpwd_Click(object sender, EventArgs e)
    {
        string mail = "404error@163.com";
        try
        {
            new Bus.DAL.account().resetPwd(mail);
            lblmsg.Text = "reset mail has sent to your mailbox";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }


    #endregion

    #region 音乐


    //频道
    protected void btn_getlistbychannel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new Bus.DAL.music().getListByChannel(1);
            gv.DataSource = dt;
            gv.DataBind();
            txtresult.Text = dt.ToJson("list");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //个人收藏
    protected void btn_getlistbyid_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new Bus.DAL.music().getListByUserID(4); ;
            gv.DataSource = dt;
            gv.DataBind();

            //string s=Jayrock.Json.Conversion.JsonConvert.ExportToString(dt);
            //string s = JSONHelper.DataTableToJson("list", dt);
            string s = dt.ToJson("list", "id", "title", "url");
            txtresult.Text = s;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //是否收藏
    protected void btn_isfave_Click(object sender, EventArgs e)
    {
        int songid = 1541;
        int member_id = 4;
        try
        {
            lblmsg.Text = (new Bus.DAL.music().isFaved(member_id, songid)).ToString();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    //收藏/取消
    protected void btn_favorcancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (new Bus.DAL.music().FaveThis(4, 1541))
                lblmsg.Text = "收藏成功";
            else lblmsg.Text = "取消收藏成功";

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    #endregion

    //guid
    protected void Button10_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new Bus.DAL.appkey().GetList("app_status=3").Tables[0];
            lblmsg.Text = "done";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    //appkey
    protected void Button11_Click(object sender, EventArgs e)
    {
        try
        {
            Bus.Model.AppKey m = new Bus.Model.AppKey();
            m.app_key = Guid.NewGuid().ToString();
            m.app_owner = "walker";
            m.app_url = "bus.fm";
            m.app_usage = "test";
            int s = new Bus.DAL.appkey().Add(m);
            lblmsg.Text = s + "位用户被添加"+m.app_key;
            s += DBHelper.SQLiteHelper.ExecuteNonQuery("select count(*) from appkey where app_key=@appkey", m.app_key);
            lblmsg.Text = s + "";
            s = new Bus.DAL.appkey().Delete(m.app_key);
            lblmsg.Text += "<br/>" + s + "位用户被删除"+m.app_key;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void channelid_Click(object sender, EventArgs e)
    {
        DataTable dt = new Bus.DAL.appkey().GetChannelList().Tables[0];
        gv.DataSource = dt;
        gv.DataBind();

        txtresult.Text = new musics().GetChannelList();
    }
    protected void visit_Click(object sender, EventArgs e)
    {
        lblmsg.Text = common.visitorRecord().ToString();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string aa="create table channels( cid int primary key,	cname varchar(20));";
        aa+="insert into channels values (1,'白');";
        aa+="insert into channels values (2,'灰');";
        aa+="insert into channels values (3,'黑');";
        aa+="insert into channels values (4,'红');";
        aa += "insert into channels values (99,'私人频道');";
        try
        {
            string s = DBHelper.SQLiteHelper.ExecuteNonQuery(aa).ToString();
            lblmsg.Text = s;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
        string bb = "create table access_record(ip varchar(100),UA varchar(100),time datetime,url varchar(500),ref_url varchar(500),appkey varchar(100))";
        try
        {
            string s2 = DBHelper.SQLiteHelper.ExecuteNonQuery(bb).ToString();
            lblmsg.Text +="done"+ s2;
        }
        catch (Exception ex)
        {
            lblmsg.Text += "done," + ex.Message;
        }
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        try
        {
            txtresult.Text = new musics().GetShengQu();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnaclick(object sender, EventArgs e)
    {
        //new Bus.DAL.appkey().Add(null);
    }
}