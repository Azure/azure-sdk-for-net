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
        #region IscsiDisk extension methods

        /// <summary>
        /// Initalizes iscsidisk instance
        /// </summary>
        /// <param name="iscsiDisk"></param>
        /// <param name="dataPolicy"></param>
        public static void Initialize(this ISCSIDisk iscsiDisk, DataPolicy dataPolicy)
        {
            iscsiDisk.Description = "Demo IscsiDisk for SDK Test " + dataPolicy.ToString();
            iscsiDisk.AccessControlRecords = new List<string>();
            iscsiDisk.DataPolicy = dataPolicy;
            iscsiDisk.DiskStatus = DiskStatus.Online;
            iscsiDisk.ProvisionedCapacityInBytes = TestConstants.ProvisionedCapacityInBytesForDisk;
            iscsiDisk.MonitoringStatus = MonitoringStatus.Enabled;
        }

        /// <summary>
        /// Create or update iscsi disk
        /// </summary>
        /// <param name="iscsiDisk"></param>
        /// <param name="deviceName"></param>
        /// <param name="fileServerName"></param>
        /// <returns></returns>
        public static ISCSIDisk CreateOrUpdate(
            this ISCSIDisk iscsiDisk,
            string deviceName,
            string fileServerName)
        {
            var isciDiskCreated = iscsiDisk.Client.IscsiDisks.CreateOrUpdate(
                deviceName.GetDoubleEncoded(),
                fileServerName.GetDoubleEncoded(),
                iscsiDisk.Name.GetDoubleEncoded(),
                iscsiDisk,
                iscsiDisk.ResourceGroupName,
                iscsiDisk.ManagerName);

            isciDiskCreated.SetBaseResourceValues(
                iscsiDisk.Client,
                iscsiDisk.ResourceGroupName,
                iscsiDisk.ManagerName);

            return isciDiskCreated;
        }

        /// <summary>
        /// Returns metrics of a given iscsi disk
        /// </summary>
        /// <param name="iscsiDisk"></param>
        /// <param name="deviceName"></param>
        /// <param name="iscsiServerName"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this ISCSIDisk iscsiDisk, 
            string deviceName, 
            string iscsiServerName, 
            ODataQuery<MetricFilter> odataQuery)
        {
            return iscsiDisk.Client.IscsiDisks.ListMetrics(
                 deviceName,
                 iscsiServerName,
                 iscsiDisk.Name,
                 iscsiDisk.ResourceGroupName,
                 iscsiDisk.ManagerName,
                 odataQuery);
        }

        /// <summary>
        /// Returns metrics definition for given iscsi disk
        /// </summary>
        /// <param name="iscsiDisk"></param>
        /// <param name="deviceName"></param>
        /// <param name="iscsiServerName"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricsDefinition(
            this ISCSIDisk iscsiDisk, 
            string deviceName, 
            string iscsiServerName)
        {
            return iscsiDisk.Client.IscsiDisks.ListMetricDefinition(
                 deviceName,
                 iscsiServerName,
                 iscsiDisk.Name,
                 iscsiDisk.ResourceGroupName,
                 iscsiDisk.ManagerName);
        }

        #endregion IscsiDisk extension  methods

        #region Public methods

        /// <summary>
        /// Deletes a given iscsi disk
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="iscsiDiskName"></param>
        /// <param name="deviceName"></param>
        /// <param name="iscsiServerName"></param>
        public static void DeleteAndValidateIscsiDisk(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string iscsiDiskName,
            string deviceName,
            string iscsiServerName)
        {
            var iscsiDisk = client.IscsiDisks.Get(
                deviceName,
                iscsiServerName,
                iscsiDiskName,
                resourceGroupName,
                managerName);

            client.IscsiDisks.Delete(
                deviceName,
                iscsiServerName,
                iscsiDiskName,
                resourceGroupName,
                managerName);

            var iscsiDiskPostDelete = client.IscsiDisks.ListByIscsiServer(
                deviceName,
                iscsiServerName,
                resourceGroupName,
                managerName);

            var deletedFileShare = iscsiDiskPostDelete.FirstOrDefault(f =>
                f.Name.Equals(iscsiDiskName, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(deletedFileShare == null, "Deletion of IscsiDisk failed");
        }

        #endregion public methods

        #region Private methods

        /// <summary>
        ///  Helper method validates property value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="actualPropertyValue"></param>
        /// <param name="expectedPropertyValue"></param>
        private static void ValidateProperty<T>(
            string propertyName,
            T actualPropertyValue,
            T expectedPropertyValue)
        {
            if (actualPropertyValue == null && expectedPropertyValue == null)
            {
                return;
            }

            Assert.True(actualPropertyValue == null || expectedPropertyValue == null,
                    String.Format("Actual {0} '{1}' not matching with the expected {0} {2}",
                    propertyName, actualPropertyValue, expectedPropertyValue));

            Assert.True(
                actualPropertyValue.Equals(expectedPropertyValue),
                String.Format("Actual {0} '{1}' not matching with the expected {0} {2}",
                    propertyName, actualPropertyValue, expectedPropertyValue));
        }

        /// <summary>
        /// Helper method to validate ACR List
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="actualACRList"></param>
        /// <param name="expectedACRList"></param>
        private static void ValidateACRList(
            string propertyName, 
            IList<string> actualACRList, 
            IList<string> expectedACRList)
        {
            Assert.True(
                actualACRList.Count == expectedACRList.Count,
                String.Format("Actual no. of {0} '{1}' not matching with the expected no. of {0} {2}",
                    propertyName, actualACRList.Count, expectedACRList.Count));

            foreach (var i in actualACRList)
            {
                Assert.True(
                    actualACRList.Contains(i),
                    String.Format("Actual {0} contains {1} not present in expected {0}",
                    propertyName, i));
            }
        }

        #endregion Private methods
    }
}