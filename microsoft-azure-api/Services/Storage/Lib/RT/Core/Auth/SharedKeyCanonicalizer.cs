// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Auth
{
    using System;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal sealed class SharedKeyCanonicalizer : ICanonicalizer
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

        public string CanonicalizeHttpRequest(HttpRequestMessage request, string accountName)
        {
            // The first element should be the Method of the request.
            // I.e. GET, POST, PUT, or HEAD.
            CanonicalizedString canonicalizedString = new CanonicalizedString(request.Method.Method);

            // The next elements are Content*
            // If any element is missing it may be empty.
            if (request.Content != null)
            {
                canonicalizedString.AppendCanonicalizedElement(HttpUtility.CombineHttpHeaderValues(request.Content.Headers.ContentEncoding));
                canonicalizedString.AppendCanonicalizedElement(HttpUtility.CombineHttpHeaderValues(request.Content.Headers.ContentLanguage));

                long contentLength = request.Content.Headers.ContentLength.HasValue ? request.Content.Headers.ContentLength.Value : -1;
                canonicalizedString.AppendCanonicalizedElement(contentLength == -1 ? string.Empty : contentLength.ToString());

                canonicalizedString.AppendCanonicalizedElement((request.Content.Headers.ContentMD5 == null) ? string.Empty :
                    Convert.ToBase64String(request.Content.Headers.ContentMD5));
                canonicalizedString.AppendCanonicalizedElement((request.Content.Headers.ContentType == null) ? string.Empty :
                    request.Content.Headers.ContentType.ToString());
            }
            else
            {
                canonicalizedString.AppendCanonicalizedElement(string.Empty);
                canonicalizedString.AppendCanonicalizedElement(string.Empty);
                if ((request.Method == HttpMethod.Put) ||
                    (request.Method == HttpMethod.Delete))
                {
                    canonicalizedString.AppendCanonicalizedElement("0");
                }
                else
                {
                    canonicalizedString.AppendCanonicalizedElement(string.Empty);
                }

                canonicalizedString.AppendCanonicalizedElement(string.Empty);
                canonicalizedString.AppendCanonicalizedElement(string.Empty);
            }

            // If x-ms-date header exists, Date should be empty string
            string dateValue = HttpResponseMessageUtils.GetHeaderSingleValueOrDefault(request.Headers, Constants.HeaderConstants.Date);
            if (!string.IsNullOrEmpty(dateValue))
            {
                dateValue = string.Empty;
            }
            else
            {
                dateValue = CommonUtils.GetDateTimeValueOrDefault(request.Headers.Date);
            }

            canonicalizedString.AppendCanonicalizedElement(dateValue);

            // Conditionals and range
            canonicalizedString.AppendCanonicalizedElement(CommonUtils.GetDateTimeValueOrDefault(request.Headers.IfModifiedSince));
            canonicalizedString.AppendCanonicalizedElement(CommonUtils.GetSingleValueOrDefault(request.Headers.IfMatch));
            canonicalizedString.AppendCanonicalizedElement(CommonUtils.GetSingleValueOrDefault(request.Headers.IfNoneMatch));
            canonicalizedString.AppendCanonicalizedElement(CommonUtils.GetDateTimeValueOrDefault(request.Headers.IfUnmodifiedSince));
            canonicalizedString.AppendCanonicalizedElement((request.Headers.Range == null) ? string.Empty :
                CommonUtils.GetSingleValueOrDefault(request.Headers.Range.Ranges));

            // Rest of the headers
            CanonicalizationHelper.AddCanonicalizedHeaders(request, canonicalizedString);

            // Now we append the canonicalized resource element
            canonicalizedString.AppendCanonicalizedElement(CanonicalizationHelper.GetCanonicalizedResourceForSharedKey(request.RequestUri, accountName));

            return canonicalizedString.Value;
        }
    }
}
