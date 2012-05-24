using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.IO;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
    }

    protected void encode(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");//获取网站根目录下的配置文件
        ConfigurationSection appSetting = config.GetSection("appSettings");//获取appSettings配置块信息
        if (appSetting != null && !appSetting.SectionInformation.IsProtected)
        {//如果没有加密则进行加密
            appSetting.SectionInformation.ProtectSection("DataprotectionConfigurationProvider");
            //appSetting.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        }
        ConfigurationSection mailSetting = config.GetSection("system.net/mailSettings/smtp");//获取mailSettings配置块信息
        if (mailSetting != null && !mailSetting.SectionInformation.IsProtected)
        {//如果没有加密则进行加密
            mailSetting.SectionInformation.ProtectSection("DataprotectionConfigurationProvider");
            //mailSetting.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        }
        config.Save();
        lblmsg.Text = "Encryption Done";
    }

    protected void decode(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");//获取网站根目录下的配置文件
        ConfigurationSection appSetting = config.GetSection("appSettings");//获取appSettings配置块信息
        if (appSetting != null && appSetting.SectionInformation.IsProtected)
        {//判断是否已经加密,如果已经加密则进行解密
            appSetting.SectionInformation.UnprotectSection();
        }
        ConfigurationSection mailSetting = config.GetSection("system.net/mailSettings/smtp");//获取mailSettings配置块信息
        if (mailSetting != null && mailSetting.SectionInformation.IsProtected)
        {
            mailSetting.SectionInformation.UnprotectSection();
        }
        config.Save();
        lblmsg.Text = "Decryption Done";
    }

    protected void validate(object sender, EventArgs e)
    {
        if (txtuid.Text == "walker" && txtpwd.Text == "wzy")
        {
            pnlconf.Visible = true;
            pnllog.Visible = false;
        }
        else
        {
            pnlconf.Visible = false;
            pnllog.Visible = true;
        }
    }

    static object o = new object();
    protected void getlog(object sender, EventArgs e)
    {
        string log = Server.MapPath("~/log/" + ddltype.Text + txtmonth.Text + ".log");
        if (!File.Exists(log))
        {
            lbllog.Text = "no logs at specific month";
            return;
        }
        lock (o)
        {
            try
            {
                StreamReader sr = new StreamReader(log);
                string newline = sr.ReadLine();
                while (newline != null)
                {
                    lbllog.Text += newline + "<br/>";
                    newline = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }

}