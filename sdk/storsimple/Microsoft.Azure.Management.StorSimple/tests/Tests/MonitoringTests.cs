namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;

    /// <summary>
    ///  Class represents monitoring tests
    /// </summary>
    public class MonitoringTests : StorSimpleTestBase
    {
        #region Constructor

        public MonitoringTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Manager metrics
        /// <summary>
        /// Test method for manager's metrics and definitions
        /// </summary>
        [Fact]
        public void TestManagerMetricsAndDefinitions()
        {
            try
            {
                var manager = TestUtilities.GetManager(
                        this.Client,
                        this.ResourceGroupName,
                        this.ManagerName);

                Assert.True(
                    manager != null, "No Manager found with name: " + this.ManagerName);

                var metricDefinitions = manager.GetMetricDefinitions(this.Client, this.ResourceGroupName);

                Assert.True(
                    metricDefinitions != null && metricDefinitions.Any(),
                    "No metric definitions found for manager: " + this.ManagerName);

                ODataQuery<MetricFilter> odataQuery = GetODataQuery(
                    DateTime.Parse(TestConstants.ManagerMetricStartTime),
                    DateTime.Parse(TestConstants.ManagerMetricEndTime));

                var metrics = manager.GetMetrics(this.Client, this.ResourceGroupName, odataQuery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No metrics found for manager: " + this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Manager metrics

        #region Device metrics

        /// <summary>
        /// Test method for device metrics and definitions
        /// </summary>
        [Fact]
        public void TestDeviceMetricsAndDefinitions()
        {
            try
            {
                //Check if atleast a device is registered to the manager.
                var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.Online, 1);

                Assert.True(devices != null && devices.FirstOrDefault() != null,
                        "No devices were found to be registered in the manger:" + this.ManagerName);

                // Get the first device
                Device device = devices.FirstOrDefault();

                var metricDefinitions = device.GetMetricDefinitions();

                Assert.True(
                    metricDefinitions != null && metricDefinitions.Any(),
                    "No metric definitions found for manager: " + this.ManagerName);

                ODataQuery<MetricFilter> odataQuery = GetODataQuery(
                    DateTime.Parse(TestConstants.DeviceMetricStartTime),
                    DateTime.Parse(TestConstants.DeviceMetricEndTime));

                var metrics = device.GetMetrics(odataQuery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No metrics found for device: " + device.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Manager metrics

        #region FileServer and FileShare

        /// <summary>
        /// Test method to get file server metrics
        /// </summary>
        [Fact]
        public void TestFileServerMetricsAndDefinitions()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    fileServers != null && fileServers.Any(),
                    "No fileservers found in resource: " + this.ManagerName);

                var fileServer = fileServers.FirstOrDefault();

                var metricDefinitions = fileServer.GetMetricDefinitions(fileServer.Name);

                Assert.True(
                    metricDefinitions != null && metricDefinitions.Any(),
                    "No metric definitions found");

                var odataQuery = GetODataQuery(
                    DateTime.Parse(TestConstants.FileServerMetricStartTime),
                    DateTime.Parse(TestConstants.FileServerMetricEndTime));

                var metrics = fileServer.GetMetrics(fileServer.Name, odataQuery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No metrics found for fileServer: " + fileServer.Name);

            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Test method to get share's metrics
        /// </summary>
        [Fact]
        public void TestFileShareMetricsAndDefinitions()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    fileServers != null && fileServers.Any(),
                    "No fileservers found in resource: " + this.ManagerName);

                var fileServer = fileServers.FirstOrDefault();

                var shares = fileServer.GetFileShares(fileServer.Name);

                Assert.True(
                    shares != null && shares.Any(),
                    "No shares found in fileserver: " + fileServer.Name);

                var share = shares.FirstOrDefault();

                var metricDefintions = share.GetMetricDefinitions(fileServer.Name, fileServer.Name);

                Assert.True(
                    metricDefintions != null && metricDefintions.Any(),
                    "No metric definitions found for Share: " + share.Name);

                var odataquery = GetODataQuery(
                    DateTime.Parse(TestConstants.FileShareMetricStartTime),
                    DateTime.Parse(TestConstants.FileShareMetricEndTime));

                var metrics = share.GetMetrics(fileServer.Name, fileServer.Name, odataquery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No Metrics found for share: " + share.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion FileServer and FileShare

        #region IscsiServer and IscsiDisk

        /// <summary>
        /// Test method to get iscsi server metrics
        /// </summary>
        [Fact]
        public void TestIscsiServerMetricsAndDefinitions()
        {
            try
            {
                var iscsiServers = TestUtilities.GetIscsiServers(
                     this.Client,
                     this.ResourceGroupName,
                     this.ManagerName);

                Assert.True(
                    iscsiServers != null && iscsiServers.Any(),
                    "No iscsi servers found in resource: " + this.ManagerName);

                var iscsiServer = iscsiServers.FirstOrDefault();

                var metricDefinitions = iscsiServer.GetMetricsDefinition(iscsiServer.Name);

                ODataQuery<MetricFilter> odataQuery = GetODataQuery(
                    DateTime.Parse(TestConstants.IscsiServerMetricStartTime),
                    DateTime.Parse(TestConstants.IscsiServerMetricEndTime));

                var metrics = iscsiServer.GetMetrics(iscsiServer.Name, odataQuery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No metrics found for iscsi server: " + iscsiServer.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }


        /// <summary>
        /// Test method to get iscsi disk metrics
        /// </summary>
        [Fact]
        public void TestIscsiDiskMetricsAndDefinitions()
        {
            try
            {
                var iscsiServers = TestUtilities.GetIscsiServers(
                     this.Client,
                     this.ResourceGroupName,
                     this.ManagerName);

                Assert.True(
                    iscsiServers != null && iscsiServers.Any(),
                    "No iscsi servers found in resource: " + this.ManagerName);

                var iscsiServer = iscsiServers.FirstOrDefault();

                var iscsiDisks = iscsiServer.GetIscsiDisks(iscsiServer.Name);

                Assert.True(
                    iscsiDisks != null && iscsiDisks.Any(),
                    "No disks found in iscsi server: " + iscsiServer.Name);

                var iscsiDisk = iscsiDisks.FirstOrDefault();

                var iscsiDiskMetricDefns =  iscsiDisk.GetMetricsDefinition(
                    iscsiServer.Name,
                    iscsiServer.Name);

                Assert.True(
                    iscsiDiskMetricDefns != null && iscsiDiskMetricDefns.Any(),
                    "IscsiDisk metric definitions are not found");

                var odataquery = GetODataQuery(
                    DateTime.Parse(TestConstants.IscsiDiskMetricStartTime),
                    DateTime.Parse(TestConstants.IscsiDiskMetricEndTime));

                var metrics = iscsiDisk.GetMetrics(iscsiServer.Name, iscsiServer.Name, odataquery);

                Assert.True(
                    metrics != null && metrics.Any(),
                    "No metrics found for iscsi disk: " + iscsiDisk.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion IscsiServer and IscsiDisk

        #region Private methods

        /// <summary>
        /// Returns ODataquery filter for given number of days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        private ODataQuery<MetricFilter> GetODataQuery(int days)
        {
            var startTime = DateTime.Today.AddDays(days);
            var endTime = DateTime.Today;

            Expression<Func<MetricFilter, bool>> filter =
                metricFilter =>
                (metricFilter.StartTime >= startTime && metricFilter.EndTime <= endTime);

            return new ODataQuery<MetricFilter>(filter);
        }


        /// <summary>
        /// Returns ODataquery for a given start time and endtime
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        private ODataQuery<MetricFilter> GetODataQuery(DateTime startTime, DateTime endTime)
        {
            Expression<Func<MetricFilter, bool>> filter =
                metricFilter =>
                (metricFilter.StartTime >= startTime && metricFilter.EndTime <= endTime);

            return new ODataQuery<MetricFilter>(filter);
        }

        #endregion Private methods
    }
}
