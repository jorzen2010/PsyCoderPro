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
    public class LevelController : BaseController
    {
        private SkyWebContext db = new SkyWebContext();

        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: /SysUser/Default1
        public ActionResult Index(int? page)
        {
            Pager pager = new Pager();
            pager.table = "Level";
            pager.strwhere = "1=1";
            pager.PageSize = SkyPageSize;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "LevelId";
            pager.FiledOrder = "LevelId desc";

            pager = CommonDal.GetPager(pager);
            IList<Level> levels = DataConvertHelper<Level>.ConvertToModel(pager.EntityDataTable);
            var levelsAsIPageList = new StaticPagedList<Level>(levels, pager.PageNo, pager.PageSize, pager.Amount);
            return View(levelsAsIPageList);
        }

        // GET: /Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // GET: /Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Level/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LevelId,LevelName,LevelValue")] Level level)
        {
            if (ModelState.IsValid)
            {
                db.Levels.Add(level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(level);
        }

        // GET: /Level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = unitOfWork.levelsRepository.GetByID(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // POST: /Level/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection fc)
        {
            int id = int.Parse(fc["LevelId"]);
            Level level = unitOfWork.levelsRepository.GetByID(id);

            level.LevelName = fc["LevelName"];
            level.LevelValue = int.Parse(fc["LevelValue"]);

            if (ModelState.IsValid)
            {

                unitOfWork.levelsRepository.Update(level);
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(level);

        }

        // GET: /Level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
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

                unitOfWork.levelsRepository.Delete(id);
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
