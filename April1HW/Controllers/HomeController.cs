using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using April1HW.Models;
using MyLibrary;

namespace April1HW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            DB dB = new DB(@"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=True;");

            return View(dB.GetPeoples());
        }
       [HttpPost]
        public IActionResult Add(List<People> peoples)
        {
            DB dB = new DB(@"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=True;");
            dB.AddPeople(peoples);
            return Redirect("/home/home");
        }

    }     
}
