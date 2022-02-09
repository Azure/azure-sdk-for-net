﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.EdgeOrder.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class ListAddressTests : EdgeOrderManagementClientBase
    {
        private AddressResourceCollection _addressResourceCollection;

        public ListAddressTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }

            await CreateAddress();
        }

        private async Task CreateAddress()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderManagementTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderManagementTestUtilities.DefaultResourceLocation, resourceGroupName);
            var addressName = Recording.GenerateAssetName("SdkAddress");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            _addressResourceCollection = await GetAddressResourceCollectionAsync(resourceGroupName);

            AddressResourceData addressResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            var createAddressOperation = await _addressResourceCollection.CreateOrUpdateAsync(true, addressName, addressResourceData);
            await createAddressOperation.WaitForCompletionAsync();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase, Order(1)]
        public async Task TestListAddressesAtSubscriptionLevel()
        {
            AsyncPageable<AddressResource> addresses = SubscriptionExtensions.GetAddressResourcesAsync(Subscription);
            List<AddressResource> addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListAddressesAtResourceGroupLevel()
        {
            AsyncPageable<AddressResource> addresses = _addressResourceCollection.GetAllAsync();
            List<AddressResource> addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }
    }
}
