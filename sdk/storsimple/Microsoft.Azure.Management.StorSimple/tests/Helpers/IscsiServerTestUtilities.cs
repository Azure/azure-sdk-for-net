// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;

    public static partial class TestUtilities
    {

        /// <summary>
        /// Initlaizes a given iscsi server instance
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="storageDomainId"></param>
        /// <param name="backupSchGroupId"></param>
        public static void Initialize(
            this ISCSIServer iscsiServer,
            string storageDomainId,
            string backupSchGroupId)
        {
            iscsiServer.StorageDomainId = storageDomainId;
            iscsiServer.BackupScheduleGroupId = backupSchGroupId;
            iscsiServer.Description = "Demo ISCSIServer for SDK Test";
            iscsiServer.ChapId = "";
            iscsiServer.ReverseChapId = "";

            var chaps = iscsiServer.Client.ChapSettings.ListByDevice(
                iscsiServer.Name,
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            if (chaps != null && chaps.Any())
            {
                iscsiServer.ChapId = chaps.First().Id;
                iscsiServer.ReverseChapId = chaps.First().Id;
            }
        }

        /// <summary>
        /// Creates or updates a given iscsiserver
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static ISCSIServer CreateOrUpdate(
            this ISCSIServer iscsiServer,
            string deviceName)
        {
            iscsiServer.Client.IscsiServers.CreateOrUpdate(
                                deviceName.GetDoubleEncoded(),
                                iscsiServer.Name.GetDoubleEncoded(),
                                iscsiServer,
                                iscsiServer.ResourceGroupName,
                                iscsiServer.ManagerName);

            var iscsiServerCreated = iscsiServer.Client.IscsiServers.Get(
                deviceName,
                iscsiServer.Name,
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            iscsiServerCreated.SetBaseResourceValues(
                iscsiServer.Client,
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            return iscsiServerCreated;
        }

        /// <summary>
        /// Returns a given iscsiserver
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        /// <param name="iscsiServerName"></param>
        /// <returns></returns>
        public static ISCSIServer GetIsciServer(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string deviceName,
                string iscsiServerName)
        {
            var iscsiServer = client.IscsiServers.Get(
                deviceName,
                iscsiServerName,
                resourceGroupName,
                managerName);

            iscsiServer.SetBaseResourceValues(client, resourceGroupName, managerName);
            return iscsiServer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <returns></returns>
        public static Backup BackupNow(this ISCSIServer iscsiServer)
        {
            var startTime = DateTime.UtcNow;
            string deviceName = iscsiServer.Name;
            iscsiServer.Client.IscsiServers.BackupNow(
                deviceName.GetDoubleEncoded(),
                iscsiServer.Name.GetDoubleEncoded(),
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            var endTime = DateTime.UtcNow;

            // Query for a backup
            Expression<Func<BackupFilter, bool>> filter =
                backupFilter => backupFilter.InitiatedBy == InitiatedBy.Manual;

            var backupSets = iscsiServer.Client.Backups.ListByDevice(
                deviceName,
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName,
                new ODataQuery<BackupFilter>(filter));

            Assert.True(backupSets != null && backupSets.Count() > 0,
                "No backups found for iscsiserver:" + iscsiServer.Name);

            var backupElements = backupSets.First().Elements;

            Assert.True(backupElements != null && backupElements.Count() > 0,
                "Backups found, however no backup elements were found.");

            foreach (var bs in backupSets)
            {
                bs.SetBaseResourceValues(
                    iscsiServer.Client,
                    iscsiServer.ResourceGroupName,
                    iscsiServer.ManagerName);
            }

            return backupSets.FirstOrDefault();
        }

        /// <summary>
        /// Returns iscsi servers in a given manager
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static IEnumerable<ISCSIServer> GetIscsiServers(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var iscsiServers = client.IscsiServers.ListByManager(resourceGroupName, managerName);

            if (iscsiServers != null)
            {
                foreach (var fs in iscsiServers)
                {
                    fs.SetBaseResourceValues(client, resourceGroupName, managerName);
                }
            }

            return iscsiServers;
        }

        /// <summary>
        /// Returns disks from a given iscsiserver on a device
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static IEnumerable<ISCSIDisk> GetIscsiDisks(
                this ISCSIServer iscsiServer,
                string deviceName)
        {
            var iscsiDisks = iscsiServer.Client.IscsiDisks.ListByIscsiServer(
                deviceName.GetDoubleEncoded(),
                iscsiServer.Name.GetDoubleEncoded(),
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            if (iscsiDisks == null || !iscsiDisks.Any())
            {
                // Create a IscsiDisk with Tiered data policy
                var iscsiDisktoCreate = new ISCSIDisk(
                    iscsiServer.Client,
                    iscsiServer.ResourceGroupName,
                    iscsiServer.ManagerName,
                    TestConstants.DefaultTieredIscsiDiskName);
                iscsiDisktoCreate.Initialize(DataPolicy.Tiered);

                var iscsiDisk = iscsiDisktoCreate.CreateOrUpdate(
                    iscsiServer.Name,
                    iscsiServer.Name);
            }

            iscsiDisks = iscsiServer.Client.IscsiDisks.ListByIscsiServer(
                deviceName.GetDoubleEncoded(),
                iscsiServer.Name.GetDoubleEncoded(),
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            foreach (var iscsiDisk in iscsiDisks)
            {
                iscsiDisk.SetBaseResourceValues(
                    iscsiServer.Client,
                    iscsiServer.ResourceGroupName,
                    iscsiServer.ManagerName);
            }

            return iscsiDisks;
        }

        /// <summary>
        /// Returns iscsi server for a given device
        /// </summary>
        /// <param name="iscsiServerName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static Device GetDeviceByIscsiServer(
            string iscsiServerName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var device = client.Devices.Get(iscsiServerName, resourceGroupName, managerName);

            if (device != null)
            {
                device.SetBaseResourceValues(client, resourceGroupName, managerName);
            }

            return device;
        }

        /// <summary>
        /// Returns metrics definitions for a given iscsiserver
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricsDefinition(
            this ISCSIServer iscsiServer, 
            string deviceName)
        {
            return iscsiServer.Client.IscsiServers.ListMetricDefinition(
                 deviceName,
                 iscsiServer.Name,
                 iscsiServer.ResourceGroupName,
                 iscsiServer.ManagerName);
        }

        /// <summary>
        /// Returns metrics for a given iscsiserver
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="deviceName"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this ISCSIServer iscsiServer, 
            string deviceName, 
            ODataQuery<MetricFilter> odataQuery)
        {
            return iscsiServer.Client.IscsiServers.ListMetrics(
                 deviceName,
                 iscsiServer.Name,
                 iscsiServer.ResourceGroupName,
                 iscsiServer.ManagerName,
                 odataQuery);
        }

        /// <summary>
        /// Deletes a given iscsiserver
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        /// <param name="iscsiServerName"></param>
        public static void DeleteAndValidateIscsiServer(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string deviceName,
                string iscsiServerName)
        {
            var iscsiServerToDelete = client.IscsiServers.Get(
                deviceName,
                iscsiServerName,
                resourceGroupName,
                managerName);

            Assert.True(iscsiServerToDelete != null, "Failed to find iscsiserver to delete");

            client.IscsiServers.Delete(deviceName, iscsiServerToDelete.Name, resourceGroupName, managerName);

            // Get IscsiServers by Manager and check
            var iscsiServersByMgrPostDelete = client.IscsiServers.ListByManager(resourceGroupName, managerName);

            // Get IscsiServer by Device and check
            var iscsiServersPostDelete = client.IscsiServers.ListByDevice(
                deviceName,
                resourceGroupName,
                managerName);

            Assert.True(iscsiServersByMgrPostDelete.FirstOrDefault(f =>
                        f.Name.Equals(iscsiServerName, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Failed to delete the iscsiServer" + iscsiServerName);

            Assert.True(iscsiServersPostDelete.FirstOrDefault(f =>
                        f.Name.Equals(iscsiServerName, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Failed to delete the iscsiServer" + iscsiServerName);
        }
    }
}