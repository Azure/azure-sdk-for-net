// -----------------------------------------------------------------------------------------
// <copyright file="HttpResponseParsers.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core.Executor;

    internal static partial class HttpResponseParsers
    {
        internal static T ProcessExpectedStatusCodeNoException<T>(HttpStatusCode expectedStatusCode, HttpResponseMessage resp, T retVal, StorageCommandBase<T> cmd, Exception ex)
        {
            return ProcessExpectedStatusCodeNoException(expectedStatusCode, resp != null ? resp.StatusCode : HttpStatusCode.Unused, retVal, cmd, ex);
        }

        internal static T ProcessExpectedStatusCodeNoException<T>(HttpStatusCode[] expectedStatusCodes, HttpResponseMessage resp, T retVal, StorageCommandBase<T> cmd, Exception ex)
        {
            return ProcessExpectedStatusCodeNoException(expectedStatusCodes, resp != null ? resp.StatusCode : HttpStatusCode.Unused, retVal, cmd, ex);
        }

        /// <summary>
        /// Gets the user-defined metadata.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>A <see cref="IDictionary"/> of the metadata.</returns>
        internal static IDictionary<string, string> GetMetadata(HttpResponseMessage response)
        {
            return GetMetadataOrProperties(response, Constants.HeaderConstants.PrefixForStorageMetadata);
        }

        /// <summary>
        /// Gets the metadata or properties.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <param name="prefix">The prefix for all the headers.</param>
        /// <returns>A <see cref="IDictionary"/> of the headers with the prefix.</returns>
        private static IDictionary<string, string> GetMetadataOrProperties(HttpResponseMessage response, string prefix)
        {
            IDictionary<string, string> nameValues = new Dictionary<string, string>();
            HttpResponseHeaders headers = response.Headers;
            int prefixLength = prefix.Length;

            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                if (header.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    nameValues[header.Key.Substring(prefixLength)] = string.Join(",", header.Value);
                }
            }

            return nameValues;
        }
    }
}
