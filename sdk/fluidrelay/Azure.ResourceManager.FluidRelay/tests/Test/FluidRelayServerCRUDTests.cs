// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FluidRelay.Models;
using Azure.ResourceManager.FluidRelay.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FluidRelay.Tests.Tests
{
    public class FluidRelayServerCRUDTests : FluidRelayManagementClientBase
    {
        public FluidRelayServerCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task TestFluidRelayServerCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await FluidRelayManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                FluidRelayManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            var fluidRelayServerName = Recording.GenerateAssetName("SdkFluidRelayServer");
            FluidRelayServerCollection fluidRelayServerResourceCollection = await GetFluidRelayServerCollectionByResourceGroupAsync(resourceGroupName);

            FluidRelayServerData fluidRelayServerResourceData = new(FluidRelayManagementTestUtilities.DefaultResourceLocation);

            // Create
            var createFluidRelayServerOperation = await fluidRelayServerResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, fluidRelayServerName, fluidRelayServerResourceData);
            await createFluidRelayServerOperation.WaitForCompletionAsync();
            Assert.IsTrue(createFluidRelayServerOperation.HasCompleted);
            Assert.IsTrue(createFluidRelayServerOperation.HasValue);

            // Get
            Response<FluidRelayServerResource> getFluidRelayResponse = await fluidRelayServerResourceCollection.GetAsync(fluidRelayServerName);
            FluidRelayServerResource fluidRelayServerResource = getFluidRelayResponse.Value;
            Assert.IsNotNull(fluidRelayServerResource);
            Assert.AreEqual(fluidRelayServerName, fluidRelayServerResource.Data.Name);

            // Get Keys
            Response<FluidRelayServerKeys> getKeyFluidRelayResponse = await fluidRelayServerResource.GetKeysAsync();
            FluidRelayServerKeys fluidRelayServerKeys = getKeyFluidRelayResponse.Value;
            Assert.IsNotNull(fluidRelayServerKeys.SecondaryKey);
            Assert.IsNotNull(fluidRelayServerKeys.PrimaryKey);

            //list by subscription
            AsyncPageable<FluidRelayServerResource> fluidRelayServerResourceCollection2 = GetFluidRelayServerCollectionBySubscriptionAsync();
            await foreach (FluidRelayServerResource server in fluidRelayServerResourceCollection2)
            {
                Assert.IsNotNull(server.Data.Name);
            }
            Assert.IsTrue(await fluidRelayServerResourceCollection2.GetAsyncEnumerator().MoveNextAsync());

            //Regenerate Keys
            RegenerateKeyContent key1 = new RegenerateKeyContent(FluidRelayKeyName.PrimaryKey);
            Response<FluidRelayServerKeys> regenerateKeyFluidRelayResponse = await fluidRelayServerResource.RegenerateKeysAsync(key1);
            FluidRelayServerKeys NewFluidRelayServerKeys = regenerateKeyFluidRelayResponse.Value;
            Assert.IsTrue(NewFluidRelayServerKeys.SecondaryKey.Equals(fluidRelayServerKeys.SecondaryKey));
            Assert.IsFalse(NewFluidRelayServerKeys.PrimaryKey.Equals(fluidRelayServerKeys.PrimaryKey));

            // Delete
            var deleteFluidRelayServerOperation = await fluidRelayServerResource.DeleteAsync(WaitUntil.Completed);
            await deleteFluidRelayServerOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteFluidRelayServerOperation.HasCompleted);
        }

        [TestCase]
        public async Task TestFluidRelayContainerCRUDOperations()
        {
            FluidRelayContainerCollection FluidRelayContainerResourceCollection = await GetFluidRelayContainerCollectionAsync("lin-demo", "dotNetSDKTest");
            Response<FluidRelayContainerResource> getFluidRelayResponse = await FluidRelayContainerResourceCollection.GetAsync("19b201e5-a5f6-4f90-b3c0-bc36b650e64e");
            FluidRelayContainerResource fluidRelayContainerResource = getFluidRelayResponse.Value;
            Assert.IsNotNull(fluidRelayContainerResource);
        }
    }
}
