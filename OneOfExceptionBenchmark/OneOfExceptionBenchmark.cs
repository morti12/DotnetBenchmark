using BenchmarkDotNet.Attributes;
using OneOf;

[MemoryDiagnoser]
public class OneOfExceptionBenchmark
{
    private const string message = "Hello World";

    #region Exception

    [Benchmark]
    public string ThrowsException()
    {
        try
        {
            var message = GetStringWithException();
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    private static string GetStringWithException()
    {
        throw new Exception(message);
    }

    #endregion

    #region Record struct

    [Benchmark]
    public string OneOfRecordStruct()
    {
        return GetOneOfRecordStructMessage().Match(
            success => success.Message,
            error => error.Message);
    }

    private static OneOf<SuccessMessageRecordStruct, ExceptionMessageRecordStruct> GetOneOfRecordStructMessage()
    {
        return new ExceptionMessageRecordStruct(message);
    }

    private record struct SuccessMessageRecordStruct(string Message);
    private record struct ExceptionMessageRecordStruct(string Message);

    #endregion

    #region Record Class

    [Benchmark]
    public string OneOfRecordClass()
    {
        return GetOneOfRecordClassMessage().Match(
            success => success.Message,
            error => error.Message);
    }

    private static OneOf<SuccessMessageRecordClass, ExceptionMessageRecordClass> GetOneOfRecordClassMessage()
    {
        return new ExceptionMessageRecordClass(message);
    }

    private record SuccessMessageRecordClass(string Message);
    private record ExceptionMessageRecordClass(string Message);

    #endregion

    #region class

    [Benchmark]
    public string OneOfClass()
    {
        return GetOneOfClassMessage().Match(
            success => success.Message,
            error => error.Message);
    }

    private static OneOf<SuccessMessageClass, ExceptionMessageClass> GetOneOfClassMessage()
    {
        return new ExceptionMessageClass(message);
    }

    private class SuccessMessageClass
    {
        public SuccessMessageClass(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    private class ExceptionMessageClass
    {
        public ExceptionMessageClass(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    #endregion

    #region struct

    [Benchmark]
    public string OneOfStruct()
    {
        return GetOneOfStructMessage().Match(
            success => success.Message,
            error => error.Message);
    }

    private static OneOf<SuccessMessageStruct, ExceptionMessageStruct> GetOneOfStructMessage()
    {
        return new ExceptionMessageStruct(message);
    }

    private struct SuccessMessageStruct
    {
        public SuccessMessageStruct(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    private struct ExceptionMessageStruct
    {
        public ExceptionMessageStruct(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    #endregion
}
