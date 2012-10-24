//-----------------------------------------------------------------------
// <copyright file="SharedKeyAuthenticationHandler.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Auth.Protocol
{
    using System;
    using System.Globalization;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    public sealed class SharedKeyAuthenticationHandler : IAuthenticationHandler
    {
        private ICanonicalizer canonicalizer;
        private StorageCredentials credentials;
        private string resourceAccountName;

        public SharedKeyAuthenticationHandler(ICanonicalizer canonicalizer, StorageCredentials credentials, string resourceAccountName)
        {
            this.canonicalizer = canonicalizer;
            this.credentials = credentials;
            this.resourceAccountName = resourceAccountName;
        }

        public void SignRequest(HttpWebRequest request, OperationContext operationContext)
        {
            string dateString = HttpUtility.ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add(Constants.HeaderConstants.Date, dateString);

            if (this.credentials.IsSharedKey)
            {
                // Canonicalize request
                string message = this.canonicalizer.CanonicalizeHttpRequest(request, this.resourceAccountName);

                // Compute hash
                string computedBase64Signature = CryptoUtility.ComputeHmac256(this.credentials.KeyValue, message);

                // Add authorization headers
                if (!string.IsNullOrEmpty(this.credentials.KeyName))
                {
                    request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, this.credentials.KeyName);
                }

                request.Headers.Add(
                    "Authorization",
                    string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", this.canonicalizer.AuthorizationScheme, this.credentials.AccountName, computedBase64Signature));
            }
        }
    }
}
