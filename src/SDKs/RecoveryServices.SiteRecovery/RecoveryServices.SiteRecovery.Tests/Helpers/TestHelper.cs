// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Tests
{
    public class TestHelper: IDisposable
    {
        private const string resourceNamespace = "Microsoft.RecoveryServices";
        private const string resourceGroupName = "siterecoveryprod1";
        private const string vaultName = "SDKVault";
        private const string location = "westus";

        public RecoveryServicesClient VaultClient { get; private set; }

        public SiteRecoveryManagementClient SiteRecoveryClient { get; private set; }

        public void Initialize(MockContext context)
        {
            VaultClient = this.GetVaultClient(context);

            this.SiteRecoveryClient = this.GetSiteRecoveryClient(context);
            this.SiteRecoveryClient.ResourceGroupName = resourceGroupName;
            this.SiteRecoveryClient.ResourceName = vaultName;
        }

        public void CreateResourceGroup(MockContext context)
        {
            ResourceManagementClient resourcesClient = this.GetResourcesClient(context);

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });

                var response = resourcesClient.ResourceGroups.Get(resourceGroupName);
                Assert.True(response.Name == resourceGroupName, "Resource groups cannot be different");
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        public void CreateVault(MockContext context)
        {
            Vault vault = new Vault()
            {
                Location = location,
                Sku = new Sku()
                {
                    Name = SkuName.Standard
                },
                Properties = new VaultProperties()
            };

            try
            {
                VaultClient.Vaults.CreateOrUpdate(resourceGroupName, vaultName, vault);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        public void DisposeVaults()
        {
            var vaults = VaultClient.Vaults.ListByResourceGroup(resourceGroupName);
            foreach (var vault in vaults)
            {
                VaultClient.Vaults.Delete(resourceGroupName, vault.Name);
            }
        }

        public void Dispose()
        {
            SiteRecoveryClient.Dispose();
            VaultClient.Dispose();
        }
    }
}