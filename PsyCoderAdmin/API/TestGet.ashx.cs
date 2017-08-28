using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsyCoderAdmin.API
{
    /// <summary>
    /// TestGet 的摘要说明
    /// </summary>
    public class TestGet : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //首先需要判断来源
            
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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