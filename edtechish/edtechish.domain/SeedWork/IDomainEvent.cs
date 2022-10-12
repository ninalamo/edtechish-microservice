using MediatR;

namespace edtechish.domain.SeedWork;

public interface IDomainEvent
{
    public void AddDomainEvent(INotification eventItem);
    public void RemoveDomainEvent(INotification eventItem);
    public void ClearDomainEvents();
}