// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    ///   Allows the XUnit framework to identify the decorated reference as a set of test cases,
    ///   eligible for automatic retries by the test runner.
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Sample:
    ///   https://github.com/xunit/samples.xunit/tree/master/RetryFactExample
    /// </remarks>
    /// 
    public class LiveTheoryDiscoverer : TheoryDiscoverer
    {
        public LiveTheoryDiscoverer(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
        }

        protected override IEnumerable<IXunitTestCase> CreateTestCasesForDataRow(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo theoryAttribute, object[] dataRow)
        {
            (var maxAttempts, var retryDelayMilliseconds) = ReadLiveTestParameters(theoryAttribute);
            return new[] { new RetriableTestCase(this.DiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod, maxAttempts, retryDelayMilliseconds, dataRow) };
        }

        protected override IEnumerable<IXunitTestCase> CreateTestCasesForTheory(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo theoryAttribute)
        {
            (var maxAttempts, var retryDelayMilliseconds) = ReadLiveTestParameters(theoryAttribute);
            return new[] { new RetriableTheoryTestCase(this.DiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod, maxAttempts, retryDelayMilliseconds) };
        }

        private (int, int) ReadLiveTestParameters(IAttributeInfo theoryAttribute)
        {
            var maxAttempts = theoryAttribute.GetNamedArgument<int>(nameof(LiveTheoryAttribute.MaxAttempts));
            var retryDelayMilliseconds = Math.Max(0, theoryAttribute.GetNamedArgument<int>(nameof(LiveTheoryAttribute.RetryDelayMilliseconds)));

            if (maxAttempts < 1)
            {
                maxAttempts = TestConstants.LiveTestDefaultMaxAttempts;
            }

            return (maxAttempts, retryDelayMilliseconds);
        }
    }
}
