// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        private readonly AsyncLockWithValue<ManagedIdentitySource> _identitySourceAsyncLock = new AsyncLockWithValue<ManagedIdentitySource>();
        private readonly ManagedIdentityClientOptions _options;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId})
        {
        }

        public ManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            _options = options;
            ClientId = options.ClientId;
            Pipeline = options.Pipeline;
        }

        internal CredentialPipeline Pipeline { get; }

        protected string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            ManagedIdentitySource identitySource = await GetManagedIdentitySourceAsync(async, cancellationToken).ConfigureAwait(false);

            // if msi is unavailable or we were unable to determine the type return CredentialUnavailable exception that no endpoint was found
            if (identitySource == default)
            {
                throw new CredentialUnavailableException(MsiUnavailableError);
            }

            return await identitySource.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
        }

        private protected virtual async ValueTask<ManagedIdentitySource> GetManagedIdentitySourceAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _identitySourceAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            ManagedIdentitySource identitySource = AppServiceV2017ManagedIdentitySource.TryCreate(_options) ??
                                                    CloudShellManagedIdentitySource.TryCreate(_options) ??
                                                    AzureArcManagedIdentitySource.TryCreate(_options) ??
                                                    ServiceFabricManagedIdentitySource.TryCreate(_options) ??
                                                    await ImdsManagedIdentitySource.TryCreateAsync(_options, async, cancellationToken).ConfigureAwait(false);

            asyncLock.SetValue(identitySource);
            return identitySource;
        }
    }
}
