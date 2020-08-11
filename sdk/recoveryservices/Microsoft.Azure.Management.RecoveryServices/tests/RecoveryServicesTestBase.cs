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
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public class RecoveryServicesTestBase : TestBase, IDisposable
    {
        private string resourceGroup = "SDKTestRg";
        private const string location = "westus";

        public RecoveryServicesClient VaultClient { get; private set; }

        public RecoveryServicesTestBase(MockContext context)
        {
            VaultClient = this.GetManagementClient(context);
            ResourceManagementClient resourcesClient = this.GetResourcesClient(context);

            CreateResourceGroup(resourcesClient);
        }

        private void CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            bool resourceGroupExists = true;
            try
            {
                resourcesClient.ResourceGroups.Get(resourceGroup);
            }
            catch (CloudException)
            {
                // Doesn't exist
                resourceGroupExists = false;
            }

            if (!resourceGroupExists)
            {
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
        }

        #region Vault
        public List<Vault> ListVaults()
        {
            return VaultClient.Vaults.ListByResourceGroup(resourceGroup).ToList();
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
            Vault vault = new Vault()
            {
                Location = location,
                Sku = new Sku()
                {
                    Name = SkuName.Standard,
                },
                Properties = new VaultProperties()
            };
            VaultClient.Vaults.CreateOrUpdate(resourceGroup, vaultName, vault);
        }
        #endregion

        #region Vault Extended Info
        public VaultExtendedInfoResource CreateVaultExtendedInfo(Vault vault)
        {
            VaultExtendedInfoResource extInfo = new VaultExtendedInfoResource()
            {
                Algorithm = "None",
                IntegrityKey = TestUtilities.GenerateRandomKey(128)
            };

            return VaultClient.VaultExtendedInfo.CreateOrUpdate(resourceGroup, vault.Name, extInfo);
        }

        public VaultExtendedInfoResource UpdateVaultExtendedInfo(Vault vault)
        {
            VaultExtendedInfoResource extInfo = new VaultExtendedInfoResource()
            {
                Algorithm = "None",
                IntegrityKey = TestUtilities.GenerateRandomKey(128)
            };

            return VaultClient.VaultExtendedInfo.CreateOrUpdate(resourceGroup, vault.Name, extInfo);
        }

        public VaultExtendedInfoResource GetVaultExtendedInfo(Vault vault)
        {
            return VaultClient.VaultExtendedInfo.Get(resourceGroup, vault.Name);
        }
        #endregion

        #region VaultUsages

        /// <summary>
        /// List vault usages.
        /// </summary>
        /// <returns>List of vault usages.</returns>
        public List<VaultUsage> ListVaultUsages(string vaultName)
        {
            return VaultClient.Usages.ListByVaults(resourceGroup, vaultName).ToList();
        }

        public List<ReplicationUsage> ListReplicationUsages(string vaultName)
        {
            return VaultClient.ReplicationUsages.List(resourceGroup, vaultName).ToList();
        }

        #endregion VaultUsages

        public void DisposeVaults()
        {
            var vaults = VaultClient.Vaults.ListByResourceGroup(resourceGroup);
            foreach (var vault in vaults)
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
