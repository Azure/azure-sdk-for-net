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
