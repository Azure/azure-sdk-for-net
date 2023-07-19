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
    /// The suite of tests for the <see cref="IntegrationRuntimesClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class IntegrationRuntimesClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public IntegrationRuntimesClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private IntegrationRuntimesClient CreateClient()
        {
            return InstrumentClient(new IntegrationRuntimesClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGet()
        {
            IntegrationRuntimesClient client = CreateClient();
            IntegrationRuntimeListResponse integrations = await client.ListAsync ();
            foreach (IntegrationRuntimeResource integration in integrations.Value)
            {
                IntegrationRuntimeResource fetchedIntegration = await client.GetAsync (integration.Name);
                Assert.AreEqual (integration.Name, fetchedIntegration.Name);
                Assert.AreEqual (integration.Id, fetchedIntegration.Id);
                Assert.AreEqual (integration.Type, fetchedIntegration.Type);
            }
        }

        [RecordedTest]
        public async Task TestList()
        {
            IntegrationRuntimesClient client = CreateClient();
            IntegrationRuntimeListResponse integrations = await client.ListAsync ();
            foreach (IntegrationRuntimeResource integration in integrations.Value)
            {
                Assert.NotNull (integration.Id);
                Assert.NotNull (integration.Name);
            }
        }
    }
}
