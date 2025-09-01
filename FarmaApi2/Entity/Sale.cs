using Microsoft.AspNetCore.Mvc;

namespace FarmaApi2.Entity
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }

    }
}
