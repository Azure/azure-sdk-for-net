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
using System.Configuration;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class ProtectedItemTestHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ProtectedItemTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public BaseRecoveryServicesJobResponse AddOrUpdateProtectedItem(string rsVaultRgName, string rsVaultName, string fabricName,
            string containerName, string protectedItemName, ProtectedItemCreateOrUpdateRequest request)
        {
            var customHeader = CommonTestHelper.GetCustomRequestHeaders();

            BaseRecoveryServicesJobResponse response = Client.ProtectedItems.CreateOrUpdateProtectedItem(rsVaultRgName, rsVaultName,
                fabricName, containerName, protectedItemName, request, customHeader);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.AzureAsyncOperation);
            Assert.NotNull(response.RetryAfter);

            var operationResponse = Client.ProtectedItems.GetProtectedItemOperationResultByURLAsync(response.Location, customHeader);
            while (operationResponse.Result.StatusCode == HttpStatusCode.Accepted)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                }
                operationResponse = Client.ProtectedItems.GetProtectedItemOperationResultByURLAsync(response.Location, customHeader);
            }

            Assert.Equal(HttpStatusCode.OK, operationResponse.Result.StatusCode);
            Assert.NotNull(operationResponse.Result.Item);

            var operationStatusResponse = Client.GetOperationStatusByURLAsync(response.AzureAsyncOperation, CommonTestHelper.GetCustomRequestHeaders());
            var operationJobResponse = (OperationStatusJobExtendedInfo)operationStatusResponse.Result.OperationStatus.Properties;

            Assert.Equal(HttpStatusCode.OK, operationStatusResponse.Result.StatusCode);

            Assert.NotNull(operationJobResponse.JobId);
            Assert.Equal(OperationStatusValues.Succeeded, operationStatusResponse.Result.OperationStatus.Status);

            return response;
        }

        public BaseRecoveryServicesJobResponse DeleteProtectedItem(string rsVaultRgName, string rsVaultName, string fabricName,
           string containerName, string protectedItemName)
        {
            var customHeader = CommonTestHelper.GetCustomRequestHeaders();

            BaseRecoveryServicesJobResponse response = Client.ProtectedItems.DeleteProtectedItem(rsVaultRgName, rsVaultName,
                fabricName, containerName, protectedItemName, customHeader);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.AzureAsyncOperation);
            Assert.NotNull(response.RetryAfter);

            var operationStatusResponse = Client.GetOperationStatusByURLAsync(response.AzureAsyncOperation, customHeader);
            while (operationStatusResponse.Result.OperationStatus.Status == OperationStatusValues.InProgress)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                }
                operationStatusResponse = Client.GetOperationStatusByURLAsync(response.AzureAsyncOperation, customHeader);
            }

            operationStatusResponse = Client.GetOperationStatusByURLAsync(response.AzureAsyncOperation, CommonTestHelper.GetCustomRequestHeaders());
            var operationJobResponse = (OperationStatusJobExtendedInfo)operationStatusResponse.Result.OperationStatus.Properties;
            Assert.NotNull(operationJobResponse.JobId);
            Assert.Equal(OperationStatusValues.Succeeded, operationStatusResponse.Result.OperationStatus.Status);
            return response;
        }

        public ProtectedItemListResponse ListProtectedItems(string rsVaultRgName, string rsVaultName, ProtectedItemListQueryParam queryParams, PaginationRequest paginationRequest = null)
        {
            var response = Client.ProtectedItems.List(rsVaultRgName, rsVaultName, queryParams, paginationRequest, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);

            return response;
        }

        public ProtectedItemResponse GetProtectedItem(string rsVaultRgName, string rsVaultName, string containerName, string protectedItemName)
        {
            string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
            var customHeader = CommonTestHelper.GetCustomRequestHeaders();

            GetProtectedItemQueryParam queryFilter = new GetProtectedItemQueryParam()
            {
                Expand = "extendedinfo"
            };
            ProtectedItemResponse response = Client.ProtectedItems.Get(rsVaultRgName, rsVaultName,
                fabricName, containerName, protectedItemName, queryFilter, customHeader);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Item);

            return response;
        }

        public void EnableProtection(string vaultRgName, string vaultName, string policyId, string containerUri, string itemUri)
        {
            string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];

            ProtectedItemCreateOrUpdateRequest input = new ProtectedItemCreateOrUpdateRequest();
            AzureIaaSClassicComputeVMProtectedItem iaasVmProtectedItem = new AzureIaaSClassicComputeVMProtectedItem();
            iaasVmProtectedItem.PolicyId = policyId;
            ProtectedItemResource protectedItemResource = new ProtectedItemResource();
            protectedItemResource.Properties = iaasVmProtectedItem;
            input.Item = protectedItemResource;

            AddOrUpdateProtectedItem(vaultRgName, vaultName, fabricName, containerUri, itemUri, input);
        }
    }
}
