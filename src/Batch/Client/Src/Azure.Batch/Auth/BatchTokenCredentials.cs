// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading;

using Microsoft.Azure.Batch.Protocol;

namespace Microsoft.Azure.Batch.Auth
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Azure Active Directory token credentials for an Azure Batch account.
    /// </summary>
    public class BatchTokenCredentials : BatchCredentials
    {
        /// <summary>
        /// Gets a function which returns an authentication token.
        /// </summary>
        public Func<Task<string>> TokenProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTokenCredentials"/> class with the specified Batch service endpoint and authentication token.
        /// </summary>
        /// <param name="baseUrl">The Batch service endpoint.</param>
        /// <param name="token">An authentication token provided by Azure Active Directory.</param>
        public BatchTokenCredentials(string baseUrl, string token)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            this.BaseUrl = baseUrl;
            var tokenTask = Task.FromResult(token);
            TokenProvider = () => tokenTask;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTokenCredentials" /> class with the specified Batch service endpoint and authentication token provider function.
        /// </summary>
        /// <param name="baseUrl">The Batch service endpoint.</param>
        /// <param name="tokenProvider">A function which returns an authentication token.</param>
        public BatchTokenCredentials(string baseUrl, Func<Task<string>> tokenProvider)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
            if (tokenProvider == null)
            {
                throw new ArgumentNullException(nameof(tokenProvider));
            }
            this.BaseUrl = baseUrl;
            this.TokenProvider = tokenProvider;
        }
    }
}
