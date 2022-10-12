using edtechish.domain.SeedWork;

namespace edtechish.domain.Aggregates.PersonAggregate;

public class Gender : Enumeration
{
    public Gender(int id, string name) : base(id, name)
    {
    }
}