// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Constants used by the Search client library.
    /// </summary>
    internal static class Constants
    {
        // TODO: #10596 - Switch constants to use JsonEncodedText

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
        public const string SearchTextKey = "@search.text";

        /// <summary>
        /// The @search.coverage key.
        /// </summary>
        public const string SearchCoverageKey = "@search.coverage";

        /// <summary>
        /// The @search.score key.
        /// </summary>
        public const string SearchScoreKey = "@search.score";

        /// <summary>
        /// The @search.facets key.
        /// </summary>
        public const string SearchFacetsKey = "@search.facets";

        /// <summary>
        /// The @search.nextPageParameters key.
        /// </summary>
        public const string SearchNextPageKey = "@search.nextPageParameters";

        /// <summary>
        /// The @search.highlights key.
        /// </summary>
        public const string SearchHighlightsKey = "@search.highlights";

        /// <summary>
        /// The @search.action key.
        /// </summary>
        public const string SearchActionKey = "@search.action";

        /// <summary>
        /// The @odata.count key.
        /// </summary>
        public const string ODataCountKey = "@odata.count";

        /// <summary>
        /// The @odata.nextLink key.
        /// </summary>
        public const string ODataNextLinkKey = "@odata.nextLink";

        /// <summary>
        /// The value key.
        /// </summary>
        public const string ValueKey = "value";

        /// <summary>
        /// The count key.
        /// </summary>
        public const string CountKey = "count";

        /// <summary>
        /// Initial ArrayPool rental size for copying unseekable streams in
        /// our sync <see cref="JsonExtensions.Deserialize{T}"/> method.
        /// </summary>
        public const int UnseekableStreamInitialRentSize = 4096;

        /// <summary>
        /// Byte order mark for a UTF8 document used by our sync
        /// <see cref="JsonExtensions.Deserialize{T}"/> method.
        /// </summary>
        public static ReadOnlySpan<byte> Utf8Bom => new byte[] { 0xEF, 0xBB, 0xBF };

        /// <summary>
        /// The default recursion limit if we don't get a value from
        /// <see cref="System.Text.Json.JsonSerializerOptions.MaxDepth"/>.
        /// The service limit is (currently) 10.
        /// </summary>
        public static int MaxJsonRecursionDepth = 64;
    }
}
