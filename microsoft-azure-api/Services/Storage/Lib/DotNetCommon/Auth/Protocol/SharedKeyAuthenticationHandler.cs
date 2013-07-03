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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;

    /// <summary>
    /// Represents a handler that signs HTTP requests with a shared key.
    /// </summary>
    public sealed class SharedKeyAuthenticationHandler : IAuthenticationHandler
    {
        private readonly ICanonicalizer canonicalizer;
        private readonly StorageCredentials credentials;
        private readonly string accountName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharedKeyAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="canonicalizer">A canonicalizer that converts HTTP request data into a standard form appropriate for signing.</param>
        /// <param name="credentials">A <see cref="StorageCredentials"/> object providing credentials for the request.</param>
        /// <param name="resourceAccountName">The name of the storage account that the HTTP request will access.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "canonicalizer", Justification = "Reviewed: Canonicalizer can be used as an identifier name.")]
        public SharedKeyAuthenticationHandler(ICanonicalizer canonicalizer, StorageCredentials credentials, string resourceAccountName)
        {
            this.canonicalizer = canonicalizer;
            this.credentials = credentials;
            this.accountName = resourceAccountName;
        }

        /// <summary>
        /// Signs the specified HTTP request with a shared key.
        /// </summary>
        /// <param name="request">The HTTP request to sign.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        public void SignRequest(HttpWebRequest request, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("request", request);

            string dateString = HttpWebUtility.ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add(Constants.HeaderConstants.Date, dateString);

            if (this.credentials.IsSharedKey)
            {
                string message = this.canonicalizer.CanonicalizeHttpRequest(request, this.accountName);
                Logger.LogVerbose(operationContext, SR.TraceStringToSign, message);

                StorageAccountKey accountKey = this.credentials.Key;
                string signature = CryptoUtility.ComputeHmac256(accountKey.KeyValue, message);

                if (!string.IsNullOrEmpty(accountKey.KeyName))
                {
                    request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, accountKey.KeyName);
                }

                request.Headers.Add(
                    "Authorization",
                    string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", this.canonicalizer.AuthorizationScheme, this.credentials.AccountName, signature));
            }
        }
    }
}
