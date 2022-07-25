using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kurs_final.Models
{
    public class Patient
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [Range(1, 500)]
        public string Chamber { get; set; }

        [Required]
        public string Telephone { get; set; }

        public string Adress { get; set; }
        public string Status { get; set; }
        public string Doctor { get; set; }
    }
}
