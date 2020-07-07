// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class ImageTests : VMTestBase
    {
        protected string LocationCentralUSEUAP = "centraluseuap";

        public ImageTests(bool isAsync)
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

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        //[Trait("Name", "TestCreateImage_with_DiskEncryptionSet")]
        public async Task TestCreateImage_with_DiskEncryptionSet()
        {
            EnsureClientsInitialized(LocationCentralUSEUAP);

            string diskEncryptionSetId = getDefaultDiskEncryptionSetId();

            await CreateImageTestHelper(DefaultLocation, diskEncryptionSetId);
        }

        [Test]
        //[Trait("Name", "TestCreateImage_without_DiskEncryptionSet")]
        public async Task TestCreateImage_without_DiskEncryptionSet()
        {
            EnsureClientsInitialized(LocationEastUs2UpperCase.ToLower());
            await CreateImageTestHelper(DefaultLocation, diskEncryptionSetId: null);
        }

        private async Task CreateImageTestHelper(string originalTestLocation, string diskEncryptionSetId)
        {
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var imageName = Recording.GenerateAssetName("imageTest");
            // Create a VM, so we can use its OS disk for creating the image
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create Storage Account
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            // Add data disk to the VM.
            Action<VirtualMachine> addDataDiskToVM = vm =>
            {
                string containerName = Recording.GenerateAssetName("testimageoperations", TestPrefix);
                var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
                var vhduri = vhdContainer + string.Format("/{0}.vhd", Recording.GenerateAssetName("testimageoperations", TestPrefix));

                vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                vm.StorageProfile.DataDisks = new List<DataDisk>();
                foreach (int index in new int[] { 1, 2 })
                {
                    var diskName = "dataDisk" + index;
                    var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, Recording.GenerateAssetName("testimageoperations", TestPrefix));
                    var dd = new DataDisk(1 + index, DiskCreateOptionTypes.Empty)
                    {
                        Caching = CachingTypes.None,
                        Image = null,
                        DiskSizeGB = 10,
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
            var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef, addDataDiskToVM);
            var createdVM = returnTwoVM.Item1;
            int expectedDiskLunWithDiskEncryptionSet = createdVM.StorageProfile.DataDisks[0].Lun;
            // Create the Image
            var imageInput = new Image(m_location)
            {
                Tags = new Dictionary<string, string>()
                        {
                            {"RG", "rg"},
                            {"testTag", "1"},
                        },
                StorageProfile = new ImageStorageProfile()
                {
                    OsDisk = new ImageOSDisk(OperatingSystemTypes.Windows, OperatingSystemStateTypes.Generalized)
                    {
                        BlobUri = createdVM.StorageProfile.OsDisk.Vhd.Uri,
                        DiskEncryptionSet = diskEncryptionSetId == null ? null : new DiskEncryptionSetParameters()
                        {
                            Id = diskEncryptionSetId
                        },
                    },
                    DataDisks = new List<ImageDataDisk>()
                            {
                                new ImageDataDisk(expectedDiskLunWithDiskEncryptionSet)
                                {
                                    BlobUri = createdVM.StorageProfile.DataDisks[0].Vhd.Uri,
                                    DiskEncryptionSet = diskEncryptionSetId == null ? null: new DiskEncryptionSetParameters()
                                    {
                                        Id = diskEncryptionSetId
                                    },
                                }
                            }
                },
                HyperVGeneration = HyperVGenerationTypes.V1
            };
            var image = await WaitForCompletionAsync(await ImagesOperations.StartCreateOrUpdateAsync(rgName, imageName, imageInput));
            var getImage = (await ImagesOperations.GetAsync(rgName, imageName)).Value;
            ValidateImage(imageInput, getImage);
            if (diskEncryptionSetId != null)
            {
                Assert.True(getImage.StorageProfile.OsDisk.DiskEncryptionSet != null, "OsDisk.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getImage.StorageProfile.OsDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "getImage.StorageProfile.OsDisk.DiskEncryptionSet is not matching with expected DiskEncryptionSet resource");
                Assert.AreEqual(1, getImage.StorageProfile.DataDisks.Count);
                Assert.True(getImage.StorageProfile.DataDisks[0].DiskEncryptionSet != null, ".DataDisks.DiskEncryptionSet is null");
                Assert.True(string.Equals(diskEncryptionSetId, getImage.StorageProfile.DataDisks[0].DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                    "DataDisks.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
            }
            ImageUpdate updateParams = new ImageUpdate()
            {
                Tags = getImage.Tags
            };
            string tagKey = "UpdateTag";
            updateParams.Tags.Add(tagKey, "TagValue");
            await WaitForCompletionAsync(await ImagesOperations.StartUpdateAsync(rgName, imageName, updateParams));
            getImage = (await ImagesOperations.GetAsync(rgName, imageName)).Value;
            Assert.True(getImage.Tags.ContainsKey(tagKey));
            var listResponse = await (ImagesOperations.ListByResourceGroupAsync(rgName)).ToEnumerableAsync();
            Assert.IsTrue(listResponse.Count() == 1);
            await WaitForCompletionAsync(await ImagesOperations.StartDeleteAsync(rgName, image.Value.Name));
        }

        public void ValidateImage(Image imageIn, Image imageOut)
        {
            Assert.True(!string.IsNullOrEmpty(imageOut.ProvisioningState));
            if (imageIn.Tags != null)
            {
                foreach (KeyValuePair<string, string> kvp in imageIn.Tags)
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
            Assert.AreEqual(imageIn.StorageProfile.ZoneResilient, imageOut.StorageProfile.ZoneResilient);
        }
    }
}
