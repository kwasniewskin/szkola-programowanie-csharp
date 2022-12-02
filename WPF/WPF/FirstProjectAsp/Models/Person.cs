using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectAsp.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Wiek osoby")]
        public int Age { get; set; }
    }
}
