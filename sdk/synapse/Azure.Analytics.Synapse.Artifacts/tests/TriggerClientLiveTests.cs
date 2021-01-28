// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.Artifacts
{
    /// <summary>
    /// The suite of tests for the <see cref="TriggerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TriggerClientLiveTests : ArtifactsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TriggerClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetTrigger()
        {
            await foreach (var expectedTrigger in TriggerClient.GetTriggersByWorkspaceAsync())
            {
                TriggerResource actualTrigger = await TriggerClient.GetTriggerAsync(expectedTrigger.Name);
                Assert.AreEqual(expectedTrigger.Name, actualTrigger.Name);
                Assert.AreEqual(expectedTrigger.Id, actualTrigger.Id);
            }
        }

        [Test]
        public async Task TestCreateTrigger()
        {
            string triggerName = Recording.GenerateName("Trigger");
            TriggerCreateOrUpdateTriggerOperation operation = await TriggerClient.StartCreateOrUpdateTriggerAsync(triggerName, new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
            TriggerResource trigger = await operation.WaitForCompletionAsync();
            Assert.AreEqual(triggerName, trigger.Name);
        }

        [Test]
        public async Task TestDeleteTrigger()
        {
            string triggerName = Recording.GenerateName("Trigger");

            TriggerCreateOrUpdateTriggerOperation createOperation = await TriggerClient.StartCreateOrUpdateTriggerAsync(triggerName, new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
            await createOperation.WaitForCompletionAsync();

            TriggerDeleteTriggerOperation deleteOperation = await TriggerClient.StartDeleteTriggerAsync(triggerName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
