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
        public async Task Cleanup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task TestAddressCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
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

            // Get
            var getAddressResponse = await EdgeOrderManagementOperations.GetAddressByNameAsync(addressName, resourceGroupName);
            Assert.IsNotNull(getAddressResponse.Value);

            // Update
            contactDetails.ContactName = "Updated contact name";
            AddressUpdateParameter addressUpdateParameter = new AddressUpdateParameter
            {
                ShippingAddress = shippingAddress,
                ContactDetails = contactDetails
            };
            EdgeOrderManagementUpdateAddressOperation updateAddressOperation = await EdgeOrderManagementOperations.StartUpdateAddressAsync(addressName,
                resourceGroupName, addressUpdateParameter);
            await updateAddressOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateAddressOperation.HasCompleted);
            Assert.IsTrue(updateAddressOperation.HasValue);

            // Delete
            EdgeOrderManagementDeleteAddressByNameOperation deleteAddressOperation = await EdgeOrderManagementOperations.StartDeleteAddressByNameAsync(addressName, resourceGroupName);
            await deleteAddressOperation.WaitForCompletionAsync();
            Assert.IsTrue(deleteAddressOperation.HasCompleted);
            Assert.IsTrue(deleteAddressOperation.HasValue);
        }
    }
}
