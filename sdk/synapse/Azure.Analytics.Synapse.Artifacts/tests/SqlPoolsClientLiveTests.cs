// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SqlPoolsClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SqlPoolsClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public SqlPoolsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SqlPoolsClient CreateClient()
        {
            return InstrumentClient(new SqlPoolsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGet()
        {
            SqlPoolsClient client = CreateClient();
            SqlPoolInfoListResult pools = await client.ListAsync ();
            foreach (SqlPool pool in pools.Value)
            {
                SqlPool actualPool = await client.GetAsync (pool.Name);
                Assert.AreEqual (pool.Id, actualPool.Id);
                Assert.AreEqual (pool.Name, actualPool.Name);
                Assert.AreEqual (pool.Status, actualPool.Status);
            }
        }
    }
}
