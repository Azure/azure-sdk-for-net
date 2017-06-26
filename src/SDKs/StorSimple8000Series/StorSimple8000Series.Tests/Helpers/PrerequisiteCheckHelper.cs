// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public static partial class Helpers
    {
        public static IEnumerable<StorageAccountCredential> CheckAndGetStorageAccountCredentials(StorSimpleTestBase testBase, int requiredCount)
        {
            var sacs = testBase.Client.StorageAccountCredentials.ListByManager(
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(sacs.Count() >= requiredCount, string.Format("Could not find minimum Storage Account Credentials: Required={0}, ActuallyFound={1}", requiredCount, sacs.Count()));

            return sacs;
        }

        public static StorageAccountCredential CheckAndGetStorageAccountCredential(StorSimpleTestBase testBase, string sacName)
        {
            var sac = testBase.Client.StorageAccountCredentials.Get(
                sacName.GetDoubleEncoded(),
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(sac != null && sac.Name.Equals(sacName), string.Format("Could not find specific Storage Account Credentials(Name={0})", sacName));

            return sac;
        }

        public static IEnumerable<AccessControlRecord> CheckAndGetAccessControlRecords(StorSimpleTestBase testBase, int requiredCount)
        {
            var accessControlRecords = testBase.Client.AccessControlRecords.ListByManager(
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(accessControlRecords.Count() >= requiredCount, string.Format("Could not find minimum access control records: Required={0}, ActuallyFound={1}", requiredCount, accessControlRecords.Count()));

            return accessControlRecords;
        }

        public static IEnumerable<BandwidthSetting> CheckAndGetBandwidthSettings(StorSimpleTestBase testBase, int requiredCount)
        {
            var bandwidthSettings = testBase.Client.BandwidthSettings.ListByManager(
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(bandwidthSettings.Count() >= requiredCount, string.Format("Could not find minimum Bandwidth settings: Required={0}, ActuallyFound={1}", requiredCount, bandwidthSettings.Count()));

            return bandwidthSettings;
        }

        /// <summary>
        /// Checks if minimum number of configured devices required for the testcase exists. If yes, returns the devices.
        /// </summary>
        public static IEnumerable<Device> CheckAndGetConfiguredDevices(StorSimpleTestBase testBase, int requiredCount)
        {
            var devices = testBase.Client.Devices.ListByManager(testBase.ResourceGroupName, testBase.ManagerName);

            var configuredDeviceCount = 0;
            var configuredDeviceNames = new List<Device>();

            foreach (var device in devices)
            {
                if (device.Status == DeviceStatus.Online)
                {
                    configuredDeviceCount++;
                    configuredDeviceNames.Add(device);
                }
            }

            Assert.True(configuredDeviceCount >= requiredCount, string.Format("Could not find minimum configured devices: Required={0}, ActuallyFound={1}", requiredCount, configuredDeviceCount));

            return configuredDeviceNames;
        }

        public static Device CheckAndGetConfiguredDevice(StorSimpleTestBase testBase, string deviceName)
        {
            var devices = testBase.Client.Devices.ListByManager(testBase.ResourceGroupName, testBase.ManagerName);

            var device = devices.FirstOrDefault(d => d.Status.Equals(DeviceStatus.Online) && d.Name.Equals(deviceName));

            Assert.True(device != null, string.Format("Could not find configured device with the specified device-name: {0}", deviceName));

            return device;
        }

        public static Device CheckAndGetDevice(StorSimpleTestBase testBase, DeviceType deviceType, DeviceStatus deviceStatus = DeviceStatus.Online)
        {
            var devices = testBase.Client.Devices.ListByManager(testBase.ResourceGroupName, testBase.ManagerName);

            var device = devices.FirstOrDefault(d => d.Status.Equals(deviceStatus) && d.DeviceType.Equals(deviceType));

            Assert.True(device != null, string.Format("Could not find configured device with the specified device-type: {0}", deviceType.ToString()));

            return device;
        }

        public static IEnumerable<VolumeContainer> CheckAndGetVolumeContainers(StorSimpleTestBase testBase, string deviceName, int requiredCount)
        {
            var volumeContainers = testBase.Client.VolumeContainers.ListByDevice(
                                    deviceName,
                                    testBase.ResourceGroupName,
                                    testBase.ManagerName);
            Assert.True(volumeContainers.Count() >= requiredCount, string.Format("Could not find minimum volumeContainers: Required={0}, ActuallyFound={1}", requiredCount, volumeContainers.Count()));

            return volumeContainers;
        }

        public static IEnumerable<Volume> CheckAndGetVolumes(StorSimpleTestBase testBase, string deviceName, string volumeContainerName, int requiredCount)
        {
            var volumes = testBase.Client.Volumes.ListByVolumeContainer(
                                     deviceName,
                                     volumeContainerName,
                                     testBase.ResourceGroupName,
                                     testBase.ManagerName);
            Assert.True(volumes.Count() >= requiredCount, string.Format("Could not find minimum volumes: Required={0}, ActuallyFound={1}", requiredCount, volumes.Count()));

            return volumes;
        }
    }
}