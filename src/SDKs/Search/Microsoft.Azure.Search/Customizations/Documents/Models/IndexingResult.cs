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
    /// Status of an indexing operation for a single document.
    /// </summary>
    public class IndexingResult
    {
        /// <summary>
        /// Initializes a new instance of the IndexingResult class.
        /// </summary>
        public IndexingResult() { }

        /// <summary>
        /// Initializes a new instance of the IndexingResult class.
        /// </summary>
        public IndexingResult(string key = default(string), string errorMessage = default(string), bool succeeded = default(bool), int statusCode = default(int))
        {
            Key = key;
            ErrorMessage = errorMessage;
            Succeeded = succeeded;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets the key of a document that was in the indexing request.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; private set; }

        /// <summary>
        /// Gets the error message explaining why the indexing operation failed for the document identified by the key; null if indexing succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the indexing operation succeeded for the document identified by the key.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Gets the status code of the indexing operation. Possible values include: 200 for a successful update or delete, 201 for successful document creation, 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy.
        /// </summary>
        [JsonProperty(PropertyName = "statusCode")]
        public int StatusCode { get; private set; }
    }
}
