﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.FileStaging
{
    /// <summary>
    /// Holds storage account information.
    /// </summary>
    public class StagingStorageAccount
    {
        /// <summary>
        /// Specifies the storage account to be used.
        /// </summary>
        public string StorageAccount
        {
            get;
            internal set;
        }

        /// <summary>
        /// Specifies the storage account key to be used.
        /// </summary>
        public string StorageAccountKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// The serviced endpoint for blob storage.
        /// </summary>
        public string BlobEndpoint
        {
            get;
            internal set;
        }

        // Constructed here to give immediate validation/failure experience.
        internal Uri BlobUri 
        { 
            get;
            set;
        }

        private StagingStorageAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StagingStorageAccount class using the specified credentials and service endpoint.
        /// </summary>
        /// <param name="storageAccount">A string specifying the storage account to be used.</param>
        /// <param name="storageAccountKey">A string specifying the storage account key to be used.</param>
        /// <param name="blobEndpoint">A string specifying the primary Blob service endpoint.</param>
        public StagingStorageAccount(string storageAccount, string storageAccountKey, string blobEndpoint)
        {
            this.StorageAccount = storageAccount;
            this.StorageAccountKey =  storageAccountKey;

            if (string.IsNullOrWhiteSpace(this.StorageAccount))
            {
                throw new ArgumentOutOfRangeException("storageAccount");
            }

            if (string.IsNullOrWhiteSpace(this.StorageAccountKey))
            {
                throw new ArgumentOutOfRangeException("storageAccountKey");
            }

            if (string.IsNullOrWhiteSpace(blobEndpoint))
            {
                throw new ArgumentOutOfRangeException("blobEndpoint");
            }

            // Constructed here to give immediate validation/failure experience.
            this.BlobUri = new Uri(blobEndpoint); 
        }
    }
}
