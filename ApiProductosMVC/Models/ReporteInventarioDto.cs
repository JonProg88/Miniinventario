namespace ApiProductosMVC.Models
{
    public class ReporteInventarioDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public decimal ValorInventario { get; set; }
    }
}
