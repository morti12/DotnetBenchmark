using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ToListVsToArray>();

[MemoryDiagnoser]
public class ToListVsToArray
{

    [Params(10, 100, 1000, 10000)]
    public int Size { get; set; }
    
    public IEnumerable<int> TestEnumerable => Enumerable.Range(0, Size);

    [Benchmark]
    public List<int> ToList() => TestEnumerable.ToList();

    [Benchmark]
    public int[] ToArray() => TestEnumerable.ToArray();
}
