using Microsoft.AspNetCore.Mvc;
using OrdersApi;

namespace MyApp.Namespace
{
    [Route("api/singleton/orders")]
    [ApiController]
    public class SingletonOrdersController : ControllerBase
    {
        private readonly ISingletonOrderService _orderService;

        public SingletonOrdersController(ISingletonOrderService orderService)
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
