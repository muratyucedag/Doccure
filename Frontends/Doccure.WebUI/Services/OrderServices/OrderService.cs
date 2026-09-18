using Doccure.WebUI.Dtos.OrderDtos;
using Newtonsoft.Json;

namespace Doccure.WebUI.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ResultOrderDto>> GetAllOrdersAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7153/api/Orders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7153/api/Orders/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdOrderDto>(jsonData);
            return value;
        }
    }
}