using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ByteArrayMemoryTest>();

[MemoryDiagnoser]
public class ByteArrayMemoryTest
{
    private static readonly byte[] Bytes = new byte[100];

    [Benchmark]
    public byte ToArrayGetLast()
    {
        return Bytes.ToArray()[^1];
    }

    [Benchmark]
    public byte ToReadonlyMemoryGetLast()
    {
        return new ReadOnlyMemory<byte>(Bytes).Span[^1];
    }
}
