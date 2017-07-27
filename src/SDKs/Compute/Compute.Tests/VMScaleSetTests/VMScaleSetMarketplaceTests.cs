// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetMarketplaceTests : VMScaleSetTestsBase
    {
        public const string vmmPublisherName = "datastax";
        public const string vmmOfferName = "datastax-enterprise";
        public const string vmmSku = "datastaxenterprise";

        public VirtualMachineImage GetMarketplaceImage()
        {
            ImageReference imageRef = FindVMImage(vmmPublisherName, vmmOfferName, vmmSku);
            // Query the image directly in order to get all the properties, including PurchasePlan
            return m_CrpClient.VirtualMachineImages.Get(m_location, vmmPublisherName, vmmOfferName, vmmSku, imageRef.Version);
        }

        [Fact]
        public void TestVMScaleSetMarketplace()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference dummyImageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                var img = GetMarketplaceImage();

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
                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, dummyImageRef, out inputVMScaleSet, vmScaleSetCustomizer: useVMMImage);

                    // Validate the VMM Plan field
                    ValidateMarketplaceVMScaleSetPlanField(vmScaleSet, img);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Legal terms have not been accepted for this item on this subscription."))
                    {
                        return;
                    }
                }
            }

        }

        private void ValidateMarketplaceVMScaleSetPlanField(VirtualMachineScaleSet vmScaleSet, VirtualMachineImage img)
        {
            Assert.NotNull(vmScaleSet.Plan);
            Assert.Equal(img.Plan.Publisher, vmScaleSet.Plan.Publisher);
            Assert.Equal(img.Plan.Product, vmScaleSet.Plan.Product);
            Assert.Equal(img.Plan.Name, vmScaleSet.Plan.Name);
        }
    }
}
