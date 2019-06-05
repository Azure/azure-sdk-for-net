namespace Microsoft.Azure.Management.HDInsight.Models
{
    using System;

    /// <summary>
    /// Gets or sets the StorageAccountName, StorageAccountKey and StorageFileSystem for the Azure Data Lake Storage Gen 2 account.
    /// </summary>
    public class AzureDataLakeStoreGen2Info : StorageInfo
    {
        private static string _defaultAzureStorageSuffix = ".dfs.core.windows.net";

        /// <summary>
        /// Gets the Azure Data Lake Storage Gen 2 file system.
        /// </summary>
        public string StorageFileSystem { get; set; }

        /// <summary>
        /// Gets the Azure Data Lake Storage Gen 2 account key.
        /// </summary>
        [Obsolete("This property is obsolete. Please use resource id and MSI resource instead.")]
        public string StorageAccountKey { get; set; }

        /// <summary>
        /// Gets the resource ID of the Azure Data Lake Storage Gen 2.
        /// </summary>
        public string StorageResourceId { get; set; }

        /// <summary>
        /// Gets the managed identity (MSI) that is allowed to access
        /// the Azure Data Lake Storage Gen 2.
        /// </summary>
        public string StorageMsiResourceId { get; set; }

        /// <summary>
        /// Initializes a new instance of the AzureStorageInfo class.
        /// </summary>
        /// <param name="storageAccountName">Fully Qualified StorageAccountName for the Azure Data Lake Storage Gen 2 Account.</param>
        /// <param name="storageFileSystem">File system for the Azure Data Lake Storage Gen 2 account. The cluster will leverage to store some cluster-level files.</param>
        /// <param name="storageResourceId">The resource ID of the Azure Data Lake Storage Gen 2.</param>
        /// <param name="storageMsiResourceId">The managed identity (MSI) that is allowed to access the Azure Data Lake Storage Gen 2.</param>
        public AzureDataLakeStoreGen2Info(string storageAccountName, string storageFileSystem, string storageResourceId, string storageMsiResourceId)
            : base(storageAccountName)
        {
            this.StorageFileSystem = storageFileSystem;
            this.StorageResourceId = storageResourceId;
            this.StorageMsiResourceId = storageMsiResourceId;
        }

        /// <summary>
        /// Initializes a new instance of the AzureStorageInfo class.
        /// </summary>
        /// <param name="storageAccountName">Fully Qualified StorageAccountName for the Azure Data Lake Storage Gen 2 Account.</param>
        /// <param name="storageAccountKey">StorageKey for the Azure Data Lake Storage Gen 2 Account.</param>
        /// <param name="storageFileSystem">File system for the Azure Data Lake Storage Gen 2 account. The cluster will leverage to store some cluster-level files.</param>
        public AzureDataLakeStoreGen2Info(string storageAccountName, string storageAccountKey, string storageFileSystem)
            : base(storageAccountName)
        {
            if (string.IsNullOrWhiteSpace(storageAccountKey))
            {
                throw new ArgumentException(Constants.Errors.ERROR_INPUT_CANNOT_BE_EMPTY, "storageAccountKey");
            }

            if (!storageAccountName.Contains("."))
            {
                this.StorageAccountName = storageAccountName + _defaultAzureStorageSuffix;
            }

            this.StorageAccountKey = storageAccountKey;
            this.StorageFileSystem = storageFileSystem;
        }
    }
}
