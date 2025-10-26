using Microsoft.AspNetCore.Mvc;
using OrdersApi;

namespace MyApp.Namespace
{
    [Route("api/transient/orders")]
    [ApiController]
    public class TransientOrdersController : ControllerBase
    {
        private readonly ITransientOrderService _orderService;

        public TransientOrdersController(ITransientOrderService orderService)
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
