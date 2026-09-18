namespace Doccure.MarketService.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
