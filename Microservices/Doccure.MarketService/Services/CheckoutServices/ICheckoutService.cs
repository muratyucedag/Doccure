namespace Doccure.MarketService.Services.CheckoutServices
{
    public interface ICheckoutService
    {
        Task<bool> CheckoutAsync(int patientId, string patientName, string blockNo, string floorNo, string roomNo);
    }
}
