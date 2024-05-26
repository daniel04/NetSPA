namespace NetSPA.ServicesApp.Model;

public class Producto
{
    public long Id { get; set; }
    
    public string? Nombre { get; set; }
    
    public double Precio { get; set; }
    
    public int Stock { get; set; }
}