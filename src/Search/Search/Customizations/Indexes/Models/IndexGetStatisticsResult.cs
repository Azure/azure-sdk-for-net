// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Statistics for a given index. Statistics are collected periodically
    /// and are not guaranteed to always be up-to-date.
    /// </summary>
    public class IndexGetStatisticsResult
    {
        /// <summary>
        /// Initializes a new instance of the IndexGetStatisticsResult class.
        /// </summary>
        public IndexGetStatisticsResult() { }

        /// <summary>
        /// Initializes a new instance of the IndexGetStatisticsResult class.
        /// </summary>
        public IndexGetStatisticsResult(long documentCount = default(long), long storageSize = default(long))
        {
            DocumentCount = documentCount;
            StorageSize = storageSize;
        }

        /// <summary>
        /// Gets the number of documents in the index.
        /// </summary>
        [JsonProperty(PropertyName = "documentCount")]
        public long DocumentCount { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

        /// <summary>
        /// Gets the amount of storage in bytes consumed by the index.
        /// </summary>
        [JsonProperty(PropertyName = "storageSize")]
        public long StorageSize { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

    }
}
