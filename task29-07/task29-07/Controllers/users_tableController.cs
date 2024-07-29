using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task29_07.Models;

namespace task29_07.Controllers
{
    public class users_tableController : Controller
    {
        private CRUDEntities db = new CRUDEntities();

        // GET: users_table
        public ActionResult Index()
        {
            return View(db.users_table.ToList());
        }

        // GET: users_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_table users_table = db.users_table.Find(id);
            if (users_table == null)
            {
                return HttpNotFound();
            }
            return View(users_table);
        }
        public ActionResult logIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult logIn([Bind(Include = "email,password")] users_table login_form)
        {
            var users = db.users_table.ToList();
            foreach (var items in users)
            {
                
                if (login_form.email == items.email)
                {
                    if(login_form.password == items.password)
                    {
                        Session["logedin"] = "true";
                        Session["id"] = items.id;
                        return RedirectToAction("index");
                    }
                }
            }
            return View();
        }
        public ActionResult logout()
        {
            Session["logedin"] = "false";
            return RedirectToAction("index");
        }

        // GET: users_table/Create
        public ActionResult Create()
        {
            return View();
        }
        

        // POST: users_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,password")] users_table users_table,string cofirmPassword)
        {
            
            if (ModelState.IsValid && users_table.password == cofirmPassword)
            {
                db.users_table.Add(users_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users_table);
        }

        // GET: users_table/Edit/5
        public ActionResult Edit()
        {
            if (Session["id"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_table users_table = db.users_table.Find(Session["id"]);
            if (users_table == null)
            {
                return HttpNotFound();
            }
            return View(users_table);
        }
        // POST: users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email")] users_table users_table, HttpPostedFileBase upload)
        {


            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                users_table.img = fileName;
            }

            db.Entry(users_table).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit_pass() {

            users_table users_table = db.users_table.Find(Session["id"]);
            if (users_table == null)
            {
                return HttpNotFound();
            }
            return View(users_table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_pass([Bind(Include = "password")] users_table users_table, string oldPass , string ConfirmPass)
        {
            int userId = (int)Session["id"];
            var users = db.users_table.Find(userId);

            if (users.password == oldPass)
            {
                if (users_table.password == ConfirmPass)
                {
                    users.password = users_table.password;
                    db.Entry(users).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View();

        }



        // GET: users_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_table users_table = db.users_table.Find(id);
            if (users_table == null)
            {
                return HttpNotFound();
            }
            return View(users_table);
        }

        // POST: users_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users_table users_table = db.users_table.Find(id);
            db.users_table.Remove(users_table);
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
