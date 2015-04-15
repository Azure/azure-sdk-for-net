//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;

namespace Microsoft.Azure.KeyVault
{
    internal static class UriExtensions
    {
        /// <summary>
        /// Returns an authority string for URI that is guaranteed to contain
        /// a port number.
        /// </summary>
        /// <param name="uri">The Uri from which to compute the authority</param>
        /// <returns>The complete authority for the Uri</returns>
        public static string FullAuthority(this Uri uri)
        {
            string authority = uri.Authority;

            if (!authority.Contains(":") && uri.Port > 0)
            {
                // Append port for complete authority
                authority = string.Format("{0}:{1}", uri.Authority, uri.Port.ToString());
            }

            return authority;
        }

        /// <summary>
        /// x-www-form-urlencoded a string without the requirement for System.Web
        /// </summary>
        /// <param name="text">The string to encode</param>
        /// <returns></returns>
        // [Obsolete("Use System.Uri.EscapeDataString instead")]
        public static string UrlFormEncode(string text)
        {
            // Sytem.Uri provides reliable parsing
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return Uri.EscapeDataString(text).Replace("%20", "+");
        }

        /// <summary>
        /// UrlDecodes a string without requiring System.Web
        /// </summary>
        /// <param name="text">String to decode.</param>
        /// <returns>decoded string</returns>
        public static string UrlFormDecode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // pre-process for + sign space formatting since System.Uri doesn't handle it
            // plus literals are encoded as %2b normally so this should be safe
            text = text.Replace("+", " ");

            return Uri.UnescapeDataString(text);
        }
    }
}
