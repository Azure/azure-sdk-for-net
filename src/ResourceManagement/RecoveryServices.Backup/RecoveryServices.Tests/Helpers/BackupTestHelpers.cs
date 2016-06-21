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
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class BackupTestHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public BackupTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public string BackupProtectedItem(string rsVaultRgName, string rsVaultName, string containerUri, string protectedItemUri)
        {
            string fabricName = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureIaasVM);

            TriggerBackupRequest backupRequest = new TriggerBackupRequest();
            backupRequest.Item = new BackupRequestResource();
            IaaSVMBackupRequest iaasVmBackupRequest = new IaaSVMBackupRequest();
            iaasVmBackupRequest.RecoveryPointExpiryTimeInUTC = DateTime.UtcNow.AddDays(2);
            backupRequest.Item.Properties = iaasVmBackupRequest;

            var response = Client.Backups.TriggerBackup(rsVaultRgName, rsVaultName, CommonTestHelper.GetCustomRequestHeaders(),
                fabricName, containerUri, protectedItemUri, backupRequest);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.AzureAsyncOperation);
            Assert.NotNull(response.RetryAfter);

            var operationResponse = Client.ProtectedItems.GetProtectedItemOperationResultByURLAsync(response.Location, CommonTestHelper.GetCustomRequestHeaders());
            while (operationResponse.Result.StatusCode == HttpStatusCode.Accepted)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                }
                operationResponse = Client.ProtectedItems.GetProtectedItemOperationResultByURLAsync(response.Location, CommonTestHelper.GetCustomRequestHeaders());
            }

            var operationStatusResponse = Client.GetOperationStatusByURLAsync(response.AzureAsyncOperation, CommonTestHelper.GetCustomRequestHeaders());
            var operationJobResponse = (OperationStatusJobExtendedInfo)operationStatusResponse.Result.OperationStatus.Properties;
            Assert.NotNull(operationJobResponse.JobId);

            return operationJobResponse.JobId;
        }
    }
}
