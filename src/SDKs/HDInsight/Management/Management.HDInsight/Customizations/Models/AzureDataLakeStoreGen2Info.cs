namespace Microsoft.Azure.Management.HDInsight.Models
{
    using System;

    /// <summary>
    /// Gets or sets the StorageAccountName, StorageAccountKey and StorageFileSystem for the Azure Data Lake Storage Gen 2 account.
    /// </summary>
    public class AzureDataLakeStoreGen2Info : StorageInfo
    {
        private readonly string _storageFileSystem;
        private readonly string _storageAccountKey;
        private static string _defaultAzureStorageSuffix = ".dfs.core.windows.net";

        /// <summary>
        /// Gets the Azure Data Lake Storage Gen 2 file system.
        /// </summary>
        public string StorageFileSystem
        {
            get { return _storageFileSystem; }
        }

        /// <summary>
        /// Gets the Azure Data Lake Storage Gen 2 account key.
        /// </summary>
        public string StorageAccountKey
        {
            get { return _storageAccountKey; }
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

            this._storageAccountKey = storageAccountKey;
            this._storageFileSystem = storageFileSystem;
        }
    }
}
