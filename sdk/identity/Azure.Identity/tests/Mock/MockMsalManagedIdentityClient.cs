// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalManagedIdentityClient : MsalManagedIdentityClient
    {
        public Func<CancellationToken, IManagedIdentityApplication> ClientAppFactory { get; set; }
        public Func<TokenRequestContext, CancellationToken, AuthenticationResult> AcquireTokenForManagedIdentityAsyncFactory { get; set; }

        public MockMsalManagedIdentityClient() { }

        public MockMsalManagedIdentityClient(AuthenticationResult result)
        {
            AcquireTokenForManagedIdentityAsyncFactory = (_, _) => result;
        }

        public MockMsalManagedIdentityClient(ManagedIdentityClientOptions options)
            : base(options) { }

        protected override ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, CancellationToken cancellationToken)
        {
            if (ClientAppFactory == null)
            {
                return base.CreateClientCoreAsync(async, enableCae, cancellationToken);
            }

            return new ValueTask<IManagedIdentityApplication>(ClientAppFactory(cancellationToken));
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsyncCore(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (AcquireTokenForManagedIdentityAsyncFactory != null)
            {
                return new ValueTask<AuthenticationResult>(AcquireTokenForManagedIdentityAsyncFactory(requestContext, cancellationToken));
            }
            return base.AcquireTokenForManagedIdentityAsyncCore(async, requestContext, cancellationToken);
        }
    }
}
