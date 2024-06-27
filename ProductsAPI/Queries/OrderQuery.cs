namespace ProductsApi.Queries
{
    public class OrderQuery
    {
        public string? Date { get; set; } = null;
        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}
