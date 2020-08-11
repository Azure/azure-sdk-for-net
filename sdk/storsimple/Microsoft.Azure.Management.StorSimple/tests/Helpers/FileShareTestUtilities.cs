// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Initalizes fileshare instance
        /// </summary>
        /// <param name="fileShare"></param>
        /// <param name="dataPolicy"></param>
        public static void Initialize(this FileShare fileShare, DataPolicy dataPolicy)
        {
            fileShare.AdminUser = TestConstants.DomainUser;
            fileShare.DataPolicy = dataPolicy;
            fileShare.Description = "Demo FileShare for SDK Test " + dataPolicy.ToString();
            fileShare.MonitoringStatus = MonitoringStatus.Enabled;
            fileShare.ShareStatus = ShareStatus.Online;
            fileShare.ProvisionedCapacityInBytes = TestConstants.ProvisionedCapacityInBytesForNonLocal;
        }

        /// <summary>
        /// Create or updates a given fileshare
        /// </summary>
        /// <param name="fileShare"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        /// <returns></returns>
        public static FileShare CreateOrUpdate(
            this FileShare fileShare,
            string deviceName,
            string fileServerName)
        {
            var fileShareCreated = fileShare.Client.FileShares.CreateOrUpdate(
                deviceName.GetDoubleEncoded(),
                fileServerName.GetDoubleEncoded(),
                fileShare.Name.GetDoubleEncoded(),
                fileShare,
                fileShare.ResourceGroupName,
                fileShare.ManagerName);

            Assert.True(fileShareCreated != null &&
                fileShareCreated.Name.Equals(fileShare.Name, StringComparison.CurrentCultureIgnoreCase) &&
                fileShareCreated.AdminUser.Equals(fileShare.AdminUser, StringComparison.CurrentCultureIgnoreCase) &&
                fileShareCreated.DataPolicy == fileShare.DataPolicy &&
                fileShareCreated.MonitoringStatus == fileShare.MonitoringStatus &&
                fileShareCreated.ShareStatus == fileShare.ShareStatus &&
                fileShareCreated.Description == fileShare.Description,
                "Creation of FileShare failed in validation");

            fileShareCreated.SetBaseResourceValues(
                fileShare.Client,
                fileShare.ResourceGroupName,
                fileShare.ManagerName);
            return fileShareCreated;
        }

        /// <summary>
        /// Deletes a given fileshare in a fileserver
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="fileShareName"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        public static void DeleteAndValidateFileShare(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string fileShareName,
            string deviceName,
            string fileServerName)
        {
            var fileShare = client.FileShares.Get(
                deviceName,
                fileServerName,
                fileShareName,
                resourceGroupName,
                managerName);

            client.FileShares.Delete(
                deviceName,
                fileServerName,
                fileShareName,
                resourceGroupName,
                managerName);

            var fileSharesPostDelete = client.FileShares.ListByFileServer(
                deviceName,
                fileServerName,
                resourceGroupName,
                managerName);

            var deletedFileShare = fileSharesPostDelete.FirstOrDefault(f =>
                f.Name.Equals(fileShareName, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(deletedFileShare == null, "Deletion of FileShare failed");
        }

        /// <summary>
        /// Returns metrics of a given fileshare
        /// </summary>
        /// <param name="fileShare"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this FileShare fileShare, 
            string deviceName, 
            string fileServerName, 
            ODataQuery<MetricFilter> odataQuery)
        {
            return fileShare.Client.FileShares.ListMetrics(
                 deviceName,
                 fileServerName,
                 fileShare.Name,
                 fileShare.ResourceGroupName,
                 fileShare.ManagerName,
                 odataQuery);
        }

        /// <summary>
        /// Returns metrics definition of given fileshare
        /// </summary>
        /// <param name="fileShare"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricDefinitions(
            this FileShare fileShare, 
            string deviceName,
            string fileServerName)
        {
            return fileShare.Client.FileShares.ListMetricDefinition(
                 deviceName,
                 fileServerName,
                 fileShare.Name,
                 fileShare.ResourceGroupName,
                 fileShare.ManagerName);
        }
    }
}