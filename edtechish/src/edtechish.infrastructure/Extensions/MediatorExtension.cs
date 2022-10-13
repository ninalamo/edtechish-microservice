using edtechish.domain.SeedWork;
using MediatR;

namespace edtechish.infrastructure.Extensions;

static class MediatorExtension
{
    public static async Task DispatchDomainEventAsync(this IMediator mediator, DataContext context)
    {
        var domainEntities = context.ChangeTracker.Entries<IDomainEvent>()
            .Where(x => x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    
    }
}