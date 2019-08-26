using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.Azure.OData;
using System.Linq.Expressions;

namespace StorSimple8000Series.Tests
{
    public class MonitoringTests : StorSimpleTestBase
    {
        public MonitoringTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestMetricOperations()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;
            var volumeContainers = Helpers.CheckAndGetVolumeContainers(this, deviceName, requiredCount: 1);
            var volumeContainerName = volumeContainers.First().Name;
            var volumes = Helpers.CheckAndGetVolumes(this, deviceName, volumeContainerName, requiredCount: 1);
            var volumeName = volumes.First().Name;

            try
            {
                //Get metric definitions and metrics for Manager
                var resourceMetricDefinition = GetManagerMetricDefinitions();
                var resourceMetrics = GetManagerMetrics(resourceMetricDefinition.First());

                //Get metric definitions and metrics for Device
                var deviceMetricDefinition = GetDeviceMetricDefinition(deviceName);
                var deviceMetrics = GetDeviceMetrics(deviceName, deviceMetricDefinition.First());

                //Get metric definitions and metrics for VolumeContainer
                var volumeContainerMetricDefinition = GetVolumeContainerMetricDefinition(deviceName, volumeContainerName);
                var volumeContainerMetrics = GetVolumeContainerMetrics(deviceName, volumeContainerName, volumeContainerMetricDefinition.First());

                //Get metric definitions and metrics for Volume
                var volumeMetricDefinition = GetVolumeMetricDefinition(deviceName, volumeContainerName, volumeName);
                var volumeMetrics = GetVolumeMetrics(deviceName, volumeContainerName, volumeName, volumeMetricDefinition.First());
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private IEnumerable<Metrics> GetManagerMetrics(MetricDefinition metricDefinition)
        {
            var managerMetrics = this.Client.Managers.ListMetrics(
                GenerateOdataFilterForMetric(metricDefinition),
                this.ResourceGroupName,
                this.ManagerName);

            return managerMetrics;
        }

        private IEnumerable<Metrics> GetDeviceMetrics(string deviceName, MetricDefinition metricDefinition)
        {
            var deviceMetrics = this.Client.Devices.ListMetrics(
                GenerateOdataFilterForMetric(metricDefinition),
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            return deviceMetrics;
        }

        private IEnumerable<Metrics> GetVolumeContainerMetrics(string deviceName, string volumeContainerName, MetricDefinition metricDefinition)
        {
            var vcMetrics = this.Client.VolumeContainers.ListMetrics(
                GenerateOdataFilterForMetric(metricDefinition),
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            return vcMetrics;
        }

        private IEnumerable<Metrics> GetVolumeMetrics(string deviceName, string volumeContainerName, string volumeName, MetricDefinition metricDefinition)
        {
            var volMetrics = this.Client.Volumes.ListMetrics(
                GenerateOdataFilterForMetric(metricDefinition),
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                volumeName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            return volMetrics;

        }

        private static ODataQuery<MetricFilter> GenerateOdataFilterForMetric(MetricDefinition metricDefinition)
        {
            Expression<Func<MetricFilter, bool>> filter =
                metricFilter => (metricFilter.Name.Value == metricDefinition.Name.Value
                && metricFilter.TimeGrain == metricDefinition.MetricAvailabilities.First().TimeGrain
                && metricFilter.StartTime >= TestConstants.MetricsStartTime
                && metricFilter.EndTime <= TestConstants.MetricsEndTime
                && metricFilter.Category == metricDefinition.Category);

            ODataQuery<MetricFilter> odataQuery = new ODataQuery<MetricFilter>(filter);
            odataQuery.Expand = "name";

            return odataQuery;
        }

        private IEnumerable<MetricDefinition> GetManagerMetricDefinitions()
        {
            var managerMetrics = this.Client.Managers.ListMetricDefinition(
                this.ResourceGroupName,
                this.ManagerName);

            return managerMetrics;
        }
        private IEnumerable<MetricDefinition> GetDeviceMetricDefinition(string deviceName)
        {
            var deviceMetrics = this.Client.Devices.ListMetricDefinition(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            return deviceMetrics;
        }

        private IEnumerable<MetricDefinition> GetVolumeContainerMetricDefinition(string deviceName, string volumeContainerName)
        {
            var volumeContainerMetrics = this.Client.VolumeContainers.ListMetricDefinition(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            return volumeContainerMetrics;
        }

        private IEnumerable<MetricDefinition> GetVolumeMetricDefinition(string deviceName, string volumeContainerName, string volumeName)
        {
            return this.Client.Volumes.ListMetricDefinition(
                deviceName.GetDoubleEncoded(),
                volumeContainerName.GetDoubleEncoded(),
                volumeName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);
        }
    }
}

