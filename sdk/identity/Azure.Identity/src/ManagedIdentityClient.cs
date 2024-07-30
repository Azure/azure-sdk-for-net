// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private bool _enableLegacyMI;
        private bool _isChainedCredential;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId })
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, ResourceIdentifier resourceId)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ResourceIdentifier = resourceId })
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
            _enableLegacyMI = options.EnableManagedIdentityLegacyBehavior;
            _isChainedCredential = options.Options?.IsChainedCredential ?? false;
            _msalManagedIdentityClient = new MsalManagedIdentityClient(options);
            _identitySource = new Lazy<ManagedIdentitySource>(() => SelectManagedIdentitySource(options, _enableLegacyMI, _msalManagedIdentityClient));
            _msalConfidentialClient = new MsalConfidentialClient(Pipeline, "MANAGED-IDENTITY-RESOURCE-TENENT", ClientId ?? "SYSTEM-ASSIGNED-MANAGED-IDENTITY", AppTokenProviderImpl, options.Options);
        }

        internal CredentialPipeline Pipeline { get; }

        internal protected string ClientId { get; }

        internal ResourceIdentifier ResourceIdentifier { get; }

        public async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            AuthenticationResult result;
            if (_enableLegacyMI)
            {
                result = await _msalConfidentialClient.AcquireTokenForClientAsync(context.Scopes, context.TenantId, context.Claims, context.IsCaeEnabled, async, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var availableSource = ManagedIdentityApplication.GetManagedIdentitySource();

                // If the source is DefaultToImds and the credential is chained, we should probe the IMDS endpoint first.
                if (availableSource == MSAL.ManagedIdentitySource.DefaultToImds && _isChainedCredential)
                {
                    return await AuthenticateCoreAsync(async, context, cancellationToken).ConfigureAwait(false);
                }

                // ServiceFabric does not support specifying user-assigned managed identity by client ID or resource ID. The managed identity selected is based on the resource configuration.
                if (availableSource == MSAL.ManagedIdentitySource.ServiceFabric && (ResourceIdentifier != null || ClientId != null))
                {
                    throw new AuthenticationFailedException(Constants.MiSeviceFabricNoUserAssignedIdentityMessage);
                }

                // The default case is to use the MSAL implementation, which does no probing of the IMDS endpoint.
                result = async ?
                    await _msalManagedIdentityClient.AcquireTokenForManagedIdentityAsync(context, cancellationToken).ConfigureAwait(false) :
                    _msalManagedIdentityClient.AcquireTokenForManagedIdentity(context, cancellationToken);
            }
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

        private static ManagedIdentitySource SelectManagedIdentitySource(ManagedIdentityClientOptions options, bool _enableLegacyMI = true, MsalManagedIdentityClient client = null)
        {
            if (_enableLegacyMI)
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
            else
            {
                return TokenExchangeManagedIdentitySource.TryCreate(options) ??
                new ImdsManagedIdentityProbeSource(options, client);
            }
        }
    }
}
