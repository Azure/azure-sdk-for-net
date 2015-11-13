﻿//
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
            return m_CrpClient.VirtualMachineImages.Get(m_location, vmmPublisherName, vmmOfferName, vmmSku, imageRef.Version);
        }

        [Fact]
        public void TestVMMarketplace()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference dummyImageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
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
                        vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, dummyImageRef, out inputVM, useVMMImage);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Legal terms have not been accepted for this item on this subscription."))
                        {
                            return;
                        }
                    }

                    // Validate the VMM Plan field
                    ValidateMarketplaceVMPlanField(vm1, img);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                finally
                {
                    // Don't wait for RG deletion since it's too slow, and there is nothing interesting expected with 
                    // the resources from this test.
                    // m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                }
            }
        }

        private void ValidateMarketplaceVMPlanField(VirtualMachine vm, VirtualMachineImage img)
        {
            Assert.NotNull(vm.Plan);
            Assert.Equal(img.Plan.Publisher, vm.Plan.Publisher);
            Assert.Equal(img.Plan.Product, vm.Plan.Product);
            Assert.Equal(img.Plan.Name, vm.Plan.Name);
        }
    }
}
