using Microsoft.AspNetCore.Mvc;
using MiniInventarioSolution.Application.DTOs;
using MiniInventarioSolution.Application.Services;

namespace MiniInventarioSolution.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : Controller
    {
        private readonly ProductoService _service;
       
        public ProductosController(ProductoService service)
        => _service = service;

        [HttpPost]
        public IActionResult Crear([FromBody] ProductoRequest request)
        {
            _service.CrearProducto(request);
            return Ok("Producto creado");
        }

        [HttpGet("reporte")]
        public IActionResult Reporte()
            => Ok(_service.ReporteInventario());

    }
}
