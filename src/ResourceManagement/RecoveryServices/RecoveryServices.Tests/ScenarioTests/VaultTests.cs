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
    public class VaultTests : RecoveryServicesTestsBase
    {
        string resourceGroupName = "testsitegroup";
        string resourceName = "rsv5";

        [Fact]
        public void CreateVault()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);
                VaultCreateArgs vaultCreateArgs= new VaultCreateArgs();
                vaultCreateArgs.Location = "westus";
                vaultCreateArgs.Properties = new VaultProperties();
                vaultCreateArgs.Sku = new VaultSku();
                vaultCreateArgs.Sku.Name = "standard";
                VaultCreateResponse response = rsmClient.Vaults.BeginCreating(resourceGroupName, resourceName, vaultCreateArgs);

                Assert.NotNull(response.Name);
                Assert.NotNull(response.Id);
                Assert.NotNull(response.Properties.ProvisioningState);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            }
        }

        [Fact]
        public void RetrieveVault()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);
                VaultListResponse response = rsmClient.Vaults.Get(resourceGroupName, RequestHeaders);

                Assert.NotNull(response.Vaults[0].Name);
                Assert.NotNull(response.Vaults[0].Id);
                Assert.NotNull(response.Vaults[0].Properties.ProvisioningState);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void RemoveVault()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);
                RecoveryServicesOperationStatusResponse response = rsmClient.Vaults.BeginDeleting(resourceGroupName, resourceName);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void CreateAndRetrieveVaultExtendedInfo()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var rsmClient = GetRecoveryServicesClient(CustomHttpHandler);
                ResourceExtendedInformation extendedInformation =
                    new ResourceExtendedInformation();
                extendedInformation.Properties = new ResourceExtendedInfoProperties();
                extendedInformation.Properties.IntegrityKey = "integrity key";
                extendedInformation.Properties.Algorithm = "none";

                ResourceExtendedInformationArgs extendedInfoArgs = new ResourceExtendedInformationArgs();
                extendedInfoArgs.Properties = new ResourceExtendedInfoProperties();
                extendedInfoArgs.Properties.Algorithm = extendedInformation.Properties.Algorithm;
                extendedInfoArgs.Properties.IntegrityKey = extendedInformation.Properties.IntegrityKey;

                AzureOperationResponse response = rsmClient.VaultExtendedInfo.CreateExtendedInfo(resourceGroupName, resourceName, extendedInfoArgs, RequestHeaders);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                ResourceExtendedInformationResponse extendedInfoResponse = rsmClient.VaultExtendedInfo.GetExtendedInfo(resourceGroupName, resourceName, RequestHeaders);
                Assert.NotNull(extendedInfoResponse.ResourceExtendedInformation.Properties.IntegrityKey);
                Assert.Equal(HttpStatusCode.OK, extendedInfoResponse.StatusCode);
            }
        }
    }
}
