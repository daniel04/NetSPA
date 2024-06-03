using Microsoft.EntityFrameworkCore;

namespace NetSPA.ServicesApp.Model;

public class SpaContext: DbContext
{
    public SpaContext(DbContextOptions<SpaContext> options) : base(options)
    {
    }

    //Aqui se mapean todas las clases del proyecto como tablas, EntityFramework toma lo de abajo y las mapea en la BD
    public DbSet<Producto> Producto { get; set; }
}