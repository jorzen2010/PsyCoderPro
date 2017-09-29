using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;


namespace Wechat
{
    public class WechatApi
    {
        public static WechatUserInfo GetUserInfo(string access_token, string userAgent,string openid)
        {
            WechatUserInfo userinfo = new WechatUserInfo();

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", access_token,openid);

            HttpWebResponse response = WechatHttpWebResponseUtility.CreateGetHttpResponse(url, null, userAgent, null);

            string result = WechatHttpWebResponseUtility.HttpResponseToString(response);
            userinfo = JsonConvert.DeserializeObject<WechatUserInfo>(result);

            return userinfo;
        
        }
    }
}