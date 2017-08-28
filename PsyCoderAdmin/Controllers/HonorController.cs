using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsyCoderCommon;
using PsyCoderEntity;
using PsyCoderDal;
using PsyCoderServices;
using PagedList;
using PagedList.Mvc;

namespace PsyCoderAdmin.Controllers
{
    public class HonorController : BaseController
    {
        private SkyWebContext db = new SkyWebContext();

        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: /SysUser/Default1
        public ActionResult Index(int? page)
        {
            Pager pager = new Pager();
            pager.table = "Honor";
            pager.strwhere = "1=1";
            pager.PageSize = SkyPageSize;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "HonorId";
            pager.FiledOrder = "HonorId desc";

            pager = CommonDal.GetPager(pager);
            IList<Honor> honors = DataConvertHelper<Honor>.ConvertToModel(pager.EntityDataTable);
            var honorsAsIPageList = new StaticPagedList<Honor>(honors, pager.PageNo, pager.PageSize, pager.Amount);
            return View(honorsAsIPageList);

        }

        // GET: /Honor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        // GET: /Honor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Honor/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HonorId,HonorName,HonorInfo,HonorImg")] Honor honor)
        {
            if (ModelState.IsValid)
            {
                db.Honors.Add(honor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(honor);
        }

        // GET: /Honor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        // POST: /Honor/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HonorId,HonorName,HonorInfo,HonorImg")] Honor honor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(honor);
        }

        // GET: /Honor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            else
            {

                unitOfWork.honorsRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
