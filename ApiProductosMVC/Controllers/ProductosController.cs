using ApiProductosMVC.Bussiness.Interfaces;
using ApiProductosMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductosMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly IProductoService _repo;

        public ProductosController(IProductoService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult ObtenerReporte()
        {
            var data = _repo.ObtenerReporte();
            return Json(data);
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto)
        {
            producto.Id = Guid.NewGuid();
            _repo.InsertarProducto(producto);
            return Ok();
        }

    }
}
