using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using DBHelper;

namespace Bus.DAL
{
    public class music
    {
        public music()
        {

        }

        //频道歌曲
        public DataTable getListByChannel(int channelID)
        {
            string sql = " select  `content_id` as id,`content_title` as title,`content_url` as url,`content_keywords` as artist,`content_password` as album,`content_thumb` as thumb ";
            sql += " from bus_content where `content_state`!=0 and channel_id=" + channelID + " order by rand() limit 10";
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "getListByChannel", sql);
                throw new Exception("获取歌曲列表失败");
            }
        }

        //收藏歌曲
        public DataTable getListByUserID(int member_id)
        {
            string sql = "SELECT `content_id` as id,`content_title` as title,`content_url` as url,`content_keywords` as artist,`content_password` as album,`content_thumb` as thumb  FROM `bus_member_mp3` m";
            sql += " left join bus_content c on c.content_id=m.mp3_id";
            sql += " where m.user_id=" + member_id + " and  c.content_state!=0 order by rand() limit 5";
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "getListByUserID", sql);
                throw new Exception("获取收藏列表失败");
            }
        }
        
        //是否收藏
        public bool isFaved(int member_id, int songid)
        {
            string sql = "select count(user_id) from bus_member_mp3 where user_id=" + member_id + " and mp3_id=" + songid;
            try
            {
                object o = SqlHelper.ExecuteScalar(sql);
                if (o != null)
                {
                    if (Convert.ToInt32(o) > 0)
                        return true;
                    else return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "isfaved", sql);
                throw new Exception("网络错误");
            }
        }
        
        //收藏/取消收藏
        public bool FaveThis(int member_id, int songid)
        {
            string sql = "";
            bool result = true;//true表示收藏成功
            if (isFaved(member_id, songid))//取消
            {
                sql = "delete from bus_member_mp3 where user_id=" + member_id + " and mp3_id=" + songid;
                result = false;//表示取消收藏成功
            }
            else//收藏
            {
                sql = " insert into bus_member_mp3 (user_id,mp3_id) values(" + member_id + "," + songid + ")";
            }
            try
            {
                SqlHelper.ExecuteNonQuery(sql);
                return result;
            }
            catch (Exception ex)
            {
                log.error(ex.Message,"faveit", sql);
                throw new Exception("操作失败");
            }
        }


        //神曲
        public DataTable getShengQu()
        {
            string sql = "select * from shengqu order by random() limit 5";
            try
            {
                DataTable dt = SQLiteHelper.ExecuteDataSet(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                log.error(ex.Message, "getShengQu", sql);
                throw new Exception("获取列表失败");
            }
        }

        //收听列表



        //推荐列表


        //偏好

    }
}
