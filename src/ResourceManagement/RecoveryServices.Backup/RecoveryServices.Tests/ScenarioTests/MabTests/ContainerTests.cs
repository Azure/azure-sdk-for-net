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

using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Backup.Tests.Helpers;
using System.Configuration;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class MabContainerTests : RecoveryServicesBackupTestsBase
    {        
        [Fact]
        public void ListContainersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();
                queryParams.BackupManagementType = BackupManagementType.MAB.ToString();

                ContainerTestHelper containerTestHelper = new ContainerTestHelper(client);
                ProtectionContainerListResponse response = containerTestHelper.ListMABContainers(queryParams);

                string containerUniqueName = CommonTestHelper.GetSetting(TestConstants.RsVaultMabContainerUniqueName);
                MabProtectionContainer container = response.ItemList.ProtectionContainers[0].Properties as MabProtectionContainer;
                Assert.NotNull(container);
                Assert.Equal(containerUniqueName, container.FriendlyName);
            }
        }

        [Fact]
        public void UnregisterContainersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                ContainerTestHelper containerTestHelper = new ContainerTestHelper(client);
                string mabContainerName = ConfigurationManager.AppSettings["MabContainerName"];
                AzureOperationResponse response = containerTestHelper.UnregisterMABContainer(mabContainerName);
            }               
        }
    }
}
