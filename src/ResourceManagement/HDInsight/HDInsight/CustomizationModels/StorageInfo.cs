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
                throw new ArgumentException("Input cannot be empty", "storageAccountName");
            }

            if (storageAccountName.Contains("://"))
            {
                throw new ArgumentException("Please specify fully qualified storage endpoint without the scheme", "storageAccountName");
            }

            this.StorageAccountName = storageAccountName;
        }
    }
}