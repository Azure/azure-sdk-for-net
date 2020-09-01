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
        public Func<IAuthRequestBuilder> AuthRequestBuilderFactory { get; set; }

        public Func<AccessToken> TokenFactory { get; set; }

        public Func<CancellationToken, bool> ImdsAvailableFunc { get; set; }

        public override ValueTask<AccessToken> AuthenticateAsync(bool async, string[] scopes, CancellationToken cancellationToken)
              => TokenFactory != null ? new ValueTask<AccessToken>(TokenFactory()) : base.AuthenticateAsync(async, scopes, cancellationToken);

        private protected override ValueTask<IAuthRequestBuilder> GetAuthRequestBuilderAsync(bool async, CancellationToken cancellationToken)
            => AuthRequestBuilderFactory != null ? new ValueTask<IAuthRequestBuilder>(AuthRequestBuilderFactory()) : base.GetAuthRequestBuilderAsync(async, cancellationToken);

        protected override ValueTask<bool> ImdsAvailableAsync(bool async, CancellationToken cancellationToken)
            => ImdsAvailableFunc != null ? new ValueTask<bool>(ImdsAvailableFunc(cancellationToken)) : base.ImdsAvailableAsync(async, cancellationToken);
    }
}
