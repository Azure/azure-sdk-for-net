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
        private const string FailedToProcessTaskExceptionMessage =
            "Failed to process task after several retry"
            + ", Status: 200 (OK)"
            + ", ErrorCode: InternalServerError";

        private const string InvalidTaskTypeExceptionMessage =
            "Invalid Task Type"
            + ", Status: 500 (Internal Server Error)"
            + ", ErrorCode: InternalServerError";

        private const string InternalServerErrorExceptionMessage =
            "Internal Server Error."
            + ", Status: 200 (OK)"
            + ", ErrorCode: InternalServerError";

        [Test]
        [TestCase(FailedToProcessTaskExceptionMessage)]
        [TestCase(InvalidTaskTypeExceptionMessage)]
        [TestCase(InternalServerErrorExceptionMessage)]
        public void FailingTestIsRetried(string exceptionMessage)
        {
            RequestFailedException exception = new(200, exceptionMessage, "InternalServerError", null);
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
