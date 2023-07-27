// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class AddressCRUDTests : EdgeOrderManagementClientBase
    {
        public AddressCRUDTests() : base(true)
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
        public async Task TestAddressCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            var addressName = Recording.GenerateAssetName("SdkAddress");
            EdgeOrderAddressContactDetails contactDetails = GetDefaultContactDetails();
            EdgeOrderShippingAddress shippingAddress = GetDefaultShippingAddress();
            EdgeOrderAddressCollection addressResourceCollection = await GetAddressResourceCollectionAsync(resourceGroupName);

            EdgeOrderAddressData addressResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation, contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            var createAddressOperation = await addressResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, addressName, addressResourceData);
            await createAddressOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAddressOperation.HasCompleted);
            Assert.IsTrue(createAddressOperation.HasValue);

            // Get
            Response<EdgeOrderAddressResource> getAddressResponse = await addressResourceCollection.GetAsync(addressName);
            EdgeOrderAddressResource addressResource = getAddressResponse.Value;
            Assert.IsNotNull(addressResource);

            // Update
            contactDetails.ContactName = "Updated contact name";
            EdgeOrderAddressPatch addressUpdateParameter = new()
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

            // Delete
            var deleteAddressOperation = await addressResource.DeleteAsync(WaitUntil.Completed);
            await deleteAddressOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteAddressOperation.HasCompleted);
        }
    }
}
