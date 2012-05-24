using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// WebService1 的摘要说明
/// </summary>
[WebService(Namespace = "http://api.bus.fm/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
[System.Web.Script.Services.ScriptService]
public class sample : System.Web.Services.WebService
{
    /// <summary>
    /// 无参数
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World ";
    }

    /// <summary>
    /// 带参数
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="value3"></param>
    /// <param name="value4"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetWish(string value1, string value2, string value3, int value4)
    {
        return string.Format("整形参:{3}，字符串参：{0}、{1}、{2}", value1, value2, value3, value4);
    }

    /// <summary>
    /// 返回集合
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    [WebMethod]
    public List<int> GetArray(int i)
    {
        List<int> list = new List<int>();

        while (i >= 0)
        {
            list.Add(i--);
        }

        return list;
    }

    /// <summary>
    /// 返回一个复合类型
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public Class1 GetClass()
    {
        return new Class1 { ID = "1", Value = "类属性2" };
    }


    /// <summary>
    /// 返回XML
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public DataSet GetDataSet()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", Type.GetType("System.String"));
        dt.Columns.Add("Value", Type.GetType("System.String"));
        DataRow dr = dt.NewRow();
        dr["ID"] = "1";
        dr["Value"] = "第一行";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["ID"] = "2";
        dr["Value"] = "第二行";
        dt.Rows.Add(dr);
        ds.Tables.Add(dt);
        return ds;
    }
    [WebMethod]
    public string getJsonStr()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("col1", typeof(int));
        dt.Columns.Add("col2", typeof(string));
        dt.Columns.Add("col3", typeof(string));
        dt.Columns.Add("col4", typeof(string));
        dt.Columns.Add("col5", typeof(string));
        dt.Rows.Add(1, "col2", "col3", "col4", "col5");
        dt.Rows.Add(2, "col2", "col3", "col4", "col5");
        dt.Rows.Add(3, "col2", "col3", "col4", "col5");
        dt.Rows.Add(4, "col2", "col3", "col4", "col5");
        dt.Rows.Add(5, "col2", "col3", "col4", "col5");
        return dt.ToJson("jsname");
    }
}
//自定义的类，只有两个属性
public class Class1
{
    public string ID { get; set; }
    public string Value { get; set; }
}
