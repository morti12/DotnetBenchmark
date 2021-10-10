using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ClassRecordStructRecord
{
    [Benchmark]
    public BenchmarkRecordClass ClassBenchmark()
    {
        var record = new BenchmarkRecordClass("Hello", "World", 42);

        record = record with { Name = "World", FamilyName = "Hello", Age = 4711 };

        return record;
    }

    [Benchmark]
    public BenchmarkRecordStruct StructBenchmark()
    {
        var record = new BenchmarkRecordStruct("Hello", "World", 42);

        record = record with { Name = "World", FamilyName = "Hello", Age = 4711 };

        return record;
    }

    public record class BenchmarkRecordClass(string Name, string FamilyName, int Age);
    public record struct BenchmarkRecordStruct(string Name, string FamilyName, int Age);
}
