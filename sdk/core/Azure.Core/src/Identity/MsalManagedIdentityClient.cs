// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class MsalManagedIdentityClient
    {
        private readonly ConcurrentDictionary<(bool EnableCae, bool IsTokenBinding), AsyncLockWithValue<IManagedIdentityApplication>> _clientCache = new();
        private bool _isForceRefreshEnabled { get; }
        private readonly bool _disableMtlsProofOfPossession;
        private static readonly Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> s_withAttestationSupport = ResolveWithAttestationSupport();

        internal bool IsSupportLoggingEnabled { get; }
        internal Microsoft.Identity.Client.AppConfig.ManagedIdentityId ManagedIdentityId { get; }
        internal bool DisableInstanceDiscovery { get; }
        internal CredentialPipeline Pipeline { get; }
        internal Uri AuthorityHost { get; }
        protected string[] cp1Capabilities = ["CP1"];

        protected MsalManagedIdentityClient()
        { }

        public MsalManagedIdentityClient(ManagedIdentityClientOptions clientOptions)
        {
            // This validation is performed as a backstop. Validation in TokenCredentialOptions.AuthorityHost prevents users from explicitly
            // setting AuthorityHost to a non TLS endpoint. However, the AuthorityHost can also be set by the AZURE_AUTHORITY_HOST environment
            // variable rather than in code. In this case we need to validate the endpoint before we use it. However, we can't validate in
            // CredentialPipeline as this is also used by the ManagedIdentityCredential which allows non TLS endpoints. For this reason
            // we validate here as all other credentials will create an MSAL client.
            Validations.ValidateAuthorityHost(clientOptions?.Options?.AuthorityHost);
            AuthorityHost = clientOptions?.Options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault();
            IsSupportLoggingEnabled = clientOptions?.Options?.IsUnsafeSupportLoggingEnabled ?? false;

            // select the correct managed identity Id.
            ManagedIdentityId = clientOptions.ManagedIdentityId?._idType switch
            {
                ManagedIdentityIdType.SystemAssigned or null => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.SystemAssigned,
                ManagedIdentityIdType.ClientId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedClientId(clientOptions.ManagedIdentityId._userAssignedId),
                ManagedIdentityIdType.ResourceId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedResourceId(clientOptions.ManagedIdentityId._userAssignedId),
                ManagedIdentityIdType.ObjectId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedObjectId(clientOptions.ManagedIdentityId._userAssignedId),
                _ => throw new InvalidOperationException("Invalid ManagedIdentityIdType")
            };

            Pipeline = clientOptions.Pipeline;
            _isForceRefreshEnabled = clientOptions.IsForceRefreshEnabled;
            _disableMtlsProofOfPossession = clientOptions.DisableMtlsProofOfPossession;
        }

        private static Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> ResolveWithAttestationSupport()
        {
            const string managedIdentityAttestationExtensionTypeName = "Microsoft.Identity.Client.KeyAttestation.ManagedIdentityAttestationExtensions, Microsoft.Identity.Client.KeyAttestation";

            try
            {
                Type extensionType = Type.GetType(managedIdentityAttestationExtensionTypeName, throwOnError: false);

                MethodInfo withAttestationSupport = extensionType?.GetMethod(
                    "WithAttestationSupport",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: [typeof(AcquireTokenForManagedIdentityParameterBuilder)],
                    modifiers: null);

                return withAttestationSupport == null
                    ? null
                    : (Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder>)withAttestationSupport.CreateDelegate(typeof(Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder>));
            }
            catch
            {
                return null;
            }
        }

        protected ValueTask<IManagedIdentityApplication> CreateClientAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            return CreateClientCoreAsync(async, enableCae, isTokenBindingAvailable, cancellationToken);
        }

        protected virtual ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            string[] clientCapabilities =
                enableCae ? cp1Capabilities : Array.Empty<string>();

            ManagedIdentityApplicationBuilder miAppBuilder = ManagedIdentityApplicationBuilder
                .Create(ManagedIdentityId)
                .WithLogging(AzureIdentityEventSource.Singleton, enablePiiLogging: IsSupportLoggingEnabled);

            // When token binding (mTLS PoP) is enabled, MSAL must manage its own HTTP
            // client so it can perform the mTLS handshake with the platform's bound certificate.
            // The Azure.Core pipeline transport does not carry these mTLS credentials, so
            // WithHttpClientFactory is intentionally omitted in this path.
            if (!isTokenBindingAvailable)
            {
                miAppBuilder.WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline, Pipeline.ClientOptions), false);
            }

            if (clientCapabilities.Length > 0)
            {
                miAppBuilder.WithClientCapabilities(clientCapabilities);
            }

            return new ValueTask<IManagedIdentityApplication>(miAppBuilder.Build());
        }

        protected async ValueTask<IManagedIdentityApplication> GetClientAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            var key = (enableCae, isTokenBindingAvailable);
            var lockInstance = _clientCache.GetOrAdd(key, _ => new AsyncLockWithValue<IManagedIdentityApplication>());

            using var asyncLock = await lockInstance.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            var client = await CreateClientAsync(async, enableCae, isTokenBindingAvailable, cancellationToken).ConfigureAwait(false);
            asyncLock.SetValue(client);
            return client;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsync(TokenRequestContext requestContext, bool isTokenBindingAvailable, CancellationToken cancellationToken) =>
            await AcquireTokenForManagedIdentityAsyncCore(true, requestContext, isTokenBindingAvailable, cancellationToken).ConfigureAwait(false);

        public virtual AuthenticationResult AcquireTokenForManagedIdentity(TokenRequestContext requestContext, bool isTokenBindingAvailable, CancellationToken cancellationToken) =>
            AcquireTokenForManagedIdentityAsyncCore(false, requestContext, isTokenBindingAvailable, cancellationToken).EnsureCompleted();

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsyncCore(bool async, TokenRequestContext requestContext, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            IManagedIdentityApplication client = await GetClientAsync(async, requestContext.IsCaeEnabled, isTokenBindingAvailable, cancellationToken).ConfigureAwait(false);
            var builder = client.AcquireTokenForManagedIdentity(requestContext.Scopes.FirstOrDefault());

            if (!string.IsNullOrEmpty(requestContext.Claims))
            {
                builder.WithClaims(requestContext.Claims);
            }

            bool shouldEnableMtlsPop = !_disableMtlsProofOfPossession && requestContext.IsProofOfPossessionEnabled && isTokenBindingAvailable && s_withAttestationSupport != null;
            if (shouldEnableMtlsPop)
            {
                builder.WithMtlsProofOfPossession();
                AzureIdentityEventSource.Singleton.LogMsal(LogLevel.Verbose, "Managed identity token request configured with mTLS proof-of-possession.");
                builder = s_withAttestationSupport(builder);
            }

            if (_isForceRefreshEnabled)
            {
                builder.WithForceRefresh(true);
            }
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return async ?
                await builder.ExecuteAsync(cancellationToken).ConfigureAwait(false) :
                builder.ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        public virtual async ValueTask<Microsoft.Identity.Client.ManagedIdentity.ManagedIdentityCapabilities> GetManagedIdentityCapabilitiesAsync(TokenRequestContext context, CancellationToken cancellationToken)
        {
            // Keep honoring PoP request intent when selecting the cached MSAL MI app,
            // same behavior as GetManagedIdentitySourceAsync.
            IManagedIdentityApplication client = await GetClientAsync(true, context.IsCaeEnabled, context.IsProofOfPossessionEnabled, cancellationToken).ConfigureAwait(false);
            ManagedIdentityApplication app = client as ManagedIdentityApplication;
            return await app.GetManagedIdentityCapabilitiesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual ValueTask<Microsoft.Identity.Client.ManagedIdentity.ManagedIdentityCapabilities> GetManagedIdentityCapabilitiesCoreAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            return async
                ? GetManagedIdentityCapabilitiesAsync(context, cancellationToken)
                : new ValueTask<Microsoft.Identity.Client.ManagedIdentity.ManagedIdentityCapabilities>(GetManagedIdentityCapabilities(context, cancellationToken));
        }

        public virtual Microsoft.Identity.Client.ManagedIdentity.ManagedIdentityCapabilities GetManagedIdentityCapabilities(TokenRequestContext context, CancellationToken cancellationToken)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return GetManagedIdentityCapabilitiesAsync(context, cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }
    }
}
