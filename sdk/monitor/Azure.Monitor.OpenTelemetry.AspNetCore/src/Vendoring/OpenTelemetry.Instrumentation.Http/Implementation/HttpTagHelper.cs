// <copyright file="HttpTagHelper.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
using System;
using System.Collections.Concurrent;
using System.Net.Http;
#if NETFRAMEWORK
using System.Net.Http;
#endif

namespace OpenTelemetry.Instrumentation.Http.Implementation
{
    /// <summary>
    /// A collection of helper methods to be used when building Http activities.
    /// </summary>
    internal static class HttpTagHelper
    {
        private static readonly ConcurrentDictionary<string, string> MethodOperationNameCache = new();
        private static readonly ConcurrentDictionary<HttpMethod, string> HttpMethodOperationNameCache = new();
        private static readonly ConcurrentDictionary<HttpMethod, string> HttpMethodNameCache = new();
        private static readonly ConcurrentDictionary<Version, string> ProtocolVersionToStringCache = new();

        private static readonly Func<string, string> ConvertMethodToOperationNameRef = ConvertMethodToOperationName;
        private static readonly Func<HttpMethod, string> ConvertHttpMethodToOperationNameRef = ConvertHttpMethodToOperationName;
        private static readonly Func<HttpMethod, string> ConvertHttpMethodToNameRef = ConvertHttpMethodToName;
        private static readonly Func<Version, string> ConvertProtocolVersionToStringRef = ConvertProtocolVersionToString;

        /// <summary>
        /// Gets the OpenTelemetry standard name for an activity based on its Http method.
        /// </summary>
        /// <param name="method">Http method.</param>
        /// <returns>Activity name.</returns>
        public static string GetOperationNameForHttpMethod(string method) => MethodOperationNameCache.GetOrAdd(method, ConvertMethodToOperationNameRef);

        /// <summary>
        /// Gets the OpenTelemetry standard operation name for a span based on its <see cref="HttpMethod"/>.
        /// </summary>
        /// <param name="method"><see cref="HttpMethod"/>.</param>
        /// <returns>Span operation name.</returns>
        public static string GetOperationNameForHttpMethod(HttpMethod method) => HttpMethodOperationNameCache.GetOrAdd(method, ConvertHttpMethodToOperationNameRef);

        /// <summary>
        /// Gets the OpenTelemetry standard method name for a span based on its <see cref="HttpMethod"/>.
        /// </summary>
        /// <param name="method"><see cref="HttpMethod"/>.</param>
        /// <returns>Span method name.</returns>
        public static string GetNameForHttpMethod(HttpMethod method) => HttpMethodNameCache.GetOrAdd(method, ConvertHttpMethodToNameRef);

        /// <summary>
        /// Gets the OpenTelemetry standard version tag value for a span based on its protocol <see cref="Version"/>.
        /// </summary>
        /// <param name="protocolVersion"><see cref="Version"/>.</param>
        /// <returns>Span flavor value.</returns>
        public static string GetFlavorTagValueFromProtocolVersion(Version protocolVersion) => ProtocolVersionToStringCache.GetOrAdd(protocolVersion, ConvertProtocolVersionToStringRef);

        /// <summary>
        /// Gets the OpenTelemetry standard uri tag value for a span based on its request <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/>.</param>
        /// <returns>Span uri value.</returns>
        public static string GetUriTagValueFromRequestUri(Uri uri)
        {
            if (string.IsNullOrEmpty(uri.UserInfo))
            {
                return uri.OriginalString;
            }

            return string.Concat(uri.Scheme, Uri.SchemeDelimiter, uri.Authority, uri.PathAndQuery, uri.Fragment);
        }

        private static string ConvertMethodToOperationName(string method) => $"HTTP {method}";

        private static string ConvertHttpMethodToOperationName(HttpMethod method) => $"HTTP {method}";

        private static string ConvertHttpMethodToName(HttpMethod method) => method.ToString();

        private static string ConvertProtocolVersionToString(Version protocolVersion) => protocolVersion.ToString();
    }
}
