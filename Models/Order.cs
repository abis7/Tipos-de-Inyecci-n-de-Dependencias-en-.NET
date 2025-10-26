namespace OrdersApi;

public class Order
{
   public int Id { get; set; }
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
}
