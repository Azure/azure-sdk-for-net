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
        public Func<MsiType> MsiTypeFactory { get; set; }

        public Func<AccessToken> TokenFactory { get; set; }

        public Func<CancellationToken, bool> ImdsAvailableFunc { get; set; }

        public override AccessToken Authenticate(string[] scopes, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return TokenFactory();
            }

            return base.Authenticate(scopes, cancellationToken);
        }

        public override Task<AccessToken> AuthenticateAsync(string[] scopes, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return Task.FromResult(TokenFactory());
            }

            return base.AuthenticateAsync(scopes, cancellationToken);
        }

        protected override MsiType GetMsiType(CancellationToken cancellationToken)
        {
            if (MsiTypeFactory != null)
            {
                return MsiTypeFactory();
            }

            return base.GetMsiType(cancellationToken);
        }

        protected override Task<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken)
        {
            if (MsiTypeFactory != null)
            {
                return Task.FromResult(MsiTypeFactory());
            }

            return base.GetMsiTypeAsync(cancellationToken);
        }

        protected override bool ImdsAvailable(CancellationToken cancellationToken)
        {
            if (ImdsAvailableFunc != null)
            {
                return ImdsAvailableFunc(cancellationToken);
            }

            return base.ImdsAvailable(cancellationToken);
        }

        protected override Task<bool> ImdsAvailableAsync(CancellationToken cancellationToken)
        {
            if (ImdsAvailableFunc != null)
            {
                return Task.FromResult(ImdsAvailableFunc(cancellationToken));
            }

            return base.ImdsAvailableAsync(cancellationToken);
        }
    }
}
