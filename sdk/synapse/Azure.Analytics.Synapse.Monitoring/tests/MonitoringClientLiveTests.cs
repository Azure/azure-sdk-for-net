// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Monitoring;
using Azure.Analytics.Synapse.Monitoring.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Monitoring.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="MonitoringClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class MonitoringClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public MonitoringClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MonitoringClient CreateClient()
        {
            return InstrumentClient(new MonitoringClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MonitoringClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestListSparkApplications()
        {
            MonitoringClient client = CreateClient();
            SparkJobListViewResponse sparkJobList = await client.GetSparkJobListAsync();
            Assert.NotNull(sparkJobList);
            CollectionAssert.IsNotEmpty(sparkJobList.SparkJobs);
        }

        [RecordedTest]
        public async Task TestSqlQuery()
        {
            MonitoringClient client = CreateClient();
            SqlQueryStringDataModel sqlQuery = await client.GetSqlJobQueryStringAsync();
            Assert.NotNull(sqlQuery);
            Assert.IsNotNull(sqlQuery.Query);
        }
    }
}
