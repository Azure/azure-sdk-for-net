// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using Xunit;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.Azure.Test;
using System.Collections.Generic;

namespace StorSimple.Tests.Tests
{
    public class DeviceJobTests : StorSimpleTestBase
    {
        /// <summary>
        /// Get hold of an online device, schedule a backup job, and verify there is atleast one job in list
        /// of device jobs.
        /// </summary>
        [Fact]
        public void CanGetDeviceJobsTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                var headers = GetCustomRequestHeaders();

                // Get all devices.
                var devices = client.Devices.List(headers);

                // Get hold of an online device.
                var onlineDevice = devices.LastOrDefault(device => device.Status == DeviceStatus.Online);
                if (onlineDevice == null)
                {
                    throw new ArgumentException("Need an online device to try scheduling and retrieving device jobs");
                }

                //Get hold of a backup policy 
                BackupPolicy policy;
                var policiesResponse = client.BackupPolicy.List(onlineDevice.DeviceId, headers);
                if (policiesResponse == null)
                {
                    policy = null;
                }
                else
                {
                    policy = policiesResponse.BackupPolicies.FirstOrDefault();
                }
                if(policy == null){
                    throw new ArgumentException("The online device must have a backup policy to schedule and get device jobs");
                }

                // Schedule a backup

                var backupNowRequest = new BackupNowRequest();
                backupNowRequest.Type = BackupType.CloudSnapshot;
                var taskStatus = client.Backup.Create(onlineDevice.DeviceId, policy.InstanceId, backupNowRequest, headers);

                // Make sure the backup job was created

                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                // Get a list of device jobs for this device now.
                var response = client.DeviceJob.Get(onlineDevice.DeviceId, null, null, null, null, null, 0, 10, headers);
                Assert.NotNull(response);
                Assert.True(response.Count > 0);
                Assert.NotEmpty(response.DeviceJobList);
            }
        }

        /// <summary>
        /// Get hold of an online device, create a backup job and immediately try to stop it.
        /// </summary>
        [Fact]
        public void CanStopDeviceJobTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Get all devices.
                var devices = client.Devices.List(GetCustomRequestHeaders());

                // Get hold of an online device.
                var onlineDevice = devices.LastOrDefault(device => device.Status == DeviceStatus.Online);
                if (onlineDevice == null)
                {
                    throw new ArgumentException("Need an online device to try scheduling and retrieving device jobs");
                }

                CreateSupportingVolumeAndBackupPolicy(onlineDevice);

                //Get hold of a backup policy 
                BackupPolicy policy;
                var policiesResponse = client.BackupPolicy.List(onlineDevice.DeviceId, GetCustomRequestHeaders());
                if (policiesResponse == null)
                {
                    policy = null;
                }
                else
                {
                    policy = policiesResponse.BackupPolicies.FirstOrDefault();
                }
                if (policy == null)
                {
                    throw new ArgumentException("The online device must have a backup policy to schedule and get device jobs");
                }

                // Schedule a backup
                var backupNowRequest = new BackupNowRequest();
                backupNowRequest.Type = BackupType.CloudSnapshot;
                var taskStatus = client.Backup.Create(onlineDevice.DeviceId, policy.InstanceId, backupNowRequest, GetCustomRequestHeaders());

                // Make sure the backup job was created
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                // Get all device jobs and get hold of a job that is running
                var jobsResponse = client.DeviceJob.Get(onlineDevice.DeviceId, null, null, null, null, null, 0, 10, GetCustomRequestHeaders());
                Assert.NotNull(jobsResponse);
                var runningCancellableJob = jobsResponse.DeviceJobList.FirstOrDefault(x => x.Status.Equals("Running") && x.IsJobCancellable);
                if (runningCancellableJob == null)
                {
                    throw new ArgumentException("No running cancellable job available to stop");
                }

                var updateRequest = new UpdateDeviceJobRequest ();
                updateRequest.DeviceJobAction = DeviceJobAction.Cancel;
                var updateTaskStatus = client.DeviceJob.UpdateDeviceJob(runningCancellableJob.Device.InstanceId, runningCancellableJob.InstanceId, updateRequest, GetCustomRequestHeaders());

                //Assert the job status
                Assert.NotNull(updateTaskStatus);
                Assert.True(updateTaskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(updateTaskStatus.Result == AsyncTaskResult.Succeeded);
            }
        }

        /// <summary>
        /// In order to stop a job we need to first schedule a job that is going to run long 
        /// enough for it to be stopped.
        /// </summary>
        /// <param name="deviceInfo">Device details.</param>
        private void CreateSupportingVolumeAndBackupPolicy(DeviceInfo deviceInfo)
        {
            var client = GetServiceClient<StorSimpleManagementClient>();

            var actualdeviceId = deviceInfo.DeviceId;
            actualdeviceId = actualdeviceId.Trim();
            CustomRequestHeaders hdrs = new CustomRequestHeaders();
            hdrs.ClientRequestId = Guid.NewGuid().ToString();
            hdrs.Language = "en-us";

            //Get service configuration
            var serviceConfigList = client.ServiceConfig.Get(GetCustomRequestHeaders());

            Assert.True(serviceConfigList != null);

            var existingSac = serviceConfigList.CredentialChangeList.Updated.FirstOrDefault();

            Assert.True(existingSac != null);

            var dataContainerName = TestUtilities.GenerateName("DCName");

            // new Data container request object
            var dc = new DataContainerRequest();

            dc.IsDefault = false;
            dc.Name = dataContainerName;
            dc.BandwidthRate = 256;
            dc.VolumeCount = 0;
            dc.IsEncryptionEnabled = false;
            dc.PrimaryStorageAccountCredential = existingSac;

            //Create DataContainer call
            var taskStatus = client.DataContainer.Create(actualdeviceId, dc, hdrs);

            //Assert the job status
            Assert.NotNull(taskStatus);
            Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
            Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

            //Get Data Container call
            var Createddatacontainer = client.DataContainer.Get(actualdeviceId, dataContainerName, hdrs);

            //Assert the returned data container object
            Assert.True(Createddatacontainer != null);
            Assert.True(Createddatacontainer.DataContainerInfo.Name.Equals(dataContainerName));

            //ACR list for Virtual disk creation
            List<AccessControlRecord> acrList = new List<AccessControlRecord>();

            for (var i = 0; i < 1; i++)
            {
                AccessControlRecord acr = new AccessControlRecord()
                {
                    Name = TestUtilities.GenerateName("VDnewTestAcr"),
                    InitiatorName = TestUtilities.GenerateName("VDinitiator") + i
                };
                acrList.Add(acr);
            }

            //Virtual disk create request object
            var virtualDiskToCreate = new VirtualDiskRequest()
            {
                Name = TestUtilities.GenerateName("VD1Name"),
                AccessType = AccessType.ReadWrite,
                AcrList = acrList,
                AppType = AppType.PrimaryVolume,
                IsDefaultBackupEnabled = true,
                SizeInBytes = 107374182400,
                DataContainer = Createddatacontainer.DataContainerInfo,
                Online = true
            };

            //Virtual disk create call
            taskStatus = client.VirtualDisk.Create(actualdeviceId, virtualDiskToCreate, hdrs);

            //Asserting the job status
            Assert.NotNull(taskStatus);
            Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
            Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

            //Virtual disk get call
            var createdVirtualDisk = client.VirtualDisk.GetByName(actualdeviceId, virtualDiskToCreate.Name, hdrs);

            Assert.True(createdVirtualDisk != null);
            Assert.True(createdVirtualDisk.VirtualDiskInfo.Name.Equals(virtualDiskToCreate.Name));

            var volumeIds = new List<string>();
            volumeIds.Add(createdVirtualDisk.VirtualDiskInfo.InstanceId);

            var dailySchedule = new BackupScheduleBase();
            dailySchedule.BackupType = BackupType.CloudSnapshot;
            dailySchedule.Status = ScheduleStatus.Enabled;
            dailySchedule.RetentionCount = 5;
            dailySchedule.StartTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            dailySchedule.Recurrence = new ScheduleRecurrence();
            dailySchedule.Recurrence.RecurrenceType = RecurrenceType.Daily;
            dailySchedule.Recurrence.RecurrenceValue = 5;

            var backupPolicyToCreate = new NewBackupPolicyConfig();
            backupPolicyToCreate.Name = TestUtilities.GenerateName("PolicyName");
            backupPolicyToCreate.VolumeIds = volumeIds;
            backupPolicyToCreate.BackupSchedules = new List<BackupScheduleBase>();
            backupPolicyToCreate.BackupSchedules.Add(dailySchedule);

            //BackupPolicy create call
            taskStatus = client.BackupPolicy.Create(actualdeviceId, backupPolicyToCreate, hdrs);

            //Asserting the job status
            Assert.NotNull(taskStatus);
            Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
            Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

            //BackupPolicy list call
            var allBackupPolicies = client.BackupPolicy.List(actualdeviceId, hdrs);

            //Assert the returned BackupPolicy object
            Assert.True(allBackupPolicies != null);
            Assert.True(allBackupPolicies.Any());
        }

    }
}
