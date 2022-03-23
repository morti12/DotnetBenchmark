using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ArraySizeListSizeBenchmark>();
    
[MemoryDiagnoser]
public class ArraySizeListSizeBenchmark
{
    [Params(10, 100, 1000, 10000)] 
    public int Size { get; set; }
    
    [Benchmark]
    public int[] ArraySize()
    {
        var array = new int[Size];

        for (var i = 0; i < Size; i++)
        {
            array[i] = i;
        }

        return array;
    }
    
    [Benchmark]
    public List<int> ListSize()
    {
        var array = new List<int>(Size);

        for (var i = 0; i < Size; i++)
        {
            array.Add(i);
        }

        return array;
    }
    
    [Benchmark]
    public List<int> ListWithoutSize()
    {
        var array = new List<int>();

        for (var i = 0; i < Size; i++)
        {
            array.Add(i);
        }

        return array;
    }
}