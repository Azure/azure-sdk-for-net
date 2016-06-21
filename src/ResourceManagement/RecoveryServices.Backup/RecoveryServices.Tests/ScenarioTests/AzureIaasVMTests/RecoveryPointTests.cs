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
    public class RecoveryPointTests : RecoveryServicesBackupTestsBase
    {
        public void ListRecoveryPointTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                // TODO: Create VM instead of taking these parameters from config
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRP"];
                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRP"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string containerUri = containeType + ";" + containerUniqueName;
                string itemUri = itemType + ";" + itemUniqueName;
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
                string utcDateTimeFormat = ConfigurationManager.AppSettings["UTCDateTimeFormat"];
                
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // 2. Get default policy
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                string policyId = policyTestHelper.GetDefaultPolicyId(resourceGroupName, resourceName);

                // 3. Enable protection
                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);
                protectedItemTestHelper.EnableProtection(resourceGroupName, resourceName, policyId, containerUri, itemUri);

                // 4. Trigger backup and wait for completion
                BackupTestHelpers backupTestHelper = new BackupTestHelpers(client);
                DateTime backupStartTime = DateTime.UtcNow;
                string jobId = backupTestHelper.BackupProtectedItem(resourceGroupName, resourceName, containerUri, itemUri);
                JobTestHelpers jobTestHelper = new JobTestHelpers(client);
                jobTestHelper.WaitForJob(resourceGroupName, resourceName, jobId);
                DateTime backupEndTime = DateTime.UtcNow;

                // ACTION: Fetch RP
                RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
                queryFilter.StartDate = backupStartTime.ToString(utcDateTimeFormat);
                queryFilter.EndDate = backupEndTime.ToString(utcDateTimeFormat);
                var response = client.RecoveryPoints.List(
                    resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(), fabricName, containerUri, itemUri, queryFilter);

                // VALIDATION: Should be only one RP
                Assert.NotNull(response.RecoveryPointList);
                Assert.NotNull(response.RecoveryPointList.RecoveryPoints);
                Assert.Equal(1, response.RecoveryPointList.RecoveryPoints.Count);
            }
        }

        public void GetRecoveryPointDetailTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // 2. Get default policy
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                string policyId = policyTestHelper.GetDefaultPolicyId(resourceGroupName, resourceName);

                // 3. Enable protection
                // TODO: Create VM instead of taking these parameters from config
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRP"];
                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRP"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string containerUri = containeType + ";" + containerUniqueName;
                string itemUri = itemType + ";" + itemUniqueName;
                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);
                protectedItemTestHelper.EnableProtection(resourceGroupName, resourceName, policyId, containerUri, itemUri);

                // 4. Trigger backup and wait for completion
                BackupTestHelpers backupTestHelper = new BackupTestHelpers(client);
                DateTime backupStartTime = DateTime.UtcNow;
                string jobId = backupTestHelper.BackupProtectedItem(resourceGroupName, resourceName, containerUri, itemUri);
                JobTestHelpers jobTestHelper = new JobTestHelpers(client);
                jobTestHelper.WaitForJob(resourceGroupName, resourceName, jobId);
                DateTime backupEndTime = DateTime.UtcNow;

                // 5. Get latest RP
                RecoveryPointTestHelpers recoveryPointTestHelper = new RecoveryPointTestHelpers(client);
                var recoveryPoints = recoveryPointTestHelper.ListRecoveryPoints(
                    resourceGroupName, resourceName, containerUri, itemUri, backupStartTime, backupEndTime);
                var recoveryPointResource = recoveryPoints[0];
                var recoveryPoint = (RecoveryPoint)recoveryPointResource.Properties;

                // ACTION: Get RP details
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
                var response = client.RecoveryPoints.Get(
                    resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(),
                    fabricName, containerUri, itemUri, recoveryPointResource.Name);

                // VALIDATION: Should be valid RP
                Assert.NotNull(response);
                Assert.NotNull(response.RecPoint);
                Assert.True(!string.IsNullOrEmpty(response.RecPoint.Name), "RP Id cant be null");
                Assert.True(!string.IsNullOrEmpty(((RecoveryPoint)response.RecPoint.Properties).RecoveryPointTime),
                    "RecoveryPointTime can't be null or empty");
                Assert.True(!string.IsNullOrEmpty(((RecoveryPoint)response.RecPoint.Properties).SourceVMStorageType),
                    "SourceVMStorageType can't be null or empty");
            }
        }
    }
}
