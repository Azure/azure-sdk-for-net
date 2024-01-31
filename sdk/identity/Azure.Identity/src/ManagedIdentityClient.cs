// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError =
            "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        internal Lazy<ManagedIdentitySource> _identitySource;
        private MsalConfidentialClient _msal;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions {Pipeline = pipeline, ClientId = clientId})
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, ResourceIdentifier resourceId)
            : this(new ManagedIdentityClientOptions {Pipeline = pipeline, ResourceIdentifier = resourceId})
        {
        }

        public ManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            if (options.ClientId != null && options.ResourceIdentifier != null)
            {
                throw new ArgumentException(
                    $"{nameof(ManagedIdentityClientOptions)} cannot specify both {nameof(options.ResourceIdentifier)} and {nameof(options.ClientId)}.");
            }

            ClientId = string.IsNullOrEmpty(options.ClientId) ? null : options.ClientId;
            ResourceIdentifier = string.IsNullOrEmpty(options.ResourceIdentifier) ? null : options.ResourceIdentifier;
            Pipeline = options.Pipeline;
            _identitySource = new Lazy<ManagedIdentitySource>(() => SelectManagedIdentitySource(options));
            _msal = new MsalConfidentialClient(Pipeline, "MANAGED-IDENTITY-RESOURCE-TENENT", ClientId ?? "SYSTEM-ASSIGNED-MANAGED-IDENTITY", AppTokenProviderImpl, options.Options);
        }

        internal CredentialPipeline Pipeline { get; }

        internal protected string ClientId { get; }

        internal ResourceIdentifier ResourceIdentifier { get; }

        public async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await _msal.AcquireTokenForClientAsync(context.Scopes, context.TenantId, context.Claims, context.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }

        public virtual async ValueTask<AccessToken> AuthenticateCoreAsync(bool async, TokenRequestContext context,
            CancellationToken cancellationToken)
        {
            return await _identitySource.Value.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
        }

        private async Task<AppTokenProviderResult> AppTokenProviderImpl(AppTokenProviderParameters parameters)
        {
            TokenRequestContext requestContext = new TokenRequestContext(parameters.Scopes.ToArray(), claims: parameters.Claims);

            AccessToken token = await AuthenticateCoreAsync(true, requestContext, parameters.CancellationToken).ConfigureAwait(false);

            return new AppTokenProviderResult() { AccessToken = token.Token, ExpiresInSeconds = Math.Max(Convert.ToInt64((token.ExpiresOn - DateTimeOffset.UtcNow).TotalSeconds), 1) };
        }

        private static ManagedIdentitySource SelectManagedIdentitySource(ManagedIdentityClientOptions options)
        {
            return
                ServiceFabricManagedIdentitySource.TryCreate(options) ??
                AppServiceV2019ManagedIdentitySource.TryCreate(options) ??
                AppServiceV2017ManagedIdentitySource.TryCreate(options) ??
                CloudShellManagedIdentitySource.TryCreate(options) ??
                AzureArcManagedIdentitySource.TryCreate(options) ??
                TokenExchangeManagedIdentitySource.TryCreate(options) ??
                new ImdsManagedIdentitySource(options);
        }
    }
}
