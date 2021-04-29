// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientLiveTests : RecordedTestBase<MonitorQueryClientTestEnvironment>
    {
        public MetricsQueryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MetricsClient CreateClient()
        {
            return InstrumentClient(new MetricsClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new MetricsClientOptions())
            ));
        }

        [Test]
        public async Task CanListMetrics()
        {
            var client = CreateClient();

            var results = await client.GetMetricsAsync(TestEnvironment.MetricsResource, TestEnvironment.MetricsNamespace);

            CollectionAssert.IsNotEmpty(results.Value);
        }

        [Test]
        public async Task CanQueryMetrics()
        {
            var client = CreateClient();

            var results = await client.QueryAsync(
                TestEnvironment.MetricsResource,
                Recording.Now.AddHours(-1),
                Recording.Now,
                TimeSpan.FromMinutes(1));

            CollectionAssert.IsNotEmpty(results.Value.Metrics);
        }

        [Test]
        public async Task CanListNamespacesMetrics()
        {
            var client = CreateClient();

            var results = await client.GetMetricNamespacesAsync(
                TestEnvironment.MetricsResource);

            CollectionAssert.IsNotEmpty(results.Value);
        }
    }
}