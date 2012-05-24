using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Reflection;
using System.Text;

/// <summary>
///JSONHelper 的摘要说明
/// </summary>
public static class JSONHelper
{
    //DataTable转成Json 
    public static string ToJson(this DataTable dt, string jsonName)
    {
        StringBuilder Json = new StringBuilder();
        Json.Append("{\"" + jsonName + "\":[");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                    if (j < dt.Columns.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("}");
                if (i < dt.Rows.Count - 1)
                {
                    Json.Append(",");
                }
            }
        }
        Json.Append("]}");
        return Json.ToString();
    }
    /// <summary>选取自定义的列生成json字符串</summary>
    /// <param name="tableSource">数据库查询结果</param>
    /// <param name="fields">需要添加进来的字段名</param>
    /// <returns></returns>
    public static string ToJson(this DataTable tableSource, string jsonName, params string[] fields)
    {
        if (fields.Count() < 1) throw new Exception("fields count must be 1 or more");//至少要转化一列
        string jsonData = "{\"" + jsonName + "\":[";

        if (tableSource.Rows.Count > 0)
        {
            foreach (DataRow row in tableSource.Rows)
            {
                jsonData += "{";
                for (int i = 0; i < fields.Length; i++)
                    jsonData += "\"" + fields[i] + "\":\"" + row[fields[i]] + "\",";
                jsonData = jsonData.Substring(0, jsonData.Length - 1);
                jsonData += "},";
            }
            jsonData = jsonData.Substring(0, jsonData.Length - 1);
            jsonData += "]}";
        }
        else
        {
            jsonData += "]}";
        }

        return jsonData;
    }
}