// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Status of an indexing operation for a single document. 
    /// </summary>
    public partial class IndexingResult
    {
        /// <summary>
        /// Gets a value indicating whether the indexing operation succeeded for the document identified by 
        /// <c cref="Microsoft.Azure.Search.Models.IndexingResult.Key">Key</c>.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Succeeded { get; set; }
    }
}
