//-----------------------------------------------------------------------
// <copyright file="SharedKeyCanonicalizer.cs" company="Microsoft">
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
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    public sealed class SharedKeyCanonicalizer : ICanonicalizer
    {
        private static SharedKeyCanonicalizer instance = new SharedKeyCanonicalizer();

        public static SharedKeyCanonicalizer Instance
        {
            get
            {
                return SharedKeyCanonicalizer.instance;
            }
        }

        private SharedKeyCanonicalizer()
        {
        }

        public string AuthorizationScheme
        {
            get { return "SharedKey"; }
        }

        public string CanonicalizeHttpRequest(HttpWebRequest request, string accountName)
        {
            // The first element should be the Method of the request.
            // I.e. GET, POST, PUT, or HEAD.
            CanonicalizedString canonicalizedString = new CanonicalizedString(request.Method);

            // The next elements are Content*
            // If any element is missing it may be empty.
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.ContentEncoding]);
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.ContentLanguage]);
            canonicalizedString.AppendCanonicalizedElement(request.ContentLength == -1 ? string.Empty : request.ContentLength.ToString());
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.ContentMd5]);
            canonicalizedString.AppendCanonicalizedElement(request.ContentType);

            // If x-ms-date header exists, Date should be empty string
            string dateValue = CommonUtils.GetSingleValueOrDefault(request.Headers.GetValues(Constants.HeaderConstants.Date));
            if (!string.IsNullOrEmpty(dateValue))
            {
                dateValue = string.Empty;
            }
            else
            {
                dateValue = request.Headers[HttpRequestHeader.Date];
            }

            canonicalizedString.AppendCanonicalizedElement(dateValue);

            // Conditionals and range
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.IfModifiedSince]);
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.IfMatch]);
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.IfNoneMatch]);
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.IfUnmodifiedSince]);
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.Range]);

            // Rest of the headers
            CanonicalizationHelper.AddCanonicalizedHeaders(request.Headers, canonicalizedString);

            // Now we append the canonicalized resource element
            canonicalizedString.AppendCanonicalizedElement(CanonicalizationHelper.GetCanonicalizedResourceForSharedKey(request.Address, accountName));

            return canonicalizedString.Value;
        }
    }
}
