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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class VirtualDiskTests : StorSimpleTestBase
    {
        [Fact]
        public void VirtualDiskScenarioTest()
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
                    Name = TestUtilities.GenerateName("VDName"),
                    AccessType = AccessType.ReadWrite,
                    AcrList =  acrList,
                    AppType = AppType.ArchiveVolume,
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

                //virtual disk list call
                var vdlist = client.VirtualDisk.List(actualdeviceId, Createddatacontainer.DataContainerInfo.InstanceId, hdrs);

                Assert.True(vdlist != null);
                Assert.True(vdlist.Any());

                var vdbbyname = client.VirtualDisk.GetByName(actualdeviceId, vdlist.ListofVirtualDisks[0].Name, hdrs);
                Assert.True(vdbbyname != null);

                var virtualDiskToUpdate = vdbbyname.VirtualDiskInfo;

                virtualDiskToUpdate.SizeInBytes = 21474836480;
                virtualDiskToUpdate.Online = false;

                taskStatus = client.VirtualDisk.Update(actualdeviceId, virtualDiskToUpdate.InstanceId,
                    virtualDiskToUpdate, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                taskStatus = client.VirtualDisk.Delete(actualdeviceId, virtualDiskToUpdate.InstanceId, hdrs);

                //Asserting the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

            }
        }
    }
}