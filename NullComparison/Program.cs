using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<NullComparison>();

public class NullComparison
{
    [Benchmark]
    public bool IsNullTrue()
    {
        Person person = null;

        return person is null;
    }
    
    [Benchmark]
    public bool IsNullFalse()
    {
        Person person = null;

        return person is not null;
    }
    
    [Benchmark]
    public bool NullEqualsTrue()
    {
        Person person = null;

        return person == null;
    }
    
    [Benchmark]
    public bool NullEqualsFalse()
    {
        Person person = null;

        return person != null;
    }
    
    [Benchmark]
    public bool NullReferenceEqualsTrue()
    {
        Person person = null;

        return ReferenceEquals(null, person);
    }
    
    [Benchmark]
    public bool NullReferenceEqualsFalse()
    {
        Person person = null;

        return ReferenceEquals(person, null);
    }
}

public class Person
{
    public string? Forename { get; init; }
    public string? Surname { get; init; }

    protected bool Equals(Person other)
    {
        return Forename == other.Forename && Surname == other.Surname;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Forename, Surname);
    }

    public static bool operator ==(Person? left, Person? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        return !Equals(left, right);
    }
}
