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

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests
{
    public class AzureSqlProtectedItemTest : RecoveryServicesTestsBase
    {
        [Fact]
        public void ListProtectedItemTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
                queryParams.BackupManagementType = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureSql);
                queryParams.DatasourceType = CommonTestHelper.GetSetting(TestConstants.WorkloadTypeAzureSqlDb);

                ProtectedItemTestHelper itemTestHelper = new ProtectedItemTestHelper(client);
                var response = itemTestHelper.ListProtectedItems(queryParams);

                string itemName = ConfigurationManager.AppSettings[TestConstants.AzureSqlItemName];
                Assert.True(response.ItemList.Value.Any(item =>
                {
                    return item.Properties.GetType().IsSubclassOf(typeof(AzureSqlProtectedItem)) &&
                           item.Name.Contains(itemName);
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

                ProtectedItemTestHelper protectedItemTestHelper = new ProtectedItemTestHelper(client);

                var response = protectedItemTestHelper.DeleteProtectedItem(fabricName,
                    containerName, itemName);
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
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                ProtectedItemTestHelper protectedItemTestHelper = new ProtectedItemTestHelper(client);

                var response = protectedItemTestHelper.GetProtectedItem(fabricName,
                    containerName, itemName);

                Assert.Equal(itemName, response.Item.Name);
                Assert.Equal(typeof(AzureSqlProtectedItem).Name, response.Item.GetType().Name);
            }
        }
    }
}
