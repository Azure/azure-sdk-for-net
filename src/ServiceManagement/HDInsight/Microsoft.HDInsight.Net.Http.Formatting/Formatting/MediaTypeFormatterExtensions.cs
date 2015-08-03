// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.ComponentModel;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Extensions for adding <see cref="MediaTypeMapping"/> items to a <see cref="MediaTypeFormatter"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class MediaTypeFormatterExtensions
    {
        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s containing
        /// a specific query parameter and value.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="QueryStringMapping"/> item.</param>
        /// <param name="queryStringParameterName">The name of the query parameter.</param>
        /// <param name="queryStringParameterValue">The value assigned to that query parameter.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to associate 
        /// with a <see cref="Uri"/> containing a query string matching <paramref name="queryStringParameterName"/> 
        /// and <paramref name="queryStringParameterValue"/>.</param>
        public static void AddQueryStringMapping(
            this MediaTypeFormatter formatter,
            string queryStringParameterName,
            string queryStringParameterValue,
            MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            QueryStringMapping mapping = new QueryStringMapping(queryStringParameterName, queryStringParameterValue, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with <see cref="Uri"/>s containing
        /// a specific query parameter and value.
        /// </summary>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="QueryStringMapping"/> item.</param>
        /// <param name="queryStringParameterName">The name of the query parameter.</param>
        /// <param name="queryStringParameterValue">The value assigned to that query parameter.</param>
        /// <param name="mediaType">The media type to associate 
        /// with a <see cref="Uri"/> containing a query string matching <paramref name="queryStringParameterName"/>
        /// and <paramref name="queryStringParameterValue"/>.</param>
        public static void AddQueryStringMapping(
            this MediaTypeFormatter formatter,
            string queryStringParameterName,
            string queryStringParameterValue,
            string mediaType)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            QueryStringMapping mapping = new QueryStringMapping(queryStringParameterName, queryStringParameterValue, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with a specific HTTP request header field
        /// with a specific value.
        /// </summary>
        /// <remarks><see cref="RequestHeaderMapping"/> checks header fields associated with <see cref="M:HttpRequestMessage.Headers"/> for a match. It does
        /// not check header fields associated with <see cref="M:HttpResponseMessage.Headers"/> or <see cref="M:HttpContent.Headers"/> instances.</remarks>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaTypeMapping"/> item.</param>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The <see cref="StringComparison"/> to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to associate 
        /// with a <see cref="M:HttpRequestMessage.Header"/> entry with a name matching <paramref name="headerName"/>
        /// and a value matching <paramref name="headerValue"/>.</param>
        public static void AddRequestHeaderMapping(
            this MediaTypeFormatter formatter,
            string headerName,
            string headerValue,
            StringComparison valueComparison,
            bool isValueSubstring,
            MediaTypeHeaderValue mediaType)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            RequestHeaderMapping mapping = new RequestHeaderMapping(headerName, headerValue, valueComparison, isValueSubstring, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }

        /// <summary>
        /// Updates the given <paramref name="formatter"/>'s set of <see cref="MediaTypeMapping"/> elements
        /// so that it associates the <paramref name="mediaType"/> with a specific HTTP request header field
        /// with a specific value.
        /// </summary>
        /// <remarks><see cref="RequestHeaderMapping"/> checks header fields associated with <see cref="M:HttpRequestMessage.Headers"/> for a match. It does
        /// not check header fields associated with <see cref="M:HttpResponseMessage.Headers"/> or <see cref="M:HttpContent.Headers"/> instances.</remarks>
        /// <param name="formatter">The <see cref="MediaTypeFormatter"/> to receive the new <see cref="MediaTypeMapping"/> item.</param>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The <see cref="StringComparison"/> to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The media type to associate 
        /// with a <see cref="M:HttpRequestMessage.Header"/> entry with a name matching <paramref name="headerName"/>
        /// and a value matching <paramref name="headerValue"/>.</param>
        public static void AddRequestHeaderMapping(
            this MediaTypeFormatter formatter,
            string headerName,
            string headerValue,
            StringComparison valueComparison,
            bool isValueSubstring,
            string mediaType)
        {
            if (formatter == null)
            {
                throw Error.ArgumentNull("formatter");
            }

            RequestHeaderMapping mapping = new RequestHeaderMapping(headerName, headerValue, valueComparison, isValueSubstring, mediaType);
            formatter.MediaTypeMappings.Add(mapping);
        }
    }
}
