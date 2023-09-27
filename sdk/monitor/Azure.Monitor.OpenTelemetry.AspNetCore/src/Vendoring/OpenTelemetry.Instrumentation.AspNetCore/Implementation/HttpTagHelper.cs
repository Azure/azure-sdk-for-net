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

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation
{
    /// <summary>
    /// A collection of helper methods to be used when building Http activities.
    /// </summary>
    internal static class HttpTagHelper
    {
        /// <summary>
        /// Gets the OpenTelemetry standard version tag value for a span based on its protocol/>.
        /// </summary>
        /// <param name="protocol">.</param>
        /// <returns>Span flavor value.</returns>
        public static string GetFlavorTagValueFromProtocol(string protocol)
        {
            switch (protocol)
            {
                case "HTTP/2":
                    return "2.0";

                case "HTTP/3":
                    return "3.0";

                case "HTTP/1.1":
                    return "1.1";

                default:
                    return protocol;
            }
        }
    }
}
