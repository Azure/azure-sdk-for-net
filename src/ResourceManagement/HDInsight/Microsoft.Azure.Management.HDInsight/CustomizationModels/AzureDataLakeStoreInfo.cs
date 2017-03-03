using System;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// Gets or sets the StorageAccountName for Azure Data Lake Storage Account.
    /// </summary>
    public class AzureDataLakeStoreInfo : StorageInfo
    {
        private static string _defaultDataLakeStorageSuffix = ".azuredatalakestore.net";

        /// <summary>
        /// Gets or Sets the absolute path of the root of the cluster. Eg: "/Clusters/mycluster"
        /// </summary>
        public string StorageRootPath { get; private set; }

        /// <summary>
        /// Initializes a new instance of the AzureDataLakeStoreInfo class.
        /// </summary>
        /// <param name="storageAccountName">Fully Qualified StorageAccountName for the Azure Data Lake Storage Account.</param>
        /// <param name="storageRootPath">The absolute path of the root of the cluster. Eg: "/Clusters/mycluster" </param>
        public AzureDataLakeStoreInfo(string storageAccountName, string storageRootPath)
            : base(storageAccountName)
        {
            if(string.IsNullOrWhiteSpace(storageRootPath))
            {
                throw new ArgumentException(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageRootPath");
            }

            if (!storageAccountName.Contains("."))
            {
                this.StorageAccountName = storageAccountName + _defaultDataLakeStorageSuffix;
            }

            this.StorageRootPath = storageRootPath;
        }
    }
}
