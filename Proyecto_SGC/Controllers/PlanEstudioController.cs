using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_SGC;

namespace Proyecto_SGC.Controllers
{
    public class PlanEstudioController : Controller
    {
        private db_a82c1f_sgc db = new db_a82c1f_sgc();

        // GET: PlanEstudio
        public ActionResult Index()
        {
            return View(db.PlanEstudio.ToList());
        }

        // GET: PlanEstudio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudio planEstudio = db.PlanEstudio.Find(id);
            if (planEstudio == null)
            {
                return HttpNotFound();
            }
            return View(planEstudio);
        }

        // GET: PlanEstudio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanEstudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlanEstudio,NombrePlanEstudio")] PlanEstudio planEstudio)
        {
            if (ModelState.IsValid)
            {
                db.PlanEstudio.Add(planEstudio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planEstudio);
        }

        // GET: PlanEstudio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudio planEstudio = db.PlanEstudio.Find(id);
            if (planEstudio == null)
            {
                return HttpNotFound();
            }
            return View(planEstudio);
        }

        // POST: PlanEstudio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlanEstudio,NombrePlanEstudio")] PlanEstudio planEstudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planEstudio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planEstudio);
        }

        // GET: PlanEstudio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudio planEstudio = db.PlanEstudio.Find(id);
            if (planEstudio == null)
            {
                return HttpNotFound();
            }
            return View(planEstudio);
        }

        // POST: PlanEstudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanEstudio planEstudio = db.PlanEstudio.Find(id);
            db.PlanEstudio.Remove(planEstudio);
            db.SaveChanges();
            return RedirectToAction("Index");
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
