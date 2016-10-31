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

using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Models;
using RecoveryServices.Tests;
using System;
using System.Net;
using Xunit;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class VaultTestHelpers
    {
        public readonly RecordedDelegatingHandler RsCustomHttpHandler
            = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

        public static Microsoft.Azure.Management.RecoveryServices.Models.CustomRequestHeaders RsCustomRequestHeaders =
            new Microsoft.Azure.Management.RecoveryServices.Models.CustomRequestHeaders()
            {
                ClientRequestId = CommonTestHelper.GetCustomRequestHeaders().ClientRequestId,
            };
        
        RecoveryServicesBackupManagementClient Client { get; set; }

        public VaultTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public void CreateVault(string resourceGroupName, string resourceName, string location)
        {
            RecoveryServicesTestsBase testsBase = new RecoveryServicesTestsBase();
            var rsClient = testsBase.GetRecoveryServicesClient(RsCustomHttpHandler);

            if (!IsVaultPresent(resourceGroupName, resourceName))
            {
                VaultCreateArgs vaultCreateArgs = new VaultCreateArgs();
                vaultCreateArgs.Location = location;
                vaultCreateArgs.Properties = new VaultProperties();
                vaultCreateArgs.Sku = new VaultSku();
                vaultCreateArgs.Sku.Name = "standard";
                VaultCreateResponse response = rsClient.Vaults.BeginCreating(resourceGroupName, resourceName, vaultCreateArgs);

                Assert.NotNull(response.Name);
                Assert.NotNull(response.Id);
                Assert.NotNull(response.Properties.ProvisioningState);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            }
        }

        public bool IsVaultPresent(string resourceGroupName, string resourceName)
        {
            RecoveryServicesTestsBase testsBase = new RecoveryServicesTestsBase();
            var rsClient = testsBase.GetRecoveryServicesClient(RsCustomHttpHandler);

            bool vaultExists = true;

            try
            {
                VaultResponse response = rsClient.Vaults.Get(resourceGroupName, resourceName, RsCustomRequestHeaders);

                Assert.NotNull(response.Vault.Name);
                Assert.NotNull(response.Vault.Id);
                Assert.NotNull(response.Vault.Properties.ProvisioningState);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception)
            {
                vaultExists = false;
            }

            return vaultExists;
        }
    }
}
