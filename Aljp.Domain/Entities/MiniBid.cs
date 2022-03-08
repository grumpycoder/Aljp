using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

public class MiniBid : DomainEntity
{
    public string ProjectTitle { get; private set; } = string.Empty;
    public string DistrictName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime? DueDate { get; private set; }

    protected MiniBid()
    {
    }

    public MiniBid(string projectTitle, string districtName, string description)
    {
        ProjectTitle = projectTitle;
        DistrictName = districtName;
        Description = description;
    }

    public void UpdateDueDate(DateTime dueDate)
    {
        DueDate = dueDate; 
    }
    
    public void Update(string projectTitle, string districtName, string description)
    {
        ProjectTitle = projectTitle;
        DistrictName = districtName;
        Description = description;
    }

}