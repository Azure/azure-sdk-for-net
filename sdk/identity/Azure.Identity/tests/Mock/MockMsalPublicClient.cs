// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
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

        public Func<string[], AuthenticationResult> InteractiveAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> SilentAuthFactory { get; set; }

        public Func<string[], IAccount, bool, CancellationToken, AuthenticationResult> ExtendedSilentAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> DeviceCodeAuthFactory { get; set; }

        public override ValueTask<List<IAccount>> GetAccountsAsync(bool async, CancellationToken cancellationToken)
        {
            return new ValueTask<List<IAccount>>(Accounts);
        }

        public override ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string claims, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = UserPassAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override ValueTask<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, string claims, Prompt prompt, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = InteractiveAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, IAccount account, bool async, CancellationToken cancellationToken)
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

        public override ValueTask<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, string claims, AuthenticationRecord record, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, string claims, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = DeviceCodeAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes));
            }

            throw new NotImplementedException();
        }
    }
}
