using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using PsyCoderCommon;
using PsyCoderWechat.WechatServices;
using PsyCoderEntity.WechatEntity;

namespace PsyCoderWechat.Controllers
{
    public class WechatMessageController : Controller
    {
        //
        // GET: /WechatMessage/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TempletMessage()
        {
            return View();
        
        }
        public ActionResult SendTempletMessage()
        {
            WechatTemplateMessage msgData = new WechatTemplateMessage
            {
                touser = "oChqYt1b0t1U2_b_U9ag1JQyrebM",
                template_id = "KqDQm6LejvmNDrTWIQuRYoflIpi7JKgvUNsQfqf8i70",
                url = "http://www.baidu.com",
                data = new
                {

                    welcome = new
                    {
                        value = "宝贝，你好，训练时间到了",
                        color = "#173177"
                    },
                    first = new
                    {
                        value = "踢皮球运动",
                        color = "#173177"
                    },
                    second = new
                    {
                        value = "30分钟",
                        color = "#173177"
                    }
                }
            };

            string access_token = AccessTokenService.GetAccessToken();
            string postdata = JsonConvert.SerializeObject(msgData);

            string result = WechatMessageServices.SendTempletMessge(access_token, postdata);

            WechatResult wechatResult = JsonConvert.DeserializeObject<WechatResult>(result);
            if (wechatResult.errcode == 0)
            {
                ViewBag.msg = "模板消息发送成功！操作代码如下：";
                ViewBag.result = result;
            }
            else
            {
                ViewBag.msg = "模板消息发送失败！错误代码如下：";
                ViewBag.result = result;

            }

            return View();
        }
	}
}