//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
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
