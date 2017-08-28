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
    public class IntegralController : BaseController
    {
        private SkyWebContext db = new SkyWebContext();

        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: /SysUser/Default1
        public ActionResult Index(int? page)
        {
            Pager pager = new Pager();
            pager.table = "Integral";
            pager.strwhere = "1=1";
            pager.PageSize = SkyPageSize;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "IntegralId";
            pager.FiledOrder = "IntegralId desc";

            pager = CommonDal.GetPager(pager);
            IList<Integral> integrals = DataConvertHelper<Integral>.ConvertToModel(pager.EntityDataTable);
            var integralsAsIPageList = new StaticPagedList<Integral>(integrals, pager.PageNo, pager.PageSize, pager.Amount);
            return View(integralsAsIPageList);
        }

        public ActionResult List(int? page)
        {
            Pager pager = new Pager();
            pager.table = "IntegralDetail";
            pager.strwhere = "1=1";
            pager.PageSize = SkyPageSize;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "IntegralDetailId";
            pager.FiledOrder = "IntegralDetailId desc";

            pager = CommonDal.GetPager(pager);
            IList<IntegralDetail> integralDetails = DataConvertHelper<IntegralDetail>.ConvertToModel(pager.EntityDataTable);
            var integralsAsIPageList = new StaticPagedList<IntegralDetail>(integralDetails, pager.PageNo, pager.PageSize, pager.Amount);
            return View(integralsAsIPageList);
        }

        // GET: /Integral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Integral/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IntegralId,IntegralName,IntegralValue")] Integral integral)
        {
            if (ModelState.IsValid)
            {
                db.Integrals.Add(integral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integral);
        }



        // GET: /Integral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integral integral = db.Integrals.Find(id);
            if (integral == null)
            {
                return HttpNotFound();
            }
            return View(integral);
        }

        // POST: /Integral/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IntegralId,IntegralName,IntegralValue")] Integral integral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integral);
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

                unitOfWork.integralsRepository.Delete(id);
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
