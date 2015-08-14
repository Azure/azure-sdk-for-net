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

using System;
using System.Net;
using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Testing;
using Xunit;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    public class PirTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void VMImage()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = ComputeManagementTestUtilities.GetComputeManagementClient(fixture);
                var storage = fixture.GetStorageManagementClient();

                // Test only in Dogfood environment
                if (compute.BaseUri.ToString().Contains(".management.core.windows.net"))
                {
                    return;
                }

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("rdfepir").ToLower();
                    var vmImageName = TestUtilities.GenerateName("vmimage").ToLower();
                    var vmImageBlobName = vmImageName + ".vhd";
                    var publicVMImageBlob_Linux_WestUS = new Uri("http://longlivedstoragerruswest.blob.core.test-cint.azure-test.net/vhdblobs/CoreOS-Stable-Generalized.30GB.vhd");
                    string location = "West US";

                    try
                    {
                        // **************
                        // SETUP
                        // **************
                        // Create storage account. Used to place vhd blobs.
                        storage.StorageAccounts.Create(
                            new StorageAccountCreateParameters
                            {
                                Location = location,
                                Label = storageAccountName,
                                Name = storageAccountName,
                                AccountType = StorageAccountTypes.StandardGRS
                            });

                        // Copy public vmimage blob into our storage account (needed for vmimage create call to work).
                        var vmImageBlobUri = Microsoft.Azure.Test.ComputeManagementTestUtilities.CopyPageBlobInStorage(
                            storageAccountName,
                            publicVMImageBlob_Linux_WestUS,
                            "vmimages",
                            vmImageBlobName);

                        // Create vmimage from vhd in our storage account blob. Now we can create VMs from this image.
                        compute.VirtualMachineVMImages.Create(
                            new VirtualMachineVMImageCreateParameters
                            {
                                Name = vmImageName,
                                Label = "test",
                                Description = "test",
                                Eula = "http://test.com",
                                SmallIconUri = "test",
                                IconUri = "test",
                                PrivacyUri = new Uri("http://test.com/"),
                                ShowInGui = false,
                                ImageFamily = "test",
                                Language = "test",
                                PublishedDate = DateTime.Now,
                                RecommendedVMSize = VirtualMachineRoleSize.Small,
                                OSDiskConfiguration = new OSDiskConfigurationCreateParameters
                                {
                                    HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                    OS = VirtualMachineVMImageOperatingSystemType.Windows,
                                    OSState = VirtualMachineVMImageOperatingSystemState.Generalized,
                                    MediaLink = vmImageBlobUri
                                }
                            });

                        // **************
                        // TESTS
                        // **************
                        var vmImageParamater = new VirtualMachineVMImageReplicateParameters()
                        {
                            TargetLocations = new[] {location},
                            ComputeImageAttributes = new ComputeImageAttributes()
                            {
                                Offer = "TestOffer",
                                Sku = "Standard",
                                Version = "1.0.0"
                            },
                            // Providing this should fail for a subscription that 
                            // does not have image market place rights.
                            // Only one customer can hve image market place rights.
                            MarketplaceImageAttributes = new MarketplaceImageAttributes()
                            {
                                PublisherId = "publisherId",
                                Plan = new Plan()
                                {
                                    Name = "PlanName",
                                    Publisher = "PlanPublisher",
                                    Product = "PlanProduct"
                                }
                            }
                        };

                        // Replicate    (check new contract with ComputeImageAttributes and MarketplaceImageAttributes is accepted - 200 OK)
                        var replicateResponse = compute.VirtualMachineVMImages.Replicate(vmImageName, vmImageParamater);
                        
                        Assert.Equal(HttpStatusCode.OK, replicateResponse.StatusCode);
                        Assert.True(!string.IsNullOrEmpty(replicateResponse.RequestId));

                        // ListDetails  (check new contract with ComputeImageAttributes and MarketplaceImageAttributes is returned)
                        var vmImage = compute.VirtualMachineVMImages.GetDetails(vmImageName);
                        
                        Assert.NotNull(vmImage.ComputeImageAttributes);
                        Assert.Equal(vmImageParamater.ComputeImageAttributes.Offer, vmImage.ComputeImageAttributes.Offer);
                        Assert.Equal(vmImageParamater.ComputeImageAttributes.Version, vmImage.ComputeImageAttributes.Version);
                        Assert.Equal(vmImageParamater.ComputeImageAttributes.Sku, vmImage.ComputeImageAttributes.Sku);

                        Assert.NotNull(vmImage.MarketplaceImageAttributes);
                        Assert.Equal(vmImageParamater.MarketplaceImageAttributes.PublisherId, vmImage.MarketplaceImageAttributes.PublisherId);
                        Assert.NotNull(vmImage.MarketplaceImageAttributes.Plan);
                        Assert.Equal(vmImageParamater.MarketplaceImageAttributes.Plan.Name, vmImage.MarketplaceImageAttributes.Plan.Name);
                        Assert.Equal(vmImageParamater.MarketplaceImageAttributes.Plan.Product, vmImage.MarketplaceImageAttributes.Plan.Product);
                        Assert.Equal(vmImageParamater.MarketplaceImageAttributes.Plan.Publisher, vmImage.MarketplaceImageAttributes.Plan.Publisher);

                        // Share async    (check new async share succeeds)
                        var shareResponse = compute.VirtualMachineVMImages.Share(vmImageName, "Private");

                        Assert.Equal(OperationStatus.Succeeded, shareResponse.Status);
                        Assert.True(!string.IsNullOrEmpty(shareResponse.RequestId));
                    }
                    finally
                    {
                        // CLEANUP
                        // Unreplicate vm image
                        compute.VirtualMachineVMImages.Unreplicate(vmImageName);

                        // Delete vm image
                        compute.VirtualMachineVMImages.Delete(vmImageName, true);

                        // Delete storage account
                        storage.StorageAccounts.Delete(storageAccountName);
                    }
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void OSImage()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = ComputeManagementTestUtilities.GetComputeManagementClient(fixture);
                var storage = fixture.GetStorageManagementClient();

                // Test only in Dogfood environment
                if (compute.BaseUri.ToString().Contains(".management.core.windows.net"))
                {
                    return;
                }

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("rdfepir").ToLower();
                    var osImageName = TestUtilities.GenerateName("osimage").ToLower();
                    var osImageBlobName = osImageName + ".vhd";
                    var publicOSImageBlob_Linux_WestUS = new Uri("http://longlivedstoragerruswest.blob.core.test-cint.azure-test.net/vhdblobs/CoreOS-Stable-Generalized.30GB.vhd");
                    string location = "West US";

                    try
                    {
                        // **************
                        // SETUP
                        // **************
                        // Create storage account. Used to place os blobs.
                        storage.StorageAccounts.Create(
                            new StorageAccountCreateParameters
                            {
                                Location = location,
                                Label = storageAccountName,
                                Name = storageAccountName,
                                AccountType = StorageAccountTypes.StandardGRS
                            });

                        // Copy public osimage blob into our storage account (needed for osimage create call to work).
                        var osImageBlobUri = Microsoft.Azure.Test.ComputeManagementTestUtilities.CopyPageBlobInStorage(
                            storageAccountName,
                            publicOSImageBlob_Linux_WestUS,
                            "osimages",
                            osImageBlobName);

                        // Create osimage from vhd in our storage account blob. Now we can create OSs from this image.
                        compute.VirtualMachineOSImages.Create(new VirtualMachineOSImageCreateParameters()
                        {
                            Name = osImageName,
                            Label = "test",
                            Description = "test",
                            Eula = "http://test.com",
                            SmallIconUri = "test",
                            IconUri = "test",
                            PrivacyUri = new Uri("http://test.com/"),
                            ShowInGui = false,
                            ImageFamily = "test",
                            Language = "test",
                            PublishedDate = DateTime.Now,
                            RecommendedVMSize = VirtualMachineRoleSize.Small,
                            OperatingSystemType = VirtualMachineVMImageOperatingSystemType.Windows,
                            IsPremium = false,
                            MediaLinkUri = osImageBlobUri,
                        });

                        // **************
                        // TESTS
                        // **************
                        var osImageParamater = new VirtualMachineOSImageReplicateParameters()
                        {
                            TargetLocations = new[] { location },
                            ComputeImageAttributes = new ComputeImageAttributes()
                            {
                                Offer = "TestOffer",
                                Sku = "Standard",
                                Version = "1.0.0"
                            },
                            // Providing this should fail for a subscription that 
                            // does not have image market place rights.
                            // Only one customer can hve image market place rights.
                            MarketplaceImageAttributes = new MarketplaceImageAttributes()
                            {
                                PublisherId = "publisherId",
                                Plan = new Plan()
                                {
                                    Name = "PlanName",
                                    Publisher = "PlanPublisher",
                                    Product = "PlanProduct"
                                }
                            }
                        };

                        // Replicate    (check new contract with ComputeImageAttributes and MarketplaceImageAttributes is accepted - 200 OK)
                        var replicateResponse = compute.VirtualMachineOSImages.Replicate(osImageName, osImageParamater);

                        Assert.Equal(HttpStatusCode.OK, replicateResponse.StatusCode);
                        Assert.True(!string.IsNullOrEmpty(replicateResponse.RequestId));

                        // ListDetails  (check new contract with ComputeImageAttributes and MarketplaceImageAttributes is returned)
                        var osImage = compute.VirtualMachineOSImages.GetDetails(osImageName);

                        Assert.NotNull(osImage.ComputeImageAttributes);
                        Assert.Equal(osImageParamater.ComputeImageAttributes.Offer, osImage.ComputeImageAttributes.Offer);
                        Assert.Equal(osImageParamater.ComputeImageAttributes.Version, osImage.ComputeImageAttributes.Version);
                        Assert.Equal(osImageParamater.ComputeImageAttributes.Sku, osImage.ComputeImageAttributes.Sku);

                        Assert.NotNull(osImage.MarketplaceImageAttributes);
                        Assert.Equal(osImageParamater.MarketplaceImageAttributes.PublisherId, osImage.MarketplaceImageAttributes.PublisherId);
                        Assert.NotNull(osImage.MarketplaceImageAttributes.Plan);
                        Assert.Equal(osImageParamater.MarketplaceImageAttributes.Plan.Name, osImage.MarketplaceImageAttributes.Plan.Name);
                        Assert.Equal(osImageParamater.MarketplaceImageAttributes.Plan.Product, osImage.MarketplaceImageAttributes.Plan.Product);
                        Assert.Equal(osImageParamater.MarketplaceImageAttributes.Plan.Publisher, osImage.MarketplaceImageAttributes.Plan.Publisher);

                        // Share async    (check new async share succeeds)
                        var shareResponse = compute.VirtualMachineOSImages.Share(osImageName, "Private");

                        Assert.Equal(OperationStatus.Succeeded, shareResponse.Status);
                        Assert.True(!string.IsNullOrEmpty(shareResponse.RequestId));
                    }
                    finally
                    {
                        // CLEANUP
                        // Unreplicate os image
                        compute.VirtualMachineOSImages.Unreplicate(osImageName);

                        // Delete os image
                        compute.VirtualMachineOSImages.Delete(osImageName, true);

                        // Delete storage account
                        storage.StorageAccounts.Delete(storageAccountName);
                    }
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }



    }
}
