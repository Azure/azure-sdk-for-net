// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    public static partial class Helpers
    {
        public static IEnumerable<StorageAccountCredential> CheckAndGetStorageAccountCredentials(
            StorSimpleTestBase testBase, 
            int requiredCount)
        {
            var sacs = testBase.Client.StorageAccountCredentials.ListByManager(
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(
                sacs.Count() >= requiredCount, 
                string.Format(
                    "Could not find minimum Storage Account Credentials: Required={0}, ActuallyFound={1}", 
                    requiredCount, 
                    sacs.Count()));

            return sacs;
        }

        /// <summary>
        /// Returns a storageaccountcredential
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="sacName"></param>
        /// <returns></returns>
        public static StorageAccountCredential CheckAndGetStorageAccountCredential(
            StorSimpleTestBase testBase, 
            string sacName)
        {
            var sac = testBase.Client.StorageAccountCredentials.Get(
                sacName.GetDoubleEncoded(),
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(sac != null && sac.Name.Equals(sacName), string.Format("Could not find specific Storage Account Credentials(Name={0})", sacName));

            return sac;
        }

        /// <summary>
        /// Returns acrs
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="requiredCount"></param>
        /// <returns></returns>
        public static IEnumerable<AccessControlRecord> CheckAndGetAccessControlRecords(
            StorSimpleTestBase testBase, 
            int requiredCount)
        {
            var accessControlRecords = testBase.Client.AccessControlRecords.ListByManager(
                testBase.ResourceGroupName,
                testBase.ManagerName);

            Assert.True(accessControlRecords.Count() >= requiredCount, string.Format("Could not find minimum access control records: Required={0}, ActuallyFound={1}", requiredCount, accessControlRecords.Count()));

            return accessControlRecords;
        }

        /// <summary>
        /// Checks if minimum number of configured devices required for the testcase exists. 
        /// If yes, returns the devices.
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="deviceStatus"></param>
        /// <param name="requiredCount"></param>
        /// <returns></returns>
        public static IEnumerable<Device> CheckAndGetDevicesByStatus(
            StorSimpleTestBase testBase, 
            DeviceStatus deviceStatus,
            int requiredCount)
        {
            var devices = testBase.Client.Devices.ListByManager(
                testBase.ResourceGroupName, 
                testBase.ManagerName);

            var configuredDeviceCount = 0;
            var configuredDeviceNames = new List<Device>();

            foreach (var device in devices)
            {
                device.ResourceGroupName = testBase.ResourceGroupName;
                device.ManagerName = testBase.ManagerName;
                device.Client = testBase.Client;
                if (device.Status == deviceStatus)
                {
                    configuredDeviceCount++;
                    configuredDeviceNames.Add(device);
                }
            }

            return configuredDeviceNames;
        }

        /// <summary>
        /// Returns a device given a name
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static Device CheckAndGetConfiguredDevice(StorSimpleTestBase testBase, string deviceName)
        {
            var devices = testBase.Client.Devices.ListByManager(testBase.ResourceGroupName, testBase.ManagerName);

            var device = devices.FirstOrDefault(d => d.Status.Equals(DeviceStatus.Online) && d.Name.Equals(deviceName));

            Assert.True(device != null, string.Format("Could not find configured device with the specified device-name: {0}", deviceName));

            return device;
        }

        /// <summary>
        /// Returns device given device type and device status
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceStatus"></param>
        /// <returns></returns>
        public static Device CheckAndGetDevice(
            StorSimpleTestBase testBase, 
            DeviceType deviceType, 
            DeviceStatus deviceStatus = DeviceStatus.Online)
        {
            var devices = testBase.Client.Devices.ListByManager(
                testBase.ResourceGroupName, 
                testBase.ManagerName);

            var device = devices.FirstOrDefault(d => 
                        d.Status.Equals(deviceStatus) && 
                        d.DeviceType.Equals(deviceType));

            Assert.True(
                device != null, 
                string.Format(
                    "Could not find configured device with the specified device-type: {0}", 
                    deviceType.ToString()));

            return device;
        }

        /// <summary>
        /// Returns a fileserver from given manager
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static FileServer CheckAndGetFileServer(
            StorSimpleTestBase testBase, 
            string resourceGroupName, 
            string managerName)
        {
            var fileServers = testBase.Client.FileServers.ListByManager(
                                resourceGroupName,
                                managerName);

            Assert.True(fileServers == null || fileServers.Count() < 1,
                string.Format("Could not find ISCSI servers in manager {0}", managerName));

            return fileServers.FirstOrDefault();
        }

        /// <summary>
        /// Return isci server given a manager
        /// </summary>
        /// <param name="testBase"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static ISCSIServer CheckAndGetISCSIServer(
            StorSimpleTestBase testBase, 
            string resourceGroupName, 
            string managerName)
        {
            var iscsciServers = testBase.Client.IscsiServers.ListByManager(
                                resourceGroupName,
                                managerName);

            Assert.True (
                iscsciServers == null || iscsciServers.Count() > 0, 
                string.Format(
                    "Could not find ISCSI servers in manager {0}", 
                    managerName));

            return iscsciServers.FirstOrDefault();
        }
    }
}