using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPCreateOptionTests : DiskRPTestsBase
    {
        private static string DiskRPLocation = "centraluseuap";

        /// <summary>
        /// positive test for testing upload disks
        /// </summary>
        [Fact]
        public void UploadDiskPositiveTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Upload, rgName, 32767);
                disk.Location = DiskRPLocation;
                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    //put disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// positive test for testing disks created from a gallery image version
        /// </summary>
        [Fact]
        public void DiskFromGalleryImageVersion()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateBaseDisk(DiskCreateOption.FromImage);
                disk.Location = "centraluseuap";
                disk.CreationData.GalleryImageReference = new ImageDiskReference
                {
                    Id = "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/longrunningrg-centraluseuap/providers/Microsoft.Compute/galleries/swaggergallery/images/swaggerimage/versions/1.1.0",
                    Lun = 0
                };
                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    //put disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// positive test for snapshot created via CopyStart operation
        /// </summary>
        [Fact]
        public void CopyStartSnapshotPositiveTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // Data
                const string location = "centraluseuap";
                const string remoteLocation = "eastus2euap";
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var remoteRgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                var sourceSnapshotName = TestUtilities.GenerateName(DiskNamePrefix);
                var snapshotName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk sourceDisk = GenerateDefaultDisk(DiskCreateOption.Empty, remoteRgName, diskSizeGB: 5, location: remoteLocation);

                try
                {
                    // **********
                    // SETUP
                    // **********
                    // Create resource group
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(remoteRgName, new ResourceGroup { Location = remoteLocation });

                    // Put disk
                    Disk diskOut = m_CrpClient.Disks.CreateOrUpdate(remoteRgName, diskName, sourceDisk);
                    Validate(sourceDisk, diskOut, remoteLocation);

                    // Generate snapshot using disk info
                    Snapshot sourceSnapshot = GenerateDefaultSnapshot(diskOut.Id, incremental: true, location: remoteLocation);
                    Snapshot sourceSnapshotOut = m_CrpClient.Snapshots.CreateOrUpdate(remoteRgName, sourceSnapshotName, sourceSnapshot);

                    // Generate snapshot using snapshot info
                    Snapshot snapshot = GenerateCopyStartSnapshot(sourceSnapshotOut.Id, location: location);

                    // **********
                    // TEST
                    // **********
                    // Put
                    m_CrpClient.Snapshots.CreateOrUpdate(rgName, snapshotName, snapshot);
                    Snapshot snapshotOut = PollCloneSnaphotToCompletion(rgName, snapshotName);
                    Validate(snapshot, snapshotOut, incremental: true);
                    OperateSnapshot(snapshot, rgName, snapshotName, incremental: true);
                }
                finally
                {
                    // Delete resource group
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    m_ResourcesClient.ResourceGroups.Delete(remoteRgName);
                }
            }

        }

        /// <summary>
        /// positive test for testing UploadPreparedSecure disk
        /// </summary>
        [Fact (Skip = "DiskEncryptionSet belongs to different sub")]
        public void DiskWithUploadPreparedSecureCreateOptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);

                Disk disk = GenerateDefaultDisk(DiskCreateOption.UploadPreparedSecure, rgName, 32767);
                disk.SecurityProfile = new DiskSecurityProfile { SecurityType = DiskSecurityTypes.ConfidentialVMDiskEncryptedWithCustomerKey };
                disk.Location = DiskRPLocation;
                disk.SecurityProfile.SecureVMDiskEncryptionSetId = "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/longrunningrg-centraluseuap/providers/Microsoft.Compute/diskEncryptionSets/cvm-des3";
                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    //put disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
                    Assert.NotNull(diskOut.SecurityProfile);
                    Assert.Equal(disk.SecurityProfile.SecurityType, diskOut.SecurityProfile.SecurityType);
                    Assert.Equal(disk.SecurityProfile.SecureVMDiskEncryptionSetId, diskOut.SecurityProfile.SecureVMDiskEncryptionSetId);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// positive test for testing ImportSecure disk
        /// </summary>
        [Fact]
        public void DiskWithImportSecureCreateOptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);

                Disk disk = GenerateBaseDisk(DiskCreateOption.ImportSecure);
                disk.OsType = OperatingSystemTypes.Windows;
                disk.CreationData.SourceUri = "https://swaggeraccount.blob.core.windows.net/swagger/abcd.vhd";
                disk.CreationData.SecurityDataUri = "https://swaggeraccount.blob.core.windows.net/swagger/vmgs.vhd";
                disk.CreationData.StorageAccountId = "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/longrunningrg-centraluseuap/providers/Microsoft.Storage/storageAccounts/swaggeraccount";

                disk.SecurityProfile = new DiskSecurityProfile { SecurityType = DiskSecurityTypes.TrustedLaunch };
                disk.HyperVGeneration = HyperVGeneration.V2;
                disk.Location = DiskRPLocation;
                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });

                    //put disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.CreationData.CreateOption, diskOut.CreationData.CreateOption);
                    Assert.NotNull(diskOut.SecurityProfile);
                    Assert.Equal(disk.CreationData.SecurityDataUri, diskOut.CreationData.SecurityDataUri);
                    Assert.Equal(disk.SecurityProfile.SecurityType, diskOut.SecurityProfile.SecurityType);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}

