using iTep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTep.Controllers
{
    public class InvitationsController : Controller
    {

        private InvitationContext db = new InvitationContext();

        // GET: Invitations
        public ActionResult Index()
        {
            return View();
        }
        

        // GET: Invitations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invitations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invitations/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invitations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invitations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
