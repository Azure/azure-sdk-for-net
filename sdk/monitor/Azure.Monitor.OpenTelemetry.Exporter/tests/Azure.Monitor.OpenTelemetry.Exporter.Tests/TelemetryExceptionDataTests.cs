// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Moq;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TelemetryExceptionDataTests
    {
        [Fact]
        public void ValidateProblemIdForExceptionWithoutStackTrace()
        {
            var Id = LogsHelper.GetProblemId(new Exception("Test"));

            Assert.Equal(typeof(Exception).FullName + " at UnknownMethod", Id);
        }

        [Fact]
        public void ValidateProblemIdForExceptionWithStackTrace()
        {
            Exception ex = CreateException(1);

            var Id = LogsHelper.GetProblemId(ex);

            Assert.StartsWith(typeof(AggregateException).FullName + " at " + typeof(TelemetryExceptionDataTests).FullName + "." + nameof(FunctionWithException), Id);
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
        public void ParentIdISetAsOuterId()
        {
            var parentException = new Exception("Parent Exception");
            var parentExceptionDetails = new TelemetryExceptionDetails(parentException, parentException.Message, null);
            var exception = new Exception("Exception");
            var exceptionDetails = new TelemetryExceptionDetails(exception, exception.Message, parentExceptionDetails);

            Assert.Equal(parentExceptionDetails.Id, exceptionDetails.OuterId);
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
