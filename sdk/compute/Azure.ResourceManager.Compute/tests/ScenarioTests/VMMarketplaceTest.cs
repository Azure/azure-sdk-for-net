// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;
using Plan = Azure.ResourceManager.Compute.Models.Plan;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMMarketplaceTest : VMTestBase
    {
        public VMMarketplaceTest(bool isAsync)
         : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        public const string vmmPublisherName = "datastax";
        public const string vmmOfferName = "datastax-enterprise-non-production-use-only";
        public const string vmmSku = "sandbox_single-node";

        public async Task<VirtualMachineImage> GetMarketplaceImage()
        {
            ImageReference imageRef = await FindVMImage(vmmPublisherName, vmmOfferName, vmmSku);
            // Query the image directly in order to get all the properties, including PurchasePlan
            return await VirtualMachineImagesOperations.GetAsync(m_location, vmmPublisherName, vmmOfferName, vmmSku, imageRef.Version);
        }

        [Test]
        public async Task TestVMMarketplace()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference dummyImageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var img = await GetMarketplaceImage();

            Action<VirtualMachine> useVMMImage = vm =>
            {
                vm.StorageProfile.DataDisks = null;
                vm.StorageProfile.ImageReference = new ImageReference
                {
                    Publisher = vmmPublisherName,
                    Offer = vmmOfferName,
                    Sku = vmmSku,
                    Version = img.Name
                };

                vm.Plan = new Plan()
                {
                    Name = img.Plan.Name,
                    Product = img.Plan.Product,
                    PromotionCode = null,
                    Publisher = img.Plan.Publisher
                };
            };

            VirtualMachine vm1 = null;
            inputVM = null;
            try
            {
                var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, dummyImageRef, useVMMImage);
                vm1 = returnTwoVM.Item1;
                inputVM = returnTwoVM.Item2;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("User failed validation to purchase resources."))
                {
                    return;
                }
                throw;
            }

            // Validate the VMM Plan field
            ValidateMarketplaceVMPlanField(vm1, img);

            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
        }

        [Test]
        public async Task TestVMBYOL()
        {
            EnsureClientsInitialized(DefaultLocation);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;

            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            ImageReference dummyImageRef = null;

            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            Action<VirtualMachine> useVMMImage = async vm =>
            {
                vm.StorageProfile.ImageReference = await GetPlatformVMImage(true);
                vm.LicenseType = "Windows_Server";
            };

            VirtualMachine vm1 = null;
            try
            {
                var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, dummyImageRef, useVMMImage);
                vm1 = returnTwoVM.Item1;
                inputVM = returnTwoVM.Item2;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("License type cannot be specified when creating a virtual machine from platform image. Please use an image from on-premises instead."))
                {
                    return;
                }
                else if (ex.Message.Equals("Long running operation failed with status 'Failed'."))
                {
                    return;
                }
                throw;
            }
            var getResponse = await VirtualMachinesOperations.GetAsync(rgName, vm1.Name);
            //var getResponse = await VirtualMachinesClient.GetAsync(rgName, vm1.Name).GetAwaiter().GetResult();
            //Assert.True(getResponse.Status == HttpStatusCode.OK);
            ValidateVM(inputVM, getResponse,
                Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));
            var lroResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
            //var lroResponse = await VirtualMachinesClient.DeleteWithHttpMessagesAsync(rgName, inputVM.Name).GetAwaiter().GetResult();
            /////TODO
            //Assert.True(lroResponse .StatusCode == HttpStatusCode.OK);
        }
        private void ValidateMarketplaceVMPlanField(VirtualMachine vm, VirtualMachineImage img)
        {
            Assert.NotNull(vm.Plan);
            Assert.AreEqual(img.Plan.Publisher, vm.Plan.Publisher);
            Assert.AreEqual(img.Plan.Product, vm.Plan.Product);
            Assert.AreEqual(img.Plan.Name, vm.Plan.Name);
        }
    }
}
