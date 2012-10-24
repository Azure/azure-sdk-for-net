//-----------------------------------------------------------------------
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    
    internal static partial class CanonicalizationHelper
    {
        /// <summary>
        /// Add x-ms- prefixed headers in a fixed order.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        internal static void AddCanonicalizedHeaders(WebHeaderCollection headers, CanonicalizedString canonicalizedString)
        {
            // Look for header names that start with HeaderNames.PrefixForStorageHeader
            // Then sort them in case-insensitive manner.
            List<string> httpStorageHeaderNameArray = new List<string>();
            foreach (string key in headers.Keys)
            {
                if (key.StartsWith(Constants.HeaderConstants.PrefixForStorageHeader, StringComparison.OrdinalIgnoreCase))
                {
                    httpStorageHeaderNameArray.Add(key.ToLowerInvariant());
                }
            }

            httpStorageHeaderNameArray.Sort();

            // Now go through each header's values in the sorted order and append them to the canonicalized string.
            foreach (string key in httpStorageHeaderNameArray)
            {
                StringBuilder canonicalizedElement = new StringBuilder(key);
                string delimiter = ":";

                // Go through values, unfold them, and then append them to the canonicalized element string.
                string[] values = headers.GetValues(key);

                if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                {
                    continue;
                }

                foreach (string value in values)
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
