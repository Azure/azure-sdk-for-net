// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    internal sealed class StaticTokenCredential : ICommunicationTokenCredential
    {
        private readonly AccessToken _accessToken;

        public StaticTokenCredential(string token)
        {
            Argument.AssertNotNull(token, nameof(token));

            _accessToken = JwtTokenParser.CreateAccessToken(token);
        }

        public AccessToken GetToken(CancellationToken cancellationToken)
            => _accessToken;

        public ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken)
            => new ValueTask<AccessToken>(_accessToken);

        public void Dispose() { }
    }
}
