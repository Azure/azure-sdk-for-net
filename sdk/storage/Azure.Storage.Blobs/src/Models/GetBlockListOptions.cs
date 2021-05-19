// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class GetBlockListOptions : IRequestConditions.ITags, IRequestConditions.ILeaseId
    {
        ///<inheritdoc/>
        public string TagConditions { get; set; }

        ///<inheritdoc/>
        public string LeaseId { get; set; }

        /// <summary>
        /// Specifies whether to return the list of committed blocks, the
        /// list of uncommitted blocks, or both lists together.  If you omit
        /// this parameter, Get Block List returns the list of committed blocks.
        /// </summary>
        public BlockListTypes BlockListTypes { get; set; } = BlockListTypes.All;

        /// <summary>
        /// Optionally specifies the blob snapshot to retrieve the block list
        /// from. For more information on working with blob snapshots, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        public string Snapshot { get; set; }
    }
}
