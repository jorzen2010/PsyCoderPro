using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using PsyCoderCommon;
namespace PsyCoderWechat.WechatServices
{
    public class WechatMaterialServices
    {
        public static string GetMaterialList(string access_token, string postdata)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}", access_token);

            string result = HttpWebResponseUtility.PostJsonData(url, postdata);

            return result;

        }

    }

}