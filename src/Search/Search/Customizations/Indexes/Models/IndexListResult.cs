// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response from a List Indexes request. If successful, it includes the
    /// full definitions of all indexes.
    /// </summary>
    public class IndexListResult
    {
        /// <summary>
        /// Initializes a new instance of the IndexListResult class.
        /// </summary>
        public IndexListResult() { }

        /// <summary>
        /// Initializes a new instance of the IndexListResult class.
        /// </summary>
        public IndexListResult(IList<Index> indexes = default(IList<Index>))
        {
            Indexes = indexes;
        }

        /// <summary>
        /// Gets the indexes in the Search service.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Index> Indexes { get; private set; }

    }
}
