using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurs_final.Models
{
    public class Doctor
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Telephone { get; set; }

        public string Adress { get; set; }
    }
}
