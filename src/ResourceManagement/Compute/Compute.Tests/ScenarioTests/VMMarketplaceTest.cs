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

using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMMarketplaceTest : VMTestBase
    {
        public const string vmmPublisherName = "datastax";
        public const string vmmOfferName = "datastax-enterprise-non-production-use-only";
        public const string vmmSku = "sandbox_single-node";

        public VirtualMachineImage GetMarketplaceImage()
        {
            ImageReference imageRef = FindVMImage(vmmPublisherName, vmmOfferName, vmmSku);
            // Query the image directly in order to get all the properties, including PurchasePlan
            var parameters = new VirtualMachineImageGetParameters
            {
                Location = m_location,
                PublisherName = vmmPublisherName, Offer = vmmOfferName, Skus = vmmSku,
                Version = imageRef.Version
            };
            return m_CrpClient.VirtualMachineImages.Get(parameters).VirtualMachineImage;
        }

        [Fact]
        public void TestVMMarketplace()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference dummyImageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount( rgName, storageAccountName );

                    var img = GetMarketplaceImage();

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

                        vm.Plan = new Plan
                        {
                            Name = img.PurchasePlan.Name,
                            Product = img.PurchasePlan.Product,
                            PromotionCode = null,
                            Publisher = img.PurchasePlan.Publisher
                        }; 
                    };

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, dummyImageRef, out inputVM, useVMMImage);

                    // Validate the VMM Plan field
                    ValidateMarketplaceVMPlanField(vm1, img);

                    var lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    Assert.Equal(OperationStatus.Succeeded, lroResponse.Status);
                }
                finally
                {
                    // Don't wait for RG deletion since it's too slow, and there is nothing interesting expected with 
                    // the resources from this test.
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.BeginDeleting(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.Accepted ||
                        deleteResourceGroupResponse.StatusCode == HttpStatusCode.NotFound);
                }
            }
        }

        private void ValidateMarketplaceVMPlanField(VirtualMachine vm, VirtualMachineImage img)
        {
            Assert.NotNull(vm.Plan);
            Assert.Equal(img.PurchasePlan.Publisher, vm.Plan.Publisher);
            Assert.Equal(img.PurchasePlan.Product, vm.Plan.Product);
            Assert.Equal(img.PurchasePlan.Name, vm.Plan.Name);
        }
    }
}
