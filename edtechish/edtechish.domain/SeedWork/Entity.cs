using System.Diagnostics;
using MediatR;

namespace edtechish.domain.SeedWork;

public abstract class Entity<T> where T : struct, IComparable<T>, IEquatable<T>
{
    int? _requestedHashCode;
    T _Id;
    public virtual T Id
    {
        get => _Id;
        protected set => _Id = value;
    }

    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

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

    public bool IsTransient()
    {
        var type = typeof(T);

        if (type == typeof(int))
        {
            if (int.TryParse(this.Id.ToString(), out var ret))
            {
                return ret == default;
            }
        }else if (type == typeof(string))
        {
            return this.Id.ToString() == default;
        }else if (type == typeof(char))
        {
            if (char.TryParse(this.Id.ToString(), out var ret))
            {
                return ret == default;
            }
        }else if (type == typeof(object))
        {
            return false;
        }

        return false;
    }
    
   
    public override bool Equals(object obj)
    {
        if (obj is not Entity<T> item)
            return false;

        if (object.ReferenceEquals(this, item))
            return true;

        if (this.GetType() != item.GetType())
            return false;

        if (item.IsTransient() || this.IsTransient())
            return false;
        else
            return item.Id as object == this.Id as object;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            _requestedHashCode ??= this.Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }
        else
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();

    }
    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        if (left == null)
            return (object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !(left == right);
    }
}