using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerApplication.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomerApplication.Models.CustomerApplicationContext _context;

        public IndexModel(CustomerApplication.Models.CustomerApplicationContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Names { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CustomerNames { get; set; }

       

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genderQuery = from m in _context.Customer
                                            orderby m.Name
                                            select m.Name;

            var customers = from m in _context.Customer
                         select m;
            if (!String.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.Name.Contains(SearchString));
            }
            if (!String.IsNullOrEmpty(CustomerNames))
            {
                customers = customers.Where(x => x.Gender == CustomerNames);
            }

            Names = new SelectList(await genderQuery.Distinct().ToListAsync());
            Customer = await customers.ToListAsync();

        }
    }
}
