// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
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
                        vm1 = CreateVM(rgName, asName, storageAccountOutput, dummyImageRef, out inputVM, useVMMImage);
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

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                finally
                {
                    // Don't wait for RG deletion since it's too slow, and there is nothing interesting expected with 
                    // the resources from this test.
                    //m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                }
            }
        }

        [Fact]
        public void TestVMBYOL()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                ImageReference dummyImageRef = null;

                // Create Storage Account, so that both the VMs can share it
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                try
                {
                    Action<VirtualMachine> useVMMImage = vm =>
                    {
                        vm.StorageProfile.ImageReference = GetPlatformVMImage(true);
                        vm.LicenseType = "Windows_Server";
                    };

                    VirtualMachine vm1 = null;
                    try
                    {
                        vm1 = CreateVM(rgName, asName, storageAccountOutput, dummyImageRef, out inputVM, useVMMImage);
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

                    var getResponse = m_CrpClient.VirtualMachines.GetWithHttpMessagesAsync(rgName, vm1.Name).GetAwaiter().GetResult();
                    Assert.True(getResponse.Response.StatusCode == HttpStatusCode.OK);
                    ValidateVM(inputVM, getResponse.Body,
                        Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));

                    var lroResponse = m_CrpClient.VirtualMachines.DeleteWithHttpMessagesAsync(rgName, inputVM.Name).GetAwaiter().GetResult();
                    Assert.True(lroResponse.Response.StatusCode == HttpStatusCode.OK);
                }
                finally
                {
                    // Don't wait for RG deletion since it's too slow, and there is nothing interesting expected with
                    // the resources from this test.
                    //var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rgName);
                    m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rgName);
                    //Assert.True(deleteResourceGroupResponse.Result.Response.StatusCode == HttpStatusCode.Accepted ||
                    //   deleteResourceGroupResponse.Result.Response.StatusCode == HttpStatusCode.NotFound);
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
