using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

public class Vendor : DomainEntity
{
    public string CompanyName { get; private set; } = string.Empty;
    public string CompanyWebsiteUrl { get; private  set; } = string.Empty; 
    public string SpinNumber { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string PostalCode { get; private set; } = string.Empty;

    protected Vendor(){}
    
    public Vendor(string companyName, string spinNumber)
    {
        CompanyName = companyName;
        SpinNumber = spinNumber; 
    }


    public void UpdateAddress(string street, string city, string state, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode; 
    }

    public void UpdateCompany(string companyName, string companyWebsiteUrl, string spinNumber)
    {
        CompanyName = companyName;
        CompanyWebsiteUrl = companyWebsiteUrl; 
        SpinNumber = spinNumber; 
    }

    public void UpdatePhone(string phoneNumber)
    {
        PhoneNumber = phoneNumber; 
    }
}