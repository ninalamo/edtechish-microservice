using MediatR;

namespace edtechish.domain.SeedWork;

public abstract class DomainEntity<T> : Entity<T>, IDomainEvent 
    where T : struct, IComparable<T>, IEquatable<T>
{
    
    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    protected DomainEntity() 
    {
        _domainEvents = new List<INotification>();
    }

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

}