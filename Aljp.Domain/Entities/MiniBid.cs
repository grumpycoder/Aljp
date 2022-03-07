using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

public class MiniBid : DomainEntity
{
    public string ProjectTitle { get; set; } = string.Empty;
    public string DistrictName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}