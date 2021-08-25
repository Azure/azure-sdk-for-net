// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public abstract class MetricsAdvisorTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        public MetricsAdvisorTest(TOptions options) : base(options)
        {
            TestEnvironment = PerfTestEnvironment.Instance;

            var uri = new Uri(TestEnvironment.MetricsAdvisorUri);
            var credential = new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey);

            Client = new MetricsAdvisorClient(uri, credential);
        }

        protected PerfTestEnvironment TestEnvironment { get; }

        protected MetricsAdvisorClient Client { get; }
    }
}
