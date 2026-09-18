namespace Doccure.WebUI.Dtos.OrderDtos
{
    public class GetByIdOrderDto
    {
        public int OrderId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public List<ResultOrderDetailDto> OrderDetails { get; set; }
    }
}
