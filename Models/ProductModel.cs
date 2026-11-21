namespace ServiceLog.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; }
    }
}
