using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using PsyCoderCommon;
using Wechat;


namespace PsyCoderWechat.Controllers
{
    public class WechatMenuController : Controller
    {
       

        public ActionResult CreateWechatMenu()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateMenu()
        {
            string postData=Request.Form["content"].Replace("\r\n","").Replace("\\","");
            string token = AccessTokenService.GetAccessToken();

            string result = WechatMenuServices.CreateMenu(token, postData);
            WechatResult wechatResult = JsonConvert.DeserializeObject<WechatResult>(result);
            if (wechatResult.errcode == 0)
            {
                ViewBag.msg = "微信菜单创建成功！菜单代码如下：";
                ViewBag.result = postData;
            }
            else
            {
                ViewBag.msg = "微信菜单创建失败！错误代码如下：";
                ViewBag.result = result;
            
            }

            return View();

        }

        public ActionResult GetWechatMenu()
        {
            string token = AccessTokenService.GetAccessToken();
            string menuStr = WechatMenuServices.GetMenu(token);
            WechatResult wechatResult = JsonConvert.DeserializeObject<WechatResult>(menuStr);
            if (wechatResult.errcode != 0)
            {
                ViewBag.msg = "此公众号目前没有菜单！返回错误代码如下：";
            }
            else
            {
                ViewBag.msg = "成功获取到菜单内容！菜单代码如下：";          
            }
            ViewBag.content = menuStr;

            return View();
        
        }

        public ActionResult DeleteWechatMenu()
        {
            string token = AccessTokenService.GetAccessToken();
            string result = WechatMenuServices.DeleteMenu(token);
            ViewBag.result = result;
            WechatResult wechatResult = JsonConvert.DeserializeObject<WechatResult>(result);
            if (wechatResult.errcode == 0)
            {
                ViewBag.msg = "删除成功！";
            }
            else
            {
                ViewBag.msg = "删除失败！";
            
            }
            return View();

        }


	}
}