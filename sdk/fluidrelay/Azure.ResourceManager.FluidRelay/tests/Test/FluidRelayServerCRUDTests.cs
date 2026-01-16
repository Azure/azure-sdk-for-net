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
            Assert.That(createFluidRelayServerOperation.HasCompleted, Is.True);
            Assert.That(createFluidRelayServerOperation.HasValue, Is.True);

            // Get
            Response<FluidRelayServerResource> getFluidRelayResponse = await fluidRelayServerResourceCollection.GetAsync(fluidRelayServerName);
            FluidRelayServerResource fluidRelayServerResource = getFluidRelayResponse.Value;
            Assert.That(fluidRelayServerResource, Is.Not.Null);
            Assert.That(fluidRelayServerResource.Data.Name, Is.EqualTo(fluidRelayServerName));

            // Get Keys
            Response<FluidRelayServerKeys> getKeyFluidRelayResponse = await fluidRelayServerResource.GetKeysAsync();
            FluidRelayServerKeys fluidRelayServerKeys = getKeyFluidRelayResponse.Value;
            Assert.That(fluidRelayServerKeys.SecondaryKey, Is.Not.Null);
            Assert.That(fluidRelayServerKeys.PrimaryKey, Is.Not.Null);

            //list by subscription
            AsyncPageable<FluidRelayServerResource> fluidRelayServerResourceCollection2 = GetFluidRelayServerCollectionBySubscriptionAsync();
            await foreach (FluidRelayServerResource server in fluidRelayServerResourceCollection2)
            {
                Assert.That(server.Data.Name, Is.Not.Null);
            }
            Assert.That(await fluidRelayServerResourceCollection2.GetAsyncEnumerator().MoveNextAsync(), Is.True);

            //Regenerate Keys
            RegenerateKeyContent key1 = new RegenerateKeyContent(FluidRelayKeyName.PrimaryKey);
            Response<FluidRelayServerKeys> regenerateKeyFluidRelayResponse = await fluidRelayServerResource.RegenerateKeysAsync(key1);
            FluidRelayServerKeys NewFluidRelayServerKeys = regenerateKeyFluidRelayResponse.Value;
            Assert.That(NewFluidRelayServerKeys.SecondaryKey.Equals(fluidRelayServerKeys.SecondaryKey), Is.True);
            Assert.That(NewFluidRelayServerKeys.PrimaryKey.Equals(fluidRelayServerKeys.PrimaryKey), Is.False);

            // Delete
            var deleteFluidRelayServerOperation = await fluidRelayServerResource.DeleteAsync(WaitUntil.Completed);
            await deleteFluidRelayServerOperation.WaitForCompletionResponseAsync();
            Assert.That(deleteFluidRelayServerOperation.HasCompleted, Is.True);
        }

        [TestCase]
        public async Task TestFluidRelayContainerCRUDOperations()
        {
            FluidRelayContainerCollection FluidRelayContainerResourceCollection = await GetFluidRelayContainerCollectionAsync("lin-demo", "dotNetSDKTest");
            Response<FluidRelayContainerResource> getFluidRelayResponse = await FluidRelayContainerResourceCollection.GetAsync("19b201e5-a5f6-4f90-b3c0-bc36b650e64e");
            FluidRelayContainerResource fluidRelayContainerResource = getFluidRelayResponse.Value;
            Assert.That(fluidRelayContainerResource, Is.Not.Null);
        }
    }
}
