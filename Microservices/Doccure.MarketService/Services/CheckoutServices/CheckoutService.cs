using Doccure.MarketService.Dtos.OrderDtos;
using Doccure.MarketService.Services.CartServices;

namespace Doccure.MarketService.Services.CheckoutServices
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICartService _cartService;
        private readonly HttpClient _httpClient;
        public CheckoutService(ICartService cartService, HttpClient httpClient)
        {
            _cartService = cartService;
            _httpClient = httpClient;
        }

        public async Task<bool> CheckoutAsync(int patientId, string patientName, string blockNo, string floorNo, string roomNo)
        {
            var cartItems = await _cartService.GetCartAsync(patientId);

            if (cartItems == null || !cartItems.Any())
            {
                return false;
            }

            var orderDetails = cartItems.Select(x =>
                new CreateOrderDetailDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.Price,
                    Quantity = x.Quantity,
                    TotalPrice = x.Price * x.Quantity
                }).ToList();

            var createOrderDto = new CreateOrderDto
            {
                PatientId = patientId,
                PatientName = patientName,
                BlockNo = blockNo,
                FloorNo = floorNo,
                RoomNo = roomNo,

                TotalPrice = orderDetails.Sum(x => x.TotalPrice),
                OrderDetails = orderDetails
            };

            var response = await _httpClient.PostAsJsonAsync("api/orders", createOrderDto);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            await _cartService.ClearCartAsync(patientId);

            return true;
        }
    }
}
