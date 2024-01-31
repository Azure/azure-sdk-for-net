// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Attempts authentication using a managed identity that has been assigned to the deployment environment. This authentication type works for all Azure hosted
    /// environments that support managed identity. More information about configuring managed identities can be found at
    /// <see href="https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview"/>.
    /// </summary>
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
        /// Protected constructor for mocking.
        /// </summary>
        protected ManagedIdentityCredential()
        { }

        /// <summary>
        /// Creates an instance of the ManagedIdentityCredential capable of authenticating a resource with a managed identity.
        /// </summary>
        /// <param name="clientId">
        /// The client ID to authenticate for a user-assigned managed identity. More information on user-assigned managed identities can be found at
        /// <see href="https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm"/>.
        /// </param>
        /// <param name="options">Options to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
            : this(new ManagedIdentityClient(new ManagedIdentityClientOptions { ClientId = clientId, Pipeline = CredentialPipeline.GetInstance(options), Options = options }))
        {
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
        }

        /// <summary>
        /// Creates an instance of the ManagedIdentityCredential capable of authenticating a resource with a managed identity.
        /// </summary>
        /// <param name="resourceId">
        /// The resource ID to authenticate for a user-assigned managed identity. More information on user-assigned managed identities can be found at
        /// <see href="https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm"/>.
        /// </param>
        /// <param name="options">Options to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ManagedIdentityCredential(ResourceIdentifier resourceId, TokenCredentialOptions options = null)
            : this(new ManagedIdentityClient(new ManagedIdentityClientOptions { ResourceIdentifier = resourceId, Pipeline = CredentialPipeline.GetInstance(options), Options = options }))
        {
            _logAccountDetails = options?.Diagnostics?.IsAccountIdentifierLoggingEnabled ?? false;
            _clientId = resourceId.ToString();
        }

        internal ManagedIdentityCredential(string clientId, CredentialPipeline pipeline, TokenCredentialOptions options = null, bool preserveTransport = false)
            : this(new ManagedIdentityClient(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId, PreserveTransport = preserveTransport, Options = options }))
        {
            _clientId = clientId;
        }

        internal ManagedIdentityCredential(ResourceIdentifier resourceId, CredentialPipeline pipeline, TokenCredentialOptions options, bool preserveTransport = false)
            : this(new ManagedIdentityClient(new ManagedIdentityClientOptions{Pipeline = pipeline, ResourceIdentifier = resourceId, PreserveTransport = preserveTransport, Options = options }))
        {
            _clientId = resourceId.ToString();
        }

        internal ManagedIdentityCredential(ManagedIdentityClient client)
        {
            _pipeline = client.Pipeline;
            Client = client;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service, if available. Acquired tokens are cached by the credential
        /// instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache
        /// effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service, if available. Acquired tokens are cached by the credential
        /// instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential instances to optimize cache
        /// effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
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
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }
    }
}
