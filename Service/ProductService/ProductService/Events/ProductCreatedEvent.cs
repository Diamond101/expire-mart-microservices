namespace ProductService.Events
{
    public class ProductCreatedEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
