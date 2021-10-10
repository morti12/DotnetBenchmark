using BenchmarkDotNet.Attributes;
using OneOf;
using System;

namespace OneOfExceptionBenchmark
{
    [MemoryDiagnoser]
    public class OneOfExceptionBenchmark
    {
        private const string message = "Hello World";

        #region Exception

        [Benchmark]
        public void ThrowsException()
        {
            try
            {
                var message = GetStringWithException();
                Console.WriteLine(message);
            }
            catch (Exception _)
            {
                ;
            }
        }

        private static string GetStringWithException()
        {
            throw new Exception(message);
        }

        #endregion

        #region Record struct

        [Benchmark]
        public void OneOfRecordStruct()
        {
            GetOneOfRecordStructMessage().Switch(
                success => Console.WriteLine(success.Message),
                error => { ; });
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
        public void OneOfRecordClass()
        {
            GetOneOfRecordClassMessage().Switch(
                success => Console.WriteLine(success.Message),
                error => {; });
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
        public void OneOfClass()
        {
            GetOneOfClassMessage().Switch(
                success => Console.WriteLine(success.Message),
                error => { ; });
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
        public void OneOfStruct()
        {
            GetOneOfStructMessage().Switch(
                success => Console.WriteLine(success.Message),
                error => { ; });
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
}
