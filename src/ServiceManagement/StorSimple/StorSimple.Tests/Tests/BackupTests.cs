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
    public class BackupTests : StorSimpleTestBase
    {
        [Fact]
        public void BackupScenarioTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Listing all Devices
                var devices = client.Devices.List(GetCustomRequestHeaders());

                // Asserting that atleast One Device is returned.
                Assert.True(devices != null);
                Assert.True(devices.Any());

                var actualdeviceId = devices.FirstOrDefault().DeviceId;
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
                    SizeInBytes = 10737418240,
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

                //BackupPolicy get by name call
                var createdBackupPolicy = client.BackupPolicy.GetBackupPolicyDetailsByName(actualdeviceId, backupPolicyToCreate.Name, hdrs);

                //Assert the returned BackupPolicy object
                Assert.True(createdBackupPolicy != null);
                Assert.True(createdBackupPolicy.BackupPolicyDetails.Name.Equals(backupPolicyToCreate.Name));

                BackupNowRequest backupNowRequest = new BackupNowRequest();
                backupNowRequest.Type = BackupType.CloudSnapshot;
                

                //BackupSets Create call
                taskStatus = client.Backup.Create(actualdeviceId, createdBackupPolicy.BackupPolicyDetails.InstanceId, backupNowRequest, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                BackupScheduleBase hourlySchedule = new BackupScheduleBase();
                hourlySchedule.BackupType = BackupType.LocalSnapshot;
                hourlySchedule.Status = ScheduleStatus.Enabled;
                hourlySchedule.RetentionCount = 10;
                hourlySchedule.StartTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                hourlySchedule.Recurrence = new ScheduleRecurrence();
                hourlySchedule.Recurrence.RecurrenceType = RecurrenceType.Hourly;
                hourlySchedule.Recurrence.RecurrenceValue = 12;

                List<BackupScheduleBase> backupSchedulesToBeAdded = new List<BackupScheduleBase>();
                backupSchedulesToBeAdded.Add(hourlySchedule);

                var updatePolicyRequest = new UpdateBackupPolicyConfig();
                updatePolicyRequest.InstanceId = createdBackupPolicy.BackupPolicyDetails.InstanceId;
                updatePolicyRequest.Name = createdBackupPolicy.BackupPolicyDetails.Name;
                updatePolicyRequest.BackupSchedulesToBeAdded = backupSchedulesToBeAdded;
                updatePolicyRequest.BackupSchedulesToBeUpdated = new List<BackupScheduleUpdateRequest>();
                updatePolicyRequest.BackupSchedulesToBeDeleted = new List<string>();
                updatePolicyRequest.VolumeIds = volumeIds;

                //Backup policy update call
                taskStatus = client.BackupPolicy.Update(actualdeviceId, createdBackupPolicy.BackupPolicyDetails.InstanceId, updatePolicyRequest, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                GetBackupResponse backupSetResult;

                do
                {
                    //BackupSets Get call
                    backupSetResult = client.Backup.Get(actualdeviceId, "BackupPolicy", Boolean.TrueString, null, null, null, null, null, hdrs);

                    Assert.True(backupSetResult != null);
                    Assert.True(backupSetResult.BackupSetsList != null);

                    TestUtilities.Wait(1000);
                } while (!backupSetResult.BackupSetsList.Any());

                var backupSetId = backupSetResult.BackupSetsList.First().InstanceId;
                var restoreBackupRequest = new RestoreBackupRequest()
                {
                    BackupSetId = backupSetId,
                    SnapshotId = null
                };

                //Restore call
                taskStatus = client.Backup.Restore(actualdeviceId, restoreBackupRequest, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                //BackupSets Delete call
                taskStatus = client.Backup.Delete(actualdeviceId, backupSetId, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                TestUtilities.Wait(60*1000); //wait for 1min for the backup to be deleted

                //Backup Policy delete call
                taskStatus = client.BackupPolicy.Delete(actualdeviceId, createdBackupPolicy.BackupPolicyDetails.InstanceId, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

            }
        }



    }
}