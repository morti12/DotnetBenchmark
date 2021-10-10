using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ToListVsToArray
{
    public static IEnumerable<int> TestEnumerable => Enumerable.Range(0, 100);

    [Benchmark]
    public List<int> ToList() => TestEnumerable.ToList();

    [Benchmark]
    public int[] ToArray() => TestEnumerable.ToArray();
}
