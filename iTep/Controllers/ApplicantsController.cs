using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTep.Models;

namespace iTep.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicantContext db = new ApplicantContext();

        // GET: Applicants
        public ActionResult Index()
        {
            List<Applicant> apps = db.Applicants.ToList();

            foreach(var a in apps)
            {
                //if (a.gradesEntered())
                //{
                    a.calculateAll();
                    a.name = GetName(a.Id);
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                //}
            }

            return View(apps);
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestDate,TestID,Overall_Level,Grammar_Score,Grammar_Level,Listening_Score,Listening_Level,Reading_Score,Reading_Level,Writing_Score,Writing_Level,Speaking_Score,Speaking_Level")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Writing_Score,Writing_Level,Speaking_Score,Speaking_Level")]*/ Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                Applicant currentApplicant = db.Applicants.Find(applicant.Id);
                //db.Entry(applicant).State = EntityState.Modified;
                currentApplicant.Speaking_Score = applicant.Speaking_Score;
                currentApplicant.Writing_Score = applicant.Writing_Score;
                currentApplicant.calculateAll();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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

        public string GetName(int itepNum)
        {
            String queryString = "SELECT CONCAT(C.Name, ' ' , c.Surname) " +
                            "FROM dbo.Candidates as C, dbo.ItepWebhookResults as ITEP " +
                            "INNER JOIN dbo.Invitations I ON ITEP.InvitationId = I.Id " +
                            "INNER JOIN DBO.CandidateInPositions CIP ON CIP.Id = I.CandidateInPositionId " +
                            "where C.Id = CIP.CandidateId AND ITEP.Id = @p0;";
            var result = db.Database.SqlQuery<string>(queryString, itepNum).ToArray();
            string res = result[0].ToString();


            //getting the first.
            return res;
        }
    }
}
