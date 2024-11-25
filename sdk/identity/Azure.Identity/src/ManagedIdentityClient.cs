﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using MSAL = Microsoft.Identity.Client.ManagedIdentity;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError =
            "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        internal Lazy<ManagedIdentitySource> _identitySource;
        private MsalConfidentialClient _msalConfidentialClient;
        private MsalManagedIdentityClient _msalManagedIdentityClient;
        private bool _isChainedCredential;
        private ManagedIdentityClientOptions _options;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ManagedIdentityId = string.IsNullOrEmpty(clientId) ? ManagedIdentityId.SystemAssigned : ManagedIdentityId.FromUserAssignedClientId(clientId) })
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, ResourceIdentifier resourceId)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ManagedIdentityId = ManagedIdentityId.FromUserAssignedResourceId(resourceId) })
        {
        }

        public ManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            _options = options.Clone();
            ManagedIdentityId = options.ManagedIdentityId;
            Pipeline = options.Pipeline;
            _isChainedCredential = options.Options?.IsChainedCredential ?? false;
            _msalManagedIdentityClient = new MsalManagedIdentityClient(options);
            _identitySource = new Lazy<ManagedIdentitySource>(() => SelectManagedIdentitySource(options, _msalManagedIdentityClient));
            _msalConfidentialClient = new MsalConfidentialClient(
                Pipeline,
                "MANAGED-IDENTITY-RESOURCE-TENENT",
                options.ManagedIdentityId._idType != ManagedIdentityIdType.SystemAssigned ? options.ManagedIdentityId._userAssignedId : "SYSTEM-ASSIGNED-MANAGED-IDENTITY",
                AppTokenProviderImpl,
                options.Options);
        }

        internal CredentialPipeline Pipeline { get; }

        internal ManagedIdentityId ManagedIdentityId { get; }

        public async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            AuthenticationResult result;

            var availableSource = ManagedIdentityApplication.GetManagedIdentitySource();

            // If the source is DefaultToImds and the credential is chained, we should probe the IMDS endpoint first.
            if (availableSource == MSAL.ManagedIdentitySource.DefaultToImds && _isChainedCredential)
            {
                return await AuthenticateCoreAsync(async, context, cancellationToken).ConfigureAwait(false);
            }

            // ServiceFabric does not support specifying user-assigned managed identity by client ID or resource ID. The managed identity selected is based on the resource configuration.
            if (availableSource == MSAL.ManagedIdentitySource.ServiceFabric && (ManagedIdentityId?._idType != ManagedIdentityIdType.SystemAssigned))
            {
                throw new AuthenticationFailedException(Constants.MiSeviceFabricNoUserAssignedIdentityMessage);
            }

            // First try the TokenExchangeManagedIdentitySource, if it is not available, fall back to MSAL directly.
            var tokenExchangeManagedIdentitySource = TokenExchangeManagedIdentitySource.TryCreate(_options);
            if (default != tokenExchangeManagedIdentitySource)
            {
                return await tokenExchangeManagedIdentitySource.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
            }

            // The default case is to use the MSAL implementation, which does no probing of the IMDS endpoint.
            result = async ?
                await _msalManagedIdentityClient.AcquireTokenForManagedIdentityAsync(context, cancellationToken).ConfigureAwait(false) :
                _msalManagedIdentityClient.AcquireTokenForManagedIdentity(context, cancellationToken);

            return result.ToAccessToken();
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

            var resfreshOn = ManagedIdentitySource.InferManagedIdentityRefreshInValue(token.ExpiresOn);
            long? refreshInSeconds = resfreshOn switch
            {
                not null => Math.Max(Convert.ToInt64((resfreshOn.Value - DateTimeOffset.UtcNow).TotalSeconds), 1),
                _ => null
            };

            return new AppTokenProviderResult()
            {
                AccessToken = token.Token,
                ExpiresInSeconds = Math.Max(Convert.ToInt64((token.ExpiresOn - DateTimeOffset.UtcNow).TotalSeconds), 1),
                RefreshInSeconds = refreshInSeconds
            };
        }

        private static ManagedIdentitySource SelectManagedIdentitySource(ManagedIdentityClientOptions options, MsalManagedIdentityClient client = null)
        {
            return TokenExchangeManagedIdentitySource.TryCreate(options) ??
            new ImdsManagedIdentityProbeSource(options, client);
        }
    }
}
