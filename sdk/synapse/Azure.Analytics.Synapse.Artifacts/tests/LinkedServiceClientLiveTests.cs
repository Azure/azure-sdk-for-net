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
        internal class DisposableLinkedService : IAsyncDisposable
        {
            private readonly LinkedServiceClient _client;
            public LinkedServiceResource Resource;

            private DisposableLinkedService (LinkedServiceClient client, LinkedServiceResource resource)
            {
                _client = client;
                Resource = resource;
            }

            public string Name => Resource.Name;

            public static async ValueTask<DisposableLinkedService> Create (LinkedServiceClient client, TestRecording recording) =>
                new DisposableLinkedService (client, await CreateResource(client, recording));

            public static async ValueTask<LinkedServiceResource> CreateResource (LinkedServiceClient client, TestRecording recording)
            {
                string linkedServiceName = recording.GenerateId("LinkedService", 16);
                LinkedServiceResource resource = new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/"));
                LinkedServiceCreateOrUpdateLinkedServiceOperation operation = await client.StartCreateOrUpdateLinkedServiceAsync(linkedServiceName, resource);
                return await operation.WaitForCompletionAsync();
            }

            public async ValueTask DisposeAsync()
            {
                LinkedServiceDeleteLinkedServiceOperation operation = await _client.StartDeleteLinkedServiceAsync (Name);
                await operation.WaitForCompletionResponseAsync();
            }
        }

        public LinkedServiceClientLiveTests(bool isAsync) : base(isAsync, useLegacyTransport: true)
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

        [RecordedTest]
        public async Task TestGetLinkedService()
        {
            LinkedServiceClient client = CreateClient();

            await using DisposableLinkedService service = await DisposableLinkedService.Create (client, this.Recording);

            IList<LinkedServiceResource> services = await client.GetLinkedServicesByWorkspaceAsync().ToListAsync();
            Assert.GreaterOrEqual(services.Count, 1);

            foreach (var expectedLinkedService in services)
            {
                LinkedServiceResource actualLinkedService = await client.GetLinkedServiceAsync(expectedLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Name, actualLinkedService.Name);
                Assert.AreEqual(expectedLinkedService.Id, actualLinkedService.Id);
            }
        }

        [RecordedTest]
        public async Task TestDeleteLinkedService()
        {
            LinkedServiceClient client = CreateClient();

            LinkedServiceResource resource = await DisposableLinkedService.CreateResource (client, this.Recording);

            LinkedServiceDeleteLinkedServiceOperation operation = await client.StartDeleteLinkedServiceAsync (resource.Name);
            await operation.WaitAndAssertSuccessfulCompletion();
        }

        [RecordedTest]
        public async Task TestRenameLinkedService()
        {
            LinkedServiceClient client = CreateClient();

            LinkedServiceResource resource = await DisposableLinkedService.CreateResource (client, Recording);

            string newLinkedServiceName = Recording.GenerateId("LinkedService2", 16);

            LinkedServiceRenameLinkedServiceOperation renameOperation = await client.StartRenameLinkedServiceAsync (resource.Name, new ArtifactRenameRequest () { NewName = newLinkedServiceName } );
            await renameOperation.WaitForCompletionResponseAsync();

            LinkedServiceResource service = await client.GetLinkedServiceAsync (newLinkedServiceName);
            Assert.AreEqual (newLinkedServiceName, service.Name);

            LinkedServiceDeleteLinkedServiceOperation operation = await client.StartDeleteLinkedServiceAsync (newLinkedServiceName);
            await operation.WaitForCompletionResponseAsync();
        }
    }
}
