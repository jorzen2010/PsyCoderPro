using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsyCoderCommon;
using PsyCoderDal;
using PsyCoderEntity;
using PagedList;
using PagedList.Mvc;
using PsyCoderServices;

namespace PsyCoderAdmin.Controllers

{
    public class ArticleController : BaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: /Article/
        public ActionResult Index(int? page)
        {
            Pager pager = new Pager();
            pager.table = "Article";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "ArticleId";
            pager.FiledOrder = "ArticleId desc";


            pager = CommonDal.GetPager(pager);
            IList<Article> articleList = DataConvertHelper<Article>.ConvertToModel(pager.EntityDataTable);
            var articleListAsIPageList = new StaticPagedList<Article>(articleList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(articleListAsIPageList);
        }

      

        public ActionResult Create()
        {
            Article article = new Article();
            CategoryServices categoryServices= new CategoryServices();
            ViewData["Categorylist"] = categoryServices.GetCategorySelectList(1);
            return View(article);
        }

        // POST: /Article/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.articlesRepository.Insert(article);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            CategoryServices categoryServices = new CategoryServices();
            ViewData["Categorylist"] = categoryServices.GetCategorySelectList(1);
            return View(article);
        }

        // GET: /Article/Edit/5
        public ActionResult Edit(int? id)
        {
            CategoryServices categoryServices = new CategoryServices();
            ViewData["Categorylist"] = categoryServices.GetCategorySelectList(1);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = unitOfWork.articlesRepository.GetByID(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Article/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.articlesRepository.Update(article);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // POST: /Article/Delete/5
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

                unitOfWork.articlesRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

    }
}
