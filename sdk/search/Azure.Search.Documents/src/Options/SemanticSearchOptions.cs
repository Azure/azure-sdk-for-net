// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Collections.Generic;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Options for performing Semantic Search.
    /// </summary>
    public partial class SemanticSearchOptions
    {
        /// <summary> The name of a semantic configuration that will be used when processing documents for queries of type semantic. </summary>
        public string SemanticConfigurationName { get; set; }

        /// <summary>
        /// This parameter is only valid if the query type is 'semantic'. If set, the query returns answers extracted from key passages in the highest
        /// ranked documents.The number of answers returned can be configured by appending the pipe character '|' followed by the 'count-(number of answers)'
        /// option after the answers parameter value, such as 'extractive|count-3'. Default count is 1. The confidence threshold can be configured by appending
        /// the pipe character '|' followed by the 'threshold-(confidence threshold)' option after the answers parameter value, such as 'extractive|threshold-0.9'.
        /// Default threshold is 0.7.
        /// </summary>
        public QueryAnswer QueryAnswer { get; set; }

        /// <summary>
        /// This parameter is only valid if the query type is 'semantic'. If set, the query returns captions extracted from key passages in the highest
        /// ranked documents. When Captions is set to 'extractive', highlighting is enabled by default, and can be configured by appending the pipe
        /// character '|' followed by the 'highlight-(true/false)' option, such as 'extractive|highlight-true'. Defaults to 'None'.
        /// </summary>
        public QueryCaption QueryCaption { get; set; }

        /// <summary> Allows setting a separate search query that will be solely used for semantic reranking, semantic captions and semantic answers. Is useful for scenarios where there is a need to use different queries between the base retrieval and ranking phase, and the L2 semantic phase. </summary>
        public string SemanticQuery { get; set; }

        /// <summary> Allows the user to choose whether a semantic call should fail completely (default / current behavior), or to return partial results. </summary>
        public SemanticErrorMode? ErrorMode { get; set; }

        /// <summary> Allows the user to set an upper bound on the amount of time it takes for semantic enrichment to finish processing before the request fails. </summary>
        public TimeSpan? MaxWait { get; set; }
    }
}
