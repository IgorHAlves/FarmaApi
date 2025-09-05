namespace FarmaApi2.DTOs
{
    public class CreateSaleDTO
    {
        public Guid ProductId { get; set; }

        public Guid ClientId { get; set; }

        public int Amount { get; set; }
    }
}
