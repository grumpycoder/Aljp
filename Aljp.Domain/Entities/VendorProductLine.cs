namespace Aljp.Domain.Entities;

public class VendorProductLine
{
    // public int Id { get; set; }
    public Vendor Vendor { get; set; }
    public ProductLine ProductLine { get; set; }
    
    public int VendorId { get; set; }
    public int ProductLineId { get; set; }

    protected VendorProductLine()
    {   
    }
}