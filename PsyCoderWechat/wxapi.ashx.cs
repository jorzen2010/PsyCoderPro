using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using PsyCoderCommon;
using PsyCoderWechat.WechatServices;


namespace PsyCoderWechat
{
    /// <summary>
    /// wxapi 的摘要说明
    /// </summary>
    public class wxapi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string postString = string.Empty;
            if (System.Web.HttpContext.Current.Request.RequestType == "POST")
            {
                //StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Request.InputStream);
                //string xmlData = reader.ReadToEnd();
                //WechatService.Excute(xmlData);

                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                }

                if (!string.IsNullOrEmpty(postString))
                {
                    WechatService.Excute(postString);
                }
               

            }
            else
            {
                //微信接入的测试
                WechatService.Auth();
            
            }

           



        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}