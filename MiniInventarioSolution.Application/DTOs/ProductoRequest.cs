namespace MiniInventarioSolution.Application.DTOs
{
    public class ProductoRequest
    {
        public string Nombre { get; set; }
        public int Stock {  get; set; }
        public decimal Precio { get; set; }
    }
}
