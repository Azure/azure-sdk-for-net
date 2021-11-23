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
    public class ListOrderTests : EdgeOrderManagementClientBase
    {
        private string resourceGroupName;
        private string orderItemName;

        public ListOrderTests() : base(true)
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
        public async Task TestCreateOrderItem()
        {
            resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderTestUtilities.DefaultResourceLocation, resourceGroupName);
            orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressProperties addressProperties = new AddressProperties(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            AddressDetails addressDetails = new AddressDetails(addressProperties);
            string orderId = string.Format(EdgeOrderTestUtilities.OrderArmIdFormat,
                TestEnvironment.SubscriptionId, resourceGroupName, EdgeOrderTestUtilities.DefaultResourceLocation, orderItemName);

            // Create
            OrderItemResource orderItemResource = new OrderItemResource(EdgeOrderTestUtilities.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, orderId);
            EdgeOrderManagementCreateOrderItemOperation createOrderItemOperation = await EdgeOrderManagementOperations.StartCreateOrderItemAsync(orderItemName,
                resourceGroupName, orderItemResource);
            await createOrderItemOperation.WaitForCompletionAsync();
            Assert.IsTrue(createOrderItemOperation.HasCompleted);
            Assert.IsTrue(createOrderItemOperation.HasValue);
        }

        [TestCase, Order(2)]
        public async Task TestListOrdersAtSubscriptionLevel()
        {
            var orders = EdgeOrderManagementOperations.ListOrderAtSubscriptionLevelAsync();
            var ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }

        [TestCase, Order(3)]
        public async Task TestListOrdersAtResourceGroupLevel()
        {
            var orders = EdgeOrderManagementOperations.ListOrderAtResourceGroupLevelAsync(resourceGroupName);
            var ordersResult = await orders.ToEnumerableAsync();

            Assert.NotNull(ordersResult);
            Assert.IsTrue(ordersResult.Count >= 1);
        }

        [TestCase, Order(4)]
        public async Task TestDeleteOrderItem()
        {
            //Cancel
            var cancelOrderItemResponse = await EdgeOrderManagementOperations.CancelOrderItemAsync(orderItemName, resourceGroupName,
                new CancellationReason("Order item cancelled"));
            Assert.AreEqual(cancelOrderItemResponse.Status, 204);

            // Delete
            EdgeOrderManagementDeleteOrderItemByNameOperation deleteOrderItemByNameOperation = await EdgeOrderManagementOperations.StartDeleteOrderItemByNameAsync(
                orderItemName, resourceGroupName);
            await deleteOrderItemByNameOperation.WaitForCompletionAsync();
            Assert.IsTrue(deleteOrderItemByNameOperation.HasCompleted);
            Assert.IsTrue(deleteOrderItemByNameOperation.HasValue);
        }
    }
}
