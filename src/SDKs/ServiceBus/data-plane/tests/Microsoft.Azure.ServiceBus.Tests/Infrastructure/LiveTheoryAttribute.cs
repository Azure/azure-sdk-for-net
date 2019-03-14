// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    ///   Identifies a set of test cases as "Live", indicating that they have dependencies on external Azure services and 
    ///   is eligible for automatica retries by the test runner.
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Samples:
    ///   https://github.com/xunit/samples.xunit/tree/master/RetryFactExample
    ///   https://github.com/xunit/samples.xunit/tree/master/TraitExtensibility
    /// </remarks>
    /// 
    [TraitDiscoverer("Microsoft.Azure.ServiceBus.UnitTests.LiveTestCategoryDiscoverer", "Microsoft.Azure.ServiceBus.Tests")]
    [XunitTestCaseDiscoverer("Microsoft.Azure.ServiceBus.UnitTests.LiveTheoryDiscoverer", "Microsoft.Azure.ServiceBus.Tests")]
    public class LiveTheoryAttribute : FactAttribute, ITraitAttribute
    {
        public int MaxAttempts { get; set; } = TestConstants.LiveTestDefaultMaxAttempts;
        public int RetryDelayMilliseconds { get; set; } = TestConstants.LiveTestRetryDelayMilliseconds;
    }
}
