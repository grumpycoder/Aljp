namespace Aljp.Domain.Entities;

public class ProductLine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Rating { get; set; }
    public string ProductLineUrl { get; set; }
    
    private ICollection<Vendor> Vendors { get; set; }
}