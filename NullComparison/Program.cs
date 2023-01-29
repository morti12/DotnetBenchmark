using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<NullComparison>();

public class NullComparison
{
    public static string? stringValue;
    public static bool boolValue;
    public static Person? nullPerson;
    public static Person? objectPerson;

    [GlobalSetup]
    public static void InitalizeValues()
    {
        stringValue = "HelloWorld";
        boolValue = true;
        nullPerson = null;
        objectPerson = new Person("Hello", "World");
    }

    /// <summary>
    /// <code>
    /// return (object)nullPerson == null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool IsNullTrue()
    {
        return nullPerson is null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return (object)nullPerson != null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool IsNullFalse()
    {
        return nullPerson is not null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return nullPerson == null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool NullEqualsTrue()
    {
        return nullPerson == null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return nullPerson != null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool NullEqualsFalse()
    {
        return nullPerson != null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return (object)nullPerson == null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool NullReferenceEqualsTrue()
    {
        return ReferenceEquals(null, nullPerson);
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return (object)nullPerson == null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool NullReferenceEqualsFalse()
    {
        return ReferenceEquals(nullPerson, null);
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return boolValue;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool BooleanIsTrue()
    {
        return boolValue is true;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return !boolValue;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool BooleanIsFalse()
    {
        return boolValue is false;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return stringValue == null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool StringIsNullFalse()
    {
        return stringValue is null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return stringValue != null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool StringIsNotNullFalse()
    {
        return stringValue is not null;
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// return (object)objectPerson != null;
    /// </code>
    /// </summary>
    [Benchmark]
    public bool PersonIsObject()
    {
        return objectPerson is { };
    }

    /// <summary>
    /// Generates:
    /// <code>
    /// Person person = objectPerson;
    /// return (object)person != null && person.Forename == "Hello";
    /// </code>
    /// </summary>
    [Benchmark]
    public bool PersonCompareValues()
    {
        return objectPerson is { Forename: "Hello" };
    }
}

public class Person
{
    public Person(string? forename, string? surname)
    {
        Forename = forename;
        Surname = surname;
    }
    public string? Forename { get; }
    public string? Surname { get; }

    protected bool Equals(Person other)
    {
        return Forename == other.Forename && Surname == other.Surname;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
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
