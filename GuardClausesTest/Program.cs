using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Dawn;
using EnsureThat;

BenchmarkRunner.Run<GuardTests>();


[MemoryDiagnoser]
public class GuardTests
{
    private const string ValueToGuardAgainst = "HelloWorld";

    [Benchmark]
    public string ArdalisGuardClauses()
    {
        return Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace(ValueToGuardAgainst, nameof(ValueToGuardAgainst));
    }
    
    [Benchmark]
    public string DawnGuardClauses()
    {
        return Dawn.Guard.Argument(ValueToGuardAgainst, nameof(ValueToGuardAgainst)).NotNull().NotWhiteSpace();
    }
    
    [Benchmark]
    public string EnsureThatClauses()
    {
        EnsureThat.Ensure.That(ValueToGuardAgainst, nameof(ValueToGuardAgainst)).IsNotNullOrWhiteSpace();
        return ValueToGuardAgainst;
    }
    
    [Benchmark]
    public string EnsureStringClauses()
    {
        return EnsureThat.Ensure.String.IsNotNullOrWhiteSpace(ValueToGuardAgainst, nameof(ValueToGuardAgainst));
    }
    
    [Benchmark]
    public string GuardNetClauses()
    {
        GuardNet.Guard.NotNullOrWhitespace(ValueToGuardAgainst, nameof(ValueToGuardAgainst));
        return ValueToGuardAgainst;
    }

    [Benchmark]
    public string MicrosoftCommunityToolKit()
    {
        CommunityToolkit.Diagnostics.Guard.IsNotNullOrWhiteSpace(ValueToGuardAgainst, nameof(ValueToGuardAgainst));
        return ValueToGuardAgainst;
    }

}