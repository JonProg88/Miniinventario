using Dapper;
using Microsoft.Data.SqlClient;
using MiniInventarioSolution.Domain.Entities;
using MiniInventarioSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventarioSolution.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        => _connectionString = connectionString;

        public IEnumerable<dynamic> ObtenerReporte()
        {
            using var conn = new SqlConnection(this._connectionString);

            return conn.Query(
                "sp_ReporteInventario",
                commandType : CommandType.StoredProcedure
                );
        }

        public void Crear(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);

            conn.Execute(
                "sp_InsertarProducto",
                new
                {
                    producto.Id,
                    producto.Nombre,
                    producto.Stock,
                    producto.Precio

                },
                 commandType : CommandType.StoredProcedure
                );
        }

        
    }
}
