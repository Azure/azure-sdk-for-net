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
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;


namespace RecoveryServices.Tests
{
    public class BackupStorageConfigTests : RecoveryServicesTestsBase
    {
        string resourceGroupName = "vishakintdrg";
        string resourceName = "vishakrsvault";

        [Fact]
        public void GetBackupStorageConfig()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);

                GetResourceStorageConfigResponse response = rsmClient.Vaults.GetResourceStorageConfig(resourceGroupName, resourceName, RequestHeaders);

                Assert.NotNull(response.Id);
                Assert.NotNull(response.Name);
                Assert.NotNull(response.Type);
                Assert.NotNull(response.Properties.StorageType);
                Assert.NotNull(response.Properties.StorageTypeState);
                //Assert.NotNull(response.Properties.DedupState);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void SetBackupStorageConfig()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);

                UpdateVaultStorageTypeRequest vaultStorageRequest = new UpdateVaultStorageTypeRequest();
                vaultStorageRequest.Properties = new StorageTypeProperties();
                vaultStorageRequest.Properties.StorageModelType = "LocallyRedundant";
                vaultStorageRequest.Properties.DedupState = "enabled";

                AzureOperationResponse response = rsmClient.Vaults.UpdateStorageType(resourceGroupName, resourceName, 
                                                    vaultStorageRequest, RequestHeaders);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
