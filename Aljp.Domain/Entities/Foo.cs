using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

// TODO: placeholder for Contract domain object
public class Foo: DomainEntity
{
    public string StateContractId { get; set; }
    public DateOnly AwardDate { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly ContractExpireDate { get; private set; }
    public double Discount { get; private set; }
    public DateOnly IsoExpirationDate { get; private set; }
    public string State470Number { get; private set; } = string.Empty;

    protected Foo()
    {}

    public Foo(string stateContractId, DateOnly awardDate, DateOnly startDate, DateOnly contractExpireDate, 
        DateOnly isoExpirationDate, double discount, string state470Number)
    {
        StateContractId = stateContractId; 
        AwardDate = awardDate;
        StartDate = startDate;
        ContractExpireDate = contractExpireDate;
        IsoExpirationDate = isoExpirationDate;
        Discount = discount;
        State470Number = state470Number; 
    }
    
    
}