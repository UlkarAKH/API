namespace ProductsApi.Data
{
    public class Category
    {
        public int ProductCategoryId { get; set; }
        public string? ProductCategoryname { get; set; }
        public List<Product>? Products { get; set; }
    }
}
