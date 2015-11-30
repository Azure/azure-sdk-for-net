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
    public class CSMAzureBackupItem : BackupServicesTestsBase
    {
        //[Fact]
        public void EnableAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();
                CSMSetProtectionRequest input = new CSMSetProtectionRequest();
                input.Properties = new CSMSetProtectionRequestProperties();
                input.Properties.PolicyId = ConfigurationManager.AppSettings["PolicyId"];
                string itemName = ConfigurationManager.AppSettings["AzureBackupItemName"];
                string containerName = ConfigurationManager.AppSettings["ContainerName"];

                var response = client.DataSource.EnableProtectionCSM(BackupServicesTestsBase.ResourceGroupName, 
                    BackupServicesTestsBase.ResourceName, 
                    GetCustomRequestHeaders(), 
                    containerName, 
                    itemName, 
                    input);

                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        //[Fact]
        public void UpdateAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                CSMUpdateProtectionRequest input = new CSMUpdateProtectionRequest();
                input.Properties = new CSMUpdateProtectionRequestProperties();
                string itemName = ConfigurationManager.AppSettings["AzureBackupItemName"];
                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                input.Properties.PolicyId = string.Empty;

                var response = client.DataSource.UpdateProtectionCSM(BackupServicesTestsBase.ResourceGroupName, 
                    BackupServicesTestsBase.ResourceName, 
                    GetCustomRequestHeaders(),
                    containerName,
                    itemName,
                    input);

                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        //[Fact]
        public void DisableAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetServiceClient<BackupServicesManagementClient>();

                string itemName = ConfigurationManager.AppSettings["AzureBackupItemName"];
                string containerName = ConfigurationManager.AppSettings["ContainerName"];
                var response = client.DataSource.DisableProtectionCSM(BackupServicesTestsBase.ResourceGroupName, 
                    BackupServicesTestsBase.ResourceName, 
                    GetCustomRequestHeaders(),
                    containerName,
                    itemName);

                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            }
        }

        [Fact]
        public void ListAzureBackupItemPOTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                CSMItemQueryObject POQueryParam = new CSMItemQueryObject()
                {
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.ProtectableObject.ListCSMAsync(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, POQueryParam, GetCustomRequestHeaders()).Result;

                Assert.True(response.CSMItemListResponse.Value.Count > 0, "Protectable Object Result count can't be less than 1");

                foreach (var po in response.CSMItemListResponse.Value)
                {
                    Assert.True(!string.IsNullOrEmpty(po.Properties.ContainerId), "ContainerId can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Properties.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Properties.ItemType), "ItemType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Properties.Status), "Status can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Name), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(po.Type), "Type can't be null or empty");
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

                CSMProtectedItemQueryObject DSQueryParam = new CSMProtectedItemQueryObject()
                {
                    ProtectionStatus = null,
                    Status = null,
                    Type = null
                };

                var client = GetServiceClient<BackupServicesManagementClient>();

                var response = client.DataSource.ListCSMAsync(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, DSQueryParam, GetCustomRequestHeaders()).Result;
                foreach (var ds in response.CSMProtectedItemListResponse.Value)
                {
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.ContainerId), "ContainerId can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.FriendlyName), "FriendlyName can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.ItemType), "ItemType can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.ProtectionPolicyId), "ProtectionPolicyId can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.ProtectionStatus), "ProtectionStatus can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.RecoveryPointsCount.ToString()), "RecoveryPointsCount can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Properties.Status), "Status can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Name), "Name can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(ds.Type), "Type can't be null or empty"); 
                }

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}