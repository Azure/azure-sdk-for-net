// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPCreateOptionTests : DiskRPTestsBase
    {
        public DiskRPCreateOptionTests(bool isAsync)
        : base(isAsync)
        {
        }
        private static string DiskRPLocation = "centralus";

        /// <summary>
        /// positive test for testing upload disks
        /// </summary>
        [Test]
        public async Task UploadDiskPositiveTest()
        {
            EnsureClientsInitialized(DefaultLocation);

            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Upload.ToString(), rgName, 32767);
            disk.Location = DiskRPLocation;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        /// <summary>
        /// positive test for testing disks created from a gallery image version
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task DiskFromGalleryImageVersion()
        {
            EnsureClientsInitialized(DefaultLocation);
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = GenerateBaseDisk(DiskCreateOption.FromImage.ToString());
            disk.Location = DiskRPLocation;
            disk.CreationData.GalleryImageReference = new ImageDiskReference("/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/swaggertests/providers/Microsoft.Compute/galleries/swaggergallery/images/lunexample2/versions/1.0.0", 1);
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync(await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);

            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }
    }
}
