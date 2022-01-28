// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndexerCache
    {
        /// <summary> The connection string to the storage account where the cache data will be persisted. </summary>
        private string StorageConnectionString { get; set; }

        /// <summary>
        /// Sets the <see cref="StorageConnectionString"/> for the Search indexer cache.
        /// </summary>
        /// <param name="storageConnectionString"> The storage connection string. </param>
        public void SetStorageConnectionString(string storageConnectionString)
        {
            StorageConnectionString = storageConnectionString;
        }
    }
}
