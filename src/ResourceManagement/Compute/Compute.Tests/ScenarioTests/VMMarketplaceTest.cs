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
        public const string vmmPublisherName = "marketplace-test";
        public const string vmmOfferName = "marketplace-offer-preview";
        public const string vmmSku = "basic";
        public const string vmmVer = "1.0.0";

        public VirtualMachineImage GetMarketplaceImage()
        {
            var parameters = new VirtualMachineImageGetParameters
            {
                Location = m_location,
                PublisherName = vmmPublisherName,
                Offer = vmmOfferName,
                Skus = vmmSku,
                Version = vmmVer
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

                string imgRefId = GetPlatformOSImage(useWindowsImage: true);
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
                        vm.StorageProfile.SourceImage = null;
                        vm.StorageProfile.DataDisks = null;
                        vm.StorageProfile.ImageReference = new ImageReference
                        {
                            Publisher = vmmPublisherName,
                            Offer = vmmOfferName,
                            Sku = vmmSku,
                            Version = vmmVer
                        };

                        /* vm.Plan = new Plan
                        {
                            Name = img.PurchasePlan.Name,
                            Product = img.PurchasePlan.Product,
                            PromotionCode = null,
                            Publisher = img.PurchasePlan.Publisher
                        }; */
                    };

                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imgRefId, out inputVM, useVMMImage);

                    // Validate the VMM Plan field
                    ValidateMarketplaceVMPlanField(vm1, img);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, inputVM.Name);
                    Assert.True(getVMWithInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(getVMWithInstanceViewResponse.VirtualMachine != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse.VirtualMachine);

                    var lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    Assert.True(lroResponse.Status != OperationStatus.Failed);
                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                }
            }
        }

        private void ValidateMarketplaceVMPlanField(VirtualMachine vm, VirtualMachineImage img)
        {
            if (vm.Plan != null)
            {
                Assert.True(vm.Plan.Name != null);
                Assert.True(vm.Plan.Product != null);
                Assert.True(vm.Plan.PromotionCode != null);
            }
        }
    }
}
