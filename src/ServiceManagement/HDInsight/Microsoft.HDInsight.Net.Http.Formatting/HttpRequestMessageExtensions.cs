// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Provides extension methods for the <see cref="HttpRequestMessage"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Creates an <see cref="HttpResponseMessage"/> wired up to the associated <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <returns>An initialized <see cref="HttpResponseMessage"/>.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Caller will dispose")]
        public static HttpResponseMessage CreateResponse(this HttpRequestMessage request, HttpStatusCode statusCode)
        {
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                RequestMessage = request
            };
        }

        /// <summary>
        /// Creates an <see cref="HttpResponseMessage"/> wired up to the associated <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <returns>An initialized <see cref="HttpResponseMessage"/>.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Caller will dispose")]
        public static HttpResponseMessage CreateResponse(this HttpRequestMessage request)
        {
            if (request == null)
            {
                throw Error.ArgumentNull("request");
            }

            return new HttpResponseMessage
            {
                RequestMessage = request
            };
        }
    }
}
