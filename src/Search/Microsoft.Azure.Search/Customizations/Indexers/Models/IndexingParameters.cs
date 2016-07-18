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
    /// Represents parameters for indexer execution.
    /// </summary>
    public partial class IndexingParameters
    {
        /// <summary>
        /// Initializes a new instance of the IndexingParameters class.
        /// </summary>
        public IndexingParameters() { }

        /// <summary>
        /// Initializes a new instance of the IndexingParameters class.
        /// </summary>
        public IndexingParameters(int? batchSize = default(int?), int? maxFailedItems = default(int?), int? maxFailedItemsPerBatch = default(int?), IDictionary<string, object> configuration = default(IDictionary<string, object>))
        {
            BatchSize = batchSize;
            MaxFailedItems = maxFailedItems;
            MaxFailedItemsPerBatch = maxFailedItemsPerBatch;
            Configuration = configuration;
        }

        /// <summary>
        /// Gets or sets the number of items that are read from the data
        /// source and indexed as a single batch in order to improve
        /// performance. The default depends on the data source type.
        /// </summary>
        [JsonProperty(PropertyName = "batchSize")]
        public int? BatchSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items that can fail indexing
        /// for indexer execution to still be considered successful. -1 means
        /// no limit. Default is 0.
        /// </summary>
        [JsonProperty(PropertyName = "maxFailedItems")]
        public int? MaxFailedItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in a single batch that
        /// can fail indexing for the batch to still be considered
        /// successful. -1 means no limit. Default is 0.
        /// </summary>
        [JsonProperty(PropertyName = "maxFailedItemsPerBatch")]
        public int? MaxFailedItemsPerBatch { get; set; }

        /// <summary>
        /// Gets or sets whether indexer will base64-encode all values that
        /// are inserted into key field of the target index. This is needed
        /// if keys can contain characters that are invalid in keys (such as
        /// dot '.'). Default is false.
        /// </summary>
        [Obsolete("This property is obsolete. Please create a field mapping with the 'base64Encode' function instead: https://azure.microsoft.com/en-us/documentation/articles/search-indexer-field-mappings/#base64EncodeFunction")]
        [JsonProperty(PropertyName = "base64EncodeKeys")]
        public bool? Base64EncodeKeys { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of indexer-specific configuration
        /// properties. Each name is the name of a specific property. Each
        /// value must be of a primitive type.
        /// </summary>
        [JsonProperty(PropertyName = "configuration")]
        public IDictionary<string, object> Configuration { get; set; }

    }
}
