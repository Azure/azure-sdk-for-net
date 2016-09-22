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

using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public class RecoveryServicesTestBase : TestBase, IDisposable
    {
        private const string resourceGroup = "RecoveryServicesTestRg";
        private const string location = "westus";

        public RecoveryServicesClient VaultClient { get; private set; }

        public RecoveryServicesTestBase(MockContext context)
        {
            VaultClient = this.GetManagementClient(context);
            ResourceManagementClient resourcesClient = this.GetResourcesClient(context);

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroup,
                new ResourceGroup
                {
                    Location = location
                });

            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != HttpStatusCode.Conflict) throw;
            }
        }

        public VaultList ListVaults()
        {
            return VaultClient.Vaults.ListByResourceGroup(resourceGroup);
        }

        public void DeleteVault(string vaultName)
        {
            VaultClient.Vaults.Delete(resourceGroup, vaultName);
        }

        public Vault GetVault(string vaultName)
        {
            return VaultClient.Vaults.Get(resourceGroup, vaultName);
        }

        public void CreateVault(string vaultName)
        {
            VaultCreationArgs vaultCreationArgs = new VaultCreationArgs();
            vaultCreationArgs.Location = location;
            vaultCreationArgs.Properties = new VaultProperties();
            vaultCreationArgs.Sku = new Sku();
            vaultCreationArgs.Sku.Name = "standard";
            VaultClient.Vaults.Create(resourceGroup, vaultName, vaultCreationArgs);
        }

        public void DisposeVaults()
        {
            var vaults = VaultClient.Vaults.ListByResourceGroup(resourceGroup);
            foreach (var vault in vaults.Value)
            {
                VaultClient.Vaults.Delete(resourceGroup, vault.Name);
            }
        }

        public void Dispose()
        {
            DisposeVaults();
            VaultClient.Dispose();
        }
    }
}
