// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal abstract class MsalPublicClientAbstraction
    {
        public abstract Task<IEnumerable<IAccount>> GetAccountsAsync();

        public abstract Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, IAccount account, CancellationToken cancellationToken);

        public abstract Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, Prompt prompt, CancellationToken cancellationToken);

        public abstract Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string username, SecureString password, CancellationToken cancellationToken);

        public abstract Task<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, Func<DeviceCodeResult, Task> deviceCodeCallback, CancellationToken cancellationToken);
    }
}
