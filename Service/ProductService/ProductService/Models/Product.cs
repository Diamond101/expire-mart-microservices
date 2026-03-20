namespace ProductService.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
