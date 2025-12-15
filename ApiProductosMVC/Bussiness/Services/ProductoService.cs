using ApiProductosMVC.Bussiness.Interfaces;
using ApiProductosMVC.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProductosMVC.Bussiness.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IConfiguration _config;


        public ProductoService(IConfiguration config)
        => _config = config;

        private IDbConnection Connection =>
            new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public void InsertarProducto(Producto producto)
        {
            using var db = Connection;

            db.Execute(
                "sp_InsertarProducto",
                new
                {
                    producto.Id,
                    producto.Nombre,
                    producto.Stock,
                    producto.Precio
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public IEnumerable<ReporteInventarioDto> ObtenerReporte()
        {
            using var db = Connection;

            return db.Query<ReporteInventarioDto>(
                "sp_ReporteInventario",
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
