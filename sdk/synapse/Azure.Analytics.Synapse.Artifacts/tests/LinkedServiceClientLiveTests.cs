// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.Artifacts
{
    /// <summary>
    /// The suite of tests for the <see cref="LinkedServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class LinkedServiceClientLiveTests : ArtifactsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedServiceClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public LinkedServiceClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetLinkedService()
        {
            await foreach (var expectedLinkedService in LinkedServiceClient.GetLinkedServicesByWorkspaceAsync())
            {
                LinkedServiceResource actualLinkedService = await LinkedServiceClient.GetLinkedServiceAsync(expectedLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Name, actualLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Id, actualLinkedService.Id);
            }
        }

        [Test]
        public async Task TestCreateLinkedService()
        {
            var operation = await LinkedServiceClient.StartCreateOrUpdateLinkedServiceAsync("MyLinkedService", new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/")));
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual("MyLinkedService", operation.Value.Name);
        }

        [Test]
        public async Task TestDeleteLinkedService()
        {
            var operation = await LinkedServiceClient.StartDeleteLinkedServiceAsync("MyLinkedService");
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(200, operation.Value.Status);
        }
    }
}
