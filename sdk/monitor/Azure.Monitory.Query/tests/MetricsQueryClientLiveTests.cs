// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitory.Query;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class MetricsQueryClientLiveTests : RecordedTestBase<MonitorQueryClientTestEnvironment>
    {
        public MetricsQueryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MetricsQueryClient CreateClient()
        {
            return InstrumentClient(new MetricsQueryClient(
                TestEnvironment.Credential,
                InstrumentClientOptions(new MonitorQueryClientOptions())
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
    }
}