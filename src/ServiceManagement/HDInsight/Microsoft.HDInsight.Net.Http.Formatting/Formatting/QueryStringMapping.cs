// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Class that provides <see cref="MediaTypeHeaderValue"/>s from query strings.
    /// </summary>
    internal class QueryStringMapping : MediaTypeMapping
    {
        private static readonly Type _queryStringMappingType = typeof(QueryStringMapping);

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringMapping"/> class.
        /// </summary>
        /// <param name="queryStringParameterName">The name of the query string parameter to match, if present.</param>
        /// <param name="queryStringParameterValue">The value of the query string parameter specified by <paramref name="queryStringParameterName"/>.</param>
        /// <param name="mediaType">The media type to use if the query parameter specified by <paramref name="queryStringParameterName"/> is present
        /// and assigned the value specified by <paramref name="queryStringParameterValue"/>.</param>
        public QueryStringMapping(string queryStringParameterName, string queryStringParameterValue, string mediaType)
            : base(mediaType)
        {
            this.Initialize(queryStringParameterName, queryStringParameterValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringMapping"/> class.
        /// </summary>
        /// <param name="queryStringParameterName">The name of the query string parameter to match, if present.</param>
        /// <param name="queryStringParameterValue">The value of the query string parameter specified by <paramref name="queryStringParameterName"/>.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to use if the query parameter specified by <paramref name="queryStringParameterName"/> is present
        /// and assigned the value specified by <paramref name="queryStringParameterValue"/>.</param>
        public QueryStringMapping(string queryStringParameterName, string queryStringParameterValue, MediaTypeHeaderValue mediaType)
            : base(mediaType)
        {
            this.Initialize(queryStringParameterName, queryStringParameterValue);
        }

        /// <summary>
        /// Gets the query string parameter name.
        /// </summary>
        public string QueryStringParameterName { get; private set; }

        /// <summary>
        /// Gets the query string parameter value.
        /// </summary>
        public string QueryStringParameterValue { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the current <see cref="QueryStringMapping"/>
        /// instance can return a <see cref="MediaTypeHeaderValue"/> from <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to check.</param>
        /// <returns>If this instance can produce a <see cref="MediaTypeHeaderValue"/> from <paramref name="request"/>
        /// it returns <c>1.0</c> otherwise <c>0.0</c>.</returns>
        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            NameValueCollection queryString = GetQueryString(request.RequestUri);
            return this.DoesQueryStringMatch(queryString) ? FormattingUtilities.Match : FormattingUtilities.NoMatch;
        }

        private static NameValueCollection GetQueryString(Uri uri)
        {
            if (uri == null)
            {
                throw Error.InvalidOperation(Resources.NonNullUriRequiredForMediaTypeMapping, _queryStringMappingType.Name);
            }

            return new FormDataCollection(uri).ReadAsNameValueCollection();
        }

        private void Initialize(string queryStringParameterName, string queryStringParameterValue)
        {
            if (String.IsNullOrWhiteSpace(queryStringParameterName))
            {
                throw Error.ArgumentNull("queryStringParameterName");
            }

            if (String.IsNullOrWhiteSpace(queryStringParameterValue))
            {
                throw Error.ArgumentNull("queryStringParameterValue");
            }

            this.QueryStringParameterName = queryStringParameterName.Trim();
            this.QueryStringParameterValue = queryStringParameterValue.Trim();
        }

        private bool DoesQueryStringMatch(NameValueCollection queryString)
        {
            if (queryString != null)
            {
                foreach (string queryParameter in queryString.AllKeys)
                {
                    if (String.Equals(queryParameter, this.QueryStringParameterName, StringComparison.OrdinalIgnoreCase))
                    {
                        string queryValue = queryString[queryParameter];
                        if (String.Equals(queryValue, this.QueryStringParameterValue, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
