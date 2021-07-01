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
        internal Func<string[], AuthenticationResult> ClientFactory { get; set; }
        internal Func<string[], string, string, AuthenticationAccount, ValueTask<AuthenticationResult>> SilentFactory  { get; set; }
        internal Func<string[], string, string, string, AuthenticationResult> AuthcodeFactory { get; set; }

        public MockMsalConfidentialClient(AuthenticationResult result)
        {
            ClientFactory = (_) => result;
            AuthcodeFactory = (_, _, _, _) => result;
        }

        public MockMsalConfidentialClient(Exception exception)
        {
            ClientFactory = (_) => throw exception;
            SilentFactory = (_, _, _, _) => throw exception;
            AuthcodeFactory = (_, _, _, _) => throw exception;
        }

        public MockMsalConfidentialClient(Func<string[], AuthenticationResult> clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public MockMsalConfidentialClient(Func<string[], string, string, AuthenticationAccount, ValueTask<AuthenticationResult>> factory)
        {
            SilentFactory = factory;
        }

        public MockMsalConfidentialClient(Func<string[], string, string, string, AuthenticationResult> factory)
        {
            AuthcodeFactory = factory;
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            return new(ClientFactory(scopes));
        }

        public override async ValueTask<AuthenticationResult> AcquireTokenSilentAsync(
            string[] scopes,
            AuthenticationAccount account,
            string tenantId,
            string replyUri,
            bool async,
            CancellationToken cancellationToken)
        {
            return await SilentFactory(scopes, tenantId, replyUri, account);
        }

        public override ValueTask<AuthenticationResult> AcquireTokenByAuthorizationCodeAsync(
            string[] scopes,
            string code,
            string tenantId,
            string replyUri,
            bool async,
            CancellationToken cancellationToken)
        {
            return new(AuthcodeFactory(scopes, tenantId, replyUri, code));
        }
    }
}
