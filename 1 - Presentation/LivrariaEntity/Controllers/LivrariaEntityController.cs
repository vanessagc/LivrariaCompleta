using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LivrariaEntity.ViewModels;
using LivrariaMvc.Domain.Interfaces.Services;
using LivrariaMvc.Domain.Models;

namespace LivrariaEntity.Controllers
{
    public class LivrariaEntityController : Controller
    {
        private readonly ILivrariaService _livrariaService;

        public LivrariaEntityController(ILivrariaService livrariaService)
        {
            _livrariaService = livrariaService;
        }
        

        // GET: LivrariaEntity
        public ActionResult Index(string PropertyName)
        {
            IEnumerable<Livraria> list;
            list = _livrariaService.ObterTodos(); //db.Livrarias.ToList();

            if (PropertyName != null)
                list = _livrariaService.ObterTodos(PropertyName);

            var LivrariaView = Mapper.Map<IEnumerable<Livraria>, IEnumerable<LivrariaViewModel>>(list);

            return View(LivrariaView);

        }

        // GET: LivrariaEntity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livraria livraria = _livrariaService.ObterPorId(id??0); // db.Livrarias.Find(id);
            if (livraria == null)
            {
                return HttpNotFound();
            }

            var LivrariaView = Mapper.Map<Livraria, LivrariaViewModel>(livraria);

            return View(LivrariaView);
        }

        // GET: LivrariaEntity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LivrariaEntity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivrariaViewModel model, HttpPostedFileBase img1)
        {
            var livraria = Mapper.Map<LivrariaViewModel, Livraria>(model);

            if (ModelState.IsValid)
            {

                if (img1 != null)
                {

                    livraria.Imagem = new byte[img1.ContentLength];
                    img1.InputStream.Read(livraria.Imagem, 0, img1.ContentLength);

                }
                _livrariaService.Adicionar(livraria);

                //db.Livrarias.Add(livraria);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: LivrariaEntity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livraria livraria = _livrariaService.ObterPorId(id??0);//db.Livrarias.Find(id);
            if (livraria == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Livraria, LivrariaViewModel>(livraria);

            return View(model);
        }

        // POST: LivrariaEntity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LivrariaViewModel model, HttpPostedFileBase img1)
        {
            var livraria = Mapper.Map<LivrariaViewModel, Livraria>(model);

            if (ModelState.IsValid)
            {

                if (img1 != null)
                {

                    livraria.Imagem = new byte[img1.ContentLength];
                    img1.InputStream.Read(livraria.Imagem, 0, img1.ContentLength);

                }

                _livrariaService.Atualizar(livraria);

                //db.Entry(livraria).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: LivrariaEntity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livraria livraria = _livrariaService.ObterPorId(id??0);

            if (livraria == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Livraria, LivrariaViewModel>(livraria);

            return View(model);
        }

        // POST: LivrariaEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livraria livraria = _livrariaService.ObterPorId(id);

            if (livraria == null)
            {
                return HttpNotFound();
            }

            _livrariaService.Remover(id);

            //db.Livrarias.Remove(livraria);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _livrariaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
