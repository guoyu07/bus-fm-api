using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class apiaudit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            login.Visible = false;
            logout.Visible = false;
            string[] cookie = common.GetAuthenticatedUserData("|");
            if (cookie.Length < 2)
            {
                login.Visible = true;
                hidisloged.Value = "0";
            }
            else
            {
                logout.Visible = true;
                hidisloged.Value = "1";
            }
            initData();

        }
    }

    protected void cbxchange(object sender, EventArgs e)
    {
        initData();
    }

    private void initData()
    {
        string strWhere = " 1=1 ";
        if (!cbxshowdeny.Checked)
        {
            strWhere += " and app_status!=2 ";
        }
        if (!cbxshowpass.Checked)
        {
            strWhere += " and app_status!=1 ";
        }
        ods.SelectParameters["strWhere"].DefaultValue = strWhere;
        gv.DataSourceID = "ods";
        gv.DataBind();
    }

    protected void loginclick(object sender, EventArgs e)
    {
        if (new Bus.DAL.account().admin_login(txtuname.Text.Trim(), txtpwd.Text.Trim()))
        {
            string userdata = "admin|" + txtuname.Text.Trim();
            FlowControl.SaveLoginInfo(txtuname.Text, userdata);
            Response.Write("<script>location.href='/audit';</script>");
        }
    }

    protected void logoutclick(object sender, EventArgs e)
    {
        FlowControl.Logout();
        Response.Write("<script>location.href='/audit';</script>");
    }

    protected string parseStatus(string status)
    {
        switch (status)
        {
            case "1":
                return "<font color='green'>通过</font>";
            case "2":
                return "<font color='red'>未通过</font>";
            default:
                return "<font color='gray'>未处理</font>";
        }
    }

    protected void databind(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            drv = e.Row.DataItem as DataRowView;
            e.Row.Cells[2].Text = drv["app_owner"].ToString().cutString(22);
            e.Row.Cells[2].ToolTip = drv["app_owner"].ToString();
            e.Row.Cells[2].Text = "<a href='" + drv["app_url"].ToString() + "' target='_blank'>" + drv["app_url"].ToString().cutString(20) + "</a>";
            e.Row.Cells[2].ToolTip = drv["app_url"].ToString();
            e.Row.Cells[3].Text = drv["app_usage"].ToString().cutString(10);
            e.Row.Cells[3].ToolTip = drv["app_usage"].ToString();
        }
    }

    protected void passthis(object sender, CommandEventArgs e)
    {
        new Bus.DAL.appkey().UpdateStatus(e.CommandArgument.ToString(), 1);
        initData();
    }
    protected void denythis(object sender, CommandEventArgs e)
    {
        try
        {
            new Bus.DAL.appkey().UpdateStatus(e.CommandArgument.ToString(), 2);
            initData();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void delthis(object sender, CommandEventArgs e)
    {
        new Bus.DAL.appkey().Delete(e.CommandArgument.ToString());
        initData();
    }
}