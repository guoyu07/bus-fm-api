using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Request.Url：" + Request.Url + "<br />");
        Response.Write("Request.UrlReferrer :" + Request.UrlReferrer + "<br />");
        Response.Write("Request.Path：" + Request.Path + "<br />");
        Response.Write("Request.CurrentExecutionFilePath：" + Request.CurrentExecutionFilePath + "<br />");
        Response.Write("Request.FilePath：" + Request.FilePath + "<br />");
        Response.Write("Request.PathInfo：" + Request.PathInfo + "<br />");
        Response.Write("Request.PhysicalApplicationPath：" + Request.PhysicalApplicationPath + "<br />");
        Response.Write("Request.PhysicalPath：" + Request.PhysicalPath + "<br />");
        Response.Write("Request.RawUrl：" + Request.RawUrl + "<br />");
        Response.Write("Request.Serviables[\"url\"]：" + Request.ServerVariables["url"] + "<br />");
        Response.Write("Request.Url.host：" + Request.Url.Host + "<br />");
        Response.Write("Request.Url.Port：" + Request.Url.Port + "<br />");
        Response.Write("Request.Serviables[\"REQUEST_METHOD\"]：" + Request.ServerVariables["REQUEST_METHOD"] + "<br />");
        Response.Write("Request.Serviables[\"LOCAL_ADDR\"]：" + Request.ServerVariables["LOCAL_ADDR"] + "<br />");
        Response.Write("Request.Serviables[\"Path_Info\"]：" + Request.ServerVariables["Path_Info"] + "<br />");
        Response.Write("Request.Serviables[\"Appl_Physical_Path\"]：" + Request.ServerVariables["Appl_Physical_Path"] + "<br />");
        Response.Write("Request.Serviables[\"Path_Translated\"]：" + Request.ServerVariables["Path_Translated"] + "<br />");
        Response.Write("Request.Serviables[\"Script_Name\"]：" + Request.ServerVariables["Script_Name"] + "<br />");
        Response.Write("Request.Serviables[\"Query_String\"]：" + Request.ServerVariables["Query_String"] + "<br />");
        Response.Write("Request.Serviables[\"Http_Referer\"]：" + Request.ServerVariables["Http_Referer"] + "<br />");
        Response.Write("Request.Serviables[\"Server_Port\"]：" + Request.ServerVariables["Server_Port"] + "<br />");
        Response.Write("Request.Serviables[\"Remote_Addr\"]：" + Request.ServerVariables["Remote_Addr"] + "<br />");
        Response.Write("Request.Serviables[\"Remote_Host\"]：" + Request.ServerVariables["Remote_Host"] + "<br />");
        Response.Write("Request.Serviables[\"Http_Host\"]：" + Request.ServerVariables["Http_Host"] + "<br />");
        Response.Write("Request.Serviables[\"Server_Name\"]：" + Request.ServerVariables["Server_Name"] + "<br />");
        Response.Write("Request.Serviables[\"Request_Method\"]：" + Request.ServerVariables["Request_Method"] + "<br />");
        Response.Write("Request.Serviables[\"Server_Port_Secure\"]：" + Request.ServerVariables["Server_Port_Secure"] + "<br />");
        Response.Write("Request.Serviables[\"Server_Protocol\"]：" + Request.ServerVariables["Server_Protocol"] + "<br />");
        Response.Write("Request.Serviables[\"Server_Software\"]：" + Request.ServerVariables["Server_Software"] + "<br />");
        Response.Write("Request.Serviables[\"All_Http\"]：" + Request.ServerVariables["All_Http"] + "<br />");
        Response.Write("Request.Serviables[\"All_Raw\"]：" + Request.ServerVariables["All_Raw"] + "<br />");
        Response.Write("Request.Serviables[\"Appl_MD_Path\"]：" + Request.ServerVariables["Appl_MD_Path"] + "<br />");
        Response.Write("Request.Serviables[\"Content_Length\"]：" + Request.ServerVariables["Content_Length"] + "<br />");
        Response.Write("Request.Serviables[\"Https\"]：" + Request.ServerVariables["Https"] + "<br />");
        Response.Write("Request.Serviables[\"Instance_ID\"]：" + Request.ServerVariables["Instance_ID"] + "<br />");
        Response.Write("Request.Serviables[\"Instance_Meta_Path\"]：" + Request.ServerVariables["Instance_Meta_Path"] + "<br />");
        Response.Write("Request.Serviables[\"Http_Accept_Encoding\"]：" + Request.ServerVariables["Http_Accept_Encoding"] + "<br />");
        Response.Write("Request.Serviables[\"Http_Accept_Language\"]：" + Request.ServerVariables["Http_Accept_Language"] + "<br />");
        Response.Write("Request.Serviables[\"Http_Connection\"]：" + Request.ServerVariables["Http_Connection"] + "<br />");
        Response.Write("Request.Serviables[\"Http_User_Agent\"]：" + Request.ServerVariables["Http_User_Agent"] + "<br />");
        Response.Write("Request.Serviables[\"Https_Keysize\"]：" + Request.ServerVariables["Https_Keysize"] + "<br />");
        Response.Write("Request.Serviables[\"Https_Secretkeysize\"]：" + Request.ServerVariables["Https_Secretkeysize"] + "<br />");
        Response.Write("Request.Serviables[\"Https_Server_Issuer\"]：" + Request.ServerVariables["Https_Server_Issuer"] + "<br />");
        Response.Write("Request.Serviables[\"Https_Server_Subject\"]：" + Request.ServerVariables["Https_Server_Subject"] + "<br />");
        Response.Write("Request.Serviables[\"Auth_Password\"]：" + Request.ServerVariables["Auth_Password"] + "<br />");
        Response.Write("Request.Serviables[\"Auth_Type\"]：" + Request.ServerVariables["Auth_Type"] + "<br />");
        Response.Write("Request.Serviables[\"Auth_User\"]：" + Request.ServerVariables["Auth_User"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Flag\"]：" + Request.ServerVariables["Cert_Flag"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Issuer\"]：" + Request.ServerVariables["Cert_Issuer"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Keysize\"]：" + Request.ServerVariables["Cert_Keysize"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Secretkeysize\"]：" + Request.ServerVariables["Cert_Secretkeysize"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Serialnumber\"]：" + Request.ServerVariables["Cert_Serialnumber"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Server_Issuer\"]：" + Request.ServerVariables["Cert_Server_Issuer"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Server_Subject\"]：" + Request.ServerVariables["Cert_Server_Subject"] + "<br />");
        Response.Write("Request.Serviables[\"Cert_Subject\"]：" + Request.ServerVariables["Cert_Subject"] + "<br />");
        Response.Write("Request.Serviables[\"Content_Type\"]：" + Request.ServerVariables["Content_Type"] + "<br />");
    }
}