// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("SearchIndexerKnowledgeStore")]
    public partial class KnowledgeStore
    {
        /// <summary> The connection string to the storage account projections will be stored in. </summary>
        private string StorageConnectionString { get; set; }

        /// <summary>
        /// Sets the <see cref="StorageConnectionString"/> for the storage account projections.
        /// </summary>
        /// <param name="storageConnectionString"> The storage connection string. </param>
        public void SetStorageConnectionString(string storageConnectionString)
        {
            StorageConnectionString = storageConnectionString;
        }
    }
}
