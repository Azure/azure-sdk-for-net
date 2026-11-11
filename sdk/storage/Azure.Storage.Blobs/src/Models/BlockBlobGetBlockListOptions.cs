// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for BlockBlobClient.GetBlockList.
    /// </summary>
    public class BlockBlobGetBlockListOptions
    {
        /// <summary>
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </summary>
        public BlockListTypes BlockListTypes { get; set; }

        /// <summary>
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on retrieving the block list.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
