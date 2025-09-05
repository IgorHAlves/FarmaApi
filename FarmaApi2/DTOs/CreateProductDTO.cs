namespace FarmaApi2.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
