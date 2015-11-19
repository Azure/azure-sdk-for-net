// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Response containing the status of operations for all documents in the
    /// indexing request.
    /// </summary>
    public class DocumentIndexResult
    {
        /// <summary>
        /// Initializes a new instance of the DocumentIndexResult class.
        /// </summary>
        public DocumentIndexResult() { }

        /// <summary>
        /// Initializes a new instance of the DocumentIndexResult class.
        /// </summary>
        public DocumentIndexResult(IList<IndexingResult> results = default(IList<IndexingResult>))
        {
            Results = results;
        }

        /// <summary>
        /// Gets the list of status information for each document in the
        /// indexing request.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<IndexingResult> Results { get; private set; }

    }
}
