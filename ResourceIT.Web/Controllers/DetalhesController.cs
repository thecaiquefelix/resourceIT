using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResourceIT.Domain;
using ResourceIT.Infra.DataContext;

namespace ResourceIT.Web.Controllers
{
    public class DetalhesController : Controller
    {
        private ResourceITDataContext db = new ResourceITDataContext();

        public ActionResult Index()
        {
            return View(db.Detalhes.ToList());
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalhe detalhe = db.Detalhes.Find(id);
            if (detalhe == null)
            {
                return HttpNotFound();
            }
            return View(detalhe);
        }

        public ActionResult Inclusao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inclusao([Bind(Include = "Id,Telefone,Endereco")] Detalhe detalhe)
        {
            if (ModelState.IsValid)
            {
                db.Detalhes.Add(detalhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalhe);
        }

        public ActionResult Alteracao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalhe detalhe = db.Detalhes.Find(id);
            if (detalhe == null)
            {
                return HttpNotFound();
            }
            return View(detalhe);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alteracao([Bind(Include = "Id,Telefone,Endereco")] Detalhe detalhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalhe);
        }

        public ActionResult Exclusao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalhe detalhe = db.Detalhes.Find(id);
            if (detalhe == null)
            {
                return HttpNotFound();
            }
            return View(detalhe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Exclusao(int id)
        {
            Detalhe detalhe = db.Detalhes.Find(id);
            db.Detalhes.Remove(detalhe);
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
