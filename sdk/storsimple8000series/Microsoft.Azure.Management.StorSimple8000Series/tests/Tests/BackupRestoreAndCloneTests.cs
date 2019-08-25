using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using SSModels = Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.Azure.OData;

namespace StorSimple8000Series.Tests
{
    public class BackupRestoreAndCloneTests : StorSimpleTestBase
    {
        public BackupRestoreAndCloneTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact(Skip = "ReRecord due to CR change")]
        public void TestBackupRestoreAndClone()
        {
            //check and get pre-requisites - device, volumeContainer, volumes
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;
            var volumeContainerNames = Helpers.CheckAndGetVolumeContainers(this, deviceName, requiredCount: 1);
            var volumeContainerName = volumeContainerNames.First().Name;
            var volumes = Helpers.CheckAndGetVolumes(this, deviceName, volumeContainerName, requiredCount: 2);
            var volumeIds = new List<String>();
            volumeIds.Add(volumes.ElementAt(0).Id);
            volumeIds.Add(volumes.ElementAt(1).Id);
            var firstVolumeName = volumes.ElementAt(0).Name;
            var firstVolumeId = volumeIds.First();
            var firstVolumeAcrIds = volumes.ElementAt(0).AccessControlRecordIds;

            //initialize entity names
            var backupPolicyName = "BkUpPolicy01ForSDKTest";

            try
            {
                // Create a backup policy
                var backupPolicy = CreateBackupPolicy(deviceName, backupPolicyName, volumeIds);

                // Take manual backup
                var backup = BackupNow(deviceName, backupPolicy.Name, BackupType.CloudSnapshot);

                // Restore
                RestoreBackup(deviceName, backup.Name);

                // Clone
                CloneVolume(deviceName, firstVolumeName, firstVolumeId, firstVolumeAcrIds);

                //Delete backup-policies, and associated schedules and backups
                DeleteBackupPolicieSchedulesAndBackups(deviceName, backupPolicyName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Helper method to create backup policy for a given set of volumes.
        /// </summary>
        private BackupPolicy CreateBackupPolicy(string deviceName, string name, IList<string> volumeIds)
        {
            var bp = new BackupPolicy()
            {
                Kind = Kind.Series8000,
                VolumeIds = volumeIds
            };

            var backupPolicy = this.Client.BackupPolicies.CreateOrUpdate(
                                    deviceName.GetDoubleEncoded(),
                                    name.GetDoubleEncoded(),
                                    bp,
                                    this.ResourceGroupName,
                                    this.ManagerName);

            Assert.NotNull(backupPolicy);
            Assert.Equal(backupPolicy.SchedulesCount, 0);

            List<string> scheduleNames = new List<string>()
            {
                "schedule1",
                "schedule2",
            };

            // Create a backup schedule
            BackupSchedule bs1 = CreateBackupSchedule(deviceName, backupPolicy.Name, scheduleNames.ElementAt(0), RecurrenceType.Daily, TestConstants.Schedule1StartTime);
            BackupSchedule bs2 = CreateBackupSchedule(deviceName, backupPolicy.Name, scheduleNames.ElementAt(1), RecurrenceType.Weekly, TestConstants.Schedule2StartTime);
 
            //validate one of the schedules
            var schedule = this.Client.BackupSchedules.Get(
                deviceName.GetDoubleEncoded(),
                backupPolicy.Name.GetDoubleEncoded(),
                scheduleNames.First().GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(schedule != null && schedule.Name.Equals(scheduleNames.First()) &&
                schedule.ScheduleRecurrence.RecurrenceType.Equals(RecurrenceType.Daily), "Schedule creation was not successful.");

            return backupPolicy;
        }

        /// <summary>
        /// Helper method to trigger a manual backup.
        /// </summary>
        private Backup BackupNow(string deviceName, string policyName, BackupType backupType)
        {
            //get the backup-policy
            var backupPolicy = this.Client.BackupPolicies.Get(
                deviceName,
                policyName,
                this.ResourceGroupName,
                this.ManagerName);

            // Take the backup
            var jobStartTime = TestConstants.TimeBeforeBackupRestoreJobStart;
            this.Client.BackupPolicies.BackupNow(
                deviceName.GetDoubleEncoded(),
                policyName.GetDoubleEncoded(),
                backupType.ToString(),
                this.ResourceGroupName,
                this.ManagerName);

            // validate backup job success
            var allBackupJobs = this.GetSpecificJobsTypeByDevice(deviceName, JobType.ManualBackup);

            var backupJob = allBackupJobs.FirstOrDefault(
                    j =>
                    j.StartTime > jobStartTime
                    && j.EntityLabel.Equals(policyName, StringComparison.CurrentCultureIgnoreCase));

            Assert.NotNull(backupJob);

            // Get backup
            Expression<Func<BackupFilter, bool>> filter = backupFilter =>
                backupFilter.CreatedTime >= jobStartTime &&
                backupFilter.BackupPolicyId == backupPolicy.Id;

            var backups = this.Client.Backups.ListByDevice(
                                deviceName,
                                this.ResourceGroupName,
                                this.ManagerName,
                                new ODataQuery<BackupFilter>(filter));

            Assert.Equal(1, backups.Count());

            return backups.First() as Backup;
        }

        /// <summary>
        /// Helper method to restore volumes by backup
        /// </summary>
        private void RestoreBackup(string deviceName, string backupName)
        {
            // Get the backup
            var backups = this.Client.Backups.ListByDevice(
                                deviceName.GetDoubleEncoded(),
                                this.ResourceGroupName,
                                this.ManagerName);
            var backup = backups.FirstOrDefault(b => b.Name.Equals(backupName));
            Assert.NotNull(backup);

            //restore the backup
            var jobStartTime = TestConstants.TimeBeforeBackupRestoreJobStart;
            this.Client.Backups.Restore(
                                deviceName.GetDoubleEncoded(),
                                backup.Name.GetDoubleEncoded(),
                                this.ResourceGroupName,
                                this.ManagerName);

            // validate restore job success
            var backupPolicy = this.Client.BackupPolicies.ListByDevice(deviceName, this.ResourceGroupName, this.ManagerName).
                FirstOrDefault(bp => bp.Id.Equals(backup.BackupPolicyId));
            var allRestoreJobs = this.GetSpecificJobsTypeByDevice(deviceName, JobType.RestoreBackup);
            var restoreJob = allRestoreJobs.FirstOrDefault(
                    j =>
                    j.StartTime > jobStartTime
                    && j.EntityLabel.Equals(backupPolicy.Name, StringComparison.CurrentCultureIgnoreCase));

            Assert.True(restoreJob != null && restoreJob.Status.Equals(JobStatus.Succeeded), "Restore was not successful.");
        }

        private void CloneVolume(string deviceName, string volumeName, string volumeId, IList<string> accessControlRecordIds)
        {
            string cloneVolumeName = "Cloned" + volumeName;

            //get device
            var device = this.Client.Devices.Get(deviceName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
            Assert.NotNull(device);

            // Get the latest backups for the volume
            var volume = this.Client.Volumes.ListByDevice(deviceName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);
            var backups = GetBackupsByVolume(deviceName, volumeId);
            Assert.NotNull(backups);
            var backup = backups.First();
            Assert.NotNull(backup);
            Assert.NotNull(backup.Elements);

            //get the backup-element corresponding to the volume
            var backupElement = backup.Elements.FirstOrDefault(e => e.VolumeName.Equals(volumeName, StringComparison.CurrentCultureIgnoreCase));
            Assert.NotNull(backupElement);

            // Prepare clone request and trigger clone
            var cloneRequest = new CloneRequest
            {
                BackupElement = backupElement,
                TargetDeviceId = device.Id,
                TargetVolumeName = cloneVolumeName,
                TargetAccessControlRecordIds = accessControlRecordIds
            };
            
            this.Client.Backups.Clone(
                deviceName.GetDoubleEncoded(),
                backup.Name,
                backupElement.ElementName,
                cloneRequest,
                this.ResourceGroupName,
                this.ManagerName);

            // Verify that the clone volume is created
            var refreshedVolumes = this.Client.Volumes.ListByDevice(
                                                deviceName,
                                                this.ResourceGroupName,
                                                this.ManagerName);

            var clonedVolume = refreshedVolumes.FirstOrDefault(
                                v => v.Name.Equals(
                                    cloneVolumeName,
                                    StringComparison.CurrentCultureIgnoreCase));

            Assert.NotNull(clonedVolume);
        }

        /// <summary>
        /// Deletes the backup-policy and all backups, backup-schedules for the specified backupPolicy
        /// </summary>
        private void DeleteBackupPolicieSchedulesAndBackups(string deviceName, string backupPolicyName)
        {
            var doubleEncodedDeviceName = deviceName.GetDoubleEncoded();

            //get backupPolicy
            var bp = this.Client.BackupPolicies.Get(
                doubleEncodedDeviceName,
                backupPolicyName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //create oDataQuery
            var startTime = TestConstants.TimeBeforeBackupRestoreJobStart;
            Expression<Func<BackupFilter, bool>> filter = f => f.CreatedTime >= startTime && f.BackupPolicyId == bp.Id;
            var oDataQuery = new ODataQuery<BackupFilter>(filter);

            //get backups for the backup-policy and delete
            var backups = this.Client.Backups.ListByDevice(
                doubleEncodedDeviceName,
                this.ResourceGroupName,
                this.ManagerName,
                oDataQuery);

            foreach (var backup in backups)
            {
                this.Client.Backups.Delete(
                    doubleEncodedDeviceName,
                    backup.Name.GetDoubleEncoded(),
                    this.ResourceGroupName,
                    this.ManagerName);
            }

            //get schedules for the backup-policy and delete
            var backupSchedules = this.Client.BackupSchedules.ListByBackupPolicy(
                doubleEncodedDeviceName,
                bp.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            foreach (var schedule in backupSchedules)
            {
                this.Client.BackupSchedules.Delete(
                    doubleEncodedDeviceName,
                    bp.Name.GetDoubleEncoded(),
                    schedule.Name.GetDoubleEncoded(),
                    this.ResourceGroupName,
                    this.ManagerName);
            }

            //delete backup-policy
            this.Client.BackupPolicies.Delete(
                doubleEncodedDeviceName,
                bp.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //validate deletion
            var backupPolicies = this.Client.BackupPolicies.ListByDevice(
                doubleEncodedDeviceName,
                this.ResourceGroupName,
                this.ManagerName);

            var backupPolicy = backupPolicies.FirstOrDefault(b => b.Name.Equals(backupPolicyName));

            Assert.True(backupPolicy == null, "Deletion of backup-policy was not successful.");
        }

        /// <summary>
        /// Create Schedule for a Backup 
        /// </summary>
        private BackupSchedule CreateBackupSchedule(
            string deviceName,
            string backupPolicyName,
            string name,
            RecurrenceType recurrenceType,
            DateTime startTime)
        {
            // Initialize defaults
            ScheduleStatus scheduleStatus = ScheduleStatus.Enabled;
            int recurrenceValue = 1;
            long retentionCount = 1;
            List<SSModels.DayOfWeek> weeklyDays = new List<SSModels.DayOfWeek>()
                                     {
                                         SSModels.DayOfWeek.Friday,
                                         SSModels.DayOfWeek.Thursday,
                                         SSModels.DayOfWeek.Monday
                                     };

            var schedule = new BackupSchedule()
            {
                BackupType = BackupType.CloudSnapshot,
                Kind = Kind.Series8000,
                RetentionCount = retentionCount,
                ScheduleStatus = scheduleStatus,
                StartTime = startTime,
                ScheduleRecurrence = new ScheduleRecurrence(
                    recurrenceType,
                    recurrenceValue)
            };

            // Set the week days for the weekly schedule
            if (schedule.ScheduleRecurrence.RecurrenceType == RecurrenceType.Weekly)
            {
                schedule.ScheduleRecurrence.WeeklyDaysList =
                    weeklyDays.Select(d => (SSModels.DayOfWeek?)d).ToList();
            }

            return this.Client.BackupSchedules.CreateOrUpdate(
                    deviceName.GetDoubleEncoded(),
                    backupPolicyName.GetDoubleEncoded(),
                    name.GetDoubleEncoded(),
                    schedule,
                    this.ResourceGroupName,
                    this.ManagerName);
        }

        /// <summary>
        /// Helper method to return backups for a given volume
        /// </summary>
        private IEnumerable<Backup> GetBackupsByVolume(string deviceName, string volumeId)
        {
            // Get the backups by the VolumeId
            Expression<Func<BackupFilter, bool>> filter = backupFilter =>
                backupFilter.VolumeId == volumeId;

            return this.Client.Backups.ListByDevice(
                                deviceName,
                                this.ResourceGroupName,
                                this.ManagerName,
                                new ODataQuery<BackupFilter>(filter)) as IEnumerable<Backup>;
        }
    }
}
