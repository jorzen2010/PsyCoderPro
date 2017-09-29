using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace Wechat
{
    public class AccessTokenService
    {
        //获取accesstoken
        public static string GetAccessToken()
        {

            string access_token = "";

            WechatConfig wechatConfig = AccessTokenService.GetWechatConfig();

            if (DateTime.Now < DateTime.Parse(wechatConfig.AccessTokenExpiredTime))
            {
                access_token = wechatConfig.AccessToken;
            }
            else
            {
                access_token = AccessTokenService.RefrenshToken(wechatConfig.Appid, wechatConfig.AppSecret);

            }
            return access_token;
        }

        //刷新accesstoken
        public static string  RefrenshToken(string appid, string appsecret)
        {
            string userAgent = System.Web.HttpContext.Current.Request.UserAgent;
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, appsecret);

            HttpWebResponse res = WechatHttpWebResponseUtility.CreateGetHttpResponse(url, null, userAgent, null);
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();

            WechatAccessToken token = new WechatAccessToken();
            token = JsonConvert.DeserializeObject<WechatAccessToken>(result);
            string access_token = token.access_token;

            if (string.IsNullOrEmpty(token.access_token))
            {
                WechatError err = new WechatError();
                err = JsonConvert.DeserializeObject<WechatError>(result);
                access_token = "appid或者appsecret错误，无法获取access_token 微信错误代码：" + err.errcode + "微信错误信息：" + err.errmsg;
                WechatLogHelper.Error(access_token);
            }
            else
            {
                ConfigTools.WriteKey("WechatAccessToken", access_token);
                ConfigTools.WriteKey("WechatAccessTokenExpiredTime", System.DateTime.Now.AddMinutes(115).ToString("yyyy-MM-dd HH:mm:ss"));

            }
            return access_token;
        }

        public static WechatConfig GetWechatConfig()
        {

            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appsection = config.GetSection("appSettings") as AppSettingsSection;


            WechatConfig wechatConfig = new WechatConfig();

            wechatConfig.Appid = appsection.Settings["WechatAppID"].Value;
            wechatConfig.AppSecret = appsection.Settings["WechatAppSecret"].Value;
            wechatConfig.AccessToken = appsection.Settings["WechatAccessToken"].Value;
            wechatConfig.AccessTokenExpiredTime = appsection.Settings["WechatAccessTokenExpiredTime"].Value;

            return wechatConfig;
        }
        
    }
}