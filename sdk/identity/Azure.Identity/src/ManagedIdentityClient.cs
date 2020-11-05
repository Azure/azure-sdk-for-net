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
        private readonly CredentialPipeline _pipeline;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
        {
            _pipeline = pipeline;
            ClientId = clientId;
        }

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

            ManagedIdentitySource identitySource = AppServiceV2017ManagedIdentitySource.TryCreate(_pipeline, ClientId) ??
                                                    CloudShellManagedIdentitySource.TryCreate(_pipeline, ClientId) ??
                                                    AzureArcManagedIdentitySource.TryCreate(_pipeline, ClientId) ??
                                                    ServiceFabricManagedIdentitySource.TryCreate(_pipeline, ClientId) ??
                                                    await ImdsManagedIdentitySource.TryCreateAsync(_pipeline, ClientId, async, cancellationToken).ConfigureAwait(false);

            asyncLock.SetValue(identitySource);
            return identitySource;
        }
    }
}
