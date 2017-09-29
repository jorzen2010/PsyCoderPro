using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;


namespace Wechat
{
    public class WechatMessageServices
    {
        public static string SendTempletMessge(string access_token, string postdata)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", access_token);

            string result = WechatHttpWebResponseUtility.PostJsonData(url, postdata);

            return result;

        }
     

        public static string ResponseTextMessage(string postStr)
        { 
            string result=string.Empty;
            string content = "测试回复";
            string toUserName = "";
            WechatMessageServices.sendMsgToManage(toUserName, content);
            return result;
        
        }
        public static string ResponseImageMessage(string postStr)
        {
            string result = string.Empty;
            return result;

        }

        private static void sendMsgToManage(string toUserName, string content)
        {
            string managerweixinid = "sky20100";
            string xmlMsg = "<xml>" +
            "<ToUserName><![CDATA[" + managerweixinid + "]]></ToUserName>" +
            "<FromUserName><![CDATA[" + toUserName + "]]></FromUserName>" +
            "<CreateTime>12345678</CreateTime>" +
            "<MsgType><![CDATA[text]]></MsgType>" +
            "<Content><![CDATA[" + content + "]]></Content>" +
            "</xml>";
            HttpContext context = HttpContext.Current;
            context.Response.Write(xmlMsg);
        }
    }
}