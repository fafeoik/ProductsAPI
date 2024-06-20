namespace ProductsAPI.Queries
{
    public class ProductQuery
    {
        public string? Name { get; set; }

        public int? AbovePrice { get; set; }
        public int? BelowPrice { get; set; }
    }
}
