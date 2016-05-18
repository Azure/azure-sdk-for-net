﻿//
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
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests.Helpers
{
    public class BackupTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public BackupTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public void BackupProtectedItem()
        {
            string rsVaultRgName = "pstestrg";
            string rsVaultName = "pstestrsvault";
            string fabricName = CommonTestHelper.GetSetting(TestConstants.ProviderTypeAzureIaasVM);
            string containerName = "IaasVMContainer;iaasvmcontainerv2;pstestrg;pstestv2vm1";
            string protectedItemName = "VM;iaasvmcontainerv2;pstestrg;pstestv2vm1";

            var response = Client.Backups.TriggerBackup(rsVaultRgName, rsVaultName, CommonTestHelper.GetCustomRequestHeaders(),
                fabricName, containerName, protectedItemName);

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
        }
    }
}
