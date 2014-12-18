// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// A <see cref="RequestHeaderMapping"/> that maps the X-Requested-With http header field set by AJAX XmlHttpRequest (XHR)
    /// to the media type <c>application/json</c> if no explicit Accept header fields are present in the request.
    /// </summary>
    internal class XmlHttpRequestHeaderMapping : RequestHeaderMapping
    {
        /// <summary>
        /// Initializes a new instance of <see cref="XmlHttpRequestHeaderMapping" /> class
        /// </summary>
        public XmlHttpRequestHeaderMapping() :
            base(FormattingUtilities.HttpRequestedWithHeader, FormattingUtilities.HttpRequestedWithHeaderValue, StringComparison.OrdinalIgnoreCase, isValueSubstring: true, mediaType: MediaTypeConstants.ApplicationJsonMediaType)
        {
        }

        /// <summary>
        /// Returns a value indicating whether the current <see cref="RequestHeaderMapping"/>
        /// instance can return a <see cref="MediaTypeHeaderValue"/> from <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to check.</param>
        /// <returns>
        /// The quality of the match.
        /// A value of <c>0.0</c> signifies no match.
        /// A value of <c>1.0</c> signifies a complete match and that the request was made using XmlHttpRequest without an Accept header.
        /// </returns>
        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            // Accept header trumps XHR mapping.
            // Accept: */* is equivalent to passing no Accept header.
            if (request.Headers.Accept.Count == 0
                || (request.Headers.Accept.Count == 1 && request.Headers.Accept.First().MediaType.Equals("*/*", StringComparison.Ordinal)))
            {
                return base.TryMatchMediaType(request);
            }
            else
            {
                return FormattingUtilities.NoMatch;
            }
        }
    }
}
