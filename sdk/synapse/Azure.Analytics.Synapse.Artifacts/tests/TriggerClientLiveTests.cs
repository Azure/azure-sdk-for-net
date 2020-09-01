// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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
            var operation = await TriggerClient.StartCreateOrUpdateTriggerAsync("MyTrigger", new TriggerResource(new Trigger()));
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual("MyTrigger", operation.Value.Name);
        }

        [Test]
        public async Task TestDeleteTrigger()
        {
            var operation = await TriggerClient.StartDeleteTriggerAsync("MyTrigger");
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(200, operation.Value.Status);
        }
    }
}
