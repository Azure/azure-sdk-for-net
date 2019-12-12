// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Attestation
{
    /// <summary>
    /// The Attestation credential class that implements <see cref="ServiceClientCredentials"/>
    /// </summary>
    public class AttestationCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// Bearer token
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="token"> token. </param>
        public AttestationCredentials(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException($"{nameof(token)} must not be null or empty");
            }

            this.token = token;
        }

        /// <summary>
        /// ProcessHttpRequestAsync.
        /// </summary>
        /// <param name="request"> request. </param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Headers.Add("Authorization", "Bearer " + token);
            return Task.FromResult(true);
        }
    }
}
