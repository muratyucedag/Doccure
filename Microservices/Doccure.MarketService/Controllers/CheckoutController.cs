using Doccure.MarketService.Services.CheckoutServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.MarketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int patientId, string patientName, string blockNo, string floorNo, string roomNo)
        {
            var result = await _checkoutService.CheckoutAsync(patientId, patientName, blockNo, floorNo, roomNo);

            if (!result)
            {
                return BadRequest("Sipariş oluşturulamadı veya sepet boş.");
            }

            return Ok("Sipariş başarıyla oluşturuldu.");
        }
    }
}
