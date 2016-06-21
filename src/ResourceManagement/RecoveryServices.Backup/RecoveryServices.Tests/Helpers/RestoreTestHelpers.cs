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
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class RestoreTestHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public RestoreTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public string RestoreProtectedItem(string rsVaultRgName, string rsVaultName, string containerUri, string protectedItemUri, string sourceResourceId, string storageAccountId, RecoveryPointResource recoveryPointResource)
        {
            string fabricName = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureIaasVM);

            RecoveryPoint recoveryPoint = (RecoveryPoint)recoveryPointResource.Properties;

            TriggerRestoreRequest restoreRequest = new TriggerRestoreRequest();
            restoreRequest.Item = new RestoreRequestResource();
            IaasVMRestoreRequest iaasVmRestoreRequest = new IaasVMRestoreRequest();
            if (recoveryPoint.KeyAndSecret != null &&
                recoveryPoint.KeyAndSecret.BekDetails != null &&
                recoveryPoint.KeyAndSecret.KekDetails != null)
            {
                iaasVmRestoreRequest.EncryptionDetails = new EncryptionDetails();
                iaasVmRestoreRequest.EncryptionDetails.EncryptionEnabled = true;
                iaasVmRestoreRequest.EncryptionDetails.KekUrl = recoveryPoint.KeyAndSecret.KekDetails.KeyUrl;
                iaasVmRestoreRequest.EncryptionDetails.KekVaultId = recoveryPoint.KeyAndSecret.KekDetails.KeyVaultId;
                iaasVmRestoreRequest.EncryptionDetails.SecretKeyUrl = recoveryPoint.KeyAndSecret.BekDetails.SecretUrl;
                iaasVmRestoreRequest.EncryptionDetails.SecretKeyVaultId = recoveryPoint.KeyAndSecret.BekDetails.SecretVaultId;
            }
            iaasVmRestoreRequest.RecoveryPointId = recoveryPointResource.Name;
            iaasVmRestoreRequest.RecoveryType = RecoveryType.RestoreDisks.ToString();
            iaasVmRestoreRequest.SourceResourceId = sourceResourceId;
            iaasVmRestoreRequest.StorageAccountId = storageAccountId;
            restoreRequest.Item.Properties = iaasVmRestoreRequest;

            var response = Client.Restores.TriggerRestore(rsVaultRgName, rsVaultName, CommonTestHelper.GetCustomRequestHeaders(),
                fabricName, containerUri, protectedItemUri, recoveryPointResource.Name, restoreRequest);

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
