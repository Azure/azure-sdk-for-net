// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Tests.Infrastructure;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RetryOnInternalServerErrorAttributeTests
    {
        private const string ExceptionMessage =
            "Failed to process task after several retry"
            + "\r\nStatus: 200 (OK)"
            + "\r\nErrorCode: InternalServerError";

        [Test]
        public void PassingTestIsNotRetried()
        {
            FakeTest test = new();
            TestExecutionContext context = new() { CurrentTest = test };
            Mock<TestCommand> mockTestCommand = new(test);
            Mock<TestResult> mockResult = new(test);

            mockResult
                .Setup(res => res.PassCount)
                .Returns(1);

            mockTestCommand
                .Setup(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()))
                .Returns(mockResult.Object);

            RetryOnInternalServerErrorAttribute retryAttribute = new();
            retryAttribute.Wrap(mockTestCommand.Object).Execute(context);

            mockTestCommand
                .Verify(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()), Times.Once);
        }

        [Test]
        public void FailingTestWithUnexpectedMessageIsNotRetried()
        {
            const string differentMessage =
                "A different error occurred"
                + "\r\nStatus: 400 (Bad Request)"
                + "\r\nErrorCode: BadRequest";

            RequestFailedException exception = new(400, differentMessage, "BadRequest", null);
            FakeTest test = new();
            TestExecutionContext context = new() { CurrentTest = test };
            Mock<TestCommand> mockTestCommand = new(test);

            mockTestCommand
                .Setup(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()))
                .Throws(exception);

            RetryOnInternalServerErrorAttribute retryAttribute = new();
            retryAttribute.Wrap(mockTestCommand.Object).Execute(context);

            mockTestCommand
                .Verify(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()), Times.Once);
        }

        [Test]
        public void FailingTestIsRetried()
        {
            RequestFailedException exception = new(200, ExceptionMessage, "InternalServerError", null);
            FakeTest test = new();
            TestExecutionContext context = new() { CurrentTest = test };
            Mock<TestCommand> mockTestCommand = new(test);
            Mock<TestResult> mockTestResult = new(test);

            mockTestResult
                .Setup(res => res.PassCount)
                .Returns(1);

            mockTestCommand
                .SetupSequence(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()))
                .Throws(exception)
                .Returns(mockTestResult.Object);

            RetryOnInternalServerErrorAttribute retryAttribute = new();
            retryAttribute.Wrap(mockTestCommand.Object).Execute(context);

            mockTestCommand
                .Verify(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()), Times.Exactly(2));
        }

        [Test]
        public void FailingTestObeysRetryLimits()
        {
            RequestFailedException exception = new(200, ExceptionMessage, "InternalServerError", null);
            FakeTest test = new();
            TestExecutionContext context = new() { CurrentTest = test };
            Mock<TestCommand> mockTestCommand = new(test);

            mockTestCommand
                .Setup(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()))
                .Throws(exception);

            RetryOnInternalServerErrorAttribute retryAttribute = new();
            retryAttribute.Wrap(mockTestCommand.Object).Execute(context);

            mockTestCommand
                .Verify(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()), Times.Exactly(RetryOnInternalServerErrorAttribute.TryCount));
        }

        [Test]
        public void FailingTestIsInconclusiveWhenRetriesExhausted()
        {
            RequestFailedException exception = new(200, ExceptionMessage, "InternalServerError", null);
            FakeTest test = new();
            TestExecutionContext context = new() { CurrentTest = test };
            Mock<TestCommand> mockTestCommand = new(test);

            mockTestCommand
                .Setup(cmd => cmd.Execute(It.IsAny<TestExecutionContext>()))
                .Throws(exception);

            RetryOnInternalServerErrorAttribute retryAttribute = new();
            var result = retryAttribute.Wrap(mockTestCommand.Object).Execute(context);

            Assert.That(result.ResultState, Is.EqualTo(ResultState.Inconclusive), "The result should be inconclusive.");
        }

        public class FakeTest : Test
        {
            public FakeTest() : base("Fake")
            {
            }

            public override object[] Arguments { get; }
            public override string XmlElementName { get; }
            public override bool HasChildren { get; }
            public override IList<ITest> Tests { get; }
            public override TNode AddToXml(TNode parentNode, bool recursive) => throw new System.NotImplementedException();
            public override TestResult MakeTestResult() => new Mock<TestResult>(this).Object;
        }
    }
}
