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
using System.Configuration;
using System.Linq;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class ContainerTests : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListContainersTest()
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

                // ACTION: List containers
                ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();
                queryParams.BackupManagementType = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureIaasVM);
                ContainerTestHelper containerTestHelper = new ContainerTestHelper(client);
                ProtectionContainerListResponse response = containerTestHelper.ListContainers(resourceGroupName, resourceName, queryParams);

                // VALIDATION: VM should be found in the list
                Assert.True(response.ItemList.ProtectionContainers.Any(
                    protectionContainer =>
                    {
                        return protectionContainer.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectionContainer)) &&
                            protectionContainer.Name.Contains(containerUniqueName);
                    }),
                    "Retrieved list of containers doesn't contain AzureIaaSVMProtectionContainer test container");
            }
        }

        [Fact]
        public void RefreshContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // ACTION: Trigger refresh containers
                ContainerTestHelper containerTestHelper = new ContainerTestHelper(client);
                var response = containerTestHelper.RefreshContainer(resourceGroupName, resourceName, fabricName);
            }
        }
    }
}
