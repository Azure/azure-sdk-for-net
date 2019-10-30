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
        public Func<MsiType> MsiTypeFactory { get; set; }

        public Func<AccessToken> TokenFactory { get; set; }

        public override AccessToken Authenticate(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return TokenFactory();
            }

            throw new NotImplementedException();
        }

        public override Task<AccessToken> AuthenticateAsync(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return Task.FromResult(TokenFactory());
            }

            throw new NotImplementedException();
        }

        public override MsiType GetMsiType(CancellationToken cancellationToken)
        {
            if (MsiTypeFactory != null)
            {
                return MsiTypeFactory();
            }

            throw new NotImplementedException();
        }

        public override Task<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken)
        {
            if (MsiTypeFactory != null)
            {
                return Task.FromResult(MsiTypeFactory());
            }

            throw new NotImplementedException();
        }
    }
}
