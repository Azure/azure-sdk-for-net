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

    public class BatchTokenProvider : TokenCredential
    {
        private const string BearerAuthenticationScheme = "Bearer";

        private Func<Task<string>> TokenCredential { get; }

        public BatchTokenProvider(Func<Task<string>> tokenProvider)
        {
            this.TokenCredential = tokenProvider;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            string token = await this.TokenCredential().ConfigureAwait(false);
            return new AuthenticationHeaderValue(BearerAuthenticationScheme, token);
        }
    }
}
