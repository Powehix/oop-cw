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

namespace Kurs_final.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Kurs_final.Data.Kurs_finalContext _context;

        public IndexModel(Kurs_final.Data.Kurs_finalContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PatientStatus { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> statusQuery = from m in _context.Patient
                                             orderby m.Status
                                             select m.Status;

            var patients = from m in _context.Patient
                           select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                patients = patients.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(PatientStatus))
            {
                patients = patients.Where(x => x.Status == PatientStatus);
            }

            Status = new SelectList(await statusQuery.Distinct().ToListAsync());
            Patient = await _context.Patient.ToListAsync();
        }
    }
}
