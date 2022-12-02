using FirstProjectAsp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectAsp.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewPerson()
        {
            Person person = new Person()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 18
            };

            return View(person);
        }

        public IActionResult EditPerson(Person person)
        {


            return View();
        }
    }
}
