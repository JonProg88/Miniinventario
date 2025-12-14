using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventarioSolution.Domain.Entities
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public Producto(Guid id, 
                        string nombre, 
                        int stock, 
                        decimal precio) {
            Id = id;
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
        }


    }
}
