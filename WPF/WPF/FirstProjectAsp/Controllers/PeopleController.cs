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

            return RedirectToAction("ShowAllPersons");
        }

        [HttpGet]
        public IActionResult EditPerson(int id)
        {
            PersonDTO personDTO = peopleDBContext.Persons.
                Where(x => x.Id == id).
                Select(x => new PersonDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age
                }).
                FirstOrDefault();

            return View();
        }

        [HttpPost]
        public IActionResult EditPerson(PersonDTO personDTO)
        {
            Person person = peopleDBContext.Persons.FirstOrDefault(x => x.Id == personDTO.Id);

            if (person == null)
                return NotFound();

            person.Name = personDTO.Name;
            person.Surname = personDTO.Surname;
            person.Age = personDTO.Age;
            peopleDBContext.SaveChanges();

            return RedirectToAction("ShowAllPersons");
        }

        public IActionResult DeletePerson(int id)
        {
            Person person = peopleDBContext.Persons.FirstOrDefault(x => x.Id == id);

            if (person == null)
                return NotFound();

            peopleDBContext.Persons.Remove(person);
            peopleDBContext.SaveChanges();

            return RedirectToAction("ShowAllPersons");
        }

        [HttpGet]
        public IActionResult SearchPerson([FromQuery]string name)
        {
            List<PersonDTO> newList = peopleDBContext.Persons.
                Where(x => string.IsNullOrWhiteSpace(name) || x.Name.Contains(name)).
                Select(x => new PersonDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age
                }).ToList();

            return View(newList);
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

    }
}
