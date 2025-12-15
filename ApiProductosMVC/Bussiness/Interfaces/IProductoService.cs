using ApiProductosMVC.Models;

namespace ApiProductosMVC.Bussiness.Interfaces
{
    public interface IProductoService
    {
        void InsertarProducto(Producto producto);
        IEnumerable<ReporteInventarioDto> ObtenerReporte();
    }
}
