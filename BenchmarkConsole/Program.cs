using ToListToArrayBenchmark;
using BenchmarkDotNet.Running;

namespace BenchmarkConsole
{
    public class Program 
    { 
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ToListVsToArray>();
        }
    }
}