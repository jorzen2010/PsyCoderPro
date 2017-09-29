using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using System.Configuration;

namespace Wechat
{
    public class WechatService
    {
        //验证微信开发者
        public static void Auth()
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appsection = config.GetSection("appSettings") as AppSettingsSection;

            string token = appsection.Settings["WechatToken"].Value.ToString();
            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            string[] ArrTmp = { token, timestamp, nonce };

            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);

            tmpStr = WechatEncrypt.SHA1(tmpStr);

            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {
                System.Web.HttpContext.Current.Response.Write(echoString);
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("验证不通过");
                System.Web.HttpContext.Current.Response.End();
            }
        
        }

        //处理微信信息
        public static string  Excute(string postStr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(postStr);
            string  MsgType = xmlDoc.FirstChild.Attributes["MsgType"].Value.ToString();

            switch (MsgType)
            {
                case "image"://如果是图片消息
                    return WechatMessageServices.ResponseImageMessage(postStr);
                case "text"://如果是文本消息
                    return WechatMessageServices.ResponseTextMessage(postStr);
                default:
                    return "不被支持的关键字！";
            }

            //WeixinApiDispatch dispatch = new WeixinApiDispatch();
            //string responseContent = dispatch.Execute(postStr);

            //HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            //HttpContext.Current.Response.Write(responseContent);
 
        }

        public static string wechatApi(string operate, string access_token, string postdata)
        {
            string result = "";
            string url = "";
            switch (operate)
            {
                case "SendTemplateMessage":
                url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", access_token);               
                break;

                case "GetUserListInfo":
                url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}", access_token);              
                break;
                   
            }
            result = WechatHttpWebResponseUtility.PostJsonData(url, postdata);
            return result;
        }
    }
}