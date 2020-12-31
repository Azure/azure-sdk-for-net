// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;
using Plan = Azure.ResourceManager.Compute.Models.Plan;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetMarketplaceTests : VMScaleSetTestsBase
    {
        public VMScaleSetMarketplaceTests(bool isAsync)
        : base(isAsync)
        {
        }
        public const string vmmPublisherName = "datastax";
        public const string vmmOfferName = "datastax-enterprise";
        public const string vmmSku = "datastaxenterprise";
        public async Task<VirtualMachineImage> GetMarketplaceImage()
        {
            ImageReference imageRef = await FindVMImage(vmmPublisherName, vmmOfferName, vmmSku);
            // Query the image directly in order to get all the properties, including PurchasePlan

            return await VirtualMachineImagesOperations.GetAsync(m_location, vmmPublisherName, vmmOfferName, vmmSku, imageRef.Version);
        }
        [Test]
        public async Task TestVMScaleSetMarketplace()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference dummyImageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var img = await GetMarketplaceImage();

            Action<VirtualMachineScaleSet> useVMMImage = vmss =>
            {
                vmss.VirtualMachineProfile.StorageProfile.ImageReference = new ImageReference
                {
                    Publisher = vmmPublisherName,
                    Offer = vmmOfferName,
                    Sku = vmmSku,
                    Version = "latest"
                };

                vmss.Plan = new Plan
                {
                    Name = img.Plan.Name,
                    Product = img.Plan.Product,
                    PromotionCode = null,
                    Publisher = img.Plan.Publisher
                };
            };

            try
            {
                VirtualMachineScaleSet inputVMScaleSet;
                var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, dummyImageRef , vmScaleSetCustomizer: useVMMImage);
                VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
                inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
                // Validate the VMM Plan field
                ValidateMarketplaceVMScaleSetPlanField(vmScaleSet, img);

                await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartDeleteAsync(rgName, vmssName));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Legal terms have not been accepted for this item on this subscription."))
                {
                    return;
                }
            }
        }

        private void ValidateMarketplaceVMScaleSetPlanField(VirtualMachineScaleSet vmScaleSet, VirtualMachineImage img)
        {
            Assert.NotNull(vmScaleSet.Plan);
            Assert.AreEqual(img.Plan.Publisher, vmScaleSet.Plan.Publisher);
            Assert.AreEqual(img.Plan.Product, vmScaleSet.Plan.Product);
            Assert.AreEqual(img.Plan.Name, vmScaleSet.Plan.Name);
        }
    }
}
