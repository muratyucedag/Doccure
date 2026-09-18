using Doccure.WebUI.Dtos.OrderDtos;

namespace Doccure.WebUI.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrdersAsync();
        Task<GetByIdOrderDto> GetByIdOrderAsync(int id);
    }
}
