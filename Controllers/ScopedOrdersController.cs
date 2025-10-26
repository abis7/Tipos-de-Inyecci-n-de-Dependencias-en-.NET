using Microsoft.AspNetCore.Mvc;
using OrdersApi;

namespace MyApp.Namespace
{
    [Route("api/scoped/orders")]
    [ApiController]
    public class ScopedOrdersController : ControllerBase
    {
        private readonly IScopedOrderService _orderService;

        public ScopedOrdersController(IScopedOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Agregar(Order order)
        {
            _orderService.AgregarPedido(order);
            return Ok(new { Instancia = _orderService.ObtenerInstancia(), TotalPedidos = _orderService.ContarPedidos() });
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(new { Instancia = _orderService.ObtenerInstancia(), Pedidos = _orderService.ObtenerPedidos() });
        }
    }
}
