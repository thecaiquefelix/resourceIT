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
    public class UsuariosController : Controller
    {
        private ResourceITDataContext db = new ResourceITDataContext();
        
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Detalhe);
            return View(usuarios.ToList());
        }
        
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        
        public ActionResult Inclusao()
        {
            ViewBag.DetalheId = new SelectList(db.Detalhes, "Id", "Telefone");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inclusao([Bind(Include = "Id,Nome,Sobrenome,Email,DetalheId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DetalheId = new SelectList(db.Detalhes, "Id", "Telefone", usuario.DetalheId);
            return View(usuario);
        }


        public ActionResult Alteracao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.DetalheId = new SelectList(db.Detalhes, "Id", "Telefone", usuario.DetalheId);
            return View(usuario);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alteracao([Bind(Include = "Id,Nome,Sobrenome,Email,DetalheId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DetalheId = new SelectList(db.Detalhes, "Id", "Telefone", usuario.DetalheId);
            return View(usuario);
        }


        public ActionResult Exclusao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Exclusao(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
