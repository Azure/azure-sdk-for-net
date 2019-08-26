// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class ImageTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Image
        /// GetImages in a RG
        /// Delete Image
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestImageOperations")]
        public void TestImageOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "FranceCentral");
                EnsureClientsInitialized(context);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);

                var imageName = ComputeManagementTestUtilities.GenerateName("imageTest");

                // Create a VM, so we can use its OS disk for creating the image
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                VirtualMachine inputVM = null;

                try
                {
                    // Create Storage Account
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    // Add data disk to the VM.
                    Action<VirtualMachine> addDataDiskToVM = vm =>
                    {
                        string containerName = HttpMockServer.GetAssetName("TestImageOperations", TestPrefix);
                        var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
                        var vhduri = vhdContainer + string.Format("/{0}.vhd", HttpMockServer.GetAssetName("TestImageOperations", TestPrefix));

                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                        vm.StorageProfile.DataDisks = new List<DataDisk>();
                        foreach (int index in new int[] { 1, 2 })
                        {
                            var diskName = "dataDisk" + index;
                            var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, HttpMockServer.GetAssetName("TestImageOperations", TestPrefix));
                            var dd = new DataDisk
                            {
                                Caching = CachingTypes.None,
                                Image = null,
                                DiskSizeGB = 10,
                                CreateOption = DiskCreateOptionTypes.Empty,
                                Lun = 1 + index,
                                Name = diskName,
                                Vhd = new VirtualHardDisk
                                {
                                    Uri = ddUri
                                }
                            };
                            vm.StorageProfile.DataDisks.Add(dd);
                        }

                        var testStatus = new InstanceViewStatus
                        {
                            Code = "test",
                            Message = "test"
                        };

                        var testStatusList = new List<InstanceViewStatus> { testStatus };
                    };

                    // Create the VM, whose OS disk will be used in creating the image
                    var createdVM = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, addDataDiskToVM);

                    // Create the Image
                    var imageInput = new Image()
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>()
                        {
                            {"RG", "rg"},
                            {"testTag", "1"},
                        },
                        StorageProfile = new ImageStorageProfile()
                        {
                            OsDisk = new ImageOSDisk()
                            {
                                BlobUri = createdVM.StorageProfile.OsDisk.Vhd.Uri,
                                OsState = OperatingSystemStateTypes.Generalized,
                                OsType = OperatingSystemTypes.Windows,
                            },
                            DataDisks = new List<ImageDataDisk>()
                            {
                                new ImageDataDisk()
                                {
                                    BlobUri = createdVM.StorageProfile.DataDisks[0].Vhd.Uri,
                                    Lun = createdVM.StorageProfile.DataDisks[0].Lun,
                                }
                            },
                            ZoneResilient = true
                        }
                    };

                    var image = m_CrpClient.Images.CreateOrUpdate(rgName, imageName, imageInput);
                    var getImage = m_CrpClient.Images.Get(rgName, imageName);

                    ValidateImage(imageInput, getImage);

                    ImageUpdate updateParams = new ImageUpdate()
                    {
                        Tags = getImage.Tags
                    };

                    string tagKey = "UpdateTag";
                    updateParams.Tags.Add(tagKey, "TagValue");
                    m_CrpClient.Images.Update(rgName, imageName, updateParams);

                    getImage = m_CrpClient.Images.Get(rgName, imageName);
                    Assert.True(getImage.Tags.ContainsKey(tagKey));

                    var listResponse = m_CrpClient.Images.ListByResourceGroup(rgName);
                    Assert.Single(listResponse);

                    m_CrpClient.Images.Delete(rgName, image.Name);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    if (inputVM != null)
                    {
                        m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    }

                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        void ValidateImage(Image imageIn, Image imageOut)
        {
            Assert.True(!string.IsNullOrEmpty(imageOut.ProvisioningState));

            if(imageIn.Tags != null)
            {
                foreach(KeyValuePair<string, string> kvp in imageIn.Tags)
                {
                    Assert.True(imageOut.Tags[kvp.Key] == kvp.Value);
                }
            }

            Assert.NotNull(imageOut.StorageProfile.OsDisk);
            if (imageIn.StorageProfile.OsDisk != null)
            {
                Assert.True(imageOut.StorageProfile.OsDisk.BlobUri
                    == imageIn.StorageProfile.OsDisk.BlobUri);

                Assert.True(imageOut.StorageProfile.OsDisk.OsState
                    == imageIn.StorageProfile.OsDisk.OsState);

                Assert.True(imageOut.StorageProfile.OsDisk.OsType
                   == imageIn.StorageProfile.OsDisk.OsType);
            }

            if (imageIn.StorageProfile.DataDisks != null &&
                imageIn.StorageProfile.DataDisks.Any())
            {
                foreach (var dataDisk in imageIn.StorageProfile.DataDisks)
                {
                    var dataDiskOut = imageOut.StorageProfile.DataDisks.FirstOrDefault(
                            d => int.Equals(dataDisk.Lun, d.Lun));

                    Assert.NotNull(dataDiskOut);
                    Assert.NotNull(dataDiskOut.BlobUri);
                    Assert.NotNull(dataDiskOut.DiskSizeGB);
                }
            }

            Assert.Equal(imageIn.StorageProfile.ZoneResilient, imageOut.StorageProfile.ZoneResilient);
        }
    }
}
