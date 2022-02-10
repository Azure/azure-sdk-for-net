﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressResourceCollection addressResourceCollection = await GetAddressResourceCollectionAsync(resourceGroupName);

            AddressResourceData addressResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation, contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            var createAddressOperation = await addressResourceCollection.CreateOrUpdateAsync(true, addressName, addressResourceData);
            await createAddressOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAddressOperation.HasCompleted);
            Assert.IsTrue(createAddressOperation.HasValue);

            // Get
            Response<AddressResource> getAddressResponse = await addressResourceCollection.GetAsync(addressName);
            AddressResource addressResource = getAddressResponse.Value;
            Assert.IsNotNull(addressResource);

            // Update
            contactDetails.ContactName = "Updated contact name";
            AddressUpdateParameter addressUpdateParameter = new()
            {
                ShippingAddress = shippingAddress,
                ContactDetails = contactDetails
            };
            var updateAddressOperation = await addressResource.UpdateAsync(true, addressUpdateParameter);
            Assert.IsTrue(updateAddressOperation.HasCompleted);
            Assert.IsTrue(updateAddressOperation.HasValue);

            // Get
            getAddressResponse = await addressResourceCollection.GetAsync(addressName);
            addressResource = getAddressResponse.Value;
            Assert.IsNotNull(addressResource);
            Assert.IsTrue(string.Equals(addressResource.Data.ContactDetails.ContactName, "Updated contact name"));

            // Delete
            var deleteAddressOperation = await addressResource.DeleteAsync(true);
            await deleteAddressOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteAddressOperation.HasCompleted);
        }
    }
}
