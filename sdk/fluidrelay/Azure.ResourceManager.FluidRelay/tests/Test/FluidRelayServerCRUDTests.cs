// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FluidRelay.Models;
using Azure.ResourceManager.FluidRelay.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FluidRelay.Tests.Tests
{
    [TestFixture]
    public class FluidRelayServerCRUDTests : FluidRelayManagementClientBase
    {
        public FluidRelayServerCRUDTests() : base(true)
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
            FluidRelayServerCollection addressResourceCollection = await GetFluidRelayServerCollectionAsync(resourceGroupName);

            FluidRelayServerData addressResourceData = new(FluidRelayManagementTestUtilities.DefaultResourceLocation);

            // Create
            var createFluidRelayServerOperation = await addressResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, fluidRelayServerName, addressResourceData);
            await createFluidRelayServerOperation.WaitForCompletionAsync();
            Assert.IsTrue(createFluidRelayServerOperation.HasCompleted);
            Assert.IsTrue(createFluidRelayServerOperation.HasValue);

            // Get
            Response<FluidRelayServerResource> getFluidRelayResponse = await addressResourceCollection.GetAsync(fluidRelayServerName);
            FluidRelayServerResource fluidRelayServerResource = getFluidRelayResponse.Value;
            Assert.IsNotNull(fluidRelayServerResource);
/**
            // Update
            contactDetails.ContactName = "Updated contact name";
            AddressResourcePatch addressUpdateParameter = new()
            {
                ShippingAddress = shippingAddress,
                ContactDetails = contactDetails
            };
            var updateAddressOperation = await addressResource.UpdateAsync(WaitUntil.Completed, addressUpdateParameter);
            Assert.IsTrue(updateAddressOperation.HasCompleted);
            Assert.IsTrue(updateAddressOperation.HasValue);

            // Get
            getAddressResponse = await addressResourceCollection.GetAsync(addressName);
            addressResource = getAddressResponse.Value;
            Assert.IsNotNull(addressResource);
            Assert.IsTrue(string.Equals(addressResource.Data.ContactDetails.ContactName, "Updated contact name"));
**/
            // Delete
            var deleteFluidRelayServerOperation = await fluidRelayServerResource.DeleteAsync(WaitUntil.Completed);
            await deleteFluidRelayServerOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteFluidRelayServerOperation.HasCompleted);
        }
    }
}
