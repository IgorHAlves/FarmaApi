using Microsoft.AspNetCore.Mvc;

namespace FarmaApi2.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }

    }
}
