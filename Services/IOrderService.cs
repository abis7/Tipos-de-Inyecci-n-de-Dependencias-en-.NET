namespace OrdersApi
{
    public interface IOrderService
    {
        void AgregarPedido(Order order);
        List<Order> ObtenerPedidos();
        Guid ObtenerInstancia();
        int ContarPedidos();
    }

    public interface ITransientOrderService : IOrderService { }
    public interface IScopedOrderService : IOrderService { }
    public interface ISingletonOrderService : IOrderService { }
}
