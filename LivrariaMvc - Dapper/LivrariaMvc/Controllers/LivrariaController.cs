using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using LivrariaMvc.Models;

namespace LivrariaMvc.Controllers
{
    public class LivrariaController : Controller
    {
        IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LivrariaConnection"].ConnectionString);

        // GET: Livraria
        public ActionResult Index()
        {
            List<Livraria> FriendList = new List<Livraria>();

            FriendList = db.Query<Livraria>("Select * From Livraria").ToList();

            return View(FriendList);
        }

        // GET: Livraria/Details/5
        public ActionResult Details(int id)
        {
            Livraria _livraria = new Livraria();
            _livraria = db.Query<Livraria>("Select * From Livraria " +
                                         "WHERE LivrariaID =" + id, new { id }).SingleOrDefault();
            return View(_livraria);
        }

        // GET: Livraria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livraria/Create
        [HttpPost]
        public ActionResult Create(Livraria _livraria)
        {
            /*
             
             Lembrete: Vanessa

             Observação: para corrigir a leitura correto do campo decimal permitindo virgulas, eu alterei o web.config, o BundleConfig.cs e o arquivo: jquery.validate.js
             
             web.config:
               <system.web>
                <globalization culture="pt-BR" uiCulture="pt-BR" enableClientBasedCulture="true"/>

             jquery.validate.js:
             		number: function( value, element ) {
			            return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)?(?:,\d+)?$/.test(value);
		            },

             BundleConfig.cs:
                bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                            "~/Scripts/jquery.unobtrusive*",
                            "~/Scripts/jquery.validate*",
                            "~/Scripts/methods_pt.js"));


             */
            string sqlQuery = "Insert Into Livraria (Nome, Autor, Preco) Values ";
                   sqlQuery += String.Format(CultureInfo.InvariantCulture, " ('{0}', '{1}', {2:0.00} ) ", 
                               _livraria.Nome, _livraria.Autor, _livraria.Preco);

            int rowsAffected = db.Execute(sqlQuery);

            return RedirectToAction("Index");
        }


        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            Livraria _livraria = new Livraria();

            _livraria = db.Query<Livraria>("Select * From Livraria " +
                                    "WHERE LivrariaID =" + id, new { id }).SingleOrDefault();
            return View(_livraria);
        }

        // POST: Livraria/Edit/5
        [HttpPost]
        public ActionResult Edit(Livraria _livraria)
        {

            string sqlQuery = "update Livraria set ";
            sqlQuery += String.Format(CultureInfo.InvariantCulture, "Nome='{0}', Autor='{1}',Preco={2:0.00} where LivrariaID={4}",
                            _livraria.Nome, _livraria.Autor, _livraria.Preco, _livraria.Imagem, _livraria.LivrariaID);

            int rowsAffected = db.Execute(sqlQuery);

            return RedirectToAction("Index");
        }

        // GET: Livraria/Delete/5
        public ActionResult Delete(int id)
        {
            Livraria _livraria = new Livraria();

            _livraria = db.Query<Livraria>("Select * From Livraria " +
                                       "WHERE LivrariaID =" + id, new { id }).SingleOrDefault();
            return View(_livraria);
        }

        // POST: Livraria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string sqlQuery = "Delete From Livraria WHERE LivrariaID = " + id;

            int rowsAffected = db.Execute(sqlQuery);

            return RedirectToAction("Index");
        }


        // POST: Livraria/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// POST: Livraria/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// POST: Livraria/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

