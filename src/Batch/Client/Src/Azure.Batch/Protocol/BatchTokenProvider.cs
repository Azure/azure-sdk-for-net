// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Rest;

    internal class BatchTokenProvider : ITokenProvider
    {
        private const string BearerAuthenticationScheme = "Bearer";

        private Func<Task<string>> TokenProvider { get; }

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
