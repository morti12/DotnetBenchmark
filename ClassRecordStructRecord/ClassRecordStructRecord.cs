using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ClassRecordStructRecord
{
    [Benchmark]
    public void ClassBenchmark()
    {
        var record = new BenchmarkRecordClass("Hello", "World", 42);

        record = record with { Name = "World", FamilyName = "Hello", Age = 4711 };
    }

    [Benchmark]
    public void StructBenchmark()
    {
        var record = new BenchmarkRecordStruct("Hello", "World", 42);

        record = record with { Name = "World", FamilyName = "Hello", Age = 4711 };
    }

    private record class BenchmarkRecordClass(string Name, string FamilyName, int Age);
    private record struct BenchmarkRecordStruct(string Name, string FamilyName, int Age);
}
