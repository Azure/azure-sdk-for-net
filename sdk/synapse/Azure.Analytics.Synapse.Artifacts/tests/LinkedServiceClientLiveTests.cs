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
    /// The suite of tests for the <see cref="LinkedServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class LinkedServiceClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public LinkedServiceClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private LinkedServiceClient CreateClient()
        {
            return InstrumentClient(new LinkedServiceClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Test]
        public async Task TestGetLinkedService()
        {
            LinkedServiceClient client = CreateClient ();

            await foreach (var expectedLinkedService in client.GetLinkedServicesByWorkspaceAsync())
            {
                LinkedServiceResource actualLinkedService = await client.GetLinkedServiceAsync(expectedLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Name, actualLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Id, actualLinkedService.Id);
            }
        }

        [Test]
        public async Task TestCreateLinkedService()
        {
            LinkedServiceClient client = CreateClient ();

            string linkedServiceName = Recording.GenerateName("LinkedSercive");
            LinkedServiceCreateOrUpdateLinkedServiceOperation operation = await client.StartCreateOrUpdateLinkedServiceAsync(linkedServiceName, new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/")));
            LinkedServiceResource linkedService = await operation.WaitForCompletionAsync();
            Assert.AreEqual(linkedServiceName, linkedService.Name);
        }

        [Test]
        public async Task TestDeleteLinkedService()
        {
            LinkedServiceClient client = CreateClient ();

            string linkedServiceName = Recording.GenerateName("LinkedSercive");

            LinkedServiceCreateOrUpdateLinkedServiceOperation createOperation = await client.StartCreateOrUpdateLinkedServiceAsync(linkedServiceName, new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/")));
            await createOperation.WaitForCompletionAsync();

            LinkedServiceDeleteLinkedServiceOperation deleteOperation = await client.StartDeleteLinkedServiceAsync(linkedServiceName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
