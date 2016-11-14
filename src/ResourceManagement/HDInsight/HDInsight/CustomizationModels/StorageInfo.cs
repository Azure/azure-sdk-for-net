using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// Contains cluster storage information.
    /// </summary>
    public abstract class StorageInfo
    {
        /// <summary>
        /// Fully-qualified storage account name
        /// </summary>
        public string StorageAccountName { get; protected set; }

        public StorageInfo(string storageAccountName)
        {
            if (string.IsNullOrWhiteSpace(storageAccountName))
            {
                throw new ArgumentException(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageAccountName");
            }

            if (storageAccountName.Contains("://"))
            {
                throw new ArgumentException(Constants.ERROR_SCHEME_SPECIFIED_IN_STORAGE_FQDN, "storageAccountName");
            }

            this.StorageAccountName = storageAccountName;
        }
    }
}