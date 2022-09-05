   namespace ProductsApi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? State { get; set; }
        public bool isDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
