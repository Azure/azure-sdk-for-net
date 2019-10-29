using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.Azure.OData;

namespace StorSimple8000Series.Tests
{
    public class JobsTests : StorSimpleTestBase
    {
        public JobsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestCancelJobOperation()
        {
            //check and get pre-requisites - device, backups
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;
            var backupPolicies = Helpers.CheckAndGetBackupPolicies(this, deviceName, 1);
            var backupPolicyName = backupPolicies.First().Name;

            try
            {
                CancelInProgressBackupJobAndValidate(deviceName, backupPolicyName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private void CancelInProgressBackupJobAndValidate(string deviceName, string backupPolicyName)
        {
            var triggeredRestoreJob = this.Client.BackupPolicies.BackupNowWithHttpMessagesAsync(
                deviceName.GetDoubleEncoded(),
                backupPolicyName.GetDoubleEncoded(),
                BackupType.CloudSnapshot.ToString(),
                this.ResourceGroupName,
                this.ManagerName);

            var restoreJobStartTime = TestConstants.TimeBeforeCancelledBackupJobStart;

            var backupJobs = GetSpecificJobsTypeByDevice(
                deviceName.GetDoubleEncoded(),
                JobType.ManualBackup);

            var backupJob = backupJobs.FirstOrDefault(j => j.StartTime > restoreJobStartTime);

            Assert.True(backupJob != null && backupJob.IsCancellable.Equals(true), "Backup job is not in cancellable state.");

            this.Client.Jobs.Cancel(
                deviceName.GetDoubleEncoded(),
                backupJob.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var cancelledRestoreJob = this.Client.Jobs.Get(
                deviceName.GetDoubleEncoded(),
                backupJob.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(cancelledRestoreJob.Status.Equals(JobStatus.Canceled), "Cancellation of Job was not successful.");
        }
    }
}
