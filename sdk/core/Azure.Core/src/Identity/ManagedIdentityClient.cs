// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using MSAL = Microsoft.Identity.Client.ManagedIdentity;

namespace Azure.Identity
{
    [UnsupportedOSPlatform("browser")]
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError =
            "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        internal Lazy<ManagedIdentitySource> _identitySource;
        private MsalConfidentialClient _msalConfidentialClient;
        private MsalManagedIdentityClient _msalManagedIdentityClient;
        private ManagedIdentitySource _tokenExchangeManagedIdentitySource;
        private bool _isChainedCredential;
        private ManagedIdentityClientOptions _options;
        private bool _probeRequestSent;

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
            _msalManagedIdentityClient = CreateMsalManagedIdentityClient(options);
            _identitySource = new Lazy<ManagedIdentitySource>(() => SelectManagedIdentitySource(options, _msalManagedIdentityClient));
            _msalConfidentialClient = new MsalConfidentialClient(
                Pipeline,
                "MANAGED-IDENTITY-RESOURCE-TENENT",
                options.ManagedIdentityId._idType != ManagedIdentityIdType.SystemAssigned ? options.ManagedIdentityId._userAssignedId : "SYSTEM-ASSIGNED-MANAGED-IDENTITY",
                AppTokenProviderImpl,
                options.Options);
        }

        protected virtual MsalManagedIdentityClient CreateMsalManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            return options.MsalManagedIdentityClientOverride ?? new MsalManagedIdentityClient(options);
        }

        internal CredentialPipeline Pipeline { get; }

        internal ManagedIdentityId ManagedIdentityId { get; }

        public async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            AuthenticationResult result;

            _tokenExchangeManagedIdentitySource ??= TokenExchangeManagedIdentitySource.TryCreate(_options);
            if (default != _tokenExchangeManagedIdentitySource)
            {
                return await _tokenExchangeManagedIdentitySource.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
            }

            MSAL.ManagedIdentitySource availableSource;
            bool isMtlsPopSupportedByHost = false;
            bool requiresManagedIdentityCapabilities = context.IsProofOfPossessionEnabled && !_options.DisableMtlsProofOfPossession;
            if (requiresManagedIdentityCapabilities)
            {
                MSAL.ManagedIdentityCapabilities capabilities;
                CancellationTokenSource capabilitiesTimeoutCts = null;
                try
                {
                    CancellationToken capabilitiesCancellationToken = cancellationToken;
                    if (_isChainedCredential && _options.InitialImdsConnectionTimeout.HasValue)
                    {
                        capabilitiesTimeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                        capabilitiesTimeoutCts.CancelAfter(_options.InitialImdsConnectionTimeout.Value);
                        capabilitiesCancellationToken = capabilitiesTimeoutCts.Token;
                    }

#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
                    capabilities = await _msalManagedIdentityClient.GetManagedIdentityCapabilitiesCoreAsync(async, context, capabilitiesCancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
                }
                catch (CredentialUnavailableException)
                {
                    throw;
                }
                catch (OperationCanceledException e) when (capabilitiesTimeoutCts?.IsCancellationRequested == true && !cancellationToken.IsCancellationRequested)
                {
                    AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(ImdsManagedIdentityProbeSource.GetImdsUri(), e);
                    throw new CredentialUnavailableException(MsiUnavailableError, e);
                }
                catch (Exception e) when (_isChainedCredential && e is not OperationCanceledException)
                {
                    AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(ImdsManagedIdentityProbeSource.GetImdsUri(), e);
                    throw new CredentialUnavailableException(MsiUnavailableError, e);
                }
                finally
                {
                    capabilitiesTimeoutCts?.Dispose();
                }

                availableSource = capabilities.Source;
                isMtlsPopSupportedByHost = capabilities.IsMtlsPopSupportedByHost;
            }
            else
            {
#pragma warning disable CS0618 // GetManagedIdentitySource is obsolete
                availableSource = ManagedIdentityApplication.GetManagedIdentitySource();
#pragma warning restore CS0618
            }

            AzureIdentityEventSource.Singleton.ManagedIdentityCredentialSelected(availableSource.ToString(), _options.ManagedIdentityId.ToString());

            // MSAL versions report either DefaultToImds or None when no environment-based source is configured.
            // For ordinary chained requests, both mean that Azure.Core should use its bounded IMDS probe.
#pragma warning disable CS0618 // DefaultToImds is obsolete but still returned by the sync GetManagedIdentitySource path
            bool shouldProbeImds = availableSource == MSAL.ManagedIdentitySource.DefaultToImds ||
                availableSource == MSAL.ManagedIdentitySource.Imds ||
                (!requiresManagedIdentityCapabilities && availableSource == MSAL.ManagedIdentitySource.None);
#pragma warning restore CS0618
            if (shouldProbeImds && _isChainedCredential && !_probeRequestSent)
            {
                var probedFlowTokenResult = await AuthenticateCoreAsync(async, context, cancellationToken).ConfigureAwait(false);
                _probeRequestSent = true;
                return probedFlowTokenResult;
            }

            // ServiceFabric does not support specifying user-assigned managed identity by client ID or resource ID. The managed identity selected is based on the resource configuration.
            if (availableSource == MSAL.ManagedIdentitySource.ServiceFabric && (ManagedIdentityId?._idType != ManagedIdentityIdType.SystemAssigned))
            {
                throw new AuthenticationFailedException(Constants.MiSeviceFabricNoUserAssignedIdentityMessage);
            }

            try
            {
                // The default case is to use the MSAL implementation, which does no probing of the IMDS endpoint.
                result = async ?
                    await _msalManagedIdentityClient.AcquireTokenForManagedIdentityAsync(context, isMtlsPopSupportedByHost, cancellationToken).ConfigureAwait(false) :
                    _msalManagedIdentityClient.AcquireTokenForManagedIdentity(context, isMtlsPopSupportedByHost, cancellationToken);
            }
            // If the IMDS endpoint is not available, we will throw a CredentialUnavailableException.
            catch (MsalServiceException ex) when (HasInnerExceptionMatching(ex, e => e is RequestFailedException && e.Message.Contains("timed out")))
            {
                // If the managed identity is not found, throw a more specific exception.
                throw new CredentialUnavailableException(MsiUnavailableError, ex);
            }
            // MSAL reports that every managed identity source was probed and none is available (for example, on a
            // developer machine with no managed identity configured). When chained, surface a CredentialUnavailableException
            // so DefaultAzureCredential continues to the next credential instead of aborting the chain.
            catch (MsalException ex) when (_isChainedCredential && ex.ErrorCode == MsalError.ManagedIdentityAllSourcesUnavailable)
            {
                AzureIdentityEventSource.Singleton.ManagedIdentitySourcesUnavailable(ex);
                throw new CredentialUnavailableException(MsiUnavailableError, ex);
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

        private static ManagedIdentitySource SelectManagedIdentitySource(ManagedIdentityClientOptions options, MsalManagedIdentityClient client = null)
        {
            return TokenExchangeManagedIdentitySource.TryCreate(options) ??
            new ImdsManagedIdentityProbeSource(options, client);
        }

        private static bool HasInnerExceptionMatching(Exception exception, Func<Exception, bool> condition)
        {
            var current = exception;
            while (current != null)
            {
                if (condition(current))
                {
                    return true;
                }
                current = current.InnerException;
            }
            return false;
        }
    }
}
