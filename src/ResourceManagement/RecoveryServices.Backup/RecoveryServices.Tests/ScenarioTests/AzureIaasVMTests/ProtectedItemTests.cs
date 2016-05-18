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
    public class ProtectedItemTest : RecoveryServicesTestsBase
    {
        [Fact]
        public void EnableAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                ProtectedItemCreateOrUpdateRequest input = new ProtectedItemCreateOrUpdateRequest();
                AzureIaaSClassicComputeVMProtectedItem iaasVmProtectedItem = new AzureIaaSClassicComputeVMProtectedItem();
                iaasVmProtectedItem.PolicyId = ConfigurationManager.AppSettings["RsVaultIaasVMDefaultPolicyId"];

                ProtectedItemResource protectedItemResource = new ProtectedItemResource();
                protectedItemResource.Properties = iaasVmProtectedItem;
                input.Item = protectedItemResource;

                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string containerName = containeType + ";" + containerUniqueName;
                string itemName = itemType + ";" + itemUniqueName;
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

                string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
                string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

                ProtectedItemTestHelper protectedItemTestHelper = new ProtectedItemTestHelper(client);

                var response = protectedItemTestHelper.AddOrUpdateProtectedItem(fabricName,
                    containerName, itemName, input);
            }
        }

        [Fact]
        public void RemoveAzureBackupProtectionTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
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
        public void ListProtectedItemsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
                queryParams.BackupManagementType = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureIaasVM);
                queryParams.DatasourceType = CommonTestHelper.GetSetting(TestConstants.WorkloadTypeVM);

                ProtectedItemTestHelper itemTestHelper = new ProtectedItemTestHelper(client);
                var response = itemTestHelper.ListProtectedItems(queryParams);

                string itemName = ConfigurationManager.AppSettings["RsVaultIaasV1ContainerUniqueName"];
                Assert.True(response.ItemList.Value.Any(item => 
                    {
                        return item.Properties.GetType().IsSubclassOf(typeof(AzureIaaSVMProtectedItem)) &&
                               item.Name.Contains(itemName);
                    }),
                    "Retrieved list of items doesn't contain AzureIaaSVMProtectedItem test item");
            }
        }
    }
}
