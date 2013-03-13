// -----------------------------------------------------------------------------------------
// <copyright file="CanonicalizationHelper.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static partial class CanonicalizationHelper
    {
        /// <summary>
        /// Add x-ms- prefixed headers in a fixed order.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        internal static void AddCanonicalizedHeaders(HttpRequestMessage request, CanonicalizedString canonicalizedString)
        {
            CultureInfo sortingCulture = new CultureInfo("en-US");
            StringComparer sortingComparer = new CultureStringComparer(sortingCulture, false);

            // Look for header names that start with x-ms-, then sort them in case-insensitive manner.
            SortedDictionary<string, IEnumerable<string>> httpStorageHeaders = new SortedDictionary<string, IEnumerable<string>>(sortingComparer);
            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                if (header.Key.StartsWith(Constants.HeaderConstants.PrefixForStorageHeader, StringComparison.OrdinalIgnoreCase))
                {
                    httpStorageHeaders.Add(header.Key.ToLowerInvariant(), header.Value);
                }
            }

            if (request.Content != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
                {
                    if (header.Key.StartsWith(Constants.HeaderConstants.PrefixForStorageHeader, StringComparison.OrdinalIgnoreCase))
                    {
                        httpStorageHeaders.Add(header.Key.ToLowerInvariant(), header.Value);
                    }
                }
            }

            // Now go through each header's values in the sorted order and append them to the canonicalized string.
            foreach (KeyValuePair<string, IEnumerable<string>> header in httpStorageHeaders)
            {
                StringBuilder canonicalizedElement = new StringBuilder(header.Key);
                string delimiter = ":";

                // Go through values, unfold them, and then append them to the canonicalized element string.
                foreach (string value in header.Value)
                {
                    // Unfolding is simply removal of CRLF.
                    string unfoldedValue = value.TrimStart().Replace("\r\n", string.Empty);

                    // Append it to the canonicalized element string.
                    canonicalizedElement.Append(delimiter);
                    canonicalizedElement.Append(unfoldedValue);
                    delimiter = ",";
                }

                // Now, add this canonicalized element to the canonicalized header string.
                canonicalizedString.AppendCanonicalizedElement(canonicalizedElement.ToString());
            }
        }
    }
}
