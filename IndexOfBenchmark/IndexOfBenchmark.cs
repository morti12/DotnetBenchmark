using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class IndexOfBenchmark
{
    int[] array = null!;
    List<int> list = null!;

    [Params(100, 500, 1_000, 2_500, 5_000)]
    public int SearchIndex;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(4711);
        array = new int[5_000];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next();
        }

        list = new List<int>(array);
    }

    [Benchmark]
    public int ListIndexOf()
    {
        var value = list[SearchIndex - 1];
        return list.IndexOf(value);
    }

    [Benchmark]
    public int ArrayIndexOf()
    {
        var value = array[SearchIndex - 1];
        return Array.IndexOf(array, value);
    }
}
