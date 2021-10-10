using BenchmarkDotNet.Running;

namespace OneOfExceptionBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<OneOfExceptionBenchmark>();
        }
    }
}
