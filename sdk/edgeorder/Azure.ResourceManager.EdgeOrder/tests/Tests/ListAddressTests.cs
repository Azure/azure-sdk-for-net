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
    public class ListAddressTests : EdgeOrderManagementClientBase
    {
        private string resourceGroupName;

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
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task TestCreateAddress()
        {
            resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderTestUtilities.DefaultResourceLocation, resourceGroupName);
            var addressName = Recording.GenerateAssetName("SdkAddress");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressResource addressResource = new AddressResource(EdgeOrderTestUtilities.DefaultResourceLocation, contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            EdgeOrderManagementCreateAddressOperation createAddressOperation = await EdgeOrderManagementOperations.StartCreateAddressAsync(addressName,
                resourceGroupName, addressResource);
            await createAddressOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAddressOperation.HasCompleted);
            Assert.IsTrue(createAddressOperation.HasValue);
        }

        [TestCase, Order(2)]
        public async Task TestListAddressesAtSubscriptionLevel()
        {
            var addresses = EdgeOrderManagementOperations.ListAddressesAtSubscriptionLevelAsync();
            var addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }

        [TestCase, Order(3)]
        public async Task TestListAddressesAtResourceGroupLevel()
        {
            var addresses = EdgeOrderManagementOperations.ListAddressesAtResourceGroupLevelAsync(resourceGroupName);
            var addressesResult = await addresses.ToEnumerableAsync();

            Assert.NotNull(addressesResult);
            Assert.IsTrue(addressesResult.Count >= 1);
        }
    }
}
