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

using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;

namespace StorSimple.Tests.Tests
{
    public class DeviceFailoverTests : StorSimpleTestBase
    {
        [Fact]
        public void DeviceRestoreScenarioTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Listing all Devices
                var devices = client.Devices.List(GetCustomRequestHeaders());

                var onlineDeviceIds = from deviceInfo in devices.Devices
                                      where deviceInfo.Status == DeviceStatus.Online
                                      select deviceInfo.DeviceId;
                Assert.True(onlineDeviceIds.Count() >= 2);
                var sourceDeviceId = onlineDeviceIds.ElementAt(0);
                var targetDeviceId = onlineDeviceIds.ElementAt(1);

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
                var taskStatus = client.DataContainer.Create(sourceDeviceId, dc, hdrs);

                //Assert the task status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                //Get Data Container call
                var Createddatacontainer = client.DataContainer.Get(sourceDeviceId, dataContainerName, hdrs);

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
                    SizeInBytes = 10737418240,
                    DataContainer = Createddatacontainer.DataContainerInfo,
                    Online = true
                };

                //Virtual disk create call
                taskStatus = client.VirtualDisk.Create(sourceDeviceId, virtualDiskToCreate, hdrs);

                //Asserting the task status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                //Virtual disk get call
                var createdVirtualDisk = client.VirtualDisk.GetByName(sourceDeviceId, virtualDiskToCreate.Name, hdrs);

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
                taskStatus = client.BackupPolicy.Create(sourceDeviceId, backupPolicyToCreate, hdrs);

                //Asserting the task status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                //BackupPolicy get by name call
                var createdBackupPolicy = client.BackupPolicy.GetBackupPolicyDetailsByName(sourceDeviceId, backupPolicyToCreate.Name, hdrs);

                //Assert the returned BackupPolicy object
                Assert.True(createdBackupPolicy != null);
                Assert.True(createdBackupPolicy.BackupPolicyDetails.Name.Equals(backupPolicyToCreate.Name));

                BackupNowRequest backupNowRequest = new BackupNowRequest();
                backupNowRequest.Type = BackupType.CloudSnapshot;


                //BackupSets Create call
                taskStatus = client.Backup.Create(sourceDeviceId, createdBackupPolicy.BackupPolicyDetails.InstanceId, backupNowRequest, hdrs);

                //Asserting the task status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                GetBackupResponse backupSetResult;

                do
                {
                    //BackupSets Get call
                    backupSetResult = client.Backup.Get(sourceDeviceId, "BackupPolicy", Boolean.FalseString, createdBackupPolicy.BackupPolicyDetails.InstanceId, null, null, null, null, hdrs);
                    TestUtilities.Wait(1000);
                } while (!backupSetResult.BackupSetsList.Any());
                
                var dcGroupsGetResponse = client.DeviceFailover.ListDCGroups(sourceDeviceId, hdrs);

                var dcIdList = from drDc in dcGroupsGetResponse.DataContainerGroupResponse.DCGroups[0].DCGroup
                    select drDc.InstanceId;

                var drRequest = new DeviceFailoverRequest();
                drRequest.CleanupPrimary = false;
                drRequest.DataContainerIds = dcIdList.ToList();
                drRequest.ReturnWorkflowId = true;
                drRequest.TargetDeviceId = targetDeviceId;

                //trigger failover call
                var jobResponse = client.DeviceFailover.Trigger(sourceDeviceId, drRequest, hdrs);

                //Asserting the task status
                Assert.NotNull(jobResponse);

                //track device job for its completion
                var deviceJobResponse = new GetDeviceJobResponse();
                int retryLimit = 30;
                int pollInterval = 60 * 1000;
                int retryCount = 0;
                bool found = false;

                do
                {
                    TestUtilities.Wait(pollInterval);
                    deviceJobResponse = client.DeviceJob.Get(null, null, null, jobResponse.JobId, null, null, 0, 1, hdrs);
                    if(deviceJobResponse != null)
                    {
                        found = true;
                    }
                    retryCount++;
                } while ((!found || deviceJobResponse.DeviceJobList[0].Status == "Running") && (retryCount < retryLimit));

                Assert.NotNull(deviceJobResponse);
                Assert.Equal(deviceJobResponse.DeviceJobList[0].Status, "Completed");
            }
        }
    }
}
