namespace FarmaApi2.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}
