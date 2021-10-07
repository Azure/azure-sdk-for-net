// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The quick query format type.
    /// </summary>
    internal enum QueryFormatType
    {
        /// <summary>
        /// delimited.
        /// </summary>
        Delimited,

        /// <summary>
        /// json.
        /// </summary>
        Json,

        /// <summary>
        /// arrow.
        /// </summary>
        Arrow,

        /// <summary>
        /// parquet.
        /// </summary>
        Parquet
    }
}
