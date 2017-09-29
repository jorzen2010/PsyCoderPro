using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wechat;

namespace PsyCoderWechat.Controllers
{
    public class WechatMaterialController : Controller
    {
        //
        // GET: /WechatMaterial/
        public ActionResult TempMaterialList()
        {
            return View();
        }

        public ActionResult AddMaterial()
        {
            return View();
        }

        public ActionResult UploadMaterial()
        {
            string type = Request.Form["MaterialType"];
            
            var file = Request.Files["MaterialFile"];
            string token=AccessTokenService.GetAccessToken();

            var media_id = WechatMaterialServices.UploadForeverMedia(token, type, file.FileName, file.InputStream);
            string filename = file.FileName;
            ViewBag.filename = filename;
            ViewBag.type = type;
            ViewBag.info = media_id;
            return View();
        }
	}
}