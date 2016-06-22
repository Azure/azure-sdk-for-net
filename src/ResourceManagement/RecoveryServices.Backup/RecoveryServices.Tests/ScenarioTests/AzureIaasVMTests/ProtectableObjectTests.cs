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
    public class ProtectableObjectTests : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListProtectableObjectTest()
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

                // ACTION: List protectable objects
                ProtectableObjectListQueryParameters queryParams = new ProtectableObjectListQueryParameters();
                queryParams.BackupManagementType = BackupManagementType.AzureIaasVM.ToString();
                ProtectableObjectTestHelper poTestHelper = new ProtectableObjectTestHelper(client);
                ProtectableObjectListResponse response = poTestHelper.ListProtectableObjects(
                    resourceGroupName, resourceName, queryParams, new PaginationRequest());

                // VALIDATION: VM should not be found in the list
                Assert.False(response.ItemList.ProtectableObjects.Any(
                    protectableObject =>
                    {
                        return protectableObject.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectableItem)) &&
                            protectableObject.Name.Contains(containerUniqueName);
                    }),
                    "Retrieved list of containers doesn't contain AzureIaaSVMProtectableItem Item");
            }
        }
    }
}
