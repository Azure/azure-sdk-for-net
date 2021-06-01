// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class MockManagedIdentityClient : ManagedIdentityClient
    {
        public MockManagedIdentityClient()
            : this(null)
        {
        }

        public MockManagedIdentityClient(CredentialPipeline pipeline)
            : this(pipeline, null)
        {
        }

        public MockManagedIdentityClient(CredentialPipeline pipeline, string clientId)
            : base(pipeline, clientId)
        {
        }
        public Func<ManagedIdentitySource> ManagedIdentitySourceFactory { get; set; }

        public Func<AccessToken> TokenFactory { get; set; }

        public override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
              => TokenFactory != null ? new ValueTask<AccessToken>(TokenFactory()) : base.AuthenticateAsync(async, context, cancellationToken);

        private protected override ValueTask<ManagedIdentitySource> GetManagedIdentitySourceAsync(bool async, CancellationToken cancellationToken)
            => ManagedIdentitySourceFactory != null ? new ValueTask<ManagedIdentitySource>(ManagedIdentitySourceFactory()) : base.GetManagedIdentitySourceAsync(async, cancellationToken);
    }
}
