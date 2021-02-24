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
    /// The suite of tests for the <see cref="BigDataPoolsClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class BigDataPoolsClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public BigDataPoolsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private BigDataPoolsClient CreateClient()
        {
            return InstrumentClient(new BigDataPoolsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18080 - This test case cannot be automated due to the inability to configure infrastructure to test against.")]
        [RecordedTest]
        public async Task ListPools()
        {
            BigDataPoolsClient client = CreateClient();
            BigDataPoolResourceInfoListResult pools = await client.ListAsync ();
            Assert.GreaterOrEqual(1, pools.Value.Count);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18080 - This test case cannot be automated due to the inability to configure infrastructure to test against.")]
        [RecordedTest]
        public async Task GetPool()
        {
            const string PoolName = "sparkchhamosyna";
            BigDataPoolsClient client = CreateClient();
            BigDataPoolResourceInfo pool = await client.GetAsync (PoolName);
            Assert.AreEqual(PoolName, pool.Name);
        }
    }
}
