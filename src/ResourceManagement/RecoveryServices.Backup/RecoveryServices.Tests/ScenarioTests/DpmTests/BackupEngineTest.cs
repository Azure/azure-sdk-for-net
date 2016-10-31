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
    public class BackupEngineTest : RecoveryServicesBackupTestsBase
    {
        [Fact]
        public void ListDPMBakcupEngineTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                BackupEngineHelpers backupEngineTestHelper = new BackupEngineHelpers(client);
                BackupEngineListQueryParams queryParam = new BackupEngineListQueryParams();
                //queryParam.ProviderType = "DPM";
                PaginationRequest paginationParam = new PaginationRequest();
                paginationParam.Top = "200";
                AzureOperationResponse response = backupEngineTestHelper.ListBackupEngine(queryParam, paginationParam);
                BackupEngineListResponse  backupEngineResponse = response as BackupEngineListResponse;
                string backupEngineUniqueName = CommonTestHelper.GetSetting(TestConstants.RsVaultDpmContainerUniqueName);
                Assert.NotNull(backupEngineResponse.ItemList.BackupEngines[0].Properties as BackupEngineBase);
                Assert.Equal(backupEngineUniqueName, backupEngineResponse.ItemList.BackupEngines[0].Name); 
            }
        }

        [Fact]
        public void UnregisterDPMBackupEngineTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);
                BackupEngineHelpers backupEngineTestHelper = new BackupEngineHelpers(client);
                string dpmBackupEngineName = ConfigurationManager.AppSettings["DpmBackupEngineName"];
                AzureOperationResponse response = backupEngineTestHelper.UnregisterBackupEngine(dpmBackupEngineName);
            }
        }
    }
}
