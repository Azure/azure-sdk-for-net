// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalConfidentialClient : MsalConfidentialClient
    {
        private Func<string[], string, AuthenticationResult> _factory = null;
        private Func<string[], string, AuthenticationAccount, AuthenticationResult> _silentFactory = null;
        private Func<string[], string, string, AuthenticationResult> _authcodeFactory = null;

        public MockMsalConfidentialClient(AuthenticationResult result)
        {
            _factory = (_, _) => result;
            _silentFactory = (_, _, _) => result;
            _authcodeFactory = (_, _, _) => result;
        }

        public MockMsalConfidentialClient(Exception exception)
        {
            _factory = (_, _) => throw exception;
            _silentFactory = (_, _, _) => throw exception;
            _authcodeFactory = (_, _, _) => throw exception;
        }

        public MockMsalConfidentialClient(Func<string[], string, AuthenticationResult> factory)
        {
            _factory = factory;
        }

        public MockMsalConfidentialClient(Func<string[], string, AuthenticationAccount, AuthenticationResult> factory)
        {
            _silentFactory = factory;
        }

        public MockMsalConfidentialClient(Func<string[], string, string, AuthenticationResult> factory)
        {
            _authcodeFactory = factory;
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, string tenantId, bool async, CancellationToken cancellationToken)
        {
            return new(_factory(scopes, tenantId));
        }

        public override ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
            string[] scopes,
            AuthenticationAccount account,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            return new(_silentFactory(scopes, tenantId, account));
        }

        public override ValueTask<AuthenticationResult> AcquireTokenByAuthorizationCodeAsync(
            string[] scopes,
            string code,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            return new(_authcodeFactory(scopes, tenantId, code));
        }
    }
}
