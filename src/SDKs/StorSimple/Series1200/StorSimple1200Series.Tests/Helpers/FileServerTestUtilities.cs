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
        /// Initializes fileserver for given instance
        /// </summary>
        /// <param name="fileServer"></param>
        /// <param name="storageDomainId"></param>
        /// <param name="backupSchGroupId"></param>
        public static void Initialize(
            this FileServer fileServer,
            string storageDomainId,
            string backupSchGroupId)
        {
            fileServer.StorageDomainId = storageDomainId;
            fileServer.BackupScheduleGroupId = backupSchGroupId;
            fileServer.DomainName = TestConstants.DomainName;
            fileServer.Description = "Demo FileServer for SDK Test";
        }

        /// <summary>
        /// Create or Updates given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static FileServer CreateOrUpdate(
            this FileServer fileServer,
            string deviceName)
        {
            var fileServerCreated = fileServer.Client.FileServers.CreateOrUpdate(
                                deviceName.GetDoubleEncoded(),
                                fileServer.Name.GetDoubleEncoded(),
                                fileServer,
                                fileServer.ResourceGroupName,
                                fileServer.ManagerName);

            Assert.True(fileServerCreated.Name == fileServer.Name &&
                fileServerCreated.Description == fileServer.Description &&
                fileServerCreated.DomainName == fileServer.DomainName &&
                fileServerCreated.BackupScheduleGroupId == fileServer.BackupScheduleGroupId &&
                fileServerCreated.StorageDomainId == fileServer.StorageDomainId,
                "Creation of FileServer failed in validation");

            fileServerCreated.SetBaseResourceValues(
                fileServer.Client,
                fileServer.ResourceGroupName,
                fileServer.ManagerName);
            return fileServerCreated;
        }

        /// <summary>
        /// Returns a given fileserver from the manager
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        /// <returns></returns>
        public static FileServer GetFileServer(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string deviceName,
                string fileServerName)
        {
            var fileServer = client.FileServers.Get(
                deviceName,
                fileServerName,
                resourceGroupName,
                managerName);
            fileServer.SetBaseResourceValues(client, resourceGroupName, managerName);
            return fileServer;
        }

        /// <summary>
        /// Returns device for a given fileserver
        /// </summary>
        /// <param name="fileServerName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static Device GetDeviceByFileServer(
                string fileServerName,
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName)
        {
            var device = client.Devices.Get(fileServerName, resourceGroupName, managerName);

            if (device != null)
            {
                device.SetBaseResourceValues(client, resourceGroupName, managerName);
            }

            return device;
        }

        /// <summary>
        /// Triggers manual backup for given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        /// <returns></returns>
        public static Backup BackupNow(this FileServer fileServer)
        {
            string deviceName = fileServer.Name;
            fileServer.Client.FileServers.BackupNow(
                deviceName.GetDoubleEncoded(),
                fileServer.Name.GetDoubleEncoded(),
                fileServer.ResourceGroupName,
                fileServer.ManagerName);

            // Query for a backup
            Expression<Func<BackupFilter, bool>> filter =
                backupFilter => backupFilter.InitiatedBy == InitiatedBy.Manual;

            var backupSets = fileServer.Client.Backups.ListByDevice(
                deviceName,
                fileServer.ResourceGroupName,
                fileServer.ManagerName,
                new ODataQuery<BackupFilter>(filter));

            Assert.True(backupSets != null && backupSets.Count() > 0,
                "No backups found for fileServer:" + fileServer.Name);

            var backupElements = backupSets.First().Elements;

            Assert.True(backupElements != null && backupElements.Count() > 0,
                "Backups found, however no backup elements were found.");

            foreach (var bs in backupSets)
            {
                bs.SetBaseResourceValues(
                    fileServer.Client,
                    fileServer.ResourceGroupName,
                    fileServer.ManagerName);
            }

            return backupSets.FirstOrDefault();
        }

        /// <summary>
        /// Triggers backup async for for a given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        public static void BackupNowAsync(this FileServer fileServer)
        {
            var startTime = DateTime.UtcNow;
            string deviceName = fileServer.Name;

            fileServer.Client.FileServers.BackupNowWithHttpMessagesAsync(
                deviceName,
                fileServer.Name,
                fileServer.ResourceGroupName,
                fileServer.ManagerName);
        }

        /// <summary>
        /// Returns fileservers for given manager
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static IEnumerable<FileServer> GetFileServers(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var fileServers = client.FileServers.ListByManager(resourceGroupName, managerName);

            if (fileServers != null)
            {
                foreach (var fs in fileServers)
                {
                    fs.SetBaseResourceValues(client, resourceGroupName, managerName);
                }
            }

            return fileServers;
        }

        /// <summary>
        /// Deletes a given fileserver
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        public static void DeleteAndValidateFileServer(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                string deviceName,
                string fileServerName)
        {
            var fileServerToDelete = client.FileServers.Get(
                deviceName,
                fileServerName,
                resourceGroupName,
                managerName);

            Assert.True(fileServerToDelete != null, "Failed to find FileServer to delete");

            client.FileServers.Delete(deviceName, fileServerToDelete.Name, resourceGroupName, managerName);

            // Get FileServers by Manager and check
            var fileServersByMgrPostDelete = client.FileServers.ListByManager(resourceGroupName, managerName);

            // Get FileServer by Device and check
            var fileServersPostDelete = client.FileServers.ListByDevice(
                deviceName,
                resourceGroupName,
                managerName);

            Assert.True(fileServersByMgrPostDelete.FirstOrDefault(f =>
                        f.Name.Equals(fileServerName, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Failed to delete the FileServer" + fileServerName);

            Assert.True(fileServersPostDelete.FirstOrDefault(f =>
                        f.Name.Equals(fileServerName, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Failed to delete the FileServer" + fileServerName);
        }

        /// <summary>
        /// Returns fileshares of a given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static IEnumerable<FileShare> GetFileShares(
            this FileServer fileServer,
            string deviceName)
        {
            var fileShares = fileServer.Client.FileShares.ListByFileServer(
                deviceName.GetDoubleEncoded(),
                fileServer.Name.GetDoubleEncoded(),
                fileServer.ResourceGroupName,
                fileServer.ManagerName);

            if (fileShares != null && !fileShares.Any())
            {
                // Create a FileShare with Tiered data policy
                var fileShareToCreate = new FileShare(
                    fileServer.Client, 
                    fileServer.ResourceGroupName, 
                    fileServer.ManagerName,
                    TestConstants.DefaultTieredFileShareName);
                fileShareToCreate.Initialize(DataPolicy.Tiered);

                fileShareToCreate.CreateOrUpdate(
                   fileServer.Name,
                   fileServer.Name);
            }

            // Return from the list
            fileShares =  fileServer.Client.FileShares.ListByFileServer(
                deviceName.GetDoubleEncoded(),
                fileServer.Name.GetDoubleEncoded(),
                fileServer.ResourceGroupName,
                fileServer.ManagerName);

            if (fileShares != null)
            {
                foreach (var fileShare in fileShares)
                {
                    fileShare.SetBaseResourceValues(
                        fileServer.Client,
                        fileServer.ResourceGroupName,
                        fileServer.ManagerName);
                }
            }

            return fileShares;
        }

        /// <summary>
        /// Returns metrics of a given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        /// <param name="deviceName"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this FileServer fileServer, 
            string deviceName, 
            ODataQuery<MetricFilter> odataQuery)
        {
            return fileServer.Client.FileServers.ListMetrics(
                 deviceName,
                 fileServer.Name,
                 fileServer.ResourceGroupName,
                 fileServer.ManagerName,
                 odataQuery);
        }

        /// <summary>
        /// Returns metric definition for given fileserver
        /// </summary>
        /// <param name="fileServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricDefinitions(
            this FileServer fileServer, 
            string deviceName)
        {
            return fileServer.Client.FileServers.ListMetricDefinition(
                deviceName,
                fileServer.Name,
                fileServer.ResourceGroupName,
                fileServer.ManagerName);
        }
    }
}