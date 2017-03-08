// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
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

        public List<Vault> ListVaults()
        {
            var vaults = new List<Vault>();
            string nextLink = null;

            var pagedVaults = VaultClient.Vaults.ListByResourceGroup(resourceGroup);

            foreach (var pagedVault in pagedVaults)
            {
                vaults.Add(pagedVault);
            }

            while (!string.IsNullOrEmpty(nextLink))
            {
                nextLink = pagedVaults.NextPageLink;

                foreach (var pagedVault in VaultClient.Vaults.ListByResourceGroupNext(nextLink))
                {
                    vaults.Add(pagedVault);
                }
            }

            return vaults;
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
                Properties = new VaultProperties(),
            };
            VaultClient.Vaults.CreateOrUpdate(resourceGroup, vaultName, vault);
        }

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
