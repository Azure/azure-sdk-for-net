// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// This class provides a mapping from an arbitrary HTTP request header field to a <see cref="MediaTypeHeaderValue"/>
    /// used to select <see cref="MediaTypeFormatter"/> instances for handling the entity body of an <see cref="HttpRequestMessage"/>
    /// or <see cref="HttpResponseMessage"/>.
    /// <remarks>This class only checks header fields associated with <see cref="HttpRequestMessage.Headers"/> for a match. It does
    /// not check header fields associated with <see cref="HttpResponseMessage.Headers"/> or <see cref="HttpContent.Headers"/> instances.</remarks>
    /// </summary>
    internal class RequestHeaderMapping : MediaTypeMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHeaderMapping"/> class.
        /// </summary>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The value comparison to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The media type to use if <paramref name="headerName"/> and <paramref name="headerValue"/> 
        /// is considered a match.</param>
        public RequestHeaderMapping(string headerName, string headerValue, StringComparison valueComparison, bool isValueSubstring, string mediaType)
            : base(mediaType)
        {
            this.Initialize(headerName, headerValue, valueComparison, isValueSubstring);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHeaderMapping"/> class.
        /// </summary>
        /// <param name="headerName">Name of the header to match.</param>
        /// <param name="headerValue">The header value to match.</param>
        /// <param name="valueComparison">The <see cref="StringComparison"/> to use when matching <paramref name="headerValue"/>.</param>
        /// <param name="isValueSubstring">if set to <c>true</c> then <paramref name="headerValue"/> is 
        /// considered a match if it matches a substring of the actual header value.</param>
        /// <param name="mediaType">The <see cref="MediaTypeHeaderValue"/> to use if <paramref name="headerName"/> and <paramref name="headerValue"/> 
        /// is considered a match.</param>
        public RequestHeaderMapping(string headerName, string headerValue, StringComparison valueComparison, bool isValueSubstring, MediaTypeHeaderValue mediaType)
            : base(mediaType)
        {
            this.Initialize(headerName, headerValue, valueComparison, isValueSubstring);
        }

        /// <summary>
        /// Gets the name of the header to match.
        /// </summary>
        public string HeaderName { get; private set; }

        /// <summary>
        /// Gets the header value to match.
        /// </summary>
        public string HeaderValue { get; private set; }

        /// <summary>
        /// Gets the <see cref="StringComparison"/> to use when matching <see cref="HeaderValue"/>.
        /// </summary>
        public StringComparison HeaderValueComparison { get; private set; }

        /// <summary>
        /// Gets a value indicating whether <see cref="HeaderValue"/> is 
        /// a matched as a substring of the actual header value.
        /// this instance is value substring.
        /// </summary>
        /// <value>
        /// <c>true</c> if <see cref="HeaderValue"/> is to be matched as a substring; otherwise <c>false</c>.
        /// </value>
        public bool IsValueSubstring { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the current <see cref="RequestHeaderMapping"/>
        /// instance can return a <see cref="MediaTypeHeaderValue"/> from <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to check.</param>
        /// <returns>
        /// The quality of the match. It must be between <c>0.0</c> and <c>1.0</c>.
        /// A value of <c>0.0</c> signifies no match.
        /// A value of <c>1.0</c> signifies a complete match.
        /// </returns>
        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            return MatchHeaderValue(request, this.HeaderName, this.HeaderValue, this.HeaderValueComparison, this.IsValueSubstring);
        }

        private static double MatchHeaderValue(HttpRequestMessage request, string headerName, string headerValue, StringComparison valueComparison, bool isValueSubstring)
        {
            Contract.Assert(request != null, "request should not be null");
            Contract.Assert(headerName != null, "header name should not be null");
            Contract.Assert(headerValue != null, "header value should not be null");

            IEnumerable<string> values;
            if (request.Headers.TryGetValues(headerName, out values))
            {
                foreach (string value in values)
                {
                    if (isValueSubstring)
                    {
                        if (value.IndexOf(headerValue, valueComparison) != -1)
                        {
                            return FormattingUtilities.Match;
                        }
                    }
                    else
                    {
                        if (value.Equals(headerValue, valueComparison))
                        {
                            return FormattingUtilities.Match;
                        }
                    }
                }
            }

            return FormattingUtilities.NoMatch;
        }

        private void Initialize(string headerName, string headerValue, StringComparison valueComparison, bool isValueSubstring)
        {
            if (String.IsNullOrWhiteSpace(headerName))
            {
                throw Error.ArgumentNull("headerName");
            }

            if (String.IsNullOrWhiteSpace(headerValue))
            {
                throw Error.ArgumentNull("headerValue");
            }

            StringComparisonHelper.Validate(valueComparison, "valueComparison");

            this.HeaderName = headerName;
            this.HeaderValue = headerValue;
            this.HeaderValueComparison = valueComparison;
            this.IsValueSubstring = isValueSubstring;
        }
    }
}
