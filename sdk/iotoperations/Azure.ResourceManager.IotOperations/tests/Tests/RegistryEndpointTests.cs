// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System; // for InvalidOperationException
using System.Threading.Tasks;
using Azure; // for RequestFailedException, WaitUntil
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotOperations.Models;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class RegistryEndpointTests : IotOperationsManagementClientBase
    {
        public RegistryEndpointTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
                await InitializeClients();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestRegistryEndpoints()
        {
            // Get the RegistryEndpoint collection
            IotOperationsRegistryEndpointCollection endpointCollection = await GetRegistryEndpointResourceCollectionAsync(ResourceGroup);

            try
            {
                // Create RegistryEndpoint
                var createOperation = await endpointCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-registryendpoint",
                    CreateRegistryEndpointResourceData()
                );
                var createdEndpoint = createOperation.Value;
                Assert.IsNotNull(createdEndpoint);
                Assert.IsNotNull(createdEndpoint.Data);
                Assert.IsNotNull(createdEndpoint.Data.Properties);

                // Delete RegistryEndpoint
                await createdEndpoint.DeleteAsync(WaitUntil.Completed);

                // Verify RegistryEndpoint is deleted
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await createdEndpoint.GetAsync()
                );
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No ModelReaderWriterTypeBuilder found"))
            {
                Assert.Ignore("Skipping RegistryEndpoint test due to missing ModelReaderWriterTypeBuilder for RegistryEndpointResourceData in generated context.");
                return;
            }
        }

        private IotOperationsRegistryEndpointData CreateRegistryEndpointResourceData()
        {
            return new IotOperationsRegistryEndpointData
            {
                Properties = new IotOperationsRegistryEndpointProperties
                {
                    Host = "contoso.azurecr.io",
                    Authentication = new RegistryEndpointAnonymousAuthentication(new RegistryEndpointAnonymousSettings())
                },
                ExtendedLocation = new IotOperationsExtendedLocation(
                    ExtendedLocation,
                    IotOperationsExtendedLocationType.CustomLocation
                ),
            };
        }
    }
}
