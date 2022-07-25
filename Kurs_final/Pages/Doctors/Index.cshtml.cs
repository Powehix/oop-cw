using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kurs_final.Data;
using Kurs_final.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kurs_final.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Kurs_final.Data.Kurs_finalContext _context;

        public IndexModel(Kurs_final.Data.Kurs_finalContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Specialty { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DoctorSpecialty { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> statusQuery = from m in _context.Doctor
                                             orderby m.Specialty
                                             select m.Specialty;

            var doctors = from m in _context.Doctor
                           select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                doctors = doctors.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(DoctorSpecialty))
            {
                doctors = doctors.Where(x => x.Specialty == DoctorSpecialty);
            }

            Specialty = new SelectList(await statusQuery.Distinct().ToListAsync());
            Doctor = await _context.Doctor.ToListAsync();
        }
    }
}
