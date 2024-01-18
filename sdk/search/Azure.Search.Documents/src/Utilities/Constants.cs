// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Constants used by the Search client library.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// Gets "*" to select all fields, properties, or rows.
        /// </summary>
        public const string All = "*";

        /// <summary>
        /// The name of the API key header used for signing requests.
        /// </summary>
        public const string ApiKeyHeaderName = "api-key";

        /// <summary>
        /// Gets the representation of a NaN value.
        /// </summary>
        public const string NanValue = "NaN";

        /// <summary>
        /// Gets the representation of positive infinity.
        /// </summary>
        public const string InfValue = "INF";

        /// <summary>
        /// Gets the representation of negative infinity.
        /// </summary>
        public const string NegativeInfValue = "-INF";

        /// <summary>
        /// The prefix for special OData keys.
        /// </summary>
        public const string ODataKeyPrefix = "@";

        /// <summary>
        /// The @search.text key.
        /// </summary>
        public static readonly JsonEncodedText SearchTextKeyJson = JsonEncodedText.Encode("@search.text");

        /// <summary>
        /// The @search.coverage key.
        /// </summary>
        public static readonly JsonEncodedText SearchCoverageKeyJson = JsonEncodedText.Encode("@search.coverage");

        /// <summary>
        /// The @search.score key.
        /// </summary>
        public static readonly JsonEncodedText SearchScoreKeyJson = JsonEncodedText.Encode("@search.score");

        /// <summary>
        /// The @search.facets key.
        /// </summary>
        public static readonly JsonEncodedText SearchFacetsKeyJson = JsonEncodedText.Encode("@search.facets");

        /// <summary>
        /// The @search.nextPageParameters key.
        /// </summary>
        public static readonly JsonEncodedText SearchNextPageKeyJson = JsonEncodedText.Encode("@search.nextPageParameters");

        /// <summary>
        /// The @search.semanticPartialResponseReason key.
        /// </summary>
        public static readonly JsonEncodedText SearchSemanticErrorReasonKeyJson = JsonEncodedText.Encode("@search.semanticPartialResponseReason");

        /// <summary>
        /// The @search.semanticPartialResponseType key.
        /// </summary>
        public static readonly JsonEncodedText SearchSemanticSearchResultsTypeKeyJson = JsonEncodedText.Encode("@search.semanticPartialResponseType");

        /// <summary>
        /// The @search.answers key.
        /// </summary>
        public static readonly JsonEncodedText SearchAnswersKeyJson = JsonEncodedText.Encode("@search.answers");

        /// <summary>
        /// The @search.highlights key.
        /// </summary>
        public static readonly JsonEncodedText SearchHighlightsKeyJson = JsonEncodedText.Encode("@search.highlights");

        /// <summary>
        /// The @search.rerankerScore key.
        /// </summary>
        public static readonly JsonEncodedText SearchRerankerScoreKeyJson = JsonEncodedText.Encode("@search.rerankerScore");

        /// <summary>
        /// The @search.captions key.
        /// </summary>
        public static readonly JsonEncodedText SearchCaptionsKeyJson = JsonEncodedText.Encode("@search.captions");

        /// <summary>
        /// The @search.captions key.
        /// </summary>
        public static readonly JsonEncodedText SearchDocumentDebugInfoKeyJson = JsonEncodedText.Encode("@search.documentDebugInfo");

        /// <summary>
        /// The @search.action key.
        /// </summary>
        public static readonly JsonEncodedText SearchActionKeyJson = JsonEncodedText.Encode("@search.action");

        /// <summary>
        /// The @odata.count key.
        /// </summary>
        public static readonly JsonEncodedText ODataCountKeyJson = JsonEncodedText.Encode("@odata.count");

        /// <summary>
        /// The @odata.nextLink key.
        /// </summary>
        public static readonly JsonEncodedText ODataNextLinkKeyJson = JsonEncodedText.Encode("@odata.nextLink");

        /// <summary>
        /// The name key.
        /// </summary>
        public const string NameKey = "name";

        /// <summary>
        /// The value key.
        /// </summary>
        public const string ValueKey = "value";

        /// <summary>
        /// The value key.
        /// </summary>
        public static readonly JsonEncodedText ValueKeyJson = JsonEncodedText.Encode(ValueKey);

        /// <summary>
        /// The count key.
        /// </summary>
        public const string CountKey = "count";

        /// <summary>
        /// The count key.
        /// </summary>
        public static readonly JsonEncodedText CountKeyJson = JsonEncodedText.Encode(CountKey);

        /// <summary>
        /// The to key.
        /// </summary>
        public const string FromKey = "from";

        /// <summary>
        /// The from key.
        /// </summary>
        public const string ToKey = "to";

        /// <summary>
        /// The default recursion limit if we don't get a value from
        /// <see cref="System.Text.Json.JsonSerializerOptions.MaxDepth"/>.
        /// The service limit is (currently) 10.
        /// </summary>
        public const int MaxJsonRecursionDepth = 64;

        /// <summary>
        /// The default size of buffer to use when copying data between streams.
        /// </summary>
        public const int CopyBufferSize = 81920;
    }
}
