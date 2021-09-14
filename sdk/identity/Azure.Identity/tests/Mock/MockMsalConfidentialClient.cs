﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalConfidentialClient : MsalConfidentialClient
    {
        internal Func<string[], string, AuthenticationResult> ClientFactory { get; set; }
        internal Func<string[], string, string, AuthenticationAccount, ValueTask<AuthenticationResult>> SilentFactory { get; set; }
        internal Func<string[], string, string, string, AuthenticationResult> AuthcodeFactory { get; set; }
        internal Func<string[], string, UserAssertion, bool, CancellationToken, ValueTask<AuthenticationResult>> OnBehalfOfFactory { get; set; }

        public MockMsalConfidentialClient()
        { }

        public MockMsalConfidentialClient(AuthenticationResult result)
        {
            ClientFactory = (_, _) => result;
            SilentFactory = (_, _, _, _) => new ValueTask<AuthenticationResult>(result);
            AuthcodeFactory = (_, _, _, _) => result;
            OnBehalfOfFactory = (_, _, _, _, _) => new ValueTask<AuthenticationResult>(result);
        }

        public MockMsalConfidentialClient(Exception exception)
        {
            ClientFactory = (_, _) => throw exception;
            SilentFactory = (_, _, _, _) => throw exception;
            AuthcodeFactory = (_, _, _, _) => throw exception;
            OnBehalfOfFactory = (_, _, _, _, _) => throw exception;
        }

        public MockMsalConfidentialClient WithClientFactory(Func<string[], string, AuthenticationResult> clientFactory)
        {
            ClientFactory = clientFactory;
            return this;
        }

        public MockMsalConfidentialClient WithSilentFactory(Func<string[], string, string, AuthenticationAccount, ValueTask<AuthenticationResult>> factory)
        {
            SilentFactory = factory;
            return this;
        }

        public MockMsalConfidentialClient WithAuthCodeFactory(Func<string[], string, string, string, AuthenticationResult> factory)
        {
            AuthcodeFactory = factory;
            return this;
        }

        public MockMsalConfidentialClient WithOnBehalfOfFactory(
            Func<string[], string, UserAssertion, bool, CancellationToken, ValueTask<AuthenticationResult>> onBehalfOfFactory)
        {
            OnBehalfOfFactory = onBehalfOfFactory;
            return this;
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, string tenantId, bool async, CancellationToken cancellationToken)
        {
            return new(ClientFactory(scopes, tenantId));
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

        public override async ValueTask<AuthenticationResult> AcquireTokenOnBehalfOf(
            string[] scopes,
            string tenantId,
            UserAssertion userAssertionValue,
            bool async,
            CancellationToken cancellationToken)
        {
            return await OnBehalfOfFactory(scopes, tenantId, userAssertionValue, async, cancellationToken);
        }
    }
}
