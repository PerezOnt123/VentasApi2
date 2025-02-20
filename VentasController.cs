using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VentasAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace VentasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private static List<Venta> _ventas = new List<Venta>
        {
            new Venta { Folio = "V001", Fecha = DateTime.Now, Cantidad = 2, Total = 1000 },
            new Venta { Folio = "V002", Fecha = DateTime.Now.AddDays(-1), Cantidad = 1, Total = 500 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Venta>> GetVentas()
        {
            return _ventas;
        }

        [HttpGet("{folio}")]
        public ActionResult<Venta> GetVenta(string folio)
        {
            var venta = _ventas.FirstOrDefault(v => v.Folio == folio);
            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        [HttpPost]
        public ActionResult<Venta> PostVenta(Venta venta)
        {
            _ventas.Add(venta);
            return CreatedAtAction(nameof(GetVenta), new { folio = venta.Folio }, venta);
        }

        [HttpPut("{folio}")]
        public IActionResult PutVenta(string folio, Venta venta)
        {
            var existingVenta = _ventas.FirstOrDefault(v => v.Folio == folio);
            if (existingVenta == null)
            {
                return NotFound();
            }

            existingVenta.Fecha = venta.Fecha;
            existingVenta.Cantidad = venta.Cantidad;
            existingVenta.Total = venta.Total;

            return NoContent();
        }

        [HttpDelete("{folio}")]
        public IActionResult DeleteVenta(string folio)
        {
            var venta = _ventas.FirstOrDefault(v => v.Folio == folio);
            if (venta == null)
            {
                return NotFound();
            }

            _ventas.Remove(venta);
            return NoContent();
        }
    }
}