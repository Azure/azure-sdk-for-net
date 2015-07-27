// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System.Net.Http;

    /// <summary>
    /// Contains information about the degree to which a <see cref="MediaTypeFormatter"/> matches the  
    /// explicit or implicit preferences found in an incoming request.
    /// </summary>
    public enum MediaTypeFormatterMatchRanking
    {
        /// <summary>
        /// No match was found
        /// </summary>
        None = 0,

        /// <summary>
        /// Matched on type meaning that the formatter is able to serialize the type
        /// </summary>
        MatchOnCanWriteType,

        /// <summary>
        /// Matched on explicit literal accept header in <see cref="HttpRequestMessage"/>, 
        /// e.g. "application/json".
        /// </summary>
        MatchOnRequestAcceptHeaderLiteral,

        /// <summary>
        /// Matched on explicit subtype range accept header in <see cref="HttpRequestMessage"/>,
        /// e.g. "application/*".
        /// </summary>
        MatchOnRequestAcceptHeaderSubtypeMediaRange,

        /// <summary>
        /// Matched on explicit all media type range accept header in <see cref="HttpRequestMessage"/>,
        /// e.g. "*/*"
        /// </summary>
        MatchOnRequestAcceptHeaderAllMediaRange,

        /// <summary>
        /// Matched on <see cref="HttpRequestMessage"/> after having applied
        /// the various <see cref="MediaTypeMapping"/>s.
        /// </summary>
        MatchOnRequestWithMediaTypeMapping,

        /// <summary>
        /// Matched on the media type of the <see cref="HttpContent"/> of the <see cref="HttpRequestMessage"/>.
        /// </summary>
        MatchOnRequestMediaType,
    }
}
