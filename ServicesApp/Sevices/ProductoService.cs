using NetSPA.ServicesApp.Model;

namespace NetSPA.ServicesApp.Sevices;

public class ProductoService
{
    public List<Producto> GetAll()
    {
        return new List<Producto>()
        {
            new Producto(){Id = 1, Nombre = "SmartPhone", Precio = 140, Stock = 5},
            new Producto(){Id = 2, Nombre = "iPhone", Precio = 700, Stock = 10},
            new Producto(){Id = 3, Nombre = "Libro", Precio = 25, Stock = 50},
            new Producto(){Id = 4, Nombre = "Televisor", Precio = 44, Stock = 1}
        };
    }
}