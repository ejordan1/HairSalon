using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
namespace HairSalon.Controllers
{
    public class ClientController : Controller {

        private readonly HairSalonContext _db;

        public ClientController(HairSalonContext db){
            _db = db;
        }

        // public ActionResult Index (int clientId)
        // {
        //     Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == clientId);
           
        //     return View(thisClient);
        // }

        public ActionResult Create(int id)
        {
            Console.WriteLine("STYLIST ID ARGUMENT: " + id);
            Stylist s =_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            Console.WriteLine(s.StylistId);
            return View(_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id));
        }

        //this pathing could be improved
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
} 