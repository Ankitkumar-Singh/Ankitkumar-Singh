﻿using AnkitSinghAssignments.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using System.Collections.Generic;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment3Controller : Controller
    {
        /// <summary>Indexes this instance.</summary>
        /// <returns> Return list view of all guest in database</returns>
        public ActionResult Index()
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            List<Guest> guest = guestBusinessLayer.Guests.ToList();
            return View(guest);            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            Guest guest = guestBusinessLayer.Guests.Single(g => g.GuestId == id);
            return View(guest);
        }

        /// <summary>Edits the specified guest.</summary>
        /// <param name="guest">The guest.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
                guestBusinessLayer.UpdateGuest(guest);
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            guestBusinessLayer.DeleteGuest(id);
            return RedirectToAction("Index");
        }

    }
}