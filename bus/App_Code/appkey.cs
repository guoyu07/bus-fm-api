using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper;
using System.Data;

namespace Bus.DAL
{
    /// <summary>
    ///appkey 的摘要说明
    /// </summary>
    public class appkey
    {
        public appkey()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int Add(Bus.Model.AppKey model)
        {
            if (string.IsNullOrEmpty(model.app_owner))
            {
                throw new Exception("");
            }
            int s = SQLiteHelper.ExecuteNonQuery("insert into appkey (app_key, app_owner,app_usage,app_url) values(@app_key,@app_owner,@app_usage,@app_url)",
                Guid.NewGuid().ToString(), model.app_owner, model.app_usage, model.app_url);
            common.email("有人申请巴士电台应用key，请及时查看<br/><a href='http://api.bus.fm/audit' target='_blank'>进入管理</a>", "rock@bus.fm", "巴士电台API提醒");
            return s;
        }

        public int Delete(string guid)
        {
            int s = SQLiteHelper.ExecuteNonQuery("delete from appkey where app_key=@appkey", guid);
            return s;
        }

        public int UpdateStatus(string guid, int status)
        {
            int s = SQLiteHelper.ExecuteNonQuery("update appkey set app_status=@app_status, app_passtime=@time where app_key=@appkey", status, DateTime.Now, guid);
            if (status == 1)
            {
                DataRow dr = new Bus.DAL.appkey().GetList(" app_key='" + guid + "'").Tables[0].Rows[0];
                string mailbody = dr["app_owner"].ToString() + " 您好，您于" + dr["app_applytime"].ToString() + " 申请巴士电台API应用授权key，经我们审核已经通过您的申请<br/>您的授权key是：<b>" + guid + "</b> 请妥善保管，有其它问题请回复此邮件，保持联系<br/>开发文档：http://api.bus.fm/docs<br/><br/>巴士电台团队<br/>" + DateTime.Now.ToString();
                common.email(mailbody, dr["app_owner"].ToString(), "巴士电台开放接口授权申请通知");
            }
            return s;
        }

        public DataSet GetList(string strWhere)
        {
            DataSet ds = new DataSet();
            try
            {
                strWhere = string.IsNullOrEmpty(strWhere) ? strWhere : " where " + strWhere;
                ds = SQLiteHelper.ExecuteDataSet("select * from appkey" + strWhere);
            }
            catch (Exception ex)
            {
                log.error("查询appkey失败", ex.Message);
                ds.Tables.Add(new DataTable());
            }
            return ds;
        }

        /////////////****************功能部分*****************//////////
        //频道列表
        public DataSet GetChannelList()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SQLiteHelper.ExecuteDataSet("select * from channels");
            }
            catch (Exception ex)
            {
                log.error("查询频道列表失败", ex.Message);
                ds.Tables.Add(new DataTable());
            }
            return ds;
        }
        //记录调用信息
        public int record(Bus.Model.Vistor model)
        {
            string sql = "insert into access_record values(@ip,@ua,@time,@url,@ref_url,@appkey)";
            try
            {
                int r = SQLiteAccess.ExecuteNonQuery(sql, model.ip, model.UA, model.time, model.url, model.ref_url, model.appkey);
                return r;
            }
            catch (Exception ex)
            {
                log.warn("写访问者日志出错", ex.Message, "appkey: "+model.appkey, "visit ip: "+model.ip, "from: " + model.ref_url, "to: " + model.url, "UA: "+model.UA);
                return 0;
            }
        }
        //统计
    }
}