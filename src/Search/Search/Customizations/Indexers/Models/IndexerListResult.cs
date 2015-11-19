// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response from a List Indexers request. If successful, it includes the
    /// full definitions of all indexers.
    /// </summary>
    public class IndexerListResult
    {
        /// <summary>
        /// Initializes a new instance of the IndexerListResult class.
        /// </summary>
        public IndexerListResult() { }

        /// <summary>
        /// Initializes a new instance of the IndexerListResult class.
        /// </summary>
        public IndexerListResult(IList<Indexer> indexers = default(IList<Indexer>))
        {
            Indexers = indexers;
        }

        /// <summary>
        /// Gets the indexers in the Search service.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Indexer> Indexers { get; private set; }

    }
}
