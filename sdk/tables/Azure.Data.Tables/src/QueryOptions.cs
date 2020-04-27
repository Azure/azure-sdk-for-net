// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Models
{
    ///<inheritdoc/>
    internal partial class QueryOptions
    {
        /// <summary> The continuation token for a Tables request. </summary>
        public string NextTableName { get; set; }
        /// <summary> The partition key continuation token for an Entity request. </summary>
        public string NextPartitionKey { get; set; }
        /// <summary> The row key continuation token for an Entity request. </summary>
        public string NextRowKey { get; set; }
    }
}
