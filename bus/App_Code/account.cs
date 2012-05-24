using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using DBHelper;

namespace Bus.DAL
{
    public class account
    {
        public account()
        {

        }


        public DataSet testds()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            return ds;
            //return SqlHelper.ExecuteDataset("select * from w_member limit 10");
        }

        // 用户名（邮箱）是否存在
        public bool isAccountExist(string membermail)
        {
            string sql = "select count(member_mail) from bus_member where member_mail='" + membermail + "'";
            try
            {
                object obj = SqlHelper.ExecuteScalar(sql);
                return isExist(obj);
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "isAccountExit", sql);
                throw new Exception("操作失败");
            }
        }

        // 昵称是否存在
        public bool isNicknameExist(string nickname)
        {
            string sql = "select count(member_nickname) from bus_member where member_nickname='" + nickname + "'";
            try
            {
                object obj = SqlHelper.ExecuteScalar(sql);
                return isExist(obj);
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "isNicknameExit", sql);
                throw new Exception("操作失败");
            }
        }

        //注册
        public int add(Bus.Model.Member model)
        {
            if (string.IsNullOrEmpty(model.member_nickname.Trim()))
            {
                throw new Exception("昵称不能为空");
            }
            Regex r = new Regex(@"^\w+[\+\.]?\w+@\w+\.\w+$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(model.member_mail.Trim()))
            {
                throw new Exception("邮箱格式不正确");
            }
            if (string.IsNullOrEmpty(model.member_password.Trim()))
            {
                throw new Exception("密码不能为空");
            }
            r = new Regex("^[0-9a-zA-z]{6,20}$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(model.member_password.Trim()))
            {
                throw new Exception("密码格式不正确，请输入6-20位字母和数字");
            }
            if (isAccountExist(model.member_mail))
            {
                throw new Exception("邮箱已存在");
            }
            if (isNicknameExist(model.member_nickname))
            {
                throw new Exception("昵称已存在");
            }
            if (string.IsNullOrEmpty(model.member_last_ip))
            {
                model.member_last_ip = "unknow";
            }
            string sql = "insert into bus_member (member_nickname,member_mail,member_password,member_join_time,member_validation_key,member_last_ip,member_state,member_validation) values(";
            sql += "?member_nickname,?member_mail,?member_password,?member_join_time,?member_validation_key,?member_last_ip,1,1)";
            string key = model.member_mail.Trim() + model.member_password.Trim();
            key = key.toMD5();
            MySqlParameter p1 = new MySqlParameter("?member_nickname", model.member_nickname.Trim());
            MySqlParameter p2 = new MySqlParameter("?member_mail", model.member_mail.Trim());
            MySqlParameter p3 = new MySqlParameter("?member_password", model.member_password.tosha1());
            MySqlParameter p4 = new MySqlParameter("?member_join_time", model.member_join_time);
            MySqlParameter p5 = new MySqlParameter("?member_validation_key", key);
            MySqlParameter p6 = new MySqlParameter("?member_last_ip", model.member_last_ip);
            try
            {
                SqlHelper.ExecuteNonQuery(sql, p1, p2, p3, p4, p5, p6);
                //发邮件
                //string mailbody = model.member_nickname + "恭喜你，已注册成功 巴士电台 <a href='http://bus.fm' target='_blank'>BUS.FM</a>,";
                //mailbody += " 激活请点击<a href='http://bus.fm/ajax/member?action=member_validation&key=" + key + "' target='_blank'>这里</a>!";
                int newid = -1;
                try
                {
                    newid = getInsertedID();
                    //common.email(mailbody, model.member_mail.Trim(), "Bus.Fm注册确认邮件");
                    return newid;
                }
                catch (Exception ex)
                {
                    log.warn("发送注册确认邮件失败", "error:" + ex.Message, "e-mail:" + model.member_mail);
                    if (newid != -1) Delete(newid);//假如获取新ID成功，邮件却发送失败，删除该用户
                    throw new Exception("注册失败，请重试");
                }
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "account.add", sql, model.member_nickname, model.member_mail, model.member_password, model.member_join_time.ToString());
                throw new Exception(ex.Message);
            }
        }

        private int getInsertedID()
        {
            try
            {
                string sql = "select last_insert_id()";
                object o = SqlHelper.ExecuteScalar(sql);
                if (o == null) throw new Exception("获取刚注册的用户ID失败");
                return Convert.ToInt32(o);
            }
            catch (Exception ex)
            {
                log.warn(ex.Message);
                throw new Exception("获取刚注册的用户ID失败");
            }
        }

        //删除用户
        public void Delete(int member_id)
        {
            string sql = "delete from bus_member where member_id=" + member_id;
            try
            {
                SqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                log.error(ex.Message, sql);
                throw new Exception("删除失败");
            }
        }

        //登录
        public DataTable login(string username, string pwd)
        {
            try
            {
                string sql = "select member_id,member_mail,member_nickname,member_validation,member_state from bus_member where member_mail='" + username + "' and member_password='" + pwd.tosha1() + "'";
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (Convert.ToInt32(dr["member_validation"]) != 1)
                    {
                        throw new Exception("账户尚未通过验证");
                    }
                    else if (Convert.ToInt32(dr["member_state"]) != 1)
                    {
                        throw new Exception("账号被停用");
                    }
                    else return ds.Tables[0];
                }
                else if (!isAccountExist(username))
                {
                    throw new Exception("该用户不存在");
                }
                else
                {
                    throw new Exception("密码错误");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //登录with userid
        public void loginWithID(string userid, string pwd)
        {
            string sql = "select count(member_mail) from bus_member where member_id='" + userid + "' and member_password='" + pwd.tosha1() + "'";
            try
            {
                if (!isExist(SqlHelper.ExecuteScalar(sql)))
                {
                    throw new Exception("登录失败");
                }
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "loginWithID", sql);
                throw new Exception("未知错误");
            }
        }

        //重设密码
        public void resetPwd(string usermail)
        {
            string nickname = "";
            string sql = "";
            try
            {
                //get username
                sql = "select member_nickname from bus_member where member_mail='" + usermail + "' limit 1";
                nickname = SqlHelper.ExecuteScalar(sql).ToString();
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "resetpwd", sql);
                throw new Exception("邮件地址不存在");
            }
            //get email string
            string validatestr = usermail + "=" + common.ConvertDateTimeInt(DateTime.Now);
            string url = "http://bus.fm/my/pwd/1&cont=" + validatestr.ToBase64();
            StringBuilder mailbody = new StringBuilder("Hello " + nickname + ", <br/><br/>");
            mailbody.Append("We send you this email because you seem to have forgotten your password. If you don't know what this email is about, please simply ignore it.<br/><br/>");
            mailbody.Append("To change your old password to this one, please go to the following URL:<br/><a href='" + url + "' target='_blank'>" + url + "</a><br/><br/>");
            mailbody.Append("You can also log into your account with the new password mentioned above. If you don't go to this URL, you can keep using your old password.<br/><br/>");
            mailbody.Append("Best Regards, <br/><br/>admin@Bus.fm");
            common.email(mailbody.ToString(), usermail, "Bus.Fm Reset Password!");
        }

        //修改密码
        public void changePwd(string userid, string oldpwd, string pwd)
        {
            Regex r = new Regex("^[0-9a-zA-Z]{6,20}$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(pwd))
            {
                throw new Exception("密码格式不正确，请输入6-20位字母和数字");
            }
            try
            {
                loginWithID(userid, oldpwd);//检查旧密码
            }
            catch
            {
                throw new Exception("原始密码错误");
            }
            string sql = "update bus_member set member_password=?pwd where member_id=?userid";
            try
            {
                SqlHelper.ExecuteNonQuery(sql, new MySqlParameter("?pwd", pwd.tosha1()), new MySqlParameter("?userid", userid));
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "changepwd", "uid=" + userid, "oldpwd=" + oldpwd, "newpwd=" + pwd);
                throw new Exception("修改失败");
            }
        }

        //exist辅助方法
        private bool isExist(object obj)
        {
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        #region admin

        public bool admin_login(string uname, string pwd)
        {
            try
            {
                string sql = "select count(uname) from user where uname=@uname and upwd=@pwd";
                object o = SQLiteHelper.ExecuteScalar(sql, uname, pwd);
                if (o != null)
                {
                    int i = Convert.ToInt32(o);
                    if (i > 0) return true;
                    else return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        #endregion

    }
}