using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FVTS.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace FVTS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SystemController : Controller
    {
        private FVTSEntities db = new FVTSEntities();

        #region Default Actions
        //
        // GET: /System/

        public ActionResult Index()
        {
            return View(GetDefinitionAll());
        }

        //
        // GET: /System/Details/5

        public ActionResult Details(int id = 0)
        {
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        //
        // GET: /System/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /System/Create

        [HttpPost]
        public ActionResult Create(DefinitionModel model)
        {
            if (ModelState.IsValid)
            {
                Definition target = new Definition();
                target.displayName = model.displayName;
                target.keyName = model.keyName;
                target.keyValue = model.keyValue;
                target.keyGroup = model.keyGroup;
                if (model.sequence == null || model.sequence < 1)
                {
                    model.sequence = 1;
                }
                target.sequence = model.sequence;
                db.Definitions.Add(target);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /System/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        //
        // POST: /System/Edit/5

        [HttpPost]
        public ActionResult Edit(Definition definition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(definition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(definition);
        }

        //
        // GET: /System/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Definition definition = db.Definitions.Find(id);
            if (definition == null)
            {
                return HttpNotFound();
            }
            return View(definition);
        }

        //
        // POST: /System/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Definition definition = db.Definitions.Find(id);
            db.Definitions.Remove(definition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion Default Actions

        #region Ajax Model

        public ActionResult CreateDefinition(DefinitionModel model)
        {
            Definition target = new Definition();
            target.displayName = model.displayName;
            target.keyName = model.keyName;
            target.keyValue = model.keyValue;
            target.keyGroup = model.keyGroup;
            target.sequence = model.sequence;
            db.Definitions.Add(target);
            db.SaveChanges();

            return RedirectToAction("Index", "System");
        }

        public ActionResult Definition_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDefinitionAll().ToDataSourceResult(request));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Definition_Update([DataSourceRequest] DataSourceRequest request, DefinitionModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                {
                    var target = db.Definitions.Find(model.definitionId);
                    target.displayName = model.displayName;
                    target.keyName = model.keyName;
                    target.keyValue = model.keyValue;
                    target.keyGroup = model.keyGroup;
                    target.sequence = model.sequence;
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(ModelState.ToDataSourceResult());
        }

        #endregion

        #region Support Methods

        private IEnumerable<DefinitionModel> GetDefinitionAll()
        {

            return db.Definitions.Select(model => new DefinitionModel
            {
                definitionId = model.definitionId,
                displayName = model.displayName,
                keyName = model.keyName,
                keyValue = model.keyValue,
                keyGroup = model.keyGroup,
                sequence = model.sequence
            });
        }


        private IEnumerable<DefinitionModel> GetDefinitionByGroup(string groupName)
        {

            return db.Definitions.Where(m => m.keyGroup == groupName).Select(model => new DefinitionModel
            {
                definitionId = model.definitionId,
                displayName = model.displayName,
                keyName = model.keyName,
                keyValue = model.keyValue,
                keyGroup = model.keyGroup,
                sequence = model.sequence
            });
        }

        private IEnumerable<DefinitionModel> GetDefinitionByGroupAndSequence(string groupName)
        {

            return db.Definitions.OrderBy(m => m.sequence).Where(m => m.keyGroup == groupName).Select(model => new DefinitionModel
            {
                definitionId = model.definitionId,
                displayName = model.displayName,
                keyName = model.keyName,
                keyValue = model.keyValue,
                keyGroup = model.keyGroup,
                sequence = model.sequence
            });
        }

        public ActionResult QuickSearchGroupName()
        {
            string searchValue = Request.Params["filter[filters][0][value]"];
            var result = db.Definitions.Where(d => d.keyGroup.Contains(searchValue)).Select(model => new DefinitionModel
            {
                keyGroup = model.keyGroup
            }).Distinct().Take(10);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}