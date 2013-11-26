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
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Helper extension methods used by tracing providers.
    /// </summary>
    public static class CloudTracingExtensions
    {
        /// <summary>
        /// Returns string representation of a HttpRequestMessage.
        /// </summary>
        /// <param name="httpRequest">Request to format.</param>
        /// <returns>Formatted string.</returns>
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
                stringBuilder.AppendLine(httpRequest.Content.ReadAsStringAsync().Result);
                stringBuilder.AppendLine("}");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns string representation of a HttpResponseMessage.
        /// </summary>
        /// <param name="httpResponse">Response to format.</param>
        /// <returns>Formatted string.</returns>
        public static string AsFormattedString(this HttpResponseMessage httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException("httpResponse");
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(httpResponse.ToString());
            if (httpResponse.Content != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(httpResponse.Content.ReadAsStringAsync().Result);
                stringBuilder.AppendLine("}");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts given dictionary into a log string.
        /// </summary>
        /// <typeparam name="TKey">The dictionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="dictionary">The dictionary collection object</param>
        /// <returns>The log string</returns>
        public static string AsFormattedString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return "{}";
            }
            else
            {
                return "{" + string.Join(",", dictionary.Select(kv => kv.Key.ToString() + "=" + (kv.Value == null ? string.Empty : kv.Value.ToString())).ToArray()) + "}";
            }
        }
    }
}
