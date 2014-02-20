//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.WindowsAzure.Common.Internals
{
    /// <summary>
    /// Extensions for manipulating HTTP requests and responses.
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// Get the HTTP message content as a string.
        /// </summary>
        /// <param name="content">The HTTP content.</param>
        /// <returns>The HTTP message content as a string.</returns>
        public static string AsString(this HttpContent content)
        {
            try
            {
                if (content != null)
                {
                    // Get the content synchronously (in whatever parent sync
                    // context we happen to find ourselves)
                    return
                        content
                        .ReadAsStringAsync()
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignore content that's already been disposed
            }

            return null;
        }

        /// <summary>
        /// Get the content headers for an HTTP request.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>The content headers.</returns>
        public static HttpHeaders GetContentHeaders(this HttpRequestMessage request)
        {
            try
            {
                if (request != null && request.Content != null)
                {
                    return request.Content.Headers;
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignore already disposed requests
            }

            return null;
        }

        /// <summary>
        /// Get the content headers for an HTTP response.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <returns>The content headers.</returns>
        public static HttpHeaders GetContentHeaders(this HttpResponseMessage response)
        {
            try
            {
                if (response != null && response.Content != null)
                {
                    return response.Content.Headers;
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignore already disposed requests
            }

            return null;
        }

        #region RequestAsString
        /// <summary>
        /// Get a standard string representation of an HTTP request.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>String representation of the request.</returns>
        public static string AsString(this HttpRequestMessage request)
        {
            StringBuilder text = new StringBuilder();
            text.AppendHttpRequest(request);
            return text.ToString();
        }

        /// <summary>
        /// Get a standard string representation of an HTTP request.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>String representation of the request.</returns>
        public static string AsString(this CloudHttpRequestErrorInfo request)
        {
            StringBuilder text = new StringBuilder();
            text.AppendHttpRequest(request);
            return text.ToString();
        }

        /// <summary>
        /// Append an HTTP request.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="request">The request message.</param>
        public static void AppendHttpRequest(this StringBuilder text, HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            text.AppendHttpRequest(
                request.Method,
                request.RequestUri,
                request.Version,
                request.Headers,
                request.GetContentHeaders(),
                request.Properties,
                request.Content.AsString());
        }

        /// <summary>
        /// Append an HTTP request.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="request">The request message.</param>
        public static void AppendHttpRequest(this StringBuilder text, CloudHttpRequestErrorInfo request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            text.AppendHttpRequest(
                request.Method,
                request.RequestUri,
                request.Version,
                request.Headers,
                null,
                request.Properties,
                request.Content);
        }

        /// <summary>
        /// Append the components of an HTTP request.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="method">The request method.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="version">The request HTTP version.</param>
        /// <param name="headers">The request headers.</param>
        /// <param name="contentHeaders">The request content headers.</param>
        /// <param name="properties">The request properties.</param>
        /// <param name="content">The request content.</param>
        private static void AppendHttpRequest(
            this StringBuilder text,
            HttpMethod method,
            Uri requestUri,
            Version version,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> contentHeaders,
            IDictionary<string, object> properties,
            string content)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            else if (requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }
            else if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            text.AppendLine("REQUEST:");
            text.AppendFormat(
                "{0} {1} HTTP/{2}",
                method.ToString().ToUpper(),
                requestUri.ToString(),
                version.ToString());
            text.AppendLine();

            text.AppendHttpHeaders(headers);
            text.AppendHttpHeaders(contentHeaders);

            if (properties != null)
            {
                foreach (KeyValuePair<string, object> property in properties)
                {
                    text.AppendFormat("// Property {0}: {1}", property.Key, property.Value);
                    text.AppendLine();
                }
            }

            if (content != null)
            {
                text.AppendLine();
                text.AppendLine("REQUEST BODY:");
                text.AppendLine(content);
            }
        }
        #endregion RequestAsString

        #region ResponseAsString
        /// <summary>
        /// Get a standard string representation of an HTTP response.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <returns>String representation of the response.</returns>
        public static string AsString(this HttpResponseMessage response)
        {
            StringBuilder text = new StringBuilder();
            text.AppendHttpResponse(response);
            return text.ToString();
        }

        /// <summary>
        /// Get a standard string representation of an HTTP response.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <returns>String representation of the response.</returns>
        public static string AsString(this CloudHttpResponseErrorInfo response)
        {
            StringBuilder text = new StringBuilder();
            text.AppendHttpResponse(response);
            return text.ToString();
        }

        /// <summary>
        /// Append an HTTP response.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="response">The response message.</param>
        public static void AppendHttpResponse(this StringBuilder text, HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            text.AppendHttpResponse(
                response.StatusCode,
                response.ReasonPhrase,
                response.Version,
                response.Headers,
                response.GetContentHeaders(),
                response.Content.AsString());
        }

        /// <summary>
        /// Append an HTTP response.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="response">The response message.</param>
        public static void AppendHttpResponse(this StringBuilder text, CloudHttpResponseErrorInfo response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            text.AppendHttpResponse(
                response.StatusCode,
                response.ReasonPhrase,
                response.Version,
                response.Headers,
                null,
                response.Content);
        }

        /// <summary>
        /// Append the components of an HTTP response.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="statusCode">The response status code.</param>
        /// <param name="reasonPhrase">The response reason phrase.</param>
        /// <param name="version">The response HTTP version.</param>
        /// <param name="headers">The response headers.</param>
        /// <param name="contentHeaders">The response content headers.</param>
        /// <param name="content">The response content.</param>
        private static void AppendHttpResponse(
            this StringBuilder text,
            HttpStatusCode statusCode,
            string reasonPhrase,
            Version version,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> contentHeaders,
            string content)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            else if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            text.AppendLine();
            text.AppendLine("RESPONSE:");
            text.AppendFormat(
                "HTTP/{0}  {1} ({2}):  {3}",
                version,
                statusCode,
                (int)statusCode,
                reasonPhrase);
            text.AppendLine();

            text.AppendHttpHeaders(headers);
            text.AppendHttpHeaders(contentHeaders);
            if (content != null)
            {
                text.AppendLine();
                text.AppendLine("RESPONSE BODY:");
                text.AppendLine(content);
            }
        }
        #endregion ResponseAsString

        /// <summary>
        /// Append HTTP headers.
        /// </summary>
        /// <param name="text">The StringBuilder.</param>
        /// <param name="headers">The HTTP headers.</param>
        private static void AppendHttpHeaders(
            this StringBuilder text,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            Debug.Assert(text != null, "text should not be null.");

            if (headers != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
                {
                    if (header.Value != null)
                    {
                        foreach (string headerValue in header.Value)
                        {
                            text.AppendFormat("{0}: {1}", header.Key, headerValue);
                            text.AppendLine();
                        }
                    }
                }
            }
        }
    }
}
