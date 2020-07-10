// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Azure.Identity
{
    internal class MsalConfidentialClient
    {
        private IConfidentialClientApplication _client;
        private readonly MsalConfidentialClientOptions _options;
        private readonly Lazy<Task> _ensureInitAsync;

        protected MsalConfidentialClient()
        {
        }


        public MsalConfidentialClient(MsalConfidentialClientOptions options)
        {
            _options = options;

            _ensureInitAsync = new Lazy<Task>(InitializeAsync);
        }

        private async Task InitializeAsync()
        {
            ConfidentialClientApplicationBuilder confClientBuilder = ConfidentialClientApplicationBuilder.Create(_options.ClientId).WithAuthority(_options.AuthorityHost.AbsoluteUri, _options.TenantId).WithHttpClientFactory(new HttpPipelineClientFactory(_options.Pipeline.HttpPipeline));

            if (_options.Secret != null)
            {
                confClientBuilder.WithClientSecret(_options.Secret);
            }

            if (_options.CertificateProvider != null)
            {
                X509Certificate2 clientCertificate = await _options.CertificateProvider.GetCertificateAsync(true, default).ConfigureAwait(false);

                confClientBuilder.WithCertificate(clientCertificate);
            }

            _client = confClientBuilder.Build();

            if (_options.AttachSharedCache)
            {
                StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(Constants.DefaultMsalTokenCacheName, Constants.DefaultMsalTokenCacheDirectory, _options.ClientId)
                    .WithMacKeyChain(Constants.DefaultMsalTokenCacheKeychainService, Constants.DefaultMsalTokenCacheKeychainAccount)
                    .WithLinuxKeyring(Constants.DefaultMsalTokenCacheKeyringSchema, Constants.DefaultMsalTokenCacheKeyringCollection, Constants.DefaultMsalTokenCacheKeyringLabel, Constants.DefaultMsaltokenCacheKeyringAttribute1, Constants.DefaultMsaltokenCacheKeyringAttribute2)
                    .Build();

                MsalCacheHelper cacheHelper = await MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false);

                cacheHelper.RegisterCache(_client.UserTokenCache);
            }
        }

        private async ValueTask EnsureInitializedAsync(bool async)
        {
            if (async)
            {
                await _ensureInitAsync.Value.ConfigureAwait(false);
            }
            else
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _ensureInitAsync.Value.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }
        }

        public virtual async Task<AuthenticationResult> AcquireTokenForClientAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            await EnsureInitializedAsync(async).ConfigureAwait(false);

            return await _client.AcquireTokenForClient(scopes).ExecuteAsync(async, cancellationToken).ConfigureAwait(false);
        }
    }
}
