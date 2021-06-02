// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Azure.AI.TextAnalytics.Perf
{
    public abstract class TextAnalyticsTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        public TextAnalyticsTest(TOptions options) : base(options)
        {
            if (options.Parallel > 1)
            {
                throw new InvalidOperationException("Do not stress the service until we can reduce testing costs. Set '--parallel 1'.");
            }

            TestEnvironment = PerfTestEnvironment.Instance;
        }

        protected PerfTestEnvironment TestEnvironment { get; }
    }
}
