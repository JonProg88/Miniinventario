using Microsoft.AspNetCore.Mvc;
using MiniInventario_MVC.Models;
using System.Text;
using System.Text.Json;

namespace MiniInventario_MVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _http;

        public ProductosController(IConfiguration config)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(config["ApiSettings:BaseUrl"]!)
            };
        }

        // Vista principal
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Productos/ObtenerReporte
        [HttpGet]
        public async Task<IActionResult> ObtenerReporte()
        {
            var response = await _http.GetAsync("productos/reporte");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }

        // POST: /Productos/CrearProducto
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("productos", content);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }
    }
}
