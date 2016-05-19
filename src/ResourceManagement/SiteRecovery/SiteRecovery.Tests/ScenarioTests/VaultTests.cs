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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecoveryVault.Models;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Test;
using System.Net;
using System.Linq;
using Xunit;
using System;
using Microsoft.Azure;


namespace SiteRecovery.Tests
{
    public class VaultTests : SiteRecoveryTestsBase
    {
        string resourceGroupName = "RecoveryServices-WHNOWF6LI6NM4B55QDIYR3YG3YAEZNTDUOWHPQX7NJB2LHDGTXJA-West-US";
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
                vaultCreateArgs.Properties.Sku = new VaultSku();
                vaultCreateArgs.Properties.Sku.Name = "standard";
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

                ResourceExtendedInformationArgs args =
                    new ResourceExtendedInformationArgs("1.0", "extendedinfo", Guid.NewGuid().ToString());

                AzureOperationResponse response = rsmClient.VaultExtendedInfo.CreateExtendedInfo(resourceGroupName, resourceName, args, RequestHeaders);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                ResourceExtendedInformationResponse extendedInfoResponse = rsmClient.VaultExtendedInfo.GetExtendedInfo(resourceGroupName, resourceName, RequestHeaders);
                Assert.NotNull(extendedInfoResponse.ResourceExtendedInformation.ExtendedInfo);
                Assert.Equal(HttpStatusCode.OK, extendedInfoResponse.StatusCode);
            }
        }
    }
}
