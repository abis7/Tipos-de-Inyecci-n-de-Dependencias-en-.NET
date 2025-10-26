namespace OrdersApi
{
    public class OrderService : ITransientOrderService, IScopedOrderService, ISingletonOrderService
    {
        private readonly Guid _idInstancia;
        private readonly List<Order> _pedidos = new();

        public OrderService()
        {
            _idInstancia = Guid.NewGuid();
        }

        public void AgregarPedido(Order order) => _pedidos.Add(order);
        public List<Order> ObtenerPedidos() => _pedidos;
        public Guid ObtenerInstancia() => _idInstancia;
        public int ContarPedidos() => _pedidos.Count;
    }
}
