namespace Microsoft.Azure.Management.StorageCache.Tests.Helpers
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;

    /// <summary>
    /// Storage account helper.
    /// </summary>
    public class StorageAccountsHelper
    {
        private static readonly string DefaultSkuName = SkuName.StandardGRS;
        private static readonly string DefaultKind = Kind.Storage;

        /// <summary>
        /// Storage management client.
        /// </summary>
        public StorageManagementClient storageManagementClient;

        /// <summary>
        /// Target resource group.
        /// </summary>
        private readonly ResourceGroup resourceGroup;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccountsHelper"/> class.
        /// </summary>
        /// <param name="client">Storage management client.</param>
        /// <param name="resourceGroup">Resource group.</param>
        public StorageAccountsHelper(StorageManagementClient client, ResourceGroup resourceGroup)
        {
            this.storageManagementClient = client;
            this.resourceGroup = resourceGroup;
        }

        /// <summary>
        /// Creates storage account.
        /// </summary>
        /// <param name="storageAccountName">Storage account to be created.</param>
        /// <param name="skuName">Storage SKU.</param>
        /// <param name="storageKind">Storage kind.</param>
        /// <returns>Stoprage account.</returns>
        public StorageAccount CreateStorageAccount(string storageAccountName, string skuName = null, string storageKind = null)
        {
            var sku = string.IsNullOrEmpty(skuName) ? DefaultSkuName : skuName;
            var kind = string.IsNullOrEmpty(storageKind) ? DefaultKind : storageKind;

            StorageAccountCreateParameters storageAccountCreateParameters = new StorageAccountCreateParameters
            {
                Location = this.resourceGroup.Location,

                // Tags = DefaultTags,
                Sku = new Sku() { Name = sku },
                Kind = kind,
            };
            StorageAccount storageAccount = this.storageManagementClient.StorageAccounts.Create(this.resourceGroup.Name, storageAccountName, storageAccountCreateParameters);
            return storageAccount;
        }

        /// <summary>
        /// Create Blob container.
        /// </summary>
        /// <param name="storageAccountName">Storage account where container is to be created.</param>
        /// <param name="containerName">Container name.</param>
        /// <returns>Blob container.</returns>
        public BlobContainer CreateBlobContainer(string storageAccountName, string containerName)
        {
            BlobContainer blobContainer = this.storageManagementClient.BlobContainers.Create(this.resourceGroup.Name, storageAccountName, containerName, publicAccess: PublicAccess.Blob);
            return blobContainer;
        }
    }
}
