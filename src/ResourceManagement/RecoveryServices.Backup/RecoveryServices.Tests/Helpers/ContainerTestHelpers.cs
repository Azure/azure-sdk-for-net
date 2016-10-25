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
using Microsoft.Azure.Test.HttpRecorder;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class ContainerTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ContainerTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public ProtectionContainerListResponse ListContainers(string rsVaultRgName, string rsVaultName, ProtectionContainerListQueryParams queryParams)
        {
            ProtectionContainerListResponse response = Client.Containers.List(rsVaultRgName, rsVaultName, queryParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }

        public BaseRecoveryServicesJobResponse RefreshContainer(string rsVaultRgName, string rsVaultName, string fabricName)
        {
            BaseRecoveryServicesJobResponse response = Client.Containers.BeginRefresh(rsVaultRgName, rsVaultName, CommonTestHelper.GetCustomRequestHeaders(), fabricName);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            while (response.StatusCode == HttpStatusCode.Accepted)
            {
                response = Client.Containers.GetRefreshOperationResultByURL(response.Location);
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                }
            }

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;
        }

        public AzureOperationResponse UnregisterContainer(string containerName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            AzureOperationResponse response = Client.Containers.Unregister(rsVaultRgName, rsVaultName, containerName, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;

        }

        public ProtectionContainerListResponse ListMABContainers(ProtectionContainerListQueryParams queryParams)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            ProtectionContainerListResponse response = Client.Containers.List(rsVaultRgName, rsVaultName, queryParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }

        public AzureOperationResponse UnregisterMABContainer(string containerName)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            AzureOperationResponse response = Client.Containers.Unregister(rsVaultRgName, rsVaultName, containerName, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            return response;

        }

    }
}
