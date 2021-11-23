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
    public class OrderItemCRUDTests : EdgeOrderManagementClientBase
    {
        public OrderItemCRUDTests() : base(true)
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

        [TestCase]
        public async Task TestOrderItemCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await EdgeOrderTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EdgeOrderTestUtilities.DefaultResourceLocation, resourceGroupName);
            var orderItemName = Recording.GenerateAssetName("Sdk-OrderItem");
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

            // Get
            var getOrderItemResponse = await EdgeOrderManagementOperations.GetOrderItemByNameAsync(orderItemName, resourceGroupName);
            Assert.IsNotNull(getOrderItemResponse.Value);

            // Update
            addressProperties.ContactDetails.ContactName = "Updated contact name";
            OrderItemUpdateParameter orderItemUpdateParameter = new OrderItemUpdateParameter
            {
                ForwardAddress = addressProperties
            };
            EdgeOrderManagementUpdateOrderItemOperation updateOrderItemOperation = await EdgeOrderManagementOperations.StartUpdateOrderItemAsync(orderItemName,
                resourceGroupName, orderItemUpdateParameter);
            await updateOrderItemOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateOrderItemOperation.HasCompleted);
            Assert.IsTrue(updateOrderItemOperation.HasValue);

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
