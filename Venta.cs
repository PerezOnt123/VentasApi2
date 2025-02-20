using System;

namespace VentasAPI.Models
{
    public class Venta
    {
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public double Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
