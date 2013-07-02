// -----------------------------------------------------------------------------------------
// <copyright file="SharedKeyLiteCanonicalizer.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;

    internal sealed class SharedKeyLiteCanonicalizer : ICanonicalizer
    {
        private const string SharedKeyLiteAuthorizationScheme = "SharedKeyLite";
        private const int ExpectedCanonicalizedStringLength = 250;

        private static SharedKeyLiteCanonicalizer instance = new SharedKeyLiteCanonicalizer();

        public static SharedKeyLiteCanonicalizer Instance
        {
            get
            {
                return SharedKeyLiteCanonicalizer.instance;
            }
        }

        private SharedKeyLiteCanonicalizer()
        {
        }

        public string AuthorizationScheme
        {
            get
            {
                return SharedKeyLiteAuthorizationScheme;
            }
        }

        public string CanonicalizeHttpRequest(HttpRequestMessage request, string accountName)
        {
            // Add the method (GET, POST, PUT, or HEAD).
            CanonicalizedString canonicalizedString = new CanonicalizedString(request.Method.Method, ExpectedCanonicalizedStringLength);

            // Add the Content-* HTTP headers. Empty values are allowed.
            if (request.Content != null)
            {
                canonicalizedString.AppendCanonicalizedElement((request.Content.Headers.ContentMD5 == null) ? null :
                    Convert.ToBase64String(request.Content.Headers.ContentMD5));
                canonicalizedString.AppendCanonicalizedElement((request.Content.Headers.ContentType == null) ? null :
                    request.Content.Headers.ContentType.ToString());
            }
            else
            {
                canonicalizedString.AppendCanonicalizedElement(null);
                canonicalizedString.AppendCanonicalizedElement(null);
            }

            // Add the Date HTTP header (only if the x-ms-date header is not being used)
            AuthenticationUtility.AppendCanonicalizedDateHeader(canonicalizedString, request);

            // Add any custom headers
            AuthenticationUtility.AppendCanonicalizedCustomHeaders(canonicalizedString, request);

            // Add the canonicalized URI element
            string resourceString = AuthenticationUtility.GetCanonicalizedResourceString(request.RequestUri, accountName, true);
            canonicalizedString.AppendCanonicalizedElement(resourceString);

            return canonicalizedString.ToString();
        }
    }
}
