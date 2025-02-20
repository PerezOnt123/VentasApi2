// Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentasAPI.Data;
using VentasAPI.Models;

namespace VentasAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VentasContext _context;

        public IndexModel(VentasContext context)
        {
            _context = context;
        }

        public IList<Venta> Ventas { get; set; }

        public async Task OnGetAsync()
        {
            Ventas = await _context.Ventas.ToListAsync();
        }
    }
}