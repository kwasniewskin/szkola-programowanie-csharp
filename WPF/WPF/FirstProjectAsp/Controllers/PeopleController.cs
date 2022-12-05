using FirstProjectAsp.DataBase.Context;
using FirstProjectAsp.DataBase.Entities;
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
        private PeopleDBContext peopleDBContext = new PeopleDBContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonDTO personDTO)
        {
            peopleDBContext.Add(new Person()
            {
                Name = personDTO.Name,
                Surname = personDTO.Surname,
                Age = personDTO.Age
            });
            peopleDBContext.SaveChanges();

            return View("Index");
        }

        public IActionResult ShowAllPersons()
        {
            List<PersonDTO> allPersonList = peopleDBContext.Persons.
                Select(p => new PersonDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Age = p.Age
                })
                .ToList();

            return View(allPersonList);
        }

        public IActionResult ViewPerson()
        {
            PersonDTO person = new PersonDTO()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 18
            };

            return View(person);
        }

        //[HttpPost]
        public IActionResult EditPerson(PersonDTO person)
        {
            return View(person);
        }
    }
}
