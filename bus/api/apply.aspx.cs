using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class apply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
    }

    protected void applykey(object sender, EventArgs e)
    {
        Bus.Model.AppKey model = new Bus.Model.AppKey();
        model.app_owner = txtemail.Text.Trim();
        model.app_url = txturl.Text.Trim();
        model.app_usage = txtdesc.Text.Trim();
        try
        {
            new Bus.DAL.appkey().Add(model);
            lblmsg.Text = "&nbsp;&nbsp;您的申请已提交，我们审核通过后会将应用授权发至您填写的邮箱，请定时检查收件箱<br/><br/><br/><br/><br/>";
            fd.Visible = false;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
}