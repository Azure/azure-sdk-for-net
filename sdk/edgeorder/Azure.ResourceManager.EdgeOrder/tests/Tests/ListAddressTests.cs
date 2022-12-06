// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private EdgeOrderAddressCollection _addressResourceCollection;

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
            EdgeOrderAddressContactDetails contactDetails = GetDefaultContactDetails();
            EdgeOrderShippingAddress shippingAddress = GetDefaultShippingAddress();
            _addressResourceCollection = await GetAddressResourceCollectionAsync(resourceGroupName);

            EdgeOrderAddressData addressResourceData = new(EdgeOrderManagementTestUtilities.DefaultResourceLocation,
                contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            var createAddressOperation = await _addressResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, addressName, addressResourceData);
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
            AsyncPageable<EdgeOrderAddressResource> addresses = EdgeOrderExtensions.GetEdgeOrderAddressesAsync(Subscription);
            List<EdgeOrderAddressResource> addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListAddressesAtResourceGroupLevel()
        {
            AsyncPageable<EdgeOrderAddressResource> addresses = _addressResourceCollection.GetAllAsync();
            List<EdgeOrderAddressResource> addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }
    }
}
