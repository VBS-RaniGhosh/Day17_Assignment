using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day17AssignmentOfToday.Models;

namespace Day17AssignmentOfToday.Controllers
{
    public class Friend_RaniController : Controller
    {
        private AdventureWorks2017Entities db = new AdventureWorks2017Entities();

        // GET: Friend_Rani
        public ActionResult Index()
        {
            return View(db.Friend_Rani.ToList());
        }

        // GET: Friend_Rani/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_Rani friend_Rani = db.Friend_Rani.Find(id);
            if (friend_Rani == null)
            {
                return HttpNotFound();
            }
            return View(friend_Rani);
        }

        // GET: Friend_Rani/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend_Rani/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,FriendName,Place")] Friend_Rani friend_Rani)
        {
            if (ModelState.IsValid)
            {
                db.Friend_Rani.Add(friend_Rani);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend_Rani);
        }

        // GET: Friend_Rani/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_Rani friend_Rani = db.Friend_Rani.Find(id);
            if (friend_Rani == null)
            {
                return HttpNotFound();
            }
            return View(friend_Rani);
        }

        // POST: Friend_Rani/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,FriendName,Place")] Friend_Rani friend_Rani)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend_Rani).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend_Rani);
        }

        // GET: Friend_Rani/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_Rani friend_Rani = db.Friend_Rani.Find(id);
            if (friend_Rani == null)
            {
                return HttpNotFound();
            }
            return View(friend_Rani);
        }

        // POST: Friend_Rani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend_Rani friend_Rani = db.Friend_Rani.Find(id);
            db.Friend_Rani.Remove(friend_Rani);
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
