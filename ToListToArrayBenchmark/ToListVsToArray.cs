using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace ToListToArrayBenchmark
{
    [MemoryDiagnoser]
    public class ToListVsToArray
    {
        public static IEnumerable<int> TestEnumerable => Enumerable.Range(0, 100);

        [Benchmark]
        public void ToList() => TestEnumerable.ToList();

        [Benchmark]
        public void ToArray() => TestEnumerable.ToArray();
    }

}
