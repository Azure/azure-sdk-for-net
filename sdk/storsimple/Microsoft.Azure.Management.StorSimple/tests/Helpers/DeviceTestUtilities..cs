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
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Returns failover targets for a given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static IEnumerable<Device> GetFailoverTargets(this Device device)
        {
            var devices = device.Client.Devices.ListFailoverTarget(
                device.Name, 
                device.ResourceGroupName, 
                device.ManagerName);

            if (devices != null && devices.Any())
            {
                foreach (var dev in devices)
                {
                    dev.SetBaseResourceValues(
                        device.Client,
                        device.ResourceGroupName,
                        device.ManagerName);
                }
            }

            return devices;
        }

        /// <summary>
        /// Triggers failover for given source device to target device
        /// </summary>
        /// <param name="sourceDevice"></param>
        /// <param name="accessPointIds"></param>
        /// <param name="targetDeviceId"></param>
        public static void Failover(
            this Device sourceDevice,
            IList<string> accessPointIds,
            string targetDeviceId)
        {
            var devices = sourceDevice.Client.Devices.ListByManager(
                sourceDevice.ResourceGroupName,
                sourceDevice.ManagerName);

            Assert.True(
                devices != null && devices.Any(),
                "No devices found in manager");

            var targetDevice = devices.FirstOrDefault(d =>
                        d.Id.Equals(targetDeviceId, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(targetDevice != null, $"No device found matching to target device id: {targetDeviceId}");

            sourceDevice.Client.Devices.Failover(
                sourceDevice.Name,
                new FailoverRequest()
                {
                    AccesspointIds = accessPointIds,
                    TargetDeviceId = targetDeviceId,
                    SkipValidation = true,
                    KeepSourceDevice = true
                },
                sourceDevice.ResourceGroupName,
                sourceDevice.ManagerName);
        }

        /// <summary>
        /// Returns metric definitions for given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricDefinitions(this Device device)
        {
            return device.Client.Devices.ListMetricDefinition(
                 device.Name,
                 device.ResourceGroupName,
                 device.ManagerName);
        }

        /// <summary>
        /// Returns metrics for given device
        /// </summary>
        /// <param name="device"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this Device device, 
            ODataQuery<MetricFilter> odataQuery)
        {
            return device.Client.Devices.ListMetrics(
                 device.Name,
                 device.ResourceGroupName,
                 device.ManagerName,
                 odataQuery);
        }

        /// <summary>
        /// Returns jobs for given device
        /// </summary>
        /// <param name="device"></param>
        /// <param name="jobType"></param>
        /// <returns></returns>
        public static IPage<Job> GetJobs(this Device device, JobType jobType)
        {
            Expression<Func<JobFilter, bool>> filterExp = filter =>
                (filter.JobType == jobType);
            var jobsFilter = new ODataQuery<JobFilter>(filterExp);

            var jobs = device.Client.Jobs.ListByDevice(
                device.Name.GetDoubleEncoded(),
                device.ResourceGroupName,
                device.ManagerName,
                jobsFilter);

            if (jobs != null)
            {
                foreach (var job in jobs)
                {
                    job.SetBaseResourceValues(
                        device.Client, 
                        device.ResourceGroupName, 
                        device.ManagerName);
                }
            }

            return jobs;
        }

        /// <summary>
        /// Triggers scanning for updates and returns updates on a given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static Updates ScanForUpdates(this Device device)
        {
            device.Client.Devices.ScanForUpdates(
                device.Name,
                device.ResourceGroupName,
                device.ManagerName);

            var updates = device.Client.Devices.GetUpdateSummary(
                device.Name,
                device.ResourceGroupName,
                device.ManagerName);

            updates.Client = device.Client;
            updates.ResourceGroupName = device.ResourceGroupName;
            updates.ManagerName = device.ManagerName;

            return updates;
        }

        /// <summary>
        /// Triggers install updates for given device.
        /// </summary>
        public static void InstallUpdates(this Device device)
        {
            device.Client.Devices.InstallUpdates(
                device.Name,
                device.ResourceGroupName,
                device.ManagerName);
        }

        /// <summary>
        /// Returns alert for a given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static IPage<Alert>  GetAlerts(this Device device)
        {
            Expression<Func<AlertFilter, bool>> filterExp = filter => 
                filter.Status == AlertStatus.Active &&
                filter.SourceType == AlertSourceType.Device &&
                filter.SourceName == device.Name;

            var alertFilters = new ODataQuery<AlertFilter>(filterExp);
            alertFilters.Top = 100;

            return TestUtilities.GetAlerts(
                device.Client,
                device.ResourceGroupName,
                device.ManagerName,
                alertFilters);
        }

        /// <summary>
        /// Apply the patch to the given device
        /// </summary>
        /// <param name="device"></param>
        /// <param name="patch"></param>
        /// <returns></returns>

        public static Device Patch(this Device device, DevicePatch patch)
        {
            var deviceAfterUpdate = device.Client.Devices.Patch(
                device.Name, 
                patch, 
                device.ResourceGroupName, 
                device.ManagerName);

            deviceAfterUpdate.SetBaseResourceValues(
                device.Client, 
                device.ResourceGroupName, 
                device.ManagerName);

            return deviceAfterUpdate;
        }
    }
}