namespace edtechish.domain.SeedWork;

public abstract class Entity<T> where T : struct, IComparable<T>, IEquatable<T>
{
    T _id;
    public virtual T Id
    {
        get => _id;
        protected set => _id = value;
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
            return string.IsNullOrEmpty(this.Id.ToString());
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

        if (ReferenceEquals(this, item))
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
        if (IsTransient())
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return GetHashCode();
        else
        {
            int? _requestedHashCode = null;

            _requestedHashCode = this.Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }
    }
    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        return left == null ? Equals(right, objB: null) : left.Equals(right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !(left == right);
    }
}