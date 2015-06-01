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
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class DataContainerTests : StorSimpleTestBase
    {
        [Fact]
        public void CanGetAllDataContainersTest()
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
                
                //Listing all the data containers
                var dataContainerList = client.DataContainer.List(actualdeviceId,GetCustomRequestHeaders());

                Assert.True(dataContainerList != null);
                Assert.True(dataContainerList.Any());
            }
        }

        [Fact]
        public void CanCreateDataContainerTest()
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

                //var dataContainerToUpdate = new DataContainerRequest();

                //var sacToBeUsedForUpdate = Createddatacontainer.DataContainerInfo.PrimaryStorageAccountCredential;
                //sacToBeUsedForUpdate.PasswordEncryptionCertThumbprint = "7DE2C6A43E7B6B35997EC1180CEE43EA2333CE93";

                //dataContainerToUpdate.IsDefault = Createddatacontainer.DataContainerInfo.IsDefault;
                //dataContainerToUpdate.InstanceId = Createddatacontainer.DataContainerInfo.InstanceId;
                //dataContainerToUpdate.Name = Createddatacontainer.DataContainerInfo.Name;
                //dataContainerToUpdate.BandwidthRate = Createddatacontainer.DataContainerInfo.BandwidthRate;
                //dataContainerToUpdate.VolumeCount = Createddatacontainer.DataContainerInfo.VolumeCount;
                //dataContainerToUpdate.IsEncryptionEnabled = Createddatacontainer.DataContainerInfo.IsEncryptionEnabled;
                ////dataContainerToUpdate.EncryptionKey = Createddatacontainer.DataContainerInfo.EncryptionKey;
                //dataContainerToUpdate.PrimaryStorageAccountCredential = Createddatacontainer.DataContainerInfo.PrimaryStorageAccountCredential;
                //dataContainerToUpdate.SecretsEncryptionThumbprint = "7DE2C6A43E7B6B35997EC1180CEE43EA2333CE93";
                    

                //dataContainerToUpdate.BandwidthRate = 512;

                //jobStatus = client.DataContainer.Update(actualdeviceId, dataContainerToUpdate.InstanceId,
                //    dataContainerToUpdate, hdrs);

                ////Assert the job status
                //Assert.NotNull(taskStatus);
                //Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                //Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                taskStatus = client.DataContainer.Delete(actualdeviceId, Createddatacontainer.DataContainerInfo.InstanceId, hdrs);

                //Assert the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);
            }
        }
    }
}
