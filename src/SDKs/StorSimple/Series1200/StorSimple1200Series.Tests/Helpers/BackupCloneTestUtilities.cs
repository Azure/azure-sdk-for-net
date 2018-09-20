// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;

    public static partial class TestUtilities
    {
        #region FileServer clone

        /// <summary>
        /// Triggers clone operation on a fileserver using a given backup
        /// </summary>
        /// <param name="backupSet"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServer"></param>
        /// <param name="backupElementName"></param>
        /// <param name="restoredShareName"></param>
        public static void Clone(
            this Backup backupSet,
            string deviceName,
            FileServer fileServer,
            string backupElementName,
            string restoredShareName)
        {
            var device = backupSet.Client.Devices.Get(
                deviceName,
                backupSet.ResourceGroupName,
                backupSet.ManagerName);

            Assert.True(
                device != null,
                "no matching device found with name:" + deviceName);

            Assert.True(
                fileServer != null,
                "FileServer param is null");

            var restoreFileShare = new FileShare(
                backupSet.Client,
                backupSet.ResourceGroupName,
                backupSet.ManagerName,
                TestConstants.DefaultTieredFileShareName);

            restoreFileShare.Initialize(DataPolicy.Tiered);
            restoreFileShare.Description = "Restore file Share";
            restoreFileShare.AdminUser = deviceName + "\\StorSimpleAdmin";

            CloneRequest cloneRequest = new CloneRequest()
            {
                NewEndpointName = restoredShareName,
                TargetAccessPointId = fileServer.Id,
                TargetDeviceId = device.Id,
                Share = restoreFileShare
            };

            backupSet.Client.Backups.Clone(
                device.Name.GetDoubleEncoded(),
                backupSet.Name.GetDoubleEncoded(),
                backupElementName,
                cloneRequest,
                backupSet.ResourceGroupName,
                backupSet.ManagerName);
        }

        #endregion FileServer clone

        #region IscsiServer clone

        /// <summary>
        /// Triggers clone operation on a iscsiserver for given backupset
        /// </summary>
        /// <param name="backupSet"></param>
        /// <param name="deviceName"></param>
        /// <param name="isciServer"></param>
        /// <param name="backupElementName"></param>
        /// <param name="endPointName"></param>
        public static void Clone(
            this Backup backupSet,
            string deviceName,
            ISCSIServer isciServer,
            string backupElementName,
            string endPointName)
        {
            var device = backupSet.Client.Devices.Get(
                deviceName,
                backupSet.ResourceGroupName,
                backupSet.ManagerName);

            Assert.True(
                device != null,
                "no matching device found with name:" + deviceName);

            Assert.True(
                isciServer != null,
                "iscsiServer param is null");

            var restoreIscsiDisk = new ISCSIDisk(
                backupSet.Client,
                backupSet.ResourceGroupName,
                backupSet.ManagerName,
                endPointName);

            restoreIscsiDisk.Initialize(DataPolicy.Tiered);
            restoreIscsiDisk.Description = "Restore Disk ";

            var cloneRequest = new CloneRequest()
            {
                NewEndpointName = endPointName,
                TargetAccessPointId = isciServer.Id,
                TargetDeviceId = device.Id,
                Disk = restoreIscsiDisk
            };

            backupSet.Client.Backups.Clone(
                device.Name.GetDoubleEncoded(),
                backupSet.Name.GetDoubleEncoded(),
                backupElementName,
                cloneRequest,
                backupSet.ResourceGroupName,
                backupSet.ManagerName);

        }
        #endregion IscsiServer clone

        #region General Methods

        /// <summary>
        /// Returns backups for given manager
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="filter"></param>
        public static IPage<Backup> GetBackupsByManager(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            ODataQuery<BackupFilter> filter)
        {
            return client.Backups.ListByManager(
                resourceGroupName,
                managerName,
                filter);
        }

        /// <summary>
        /// Deletes a given backup
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        public static void DeleteBackup(
            string name,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            client.Backups.Delete(deviceName, name, resourceGroupName, managerName);
        }

        public static void GetBackupsByDevice(
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            client.Backups.ListByDevice(
                deviceName,
                resourceGroupName,
                managerName);
        }

        #endregion
    }
}