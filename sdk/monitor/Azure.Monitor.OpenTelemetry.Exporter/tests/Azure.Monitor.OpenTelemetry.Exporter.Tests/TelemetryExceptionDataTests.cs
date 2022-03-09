﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.Logging;
using Moq;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TelemetryExceptionDataTests
    {
        [Fact]
        public void ValidateProblemIdForExceptionWithoutStackTrace()
        {
            var id = LogsHelper.GetProblemId(new Exception("Test"));

            Assert.Equal(typeof(Exception).FullName + " at UnknownMethod", id);
        }

        [Fact]
        public void ValidateProblemIdForExceptionWithStackTrace()
        {
            Exception ex = CreateException(1);

            var id = LogsHelper.GetProblemId(ex);

            Assert.StartsWith(typeof(AggregateException).FullName + " at " + typeof(TelemetryExceptionDataTests).FullName + "." + nameof(FunctionWithException), id);
        }

        [Fact]
        public void CallingConvertToExceptionDetailsWithNullExceptionThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TelemetryExceptionDetails(null, "Exception Message", null));
        }

        [Fact]
        public void ParsedStackIsEmptyForExceptionWithoutStack()
        {
            var exception = new ArgumentNullException();

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);

            Assert.Equal(0, exceptionDetails.ParsedStack.Count);

            // hasFullStack defaults to true.
            Assert.True(exceptionDetails.HasFullStack);
        }

        [Fact]
        public void AllStackFramesAreConvertedIfSizeOfParsedStackIsLessOrEqualToMaximum()
        {
            var exception = CreateException(42);

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);
            Assert.Equal(43, exceptionDetails.ParsedStack.Count);
            Assert.True(exceptionDetails.HasFullStack);
        }

        [Fact]
        public void FirstAndLastStackPointsAreCollectedForLongStack()
        {
            var exception = CreateException(300);

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);

            Assert.False(exceptionDetails.HasFullStack);
            Assert.True(exceptionDetails.ParsedStack.Count < 300);

            // We should keep top of stack, and end of stack hence CreateException function should be present
            Assert.Equal(typeof(TelemetryExceptionDataTests).FullName + "." + nameof(FunctionWithException), exceptionDetails.ParsedStack[0].Method);
            Assert.Equal(typeof(TelemetryExceptionDataTests).FullName + "." + nameof(CreateException), exceptionDetails.ParsedStack[exceptionDetails.ParsedStack.Count - 1].Method);
        }

        [Fact]
        public void TestNullMethodInfoInStack()
        {
            var frameMock = new Mock<System.Diagnostics.StackFrame>(null, 0, 0);
            frameMock.Setup(x => x.GetMethod()).Returns((MethodBase)null);

            Models.StackFrame stackFrame = null;

            stackFrame = TelemetryExceptionDetails.GetStackFrame(frameMock.Object, 0);

            Assert.Equal("unknown", stackFrame.Assembly);
            Assert.Null(stackFrame.FileName);
            Assert.Equal("unknown", stackFrame.Method);
            Assert.Null(stackFrame.Line);
        }

        [Fact]
        public void CheckThatFileNameAndLineAreCorrectIfAvailable()
        {
            var exception = CreateException(1);

            StackTrace st = new StackTrace(exception, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            var fileName = frame.GetFileName();

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);
            var stack = exceptionDetails.ParsedStack;

            // Behavior may vary in some cases and line may return 0
            // In this case Line will be null
            if (line != 0)
            {
                Assert.Equal(line, stack[0].Line);
                Assert.Equal(fileName, stack[0].FileName);
            }
            else
            {
                Assert.Null(stack[0].Line);
                Assert.Null(stack[0].FileName);
            }
        }

        [Fact]
        public void CheckLevelCorrespondsToFrameForLongStack()
        {
            const int NumberOfStackFrames = 100;

            var exception = CreateException(NumberOfStackFrames - 1);

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);
            var stack = exceptionDetails.ParsedStack;

            // Checking levels for first few and last few.
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i, stack[i].Level);
            }

            for (int j = NumberOfStackFrames - 1, i = 0; j > NumberOfStackFrames - 10; j--, i++)
            {
                Assert.Equal(j, stack[stack.Count - 1 - i].Level);
            }
        }

        [Fact]
        public void SizeOfParsedStackFrameIsLessThanMaxAllowedValue()
        {
            var exception = CreateException(300);

            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, null);
            int parsedStackLength = 0;

            var stack = exceptionDetails.ParsedStack;
            for (int i = 0; i < stack.Count; i++)
            {
                parsedStackLength += (stack[i].Method == null ? 0 : stack[i].Method.Length)
                                     + (stack[i].Assembly == null ? 0 : stack[i].Assembly.Length)
                                     + (stack[i].FileName == null ? 0 : stack[i].FileName.Length);
            }
            Assert.True(parsedStackLength <= TelemetryExceptionDetails.MaxParsedStackLength);
        }

        [Fact]
        public void ParentIdIsSetAsOuterId()
        {
            var parentException = new Exception("Parent Exception");
            var parentExceptionDetails = new TelemetryExceptionDetails(parentException, parentException.Message, null);
            var exception = new Exception("Exception");
            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, parentExceptionDetails);

            Assert.Equal(parentExceptionDetails.Id, exceptionDetails.OuterId);
        }

        [Fact]
        public void ExceptionDataContainsExceptionDetails()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(TelemetryExceptionDataTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<TelemetryExceptionDataTests>();

            var exception = CreateException(1);
            logger.LogWarning(exception, exception.Message);

            var exceptionData = new TelemetryExceptionData(2, logRecords[0]);

            Assert.Equal(1, exceptionData.Exceptions.Count);
        }

        [Fact]
        public void ExceptionDataContainsExceptionDetailsofAllInnerExceptionsOfAggregateException()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(TelemetryExceptionDataTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<TelemetryExceptionDataTests>();

            Exception innerException1 = new ArgumentException("Inner1");
            Exception innerException2 = new ArgumentException("Inner2");

            AggregateException aggregateException = new AggregateException("AggregateException", new[] { innerException1, innerException2 });

            // Passing "AggregateException" explicitly here instead of using aggregateException.Message
            // aggregateException.Message will return different value in case of net461 compared to netcore
            logger.LogWarning(aggregateException, "AggregateException");

            var exceptionData = new TelemetryExceptionData(2, logRecords[0]);

            Assert.Equal(3, exceptionData.Exceptions.Count);
            Assert.Equal("AggregateException", exceptionData.Exceptions[0].Message);
            Assert.Equal("Inner1", exceptionData.Exceptions[1].Message);
            Assert.Equal("Inner2", exceptionData.Exceptions[2].Message);
        }

        [Fact]
        public void ExceptionDataContainsExceptionDetailsWithAllInnerExceptions()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(TelemetryExceptionDataTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<TelemetryExceptionDataTests>();

            var innerException1 = new Exception("Inner1");

            var innerexception2 = new Exception("Inner2", innerException1);

            var exception = new Exception("Exception", innerexception2);

            // Passing "Exception" explicitly here instead of using exception.Message
            // exception.Message will return different value in case of net461 compared to netcore
            logger.LogWarning(exception, "Exception");

            var exceptionData = new TelemetryExceptionData(2, logRecords[0]);

            Assert.Equal(3, exceptionData.Exceptions.Count);
            Assert.Equal("Exception", exceptionData.Exceptions[0].Message);
            Assert.Equal("Inner2", exceptionData.Exceptions[1].Message);
            Assert.Equal("Inner1", exceptionData.Exceptions[2].Message);
        }

        [Fact]
        public void AggregateExceptionsWithMultipleNestedExceptionsAreTrimmedAfterReachingMaxCount()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(TelemetryExceptionDataTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<TelemetryExceptionDataTests>();

            int numberOfExceptions = 15;
            int maxNumberOfExceptionsAllowed = 10;
            List<Exception> innerExceptions = new List<Exception>();
            for (int i = 0; i < numberOfExceptions; i++)
            {
                innerExceptions.Add(new Exception((i + 1).ToString(CultureInfo.InvariantCulture)));
            }

            AggregateException rootLevelException = new AggregateException("0", innerExceptions);

            // Passing "0" explicitly here instead of using rootLevelException.Message
            // rootLevelException.Message will return different value in case of net461 compared to netcore
            logger.LogWarning(rootLevelException, "0");

            var exceptionData = new TelemetryExceptionData(2, logRecords[0]);

            Assert.Equal(maxNumberOfExceptionsAllowed + 1, exceptionData.Exceptions.Count);

            for (int counter = 0; counter < maxNumberOfExceptionsAllowed; counter++)
            {
                var details = exceptionData.Exceptions[counter];

                Assert.Equal(counter.ToString(CultureInfo.InvariantCulture), details.Message);
            }

            var firstExceptionInList = exceptionData.Exceptions.First();
            var lastExceptionInList = exceptionData.Exceptions.Last();
            Assert.Equal(firstExceptionInList.Id, lastExceptionInList.OuterId);
            Assert.Equal(typeof(InnerExceptionCountExceededException).FullName, lastExceptionInList.TypeName);
            Assert.Equal(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "The number of inner exceptions was {0} which is larger than {1}, the maximum number allowed during transmission. All but the first {1} have been dropped.",
                    numberOfExceptions+1,
                    maxNumberOfExceptionsAllowed),
                lastExceptionInList.Message);
        }

        [Theory]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Critical)]
        [InlineData(LogLevel.Error)]
        public void ValidateTelemetryExceptionData(LogLevel logLevel)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(TelemetryExceptionDataTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<TelemetryExceptionDataTests>();

            var ex = new Exception("Message");
            logger.Log(logLevel, ex, "Message");

            var exceptionData = new TelemetryExceptionData(2, logRecords[0]);

            Assert.Equal(2, exceptionData.Version);
            Assert.Equal(LogsHelper.GetSeverityLevel(logLevel), exceptionData.SeverityLevel);
            Assert.Empty(exceptionData.Properties);
            Assert.Empty(exceptionData.Measurements);
            Assert.Equal(typeof(Exception).FullName + " at UnknownMethod", exceptionData.ProblemId);
            Assert.Equal(1, exceptionData.Exceptions.Count);
            Assert.Equal("Message", exceptionData.Exceptions[0].Message);
            Assert.Null(exceptionData.Exceptions[0].Stack);
            Assert.Equal(ex.GetHashCode(), exceptionData.Exceptions[0].Id);
            Assert.Empty(exceptionData.Exceptions[0].ParsedStack);
            Assert.True(exceptionData.Exceptions[0].HasFullStack);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private Exception CreateException(int stackDepth)
        {
            Exception exception = null;

            try
            {
                FunctionWithException(stackDepth);
            }
            catch (Exception exp)
            {
                exception = exp;
            }

            return exception;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void FunctionWithException(int stackDepth)
        {
            if (stackDepth > 1)
            {
                FunctionWithException(--stackDepth);
            }

            throw new AggregateException("Exception message");
        }
    }
}
