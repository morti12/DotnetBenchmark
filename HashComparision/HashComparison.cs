using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using System.Text;

namespace HashComparision
{
    [MemoryDiagnoser]
    public class HashComparison
    {
        public static readonly byte[] TestValue = Encoding.Unicode.GetBytes("Hello World");
        public static readonly MD5 md5 = MD5.Create();
        public static readonly SHA1 sha1 = SHA1.Create();
        public static readonly SHA256 sha256 = SHA256.Create();


        [Benchmark]
        public byte[] CalculateMD5()
        {
            return md5.ComputeHash(TestValue);
        }

        [Benchmark]
        public byte[] CalculateSHA1()
        {
            return sha1.ComputeHash(TestValue);
        }

        [Benchmark]
        public byte[] CalculateSHA256()
        {
            return sha256.ComputeHash(TestValue);
        }
    }
}
