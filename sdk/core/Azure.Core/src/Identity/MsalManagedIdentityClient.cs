// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Concurrent;
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
        // Keep these as contract strings because KeyAttestation is an optional package.
        // Referencing its types/members with typeof/nameof would reintroduce compile-time coupling.
        private const string ManagedIdentityAttestationExtensionTypeName = "Microsoft.Identity.Client.KeyAttestation.ManagedIdentityAttestationExtensions, Microsoft.Identity.Client.KeyAttestation";
        private const string WithAttestationSupportMethodName = "WithAttestationSupport";
        private static readonly string[] s_cp1Capabilities = ["CP1"];

        private readonly ConcurrentDictionary<(bool EnableCae, bool IsTokenBinding), AsyncLockWithValue<IManagedIdentityApplication>> _clientCache = new();
        private readonly bool _isForceRefreshEnabled;
        private readonly bool _disableMtlsProofOfPossession;
        private static readonly Lazy<Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder>> s_withAttestationSupport =
            new(ResolveWithAttestationSupport, LazyThreadSafetyMode.ExecutionAndPublication);

        internal bool IsSupportLoggingEnabled { get; }
        internal Microsoft.Identity.Client.AppConfig.ManagedIdentityId ManagedIdentityId { get; }
        internal bool DisableInstanceDiscovery { get; }
        internal CredentialPipeline Pipeline { get; }
        internal Uri AuthorityHost { get; }

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
            if (!TryCreateWithAttestationSupport(out Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> withAttestationSupport))
            {
                return null;
            }

            return withAttestationSupport;
        }

        private static bool TryCreateWithAttestationSupport(out Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> withAttestationSupport)
        {
            withAttestationSupport = null;

            try
            {
                // Use Type.GetType and MethodInfo because they can be analyzed by the ILLinker and are
                // AOT friendly.
                Type extensionType = Type.GetType(ManagedIdentityAttestationExtensionTypeName, throwOnError: false);
                if (extensionType == null)
                {
                    return false;
                }

                MethodInfo extensionMethod = extensionType.GetMethod(
                    WithAttestationSupportMethodName,
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: [typeof(AcquireTokenForManagedIdentityParameterBuilder)],
                    modifiers: null);

                if (extensionMethod == null)
                {
                    return false;
                }

                withAttestationSupport = (Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder>)extensionMethod.CreateDelegate(typeof(Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder>));
                return true;
            }
            catch (Exception ex)
            {
                AzureIdentityEventSource.Singleton.LogMsalInformational(
                    $"Exception occurred while resolving managed identity attestation extension: {ex.Message}");
                return false;
            }
        }

        protected ValueTask<IManagedIdentityApplication> CreateClientAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            return CreateClientCoreAsync(async, enableCae, isTokenBindingAvailable, cancellationToken);
        }

        protected virtual ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            string[] clientCapabilities =
                enableCae ? s_cp1Capabilities : Array.Empty<string>();

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

            if (ShouldAttemptMtlsPop(requestContext, isTokenBindingAvailable))
            {
                var withAttestationSupport = s_withAttestationSupport.Value;
                if (withAttestationSupport != null)
                {
                    builder.WithMtlsProofOfPossession();
                    AzureIdentityEventSource.Singleton.LogMsal(LogLevel.Verbose, "Managed identity token request configured with mTLS proof-of-possession.");
                    builder = withAttestationSupport(builder);
                }
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

        private bool ShouldAttemptMtlsPop(TokenRequestContext requestContext, bool isTokenBindingAvailable) =>
            !_disableMtlsProofOfPossession &&
            requestContext.IsProofOfPossessionEnabled &&
            isTokenBindingAvailable;
    }
}
