using ASP_Bikin.DAL;
using ASP_Bikin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Bikin.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Services services)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Add(services);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.Id == id);

            if(service==null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(service);
        }

        [HttpPost]

        public IActionResult Edit(Services services)
        {
            var service = _context.Services.FirstOrDefault(x => x.Id == services.Id);


            if (service == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            service.Icon = services.Icon;
            service.Title = services.Title;
            service.Desc = services.Desc;

            _context.SaveChanges();


            return RedirectToAction("index");
        }
    }
}
