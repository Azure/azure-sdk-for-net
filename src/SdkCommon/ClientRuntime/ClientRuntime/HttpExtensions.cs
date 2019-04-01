// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest
{
    /// <summary>
    /// Extensions for manipulating HTTP request and response objects.
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// Formats an HttpContent object as String.
        /// </summary>
        /// <param name="content">The HttpContent to format.</param>
        /// <returns>The formatted string.</returns>
        public static string AsString(this HttpContent content)
        {
            if (content != null)
            {
                // Await for the content.
                return
                    content
                        .ReadAsStringAsync()
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
            }

            return null;
        }

        /// <summary>
        /// Get the content headers of an HtttRequestMessage.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>The content headers.</returns>
        public static HttpHeaders GetContentHeaders(this HttpRequestMessage request)
        {
            if (request != null && request.Content != null)
            {
                return request.Content.Headers;
            }

            return null;
        }

        /// <summary>
        /// Get the content headers of an HttpResponseMessage.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <returns>The content headers.</returns>
        public static HttpHeaders GetContentHeaders(this HttpResponseMessage response)
        {
            if (response != null && response.Content != null)
            {
                return response.Content.Headers;
            }

            return null;
        }

        /// <summary>
        /// Returns string representation of a HttpRequestMessage.
        /// </summary>
        /// <param name="httpRequest">Request object to format.</param>
        /// <returns>The string, formatted into curly braces.</returns>
        public static string AsFormattedString(this HttpRequestMessage httpRequest)
        {
            if (httpRequest == null)
            {
                throw new ArgumentNullException("httpRequest");
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(httpRequest.ToString());
            if (httpRequest.Content != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(httpRequest.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
                stringBuilder.AppendLine("}");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns string representation of a HttpResponseMessage.
        /// </summary>
        /// <param name="httpResponse">Response object to format.</param>
        /// <returns>The string, formatted into curly braces.</returns>
        public static string AsFormattedString(this HttpResponseMessage httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException("httpResponse");
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(httpResponse.ToString());
            if (httpResponse.Content != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
                stringBuilder.AppendLine("}");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts given dictionary into a log string.
        /// </summary>
        /// <typeparam name="TKey">The dictionary key type.</typeparam>
        /// <typeparam name="TValue">The dictionary value type.</typeparam>
        /// <param name="dictionary">The dictionary object.</param>
        /// <returns>The string, formatted into curly braces.</returns>
        public static string AsFormattedString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return "{}";
            }

            return "{" + string.Join(",",
                dictionary.Select(kv => kv.Key.ToString() +
                                        "=" +
                                        (kv.Value == null ? string.Empty : kv.Value.ToString()))
                    .ToArray()) + "}";
        }

        /// <summary>
        /// Serializes HttpHeaders as Json dictionary.
        /// </summary>
        /// <param name="headers">HttpHeaders</param>
        /// <returns>Json string</returns>
        public static JObject ToJson(this HttpHeaders headers)
        {
            if (headers == null || !headers.Any())
            {
                return new JObject();
            }
            else
            {
                return headers.ToDictionary(h => h.Key, h => h.Value).ToJson();
            }
        }

        /// <summary>
        /// Serializes header dictionary as Json dictionary.
        /// </summary>
        /// <param name="headers">Dictionary</param>
        /// <returns>Json string</returns>
        public static JObject ToJson(this IDictionary<string, IEnumerable<string>> headers)
        {
            if (headers == null || !headers.Any())
            {
                return new JObject();
            }
            else
            {
                var jObject = new JObject();
                foreach (var httpResponseHeader in headers)
                {
                    if (httpResponseHeader.Value.Count() > 1)
                    {
                        jObject[httpResponseHeader.Key] = new JArray(httpResponseHeader.Value);
                    }
                    else
                    {
                        jObject[httpResponseHeader.Key] = httpResponseHeader.Value.FirstOrDefault();
                    }
                }
                return jObject;
            }
        }

        /// <summary>
        /// Serializes HttpResponseHeaders and HttpContentHeaders as Json dictionary.
        /// </summary>
        /// <param name="message">HttpResponseMessage</param>
        /// <returns>Json string</returns>
        public static JObject GetHeadersAsJson(this HttpResponseMessage message)
        {
            if (message == null)
            {
                return new JObject();
            }

            var jObject = new JObject();
            foreach (var httpResponseHeader in message.Headers)
            {
                if (httpResponseHeader.Value.Count() > 1)
                {
                    jObject[httpResponseHeader.Key] = new JArray(httpResponseHeader.Value);
                }
                else
                {
                    jObject[httpResponseHeader.Key] = httpResponseHeader.Value.FirstOrDefault();
                }
            }
            if (message.Content != null)
            {
                foreach (var httpResponseHeader in message.Content.Headers)
                {
                    if (httpResponseHeader.Value.Count() > 1)
                    {
                        jObject[httpResponseHeader.Key] = new JArray(httpResponseHeader.Value);
                    }
                    else
                    {
                        jObject[httpResponseHeader.Key] = httpResponseHeader.Value.FirstOrDefault();
                    }
                }
            }
            return jObject;
        }
    }
}