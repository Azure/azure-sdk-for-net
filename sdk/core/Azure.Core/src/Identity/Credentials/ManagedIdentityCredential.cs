// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Attempts authentication using a managed identity that has been assigned to the deployment environment. This authentication type works for all Azure-hosted
    /// environments that support managed identity. For end-to-end guidance, see <see href="https://learn.microsoft.com/dotnet/azure/sdk/authentication/user-assigned-managed-identity">user-assigned managed identity</see>
    /// or <see href="https://learn.microsoft.com/dotnet/azure/sdk/authentication/system-assigned-managed-identity">system-assigned managed identity</see>.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [UnsupportedOSPlatform("browser")]
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public class ManagedIdentityCredential : TokenCredential
    {
        internal const string MsiUnavailableError = "No managed identity endpoint found.";

        private readonly CredentialPipeline _pipeline;
        internal ManagedIdentityClient Client { get; }
        private readonly string _clientId;
        private readonly bool _logAccountDetails;

        private const string Troubleshooting =
            "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/managedidentitycredential/troubleshoot";

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected ManagedIdentityCredential()
        { }

        /// <summary>
        /// Creates an instance of <see cref="ManagedIdentityCredential"/> capable of authenticating a resource with a user-assigned or a system-assigned managed identity.
        /// </summary>
        /// <param name="clientId">
        /// The client ID to authenticate for a <see href="https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm">user-assigned managed identity</see>.
        /// If not provided, a system-assigned managed identity is used.
        /// </param>
        /// <param name="options">Options to configure the management of the requests sent to Microsoft Entra ID.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use constructor ManagedIdentityCredential(ManagedIdentityId id) or ManagedIdentityCredential(ManagedIdentityCredentialOptions options).")]
        public ManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                options,
                string.IsNullOrEmpty(clientId) ? ManagedIdentityId.SystemAssigned : ManagedIdentityId.FromUserAssignedClientId(clientId),
                CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true))))
        {
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
        }

        /// <summary>
        /// Creates an instance of <see cref="ManagedIdentityCredential"/> capable of authenticating a resource with a user-assigned managed identity.
        /// </summary>
        /// <param name="resourceId">
        /// The resource ID to authenticate for a <see href="https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm">user-assigned managed identity</see>.
        /// </param>
        /// <param name="options">Options to configure the management of the requests sent to Microsoft Entra ID.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use constructor ManagedIdentityCredential(ManagedIdentityId id) or ManagedIdentityCredential(ManagedIdentityCredentialOptions options).")]
        public ManagedIdentityCredential(ResourceIdentifier resourceId, TokenCredentialOptions options = null)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                options,
                ManagedIdentityId.FromUserAssignedResourceId(resourceId),
                CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true))))
        {
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            _clientId = resourceId.ToString();
        }

        /// <summary>
        /// Creates an instance of <see cref="ManagedIdentityCredential"/> capable of authenticating using the specified <see cref="ManagedIdentityId"/>.
        /// </summary>
        /// <param name="id">The <see cref="ManagedIdentityId"/> specifying which managed identity will be configured.</param>
        public ManagedIdentityCredential(ManagedIdentityId id)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                null,
                id,
                CredentialPipeline.GetInstance(null, IsManagedIdentityCredential: true))))
        {
            if (id == null)
            {
                Argument.AssertNotNull(id, nameof(id));
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="ManagedIdentityCredential"/> configured with the specified options.
        /// </summary>
        /// <param name="options">The options used to configure the credential.</param>
        public ManagedIdentityCredential(ManagedIdentityCredentialOptions options)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                options,
                options.ManagedIdentityId,
                CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true))))
        {
            Argument.AssertNotNull(options, nameof(options));
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
        }

        internal ManagedIdentityCredential(string clientId, CredentialPipeline pipeline, TokenCredentialOptions options = null, bool preserveTransport = false)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                options,
                ManagedIdentityId.FromUserAssignedClientId(clientId),
                pipeline,
                preserveTransport)))
        {
            _clientId = clientId;
        }

        internal ManagedIdentityCredential(ResourceIdentifier resourceId, CredentialPipeline pipeline, TokenCredentialOptions options, bool preserveTransport = false)
            : this(new ManagedIdentityClient(CreateManagedIdentityClientOptions(
                options,
                ManagedIdentityId.FromUserAssignedResourceId(resourceId),
                pipeline,
                preserveTransport)))
        {
            _clientId = resourceId.ToString();
        }

        private static ManagedIdentityClientOptions CreateManagedIdentityClientOptions(
            TokenCredentialOptions options,
            ManagedIdentityId managedIdentityId,
            CredentialPipeline pipeline,
            bool preserveTransport = false)
        {
            return new ManagedIdentityClientOptions
            {
                ManagedIdentityId = managedIdentityId,
                Pipeline = pipeline,
                PreserveTransport = preserveTransport,
                Options = options,
                DisableMtlsProofOfPossession = ResolveDisableMtlsProofOfPossession(options)
            };
        }

        private static bool ResolveDisableMtlsProofOfPossession(TokenCredentialOptions options)
        {
            return options is ManagedIdentityCredentialOptions managedIdentityCredentialOptions && managedIdentityCredentialOptions.DisableMtlsProofOfPossession;
        }

        internal ManagedIdentityCredential(ManagedIdentityClient client)
        {
            _pipeline = client.Pipeline;
            Client = client;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service, if available. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token
        /// lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service, if available. Acquired tokens are
        /// <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential instance. Token
        /// lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ManagedIdentityCredential.GetToken", requestContext);

            try
            {
                AccessToken result = await Client.AuthenticateAsync(async, requestContext, cancellationToken).ConfigureAwait(false);
                if (_logAccountDetails)
                {
                    var accountDetails = TokenHelper.ParseAccountInfoFromToken(result.Token);
                    AzureIdentityEventSource.Singleton.AuthenticatedAccountDetails(accountDetails.ClientId ?? _clientId, accountDetails.TenantId, accountDetails.Upn, accountDetails.ObjectId);
                }
                return scope.Succeeded(result);
            }
            // The managed_identity_response_parse_failure error is thrown when the response from the managed identity endpoint cannot be parsed.
            // Since for non-DAC invocations of the credential, we do not participate in parsing the raw response, we rely on this error to indicate
            // that the response was not valid JSON.
            catch (MsalServiceException e) when (e.ErrorCode == MsalError.ManagedIdentityResponseParseFailure)
            {
                throw scope.FailWrapAndThrow(new CredentialUnavailableException(MsiUnavailableError, e), Troubleshooting);
            }
            catch (Exception e)
            {
                // This exception pattern indicates that the MI endpoint is not available after exhausting all retries.
                if (e.InnerException is AggregateException ae && ae.InnerExceptions.All(inner => inner is RequestFailedException))
                {
                    throw scope.FailWrapAndThrow(new CredentialUnavailableException(ImdsManagedIdentityProbeSource.AggregateError, e), Troubleshooting);
                }
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }
    }
#pragma warning restore AZC0034
}
