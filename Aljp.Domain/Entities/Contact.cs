using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

public class Contact: DomainEntity
{
    public string Firstname { get; private set; } = string.Empty; 
    public string Lastname { get; private set; } = string.Empty; 
    public string EmailAddress { get; private set; } = string.Empty; 
    public string Title { get; private set; } = string.Empty; 
    public string BusinessPhone { get; private set; } = string.Empty; 
    public string MobilePhone { get; private set; } = string.Empty;

    protected Contact()
    {
        
    }

    public Contact(string firstname, string lastname, string title, string emailAddress)
    {
        Firstname = firstname;
        Lastname = lastname;
        Title = title;
        EmailAddress = emailAddress; 
    }
}