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
        internal Func<string[], string, string, bool, AuthenticationResult> ClientFactory { get; set; }
        internal Func<string[], AuthenticationAccount, string, string, string, bool, ValueTask<AuthenticationResult>> SilentFactory { get; set; }
        internal Func<string[], string, string, string, string, bool, AuthenticationResult> AuthcodeFactory { get; set; }
        internal Func<string[], string, UserAssertion, string, bool, bool, CancellationToken, ValueTask<AuthenticationResult>> OnBehalfOfFactory { get; set; }
        public Func<bool, IConfidentialClientApplication> ClientAppFactory { get; set; }

        public MockMsalConfidentialClient()
        { }

        public MockMsalConfidentialClient(CredentialPipeline pipeline, string tenantId, string clientId, string clientSecret, string redirectUrl, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, clientSecret, redirectUrl, options)
        { }

        public MockMsalConfidentialClient(AuthenticationResult result)
        {
            ClientFactory = (_, _, _, _) => result;
            SilentFactory = (_, _, _, _, _, _) => new ValueTask<AuthenticationResult>(result);
            AuthcodeFactory = (_, _, _, _, _, _) => result;
            OnBehalfOfFactory = (_, _, _, _, _, _, _) => new ValueTask<AuthenticationResult>(result);
        }

        public MockMsalConfidentialClient(Exception exception)
        {
            ClientFactory = (_, _, _, _) => throw exception;
            SilentFactory = (_, _, _, _, _, _) => throw exception;
            AuthcodeFactory = (_, _, _, _, _, _) => throw exception;
            OnBehalfOfFactory = (_, _, _, _, _, _, _) => throw exception;
        }

        public MockMsalConfidentialClient WithClientFactory(Func<string[], string, string, bool, AuthenticationResult> clientFactory)
        {
            ClientFactory = clientFactory;
            return this;
        }

        public MockMsalConfidentialClient WithSilentFactory(Func<string[], AuthenticationAccount, string, string, string, bool, ValueTask<AuthenticationResult>> factory)
        {
            SilentFactory = factory;
            return this;
        }

        public MockMsalConfidentialClient WithAuthCodeFactory(Func<string[], string, string, string, string, bool, AuthenticationResult> factory)
        {
            AuthcodeFactory = factory;
            return this;
        }

        public MockMsalConfidentialClient WithOnBehalfOfFactory(
            Func<string[], string, UserAssertion, string, bool, bool, CancellationToken, ValueTask<AuthenticationResult>> onBehalfOfFactory)
        {
            OnBehalfOfFactory = onBehalfOfFactory;
            return this;
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForClientCoreAsync(
            string[] scopes,
            string tenantId,
            string claims,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            return new(ClientFactory(scopes, tenantId, claims, enableCae));
        }

        public override async ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            AuthenticationAccount account,
            string tenantId,
            string replyUri,
            string claims,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            return await SilentFactory(scopes, account, tenantId, replyUri, claims, enableCae);
        }

        public override ValueTask<AuthenticationResult> AcquireTokenByAuthorizationCodeCoreAsync(
            string[] scopes,
            string code,
            string tenantId,
            string replyUri,
            string claims,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            return new(AuthcodeFactory(scopes, code, tenantId, replyUri, claims, enableCae));
        }

        public override async ValueTask<AuthenticationResult> AcquireTokenOnBehalfOfCoreAsync(
            string[] scopes,
            string tenantId,
            UserAssertion userAssertionValue,
            string claims,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            return await OnBehalfOfFactory(scopes, tenantId, userAssertionValue, claims, enableCae, async, cancellationToken);
        }

        internal ValueTask<IConfidentialClientApplication> CallCreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return CreateClientAsync(enableCae, async, cancellationToken);
        }

        internal ValueTask<IConfidentialClientApplication> CallBaseGetClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return GetClientAsync(enableCae, async, cancellationToken);
        }

        protected override ValueTask<IConfidentialClientApplication> CreateClientCoreAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            if (ClientAppFactory == null)
            {
                return base.CreateClientCoreAsync(enableCae, async, cancellationToken);
            }

            return new ValueTask<IConfidentialClientApplication>(ClientAppFactory(enableCae));
        }
    }
}
