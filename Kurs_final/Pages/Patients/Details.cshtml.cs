using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kurs_final.Data;
using Kurs_final.Models;

namespace Kurs_final.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly Kurs_final.Data.Kurs_finalContext _context;

        public DetailsModel(Kurs_final.Data.Kurs_finalContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.FirstOrDefaultAsync(m => m.ID == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
