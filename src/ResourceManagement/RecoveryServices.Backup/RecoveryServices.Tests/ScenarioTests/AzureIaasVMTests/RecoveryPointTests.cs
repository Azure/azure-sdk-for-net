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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using Microsoft.Azure;

namespace RecoveryServices.Tests
{
    public class RecoveryPointTests : RecoveryServicesTestsBase
    {
        [Fact]
        public void ListRecoveryPointTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRestore"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRestore"];
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRestore"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string containerUri = containeType + ";" + containerUniqueName;

                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRestore"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string itemUri = itemType + ";" + itemUniqueName;

                DateTime startTime = new DateTime(2016, 4, 17, 15, 25, 9, DateTimeKind.Utc);
                DateTime endTime = new DateTime(2016, 4, 18, 19, 25, 9, DateTimeKind.Utc);

                RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
                queryFilter.StartDate = startTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                queryFilter.EndDate = endTime.ToString("yyyy-MM-dd hh:mm:ss tt");

                var response = client.RecoveryPoints.List(resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(),
                    fabricName, containerUri, itemUri, queryFilter);
                
                Assert.NotNull(response.RecoveryPointList);
                Assert.NotNull(response.RecoveryPointList.RecoveryPoints);

                foreach (var rpo in response.RecoveryPointList.RecoveryPoints)
                {
                    Assert.True(!string.IsNullOrEmpty(rpo.Name), "RP Id cant be null");
                    RecoveryPoint rp = rpo.Properties as RecoveryPoint;
                    Assert.True(!string.IsNullOrEmpty(rp.RecoveryPointTime), "RecoveryPointTime can't be null or empty");
                    Assert.True(!string.IsNullOrEmpty(rp.SourceVMStorageType), "SourceVMStorageType can't be null or empty");
                }
            }
        }

        [Fact]
        public void GetRecoveryPointDetailTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRestore"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRestore"]; string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRestore"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string containerUri = containeType + ";" + containerUniqueName;

                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRestore"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string itemUri = itemType + ";" + itemUniqueName;
                string rpId = ConfigurationManager.AppSettings["RecoveryPointName"];
                
                var response = client.RecoveryPoints.Get(resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(),
                    fabricName, containerUri, itemUri, rpId);

                var rpo = response.RecPoint;
                Assert.NotNull(rpo);
                Assert.True(!string.IsNullOrEmpty(rpo.Name), "RP Id cant be null");
                RecoveryPoint rp = rpo.Properties as RecoveryPoint;
                Assert.True(!string.IsNullOrEmpty(rp.RecoveryPointTime), "RecoveryPointTime can't be null or empty");
                Assert.True(!string.IsNullOrEmpty(rp.SourceVMStorageType), "SourceVMStorageType can't be null or empty");
            }
        }
    }
}
