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

using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Backup.Tests.Helpers;
using System;
using System.Configuration;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class AzureSqlRecoveryPointTests : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListRecoveryPointTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgName"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultName"];
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string containerUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlContainerName];
                string containeType = ConfigurationManager.AppSettings[TestConstants.ContainerTypeAzureSql];
                string containerUri = containeType + ";" + containerUniqueName;

                string itemUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                string itemType = ConfigurationManager.AppSettings[TestConstants.WorkloadTypeAzureSqlDb];
                string itemUri = itemType + ";" + itemUniqueName;

                DateTime startTime = new DateTime(2016, 6, 13, 15, 25, 9, DateTimeKind.Utc);
                DateTime endTime = new DateTime(2016, 6, 16, 19, 25, 9, DateTimeKind.Utc);

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
                    GenericRecoveryPoint rp = rpo.Properties as GenericRecoveryPoint;
                    Assert.True(!string.IsNullOrEmpty(rp.RecoveryPointTime), "RecoveryPointTime can't be null or empty");
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

                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgName"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultName"];
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string containerUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlContainerName];
                string containeType = ConfigurationManager.AppSettings[TestConstants.ContainerTypeAzureSql];
                string containerUri = containeType + ";" + containerUniqueName;

                string itemUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                string itemType = ConfigurationManager.AppSettings[TestConstants.WorkloadTypeAzureSqlDb];
                string itemUri = itemType + ";" + itemUniqueName;
                string rpId = ConfigurationManager.AppSettings[TestConstants.AzureSqlRpId];

                var response = client.RecoveryPoints.Get(resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(),
                    fabricName, containerUri, itemUri, rpId);

                var rpo = response.RecPoint;
                Assert.NotNull(rpo);
                Assert.True(!string.IsNullOrEmpty(rpo.Name), "RP Id cant be null");
                GenericRecoveryPoint rp = rpo.Properties as GenericRecoveryPoint;
                Assert.True(!string.IsNullOrEmpty(rp.RecoveryPointTime), "RecoveryPointTime can't be null or empty");
            }
        }
    }
}
