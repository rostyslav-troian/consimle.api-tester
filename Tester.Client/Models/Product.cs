namespace Tester.Client.Models
{
    public class Product:Entity<Product>
    {
        public int CategoryId { get; set; }
        
        public override int GetHashCode() => Id.GetHashCode() + Name.GetHashCode() + CategoryId.GetHashCode();
    }
}
