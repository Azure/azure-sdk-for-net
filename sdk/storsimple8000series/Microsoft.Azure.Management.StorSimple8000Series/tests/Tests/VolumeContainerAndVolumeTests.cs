using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class VolumeContainerAndVolumeTests : StorSimpleTestBase
    {
        public VolumeContainerAndVolumeTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestVolumeContainerAndVolume()
        {
            //check and get prerequisites - device, sac, acr, bws
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var sac = Helpers.CheckAndGetStorageAccountCredential(this, TestConstants.DefaultStorageAccountCredential);
            var bandwidthSettings = Helpers.CheckAndGetBandwidthSettings(this, requiredCount: 1);
            var acrs = Helpers.CheckAndGetAccessControlRecords(this, requiredCount: 1);
            var deviceName = device.Name;
            var sacName = sac.Name;
            var bwsName = bandwidthSettings.First().Name;
            var acrName = acrs.First().Name;

            //initialize entity names
            var vcName = "VolumeContainerForSDKTest";
            var encryptionKeyForVC = "DummyEncryptionKeyForVC";
            var volName1 = "Volume1ForSDKTest";
            var volName2 = "Volume2ForSDKTest";

            try
            {
                //Create Volume Container
                var vc = CreateVolumeContainer(deviceName, vcName, encryptionKeyForVC, sacName, bwsName);

                //Create volumes
                var vol1 = CreateVolume(deviceName, vc.Name, volName1, VolumeType.Tiered, VolumeStatus.Offline, acrName);
                var vol2= CreateVolume(deviceName, vc.Name, volName2, VolumeType.Tiered, VolumeStatus.Offline, acrName);

                //get all volumes in device
                var volumesInDevice = ListAllVolumesInDevice(deviceName);

                //Delete volumes in volume container
                DeleteVolumeAndValidate(deviceName, vcName, volName1);
                DeleteVolumeAndValidate(deviceName, vcName, volName2);

                DeleteVolumeContainerAndValidate(deviceName, vcName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Create Volume Container, with Bandwidth Setting template.
        /// </summary>
        private VolumeContainer CreateVolumeContainer(string deviceName, string volumeContainerName, string encryptionKeyInPlainText, string sacName, string bwsName)
        {
            var sac = this.Client.StorageAccountCredentials.Get(sacName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
            var bws = this.Client.BandwidthSettings.Get(bwsName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
            Assert.True(sac != null && sac.Id != null, "Storage account credential name passed for use in volume container doesn't exists.");
            Assert.True(bws != null && bws.Id != null, "Bandwidth setting name passed for use in volume container doesn't exists.");

            var vcToCreate = new VolumeContainer()
            {
                StorageAccountCredentialId = sac.Id,
                BandwidthSettingId = bws.Id,
                EncryptionKey = this.Client.Managers.GetAsymmetricEncryptedSecret(this.ResourceGroupName, this.ManagerName, encryptionKeyInPlainText)
            };

            var vc = this.Client.VolumeContainers.CreateOrUpdate(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                vcToCreate,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(vc != null && vc.Name.Equals(volumeContainerName) &&
                vc.StorageAccountCredentialId.Equals(sac.Id) &&
                vc.BandwidthSettingId.Equals(bws.Id),
                "Creation of Volume Container was not successful");

            return vc;
        }

        /// <summary>
        /// Creates Volume.
        /// </summary>
        private Volume CreateVolume(string deviceName, string volumeContainerName, string volumeName, VolumeType volumeType, VolumeStatus volumeStatus, string acrName)
        {
            var acr = this.Client.AccessControlRecords.Get(acrName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
            Assert.True(acr != null && acr.Name.Equals(acrName), "Access control record name passed for use in volume doesn't exists.");

            var volumeToCreate = new Volume()
            {
                AccessControlRecordIds = new List<string>() { acr.Id },
                MonitoringStatus = MonitoringStatus.Enabled,
                SizeInBytes = (long)5 * 1024 * 1024 * 1024, //5 Gb
                VolumeType = volumeType,
                VolumeStatus = volumeStatus
            };

            var volume = this.Client.Volumes.CreateOrUpdate(deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                volumeName.GetDoubleEncoded(),
                volumeToCreate,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(volume != null && volume.Name.Equals(volumeName) &&
                volume.MonitoringStatus.Equals(MonitoringStatus.Enabled) &&
                volume.VolumeType.Equals(volumeType) &&
                volume.VolumeStatus.Equals(volumeStatus),
                "Creation of Volume was not successful");

            return volume;
        }

        private IEnumerable<Volume> ListAllVolumesInDevice(string deviceName)
        {
            return this.Client.Volumes.ListByDevice(deviceName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
        }

        private void DeleteVolumeContainerAndValidate(string deviceName, string volumeContainerName)
        {
            var doubleEncodedDeviceName = deviceName.GetDoubleEncoded();

            var volumeContainerToDelete = this.Client.VolumeContainers.Get(
                doubleEncodedDeviceName,
                volumeContainerName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);
            
            this.Client.VolumeContainers.Delete(
                doubleEncodedDeviceName,
                volumeContainerToDelete.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var volumeContainers = this.Client.VolumeContainers.ListByDevice(
                doubleEncodedDeviceName,
                this.ResourceGroupName,
                this.ManagerName);

            var volumeContainer = volumeContainers.FirstOrDefault(vc => vc.Name.Equals(volumeContainerToDelete.Name));

            Assert.True(volumeContainer == null, "Deletion of volume-container was not successful.");
        }

        private void DeleteVolumeAndValidate(string deviceName, string volumeContainerName, string volumeName)
        {
            var volumeToDelete = this.Client.Volumes.Get(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                volumeName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            this.Client.Volumes.Delete(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                volumeName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var volumes = this.Client.Volumes.ListByVolumeContainer(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var volume = volumes.FirstOrDefault(v => v.Name.Equals(volumeToDelete.Name));

            Assert.True(volume == null, "Deletion of volume was not successful.");
        }
    }
}

