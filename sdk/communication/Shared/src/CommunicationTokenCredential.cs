// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Identity;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.Pipeline
{
    internal class CommunicationTokenCredential : TokenCredential
    {
        private readonly AccessToken _token;

        public CommunicationTokenCredential(CommunicationUserCredential userCredential) {
            _token = userCredential.GetToken();
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => _token;
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => new ValueTask<AccessToken>(_token);

    }
}
