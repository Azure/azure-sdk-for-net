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
    public class RestoreDiskTests : RecoveryServicesTestsBase
    {
        [Fact]
        public void RestoreDiskTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string vaultLocation = ConfigurationManager.AppSettings["vaultLocation"];
                string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRestore"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRestore"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string recoveryPointId = ConfigurationManager.AppSettings["RecoveryPointName"];
                string storageAccountId = ConfigurationManager.AppSettings["StorageAccountId"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRestore"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRestore"];
                string containerUri = containeType + ";" + containerUniqueName;
                string itemUri = itemType + ";" + itemUniqueName;

                IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
                {
                    AffinityGroup = String.Empty,
                    CloudServiceOrResourceGroup = String.Empty,
                    CreateNewCloudService = false,
                    RecoveryPointId = recoveryPointId,
                    RecoveryType = RecoveryType.RestoreDisks,
                    Region = vaultLocation,
                    StorageAccountId = storageAccountId,
                    SubnetId = string.Empty,
                    VirtualMachineName = string.Empty,
                    VirtualNetworkId = string.Empty,
                };

                TriggerRestoreRequest triggerRestoreRequest = new TriggerRestoreRequest();
                triggerRestoreRequest.Item = new RestoreRequestResource();
                triggerRestoreRequest.Item.Properties = new RestoreRequest();
                triggerRestoreRequest.Item.Properties = restoreRequest;

                var response = client.Restores.TriggerRestore(resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(),
                    fabricName, containerUri, itemUri, recoveryPointId, triggerRestoreRequest);

                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
                Assert.True(!string.IsNullOrEmpty(response.Location), "Location cant be null");
            }
        }
    }
}
