using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

[MemoryDiagnoser]
public class ListVsImmutableList
{
    [Benchmark]
    public void ImmutableListAdd()
    {
        var immutableList = ImmutableList<int>.Empty;

        for (int i = 0; i < 1000; i++)
        {
            immutableList = immutableList.Add(i);
        }
    }

    [Benchmark]
    public void ListAdd()
    {
        var list = new List<int>();

        for (int i = 0; i < 1000; i++)
        {
            list.Add(i);
        }
    }

    private static IEnumerable<int> GenerateNumbers()
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return i;
        }
    }

    [Benchmark]
    public void ImmutableListAddRange()
    {
        var immutableList = ImmutableList<int>.Empty;

        immutableList.AddRange(GenerateNumbers());
    }

    [Benchmark]
    public void ListAddRange()
    {
        var list = new List<int>();

        list.AddRange(GenerateNumbers());
    }
}
