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
    /// The suite of tests for the <see cref="TriggerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TriggerClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public TriggerClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private TriggerClient CreateClient()
        {
            return InstrumentClient(new TriggerClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Test]
        public async Task TestGetTrigger()
        {
            TriggerClient client = CreateClient();
            await foreach (var expectedTrigger in client.GetTriggersByWorkspaceAsync())
            {
                TriggerResource actualTrigger = await client.GetTriggerAsync(expectedTrigger.Name);
                Assert.AreEqual(expectedTrigger.Name, actualTrigger.Name);
                Assert.AreEqual(expectedTrigger.Id, actualTrigger.Id);
            }
        }

        [Test]
        public async Task TestCreateTrigger()
        {
            TriggerClient client = CreateClient();

            string triggerName = Recording.GenerateName("Trigger");
            TriggerCreateOrUpdateTriggerOperation operation = await client.StartCreateOrUpdateTriggerAsync(triggerName, new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
            TriggerResource trigger = await operation.WaitForCompletionAsync();
            Assert.AreEqual(triggerName, trigger.Name);
        }

        [Test]
        public async Task TestDeleteTrigger()
        {
            TriggerClient client = CreateClient();

            string triggerName = Recording.GenerateName("Trigger");

            TriggerCreateOrUpdateTriggerOperation createOperation = await client.StartCreateOrUpdateTriggerAsync(triggerName, new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
            await createOperation.WaitForCompletionAsync();

            TriggerDeleteTriggerOperation deleteOperation = await client.StartDeleteTriggerAsync(triggerName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
