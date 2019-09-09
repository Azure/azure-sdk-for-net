// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
