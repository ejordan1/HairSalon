using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;
using System;
namespace HairSalon.Controllers{

    public class StylistController : Controller
    {
        private readonly HairSalonContext _db;
        public StylistController(HairSalonContext db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            Console.WriteLine("STYLIST CONTROLLER INDEX");
            List<Stylist> model = _db.Stylists.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
             Console.WriteLine("STYLIST CONTROLLER DETAILS");
            Stylist stylist = _db.Stylists.FirstOrDefault(sty => sty.StylistId == id);
            List<Client> clientList = _db.Clients.Where(client => client.StylistId == id).ToList();
            ViewBag.clientList = clientList;
            return View(stylist);
        }
    }
}