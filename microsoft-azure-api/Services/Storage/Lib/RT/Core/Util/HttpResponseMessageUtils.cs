// -----------------------------------------------------------------------------------------
// <copyright file="HttpResponseMessageUtils.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Linq;
    using System.Net.Http.Headers;

    internal static class HttpResponseMessageUtils
    {
        /// <summary>
        /// Gets the first header value for a specified header or an empty string if it does not exist.
        /// </summary>
        /// <param name="headers">A collection of headers and their values.</param>
        /// <param name="name">The name of the header to return.</param>
        /// <returns>The first header value or an empty string if the header does not exist.</returns>
        public static string GetHeaderSingleValueOrDefault(this HttpHeaders headers, string name)
        {
            if (headers.Contains(name))
            {
                return CommonUtility.GetFirstHeaderValue(headers.GetValues(name));
            }

            return string.Empty;
        }
    }
}
