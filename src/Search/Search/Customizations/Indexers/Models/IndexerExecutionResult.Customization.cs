// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public partial class IndexerExecutionResult
    {
        /// <summary>
        /// Gets the number of items that failed to be indexed during
        /// this indexer execution.
        /// </summary>
        public int FailedItemCount
        {
            get { return this.ItemsFailed.GetValueOrDefault(); }
        }

        /// <summary>
        /// Gets the number of items that were processed during this
        /// indexer execution. This includes both successfully processed items
        /// and items where indexing was attempted but failed.
        /// </summary>
        public int ItemCount
        {
            get { return this.ItemsProcessed.GetValueOrDefault(); }
        }
    }
}
