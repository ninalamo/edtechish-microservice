using edtechish.domain.SeedWork;

namespace edtechish.domain.Aggregates.PersonAggregate;

public class Person : DomainEntity<Guid>, IAggregateRoot
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? MiddleName { get; private set; }
    
    public DateTime DateOfBirth { get; private set; }

    private int _genderId;
    public Gender Gender { get; private set; }

    #region Ctor
    protected Person() : base()
    {
        
    }

    public Person(string firstName, string lastName, string middleName, DateTime dateOfBirth, int gender) : base()
    {
        SetName(firstName, lastName, middleName);
        SetDateOfBirth(dateOfBirth);
    }
    #endregion

    #region Behaviors
    public void SetName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public void SetDateOfBirth(DateTime dateOfBirth) => DateOfBirth = dateOfBirth;

    public void SetGender(Gender gender) => _genderId = gender.Id;
    
    public string GetFullName() => $"{FirstName} {MiddleName} {LastName}";

    public int GetGender => _genderId;

    #endregion



}