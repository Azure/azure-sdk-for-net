// -----------------------------------------------------------------------------------------
// <copyright file="SharedKeyAuthenticationHttpHandler.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Auth.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class SharedKeyAuthenticationHttpHandler : HttpClientHandler
    {
        private readonly ICanonicalizer canonicalizer;
        private readonly StorageCredentials credentials;
        private readonly string accountName;
        
        public SharedKeyAuthenticationHttpHandler(ICanonicalizer canonicalizer, StorageCredentials credentials, string accountName)
        {
            this.canonicalizer = canonicalizer;
            this.credentials = credentials;
            this.accountName = accountName;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string dateString = HttpWebUtility.ConvertDateTimeToHttpString(DateTimeOffset.UtcNow);
            request.Headers.Add(Constants.HeaderConstants.Date, dateString);

            if (this.credentials.IsSharedKey)
            {
                string message = this.canonicalizer.CanonicalizeHttpRequest(request, this.accountName);

                StorageAccountKey accountKey = this.credentials.Key;

                string signature = CryptoUtility.ComputeHmac256(accountKey.KeyValue, message);

                if (!string.IsNullOrEmpty(accountKey.KeyName))
                {
                    request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, accountKey.KeyName);
                }

                request.Headers.Authorization = new AuthenticationHeaderValue(
                    this.canonicalizer.AuthorizationScheme,
                    string.Format(CultureInfo.InvariantCulture, "{0}:{1}", this.credentials.AccountName, signature));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
