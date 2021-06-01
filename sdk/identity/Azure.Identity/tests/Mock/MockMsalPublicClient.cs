// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalPublicClient : MsalPublicClient
    {
        public List<IAccount> Accounts { get; set; }

        public Func<string[], AuthenticationResult> AuthFactory { get; set; }

        public Func<string[], AuthenticationResult> UserPassAuthFactory { get; set; }

        public Func<string[], string, Prompt, string, bool, CancellationToken, AuthenticationResult> InteractiveAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> SilentAuthFactory { get; set; }

        public Func<string[], IAccount, bool, CancellationToken, AuthenticationResult> ExtendedSilentAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> DeviceCodeAuthFactory { get; set; }

        public Func<string[], IPublicClientApplication> PubClientAppFactory { get; set; }

        protected override ValueTask<List<IAccount>> GetAccountsCoreAsync(bool async, CancellationToken cancellationToken)
        {
            return new(Accounts);
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordCoreAsync(string[] scopes, string claims, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = UserPassAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenInteractiveCoreAsync(string[] scopes, string claims, Prompt prompt, string loginHint, bool async, CancellationToken cancellationToken)
        {
            var interactiveAuthFactory = InteractiveAuthFactory;
            var authFactory = AuthFactory;

            if (interactiveAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(interactiveAuthFactory(scopes, claims, prompt, loginHint, async, cancellationToken));
            }
            if (authFactory != null)
            {
                return new ValueTask<AuthenticationResult>(authFactory(scopes));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(string[] scopes, string claims, IAccount account, bool async, CancellationToken cancellationToken)
        {
            if (ExtendedSilentAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(ExtendedSilentAuthFactory(scopes, account, async, cancellationToken));
            }

            Func<string[], AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(string[] scopes, string claims, AuthenticationRecord record, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeCoreAsync(string[] scopes, string claims, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = DeviceCodeAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        internal ValueTask<IPublicClientApplication> CallCreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            return CreateClientAsync(async, cancellationToken);
        }

        protected override ValueTask<IPublicClientApplication> CreateClientCoreAsync(string[] clientCapabilities, bool async, CancellationToken cancellationToken)
        {
            if (PubClientAppFactory == null)
            {
                throw new NotImplementedException();
            }

            return new ValueTask<IPublicClientApplication>(PubClientAppFactory(clientCapabilities));
        }
    }
}
