// -----------------------------------------------------------------------------------------
// <copyright file="SharedKeyLiteTableCanonicalizer.cs" company="Microsoft">
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
    using System.Net.Http;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal sealed class SharedKeyLiteTableCanonicalizer : ICanonicalizer
    {
        private static SharedKeyLiteTableCanonicalizer instance = new SharedKeyLiteTableCanonicalizer();

        public static SharedKeyLiteTableCanonicalizer Instance
        {
            get
            {
                return SharedKeyLiteTableCanonicalizer.instance;
            }
        }

        private SharedKeyLiteTableCanonicalizer()
        {
        }

        public string AuthorizationScheme
        {
            get { return "SharedKeyLite"; }
        }

        public string CanonicalizeHttpRequest(HttpRequestMessage request, string accountName)
        {
            // Start with x-ms-date or Date
            string dateValue = HttpResponseMessageUtils.GetHeaderSingleValueOrDefault(request.Headers, Constants.HeaderConstants.Date);          
            if (string.IsNullOrEmpty(dateValue))
            {
                dateValue = CommonUtils.GetDateTimeValueOrDefault(request.Headers.Date);
            }

            CanonicalizedString canonicalizedString = new CanonicalizedString(dateValue);

            // And we only need the canonicalized resource in addition to date
            canonicalizedString.AppendCanonicalizedElement(CanonicalizationHelper.GetCanonicalizedResourceForSharedKeyLite(request.RequestUri, accountName));

            return canonicalizedString.Value;
        }
    }
}
