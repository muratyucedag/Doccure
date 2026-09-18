using Doccure.WebUI.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrdersAsync();
            return View(values);
        }
        public async Task<IActionResult> OrderDetail(int id)
        {
            var value = await _orderService.GetByIdOrderAsync(id);
            return View(value);
        }
    }
}
