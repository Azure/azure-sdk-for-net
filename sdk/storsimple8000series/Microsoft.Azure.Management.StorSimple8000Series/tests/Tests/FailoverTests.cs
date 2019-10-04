using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class FailoverTests : StorSimpleTestBase
    {
        public FailoverTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestFailover()
        {
            //check and get pre-requisites - 2 devices, volumeContainer, volumes
            var device1 = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var device2 = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DeviceForFailover);
            var sourceDeviceName = device1.Name;
            var targetDeviceName = device2.Name;
            var targetDeviceId = device2.Id;

            try
            {
                // Do failover
                Failover(sourceDeviceName, targetDeviceName, targetDeviceId);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Helper method to trigger failover
        /// </summary>
        private void Failover(string sourceDeviceName, string targetDeviceName, string targetDeviceId)
        {
            //validate source and target device are not same
            Assert.False(sourceDeviceName.Equals(
                targetDeviceName,
                StringComparison.CurrentCultureIgnoreCase));

            // Get failover sets from source device
            var failoverSets = this.Client.Devices.ListFailoverSets(
                sourceDeviceName,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.NotNull(failoverSets);
            Assert.NotEmpty(failoverSets);

            var volumeContainerIds = failoverSets.First().VolumeContainers.Select(vc => vc.VolumeContainerId).ToList();
            Assert.NotNull(volumeContainerIds);
                        
            // Get failover targets
            ListFailoverTargetsRequest failoverTargetsRequest = new ListFailoverTargetsRequest()
            {
                VolumeContainers = volumeContainerIds
            };

            var failoverTargets = this.Client.Devices.ListFailoverTargets(
                sourceDeviceName,
                failoverTargetsRequest,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.NotNull(failoverTargets);
            Assert.NotEmpty(failoverTargets);

            //validate that target device is eligible
            var targetDeviceIsValid = failoverTargets.FirstOrDefault(t => t.DeviceId.Equals(targetDeviceId) && t.EligibilityResult.EligibilityStatus.Equals(TargetEligibilityStatus.Eligible));
            Assert.NotNull(targetDeviceIsValid);

            // Create a failover request
            FailoverRequest failoverRequest = new FailoverRequest()
            {
                TargetDeviceId = targetDeviceId,
                VolumeContainers = volumeContainerIds
            };

            var jobStartTime = new DateTime(2017, 06, 21);

            // Trigger failover
            this.Client.Devices.Failover(
                                sourceDeviceName.GetDoubleEncoded(),
                                failoverRequest,
                                this.ResourceGroupName,
                                this.ManagerName);

            //validate
            var allFailoverJobs = GetSpecificJobsTypeByManager(this.ManagerName, JobType.FailoverVolumeContainers);

            var failoverJob = allFailoverJobs.FirstOrDefault(
                j => j.StartTime > jobStartTime &&
                j.EntityLabel.Equals(sourceDeviceName, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(failoverJob != null && failoverJob.Status.Equals(JobStatus.Succeeded), "Failover was not successful.");
        }
    }
}
