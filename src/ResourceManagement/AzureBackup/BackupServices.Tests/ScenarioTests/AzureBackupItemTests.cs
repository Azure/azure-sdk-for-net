//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BackupServices.Tests
{
    public class AzureBackupItemTests : BackupServicesTestsBase
    {
        [Fact]
        public void EnableDisbaleAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                var client = GetServiceClient<BackupServicesManagementClient>();
                context.Start();
                SetProtectionRequestInput input = new SetProtectionRequestInput();
                input.PolicyId = ConfigurationManager.AppSettings["PolicyId"];
                input.ProtectableObjects.Add(ConfigurationManager.AppSettings["AzureBackupItemName"]);
                input.ProtectableObjectType = ConfigurationManager.AppSettings["DataSourceType"];
                var response = client.DataSource.EnableProtection(GetCustomRequestHeaders(), input);
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

                Thread.Sleep(1000 * 20);
                RemoveProtectionRequestInput input1 = new RemoveProtectionRequestInput();
                input1.RemoveProtectionOption = "RetainBackupData";
                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                string dataSourceType = ConfigurationManager.AppSettings["DataSourceType"];
                string dataSourceId = ConfigurationManager.AppSettings["DataSourceId"];
                var response1 = client.DataSource.DisableProtection(GetCustomRequestHeaders(),
                    containerName,
                    dataSourceType,
                    dataSourceId,
                    input1);
                Assert.Equal(HttpStatusCode.Accepted, response1.StatusCode);

                Thread.Sleep(1000 * 20);
                var response3 = client.DataSource.EnableProtection(GetCustomRequestHeaders(), input);
                Assert.Equal(HttpStatusCode.Accepted, response3.StatusCode);

            }
        }

        [Fact]
        public void ListAzureBackupItemPOTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                POQueryParameter POQueryParam = new POQueryParameter()
                {
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.ProtectableObject.ListAsync(POQueryParam, GetCustomRequestHeaders()).Result;

                Assert.True(response.ProtectableObject.ResultCount > 0, "Protectable Object Result count can't be less than 1");

                foreach (var po in response.ProtectableObject.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(po.ContainerName), "ContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ContainerType), "ContainerType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Type), "Type can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.InstanceId), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Name), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ParentContainerFriendlyName), "ParentContainerFriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ParentContainerName), "ParentContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.ProtectionStatus), "ProtectionStatus can't be null or empty");
                }

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void ListAzureBackupItemDSTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                DataSourceQueryParameter DSQueryParam = new DataSourceQueryParameter()
                {
                    ProtectionStatus = null,
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.DataSource.ListAsync(DSQueryParam, GetCustomRequestHeaders()).Result;
                foreach (var ds in response.DataSources.Objects)
                {
                    Assert.True(!string.IsNullOrEmpty(ds.ContainerName), "ContainerName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ContainerType), "ContainerType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Type), "Type can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.RecoveryPointsCount.ToString()), "RecoveryPointsCount can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ProtectableObjectName), "ProtectableObjectName can't be  null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.InstanceId), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Name), "WorkloadType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.ProtectionStatus), "ProtectionStatus can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Status), "Status can't be null or empty"); ;
                }

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
