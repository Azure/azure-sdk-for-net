// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    ///   Allows the XUnit framework to identify the decorated reference as a test case,
    ///   eligible for automatic retries by the test runner.
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Sample:
    ///   https://github.com/xunit/samples.xunit/tree/master/RetryFactExample
    /// </remarks>
    /// 
    public class LiveFactDiscoverer : FactDiscoverer
    {
        public LiveFactDiscoverer(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
        }

        protected override IXunitTestCase CreateTestCase(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var maxAttempts = factAttribute.GetNamedArgument<int>(nameof(LiveFactAttribute.MaxAttempts));
            var retryDelayMilliseconds = Math.Max(0, factAttribute.GetNamedArgument<int>(nameof(LiveFactAttribute.RetryDelayMilliseconds)));
            
            if (maxAttempts < 1)
            {
                maxAttempts = TestConstants.LiveTestDefaultMaxAttempts;
            }

            return new RetriableTestCase(this.DiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod, maxAttempts, retryDelayMilliseconds);
        }
    }
}
