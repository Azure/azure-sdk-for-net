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
        public IEnumerable<IAccount> Accounts { get; set; }

        public Func<string[], AuthenticationResult> AuthFactory { get; set; }

        public Func<string[], AuthenticationResult> UserPassAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> InteractiveAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> SilentAuthFactory { get; set; }

        public Func<string[], AuthenticationResult> DeviceCodeAuthFactory { get; set; }


        public override Task<IEnumerable<IAccount>> GetAccountsAsync()
        {
            return Task.FromResult(Accounts);
        }

        public override Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string username, SecureString password, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = UserPassAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return Task.FromResult(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, Prompt prompt, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = InteractiveAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return Task.FromResult(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, IAccount account, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return Task.FromResult(factory(scopes));
            }

            throw new NotImplementedException();
        }

        public override Task<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, Func<DeviceCodeResult, Task> deviceCodeCallback, CancellationToken cancellationToken)
        {
            Func<string[], AuthenticationResult> factory = DeviceCodeAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return Task.FromResult(factory(scopes));
            }

            throw new NotImplementedException();
        }
    }
}
