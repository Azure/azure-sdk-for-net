// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class MsalPublicClient
    {
        private readonly IPublicClientApplication _client;
        private readonly MsalCacheReader _cacheReader;

        protected MsalPublicClient()
        {
        }

        public MsalPublicClient(HttpPipeline pipeline, string clientId, string tenantId = default, string redirectUrl = default, bool attachSharedCache = false)
        {
            PublicClientApplicationBuilder pubAppBuilder = PublicClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(pipeline));

            tenantId ??= Constants.OrganizationsTenantId;

            pubAppBuilder = pubAppBuilder.WithTenantId(tenantId);

            if (!string.IsNullOrEmpty(redirectUrl))
            {
                pubAppBuilder = pubAppBuilder.WithRedirectUri(redirectUrl);
            }

            _client = pubAppBuilder.Build();

            if (attachSharedCache)
            {
                _cacheReader = new MsalCacheReader(_client.UserTokenCache, Constants.SharedTokenCacheFilePath, Constants.SharedTokenCacheAccessRetryCount, Constants.SharedTokenCacheAccessRetryDelay);
            }
        }

        public virtual async Task<IEnumerable<IAccount>> GetAccountsAsync()
        {
            return await _client.GetAccountsAsync().ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes, IAccount account, bool async, CancellationToken cancellationToken)
        {
            return await _client.AcquireTokenSilent(scopes, account).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes, Prompt prompt, bool async, CancellationToken cancellationToken)
        {
            return await _client.AcquireTokenInteractive(scopes).WithPrompt(prompt).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenByUsernamePasswordAsync(string[] scopes, string username, SecureString password, bool async, CancellationToken cancellationToken)
        {
            return await _client.AcquireTokenByUsernamePassword(scopes, username, password).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<AuthenticationResult> AcquireTokenWithDeviceCodeAsync(string[] scopes, Func<DeviceCodeResult, Task> deviceCodeCallback, bool async, CancellationToken cancellationToken)
        {
            return await _client.AcquireTokenWithDeviceCode(scopes, deviceCodeCallback).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }
    }
}
