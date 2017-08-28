using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsyCoderAdmin.API
{
    /// <summary>
    /// TestPost 的摘要说明
    /// </summary>
    public class TestPost : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["name"];
            string url = context.Request.Form["url"];
            string result = "";
            try
            {
                result = context.Request.UrlReferrer.DnsSafeHost;
            }
            catch
            {
                result = "url来路不明,你想干啥";
               
            
            }

            if (string.IsNullOrEmpty(result))
            {
                result = "发生意外错误";

            }
            else
            {

                result = name + url;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
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