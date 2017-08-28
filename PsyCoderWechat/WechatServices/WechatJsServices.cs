using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Configuration;
using PsyCoderEntity.WechatEntity;
using PsyCoderCommon;

namespace PsyCoderWechat.WechatServices
{
    public class WechatJsServices
    {

        public static string GetJsapi_ticket(string access_token, string userAgent)
        {

            string ticket = "";

            WechatJsConfig JsConfig = WechatJsServices.GetWechatJsConfig();

            if (DateTime.Now < DateTime.Parse(JsConfig.WechatJsTicketExpiredTime))
            {
                ticket = JsConfig.WechatJsTicket;
            }
            else
            {
                ticket = WechatJsServices.RefrenshJsapi_ticket(access_token, userAgent).ticket;

            }
            return ticket;
        }
        public static WechatJsTicket RefrenshJsapi_ticket(string access_token, string userAgent)
        {

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", access_token);

            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, userAgent, null);

            //Stream stream = response.GetResponseStream();
            //StreamReader sr = new StreamReader(stream);
            //string result = sr.ReadToEnd();
            string result = HttpWebResponseUtility.HttpResponseToString(response);
            WechatJsTicket ticket = JsonConvert.DeserializeObject<WechatJsTicket>(result);
            if (string.IsNullOrEmpty(ticket.ticket))
            {
                WechatError err = new WechatError();
                err = JsonConvert.DeserializeObject<WechatError>(result);
                string error = "appid或者appsecret错误，无法获取access_token 微信错误代码：" + err.errcode + "微信错误信息：" + err.errmsg;
                LogHelper.Error(error);
            }
            else
            { 
                string ticketExpiredTime=System.DateTime.Now.AddMinutes(115).ToString("yyyy-MM-dd HH:mm:ss");

            ConfigTools.WriteKey("WechatJsapi_ticket", ticket.ticket);
            ConfigTools.WriteKey("WechatJsapi_ticketExpiredTime", ticketExpiredTime);
            }
            

            return ticket;
       
        }

       

      

        public static string GetSignature(string jsapi_ticket, string nonceStr, string timestamp,string currentUrl)
        {

            string string1 = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", jsapi_ticket, nonceStr, timestamp, currentUrl);
      //      string string1 = "jsapi_ticket=" + jsapi_ticket +"&noncestr=" + "zhaozhengo" +"&timestamp=" + "1414587487" +"&url=" + currentUrl;
            return SkyEncrypt.SHA1(string1);

        }

        public static WechatJsConfig GetWechatJsConfig()
        {

            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");


            AppSettingsSection appsection = config.GetSection("appSettings") as AppSettingsSection;


            WechatJsConfig JsConfig = new WechatJsConfig();

            JsConfig.WechatJsUrl = appsection.Settings["WechatJsUrl"].Value;
            JsConfig.WechatJsToken = appsection.Settings["WechatJsToken"].Value;
            JsConfig.WechatJsDomain = appsection.Settings["WechatJsDomain"].Value;
            JsConfig.WechatJsReturnDomain = appsection.Settings["WechatJsReturnDomain"].Value;
            JsConfig.WechatJsTicket = appsection.Settings["WechatJsTicket"].Value;
            JsConfig.WechatJsTicketExpiredTime = appsection.Settings["WechatJsTicketExpiredTime"].Value;



            return JsConfig;
        }

        public static WebchatJsUserinfo GetUserInfo(string userAgent, string CODE)
        {
            WechatConfig wechatconfig = AccessTokenService.GetWechatConfig();
            WebchatJsUserinfo userinfo = new WebchatJsUserinfo();
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + wechatconfig.Appid + "&secret=" + wechatconfig.AppSecret + "&code=" + CODE + "&grant_type=authorization_code";
       
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, userAgent, null);

            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();

            WechatJsToken token = JsonConvert.DeserializeObject<WechatJsToken>(result);


            string url2 = "https://api.weixin.qq.com/sns/userinfo?access_token=" + token.access_token + "&openid=" + token.openid + "&lang=zh_CN";

            HttpWebResponse res = HttpWebResponseUtility.CreateGetHttpResponse(url2, null, userAgent, null);
            Stream stream2 = res.GetResponseStream();
            StreamReader sr2 = new StreamReader(stream2);
            string result2 = sr2.ReadToEnd();

            userinfo = JsonConvert.DeserializeObject<WebchatJsUserinfo>(result2);

            return userinfo;
        
        }
      
    }
}