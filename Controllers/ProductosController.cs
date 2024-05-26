using Microsoft.AspNetCore.Mvc;
using NetSPA.ServicesApp.Model;
using NetSPA.ServicesApp.Sevices;

namespace NetSPA.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController: ControllerBase
{
    [HttpGet]
    public IEnumerable<Producto> GetAll()
    {
        var productoService = new ProductoService();
        return productoService.GetAll();
    }
}