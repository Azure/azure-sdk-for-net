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
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class AzureSqlProtectedItemTest : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListProtectedItemTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
                queryParams.BackupManagementType = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureSql);
                queryParams.DatasourceType = CommonTestHelper.GetSetting(TestConstants.WorkloadTypeAzureSqlDb);

                ProtectedItemTestHelpers itemTestHelper = new ProtectedItemTestHelpers(client);
                var response = itemTestHelper.ListProtectedItems(rsVaultRgName, rsVaultName, queryParams);

                string itemName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                Assert.True(response.ItemList.Value.Any(item =>
                {
                    return ((item.Properties is AzureSqlProtectedItem) &&
                           item.Name.Contains(itemName));
                }),
                    "Retrieved list of items doesn't contain AzureSqlProtectedItem test item");
            }
        }

        [Fact]
        public void DeleteProtectedItemTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string itemUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                string containerUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlContainerName];
                string containeType = ConfigurationManager.AppSettings[TestConstants.ContainerTypeAzureSql];
                string itemType = ConfigurationManager.AppSettings[TestConstants.WorkloadTypeAzureSqlDb];
                string containerName = containeType + ";" + containerUniqueName;
                string itemName = itemType + ";" + itemUniqueName;
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);

                var response = protectedItemTestHelper.DeleteProtectedItem(
                    rsVaultRgName, rsVaultName, fabricName, containerName, itemName);
                Assert.Equal(response.StatusCode, HttpStatusCode.Accepted);
            }
        }

        [Fact]
        public void GetProtectedItemTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string itemUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                string containerUniqueName = ConfigurationManager.AppSettings[TestConstants.AzureSqlContainerName];
                string containeType = ConfigurationManager.AppSettings[TestConstants.ContainerTypeAzureSql];
                string itemType = ConfigurationManager.AppSettings[TestConstants.WorkloadTypeAzureSqlDb];
                string containerName = containeType + ";" + containerUniqueName;
                string itemName = itemType + ";" + itemUniqueName;

                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);

                var response = protectedItemTestHelper.GetProtectedItem(rsVaultRgName, rsVaultName, containerName, itemName);

                Assert.Equal(itemUniqueName, response.Item.Name);
                Assert.NotNull(response.Item.Properties as AzureSqlProtectedItem);
            }
        }
    }
}
