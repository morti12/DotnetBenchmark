using BenchmarkDotNet.Running;

namespace ToListToArrayBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ToListVsToArray>();
        }
    }
}
