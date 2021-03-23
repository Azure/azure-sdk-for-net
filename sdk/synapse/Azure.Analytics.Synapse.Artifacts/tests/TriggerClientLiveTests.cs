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

        private PipelineClient CreatePipelineClient()
        {
            return InstrumentClient(new PipelineClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetTrigger()
        {
            TriggerClient client = CreateClient();
            await using DisposableTrigger singleTrigger = await DisposableTrigger.Create (client, Recording);

            await foreach (var trigger in client.GetTriggersByWorkspaceAsync())
            {
                TriggerResource actualTrigger = await client.GetTriggerAsync(trigger.Name);
                Assert.AreEqual(trigger.Name, actualTrigger.Name);
                Assert.AreEqual(trigger.Id, actualTrigger.Id);
            }
        }

        [RecordedTest]
        public async Task TestDeleteSparkJob()
        {
            TriggerClient client = CreateClient();

            TriggerResource resource = await DisposableTrigger.CreateResource (client, Recording);

            TriggerDeleteTriggerOperation deleteOperation = await client.StartDeleteTriggerAsync  (resource.Name);
            await deleteOperation.WaitAndAssertSuccessfulCompletion();
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18079 - Missing or invalid pipeline references for trigger but no obvious place to put pipeline?")]
        [RecordedTest]
        public async Task TestStartStop()
        {
            TriggerClient client = CreateClient();
            PipelineClient pipelineClient = CreatePipelineClient ();

            await using DisposableTrigger trigger = await DisposableTrigger.Create (client, Recording);
            await using DisposablePipeline pipeline = await DisposablePipeline.Create (pipelineClient, Recording);
            // SYNAPSE_API_ISSUE - How do we point the trigger to our pipeline

            TriggerStartTriggerOperation startOperation = await client.StartStartTriggerAsync (trigger.Name);
            Response startResponse = await startOperation.WaitForCompletionAsync();
            startResponse.AssertSuccess();

            TriggerStopTriggerOperation stopOperation = await client.StartStopTriggerAsync (trigger.Name);
            Response stopResponse = await stopOperation.WaitForCompletionAsync();
            stopResponse.AssertSuccess();
        }

        [RecordedTest]
        public async Task TestSubscribeUnsubscribe()
        {
            TriggerClient client = CreateClient();

            await using DisposableTrigger trigger = await DisposableTrigger.Create (client, Recording);
            TriggerSubscribeTriggerToEventsOperation subOperation = await client.StartSubscribeTriggerToEventsAsync (trigger.Name);
            TriggerSubscriptionOperationStatus subResponse = await subOperation.WaitForCompletionAsync();
            Assert.AreEqual (EventSubscriptionStatus.Enabled, subResponse.Status);

            TriggerUnsubscribeTriggerFromEventsOperation unsubOperation = await client.StartUnsubscribeTriggerFromEventsAsync (trigger.Name);
            TriggerSubscriptionOperationStatus unsubResponse = await unsubOperation.WaitForCompletionAsync();
            Assert.AreEqual (EventSubscriptionStatus.Disabled, unsubResponse.Status);
        }

        [RecordedTest]
        public async Task TestEventStatus()
        {
            TriggerClient client = CreateClient();

            await using DisposableTrigger trigger = await DisposableTrigger.Create (client, Recording);
            TriggerSubscriptionOperationStatus statusOperation = await client.GetEventSubscriptionStatusAsync (trigger.Name);
            Assert.AreEqual (statusOperation.TriggerName, trigger.Name);
        }
    }
}
