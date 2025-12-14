using MiniInventarioSolution.Application.DTOs;
using MiniInventarioSolution.Domain.Entities;
using MiniInventarioSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventarioSolution.Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
            => _productoRepository = productoRepository;

        public void CrearProducto(ProductoRequest req)
        {
          var producto = new Producto(
              Guid.NewGuid(),
              req.Nombre,
              req.Stock,
              req.Precio
           );

            _productoRepository.Crear(producto);

        }

        public IEnumerable<dynamic> ReporteInventario()
        => _productoRepository.ObtenerReporte();
    }
}
