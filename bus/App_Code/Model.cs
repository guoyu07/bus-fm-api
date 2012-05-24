using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bus.Model
{
    public class Member
    {
        public int member_id { get; set; }
        public string member_nickname { get; set; }
        public string member_mail { get; set; }
        public string member_password { get; set; }
        public int member_join_time { get; set; }
        public int member_last_time { get; set; }
        public string member_last_ip { get; set; }
        public int member_state { get; set; }
    }

    public class AppKey
    {
        public string app_key { get; set; }
        public string app_owner { get; set; }
        public string app_usage { get; set; }
        public string app_url { get; set; }
        public int app_status { get; set; }
    }

    public class Vistor
    {
        public string ip { get; set; }
        public string UA { get; set; }
        public DateTime time { get; set; }
        public string url { get; set; }
        public string ref_url { get; set; }
        public string appkey { get; set; }
    }

    public class Sites
    {
        public int id { get; set; }
        public string sitename { get; set; }
        public string siteurl { get; set; }
        public string siteimg { get; set; }
        public int category { get; set; }
        public string tags { get; set; }
        public string summary { get; set; }
        public string submit { get; set; }
        public string sub_mail { get; set; }
        public DateTime sub_time { get; set; }
        public int status { get; set; }
        public DateTime modify_time { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string catename { get; set; }
        public int count { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string tag { get; set; }
        public int count { get; set; }
    }
}
