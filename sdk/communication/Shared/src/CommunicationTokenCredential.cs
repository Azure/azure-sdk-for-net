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
        private readonly CommunicationUserCredential _credential;

        public CommunicationTokenCredential(CommunicationUserCredential credential) => _credential = credential;

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => _credential.GetToken(cancellationToken);
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) => _credential.GetTokenAsync(cancellationToken);
    }
}
