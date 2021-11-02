using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace EmptyListArrayBenchmark
{
    [MemoryDiagnoser]
    public class EmptyListArrayBenchmark
    {
        private readonly Consumer consumer = new();

        [Benchmark]
        public void NewList() => new List<int>().Consume(consumer);

        [Benchmark]
        public void NewEmptyList() => new List<int>(0).Consume(consumer);

        [Benchmark]
        public void NewEmptyArray() => new int[0].Consume(consumer);

        [Benchmark]
        public void EmptyArray() => Array.Empty<int>().Consume(consumer);

        [Benchmark]
        public void EnumerableEmpty() => Enumerable.Empty<int>().Consume(consumer);
    }
}