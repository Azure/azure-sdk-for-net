// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Rest;

    public class BatchTokenProvider : ITokenProvider
    {
        private const string BearerAuthenticationScheme = "Bearer";

        private Func<Task<string>> TokenProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTokenProvider"/> class.
        /// </summary>
        /// <param name="tokenProvider">A token provider function which retrieves an AAD token.</param>
        public BatchTokenProvider(Func<Task<string>> tokenProvider)
        {
            this.TokenProvider = tokenProvider;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            string token = await this.TokenProvider().ConfigureAwait(false);
            return new AuthenticationHeaderValue(BearerAuthenticationScheme, token);
        }
    }
}
