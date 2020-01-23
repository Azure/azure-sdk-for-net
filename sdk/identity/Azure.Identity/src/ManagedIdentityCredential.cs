// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Diagnostics;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Attempts authentication using a managed identity that has been assigned to the deployment environment.This authentication type works in Azure VMs,
    /// App Service and Azure Functions applications, as well as inside of Azure Cloud Shell. More information about configuring managed identities can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview
    /// </summary>
    public class ManagedIdentityCredential : TokenCredential, IExtendedTokenCredential
    {
        internal const string MsiUnavailableError = "No managed identity endpoint found.";

        private readonly string _clientId;
        private readonly CredentialPipeline _pipeline;
        private readonly ManagedIdentityClient _client;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ManagedIdentityCredential()
        {

        }

        /// <summary>
        /// Creates an instance of the ManagedIdentityCredential capable of authenticating a resource with a managed identity.
        /// </summary>
        /// <param name="clientId">
        /// The client id to authenticate for a user assigned managed identity.  More information on user assigned managed identities cam be found here:
        /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm
        /// </param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
            : this(clientId, CredentialPipeline.GetInstance(options))
        {
        }

        internal ManagedIdentityCredential(string clientId, CredentialPipeline pipeline)
            : this(clientId, pipeline, new ManagedIdentityClient(pipeline))
        {
        }

        internal ManagedIdentityCredential(string clientId, CredentialPipeline pipeline, ManagedIdentityClient client)
        {
            _clientId = clientId;

            _pipeline = pipeline;

            _client = client;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImpl(requestContext, cancellationToken).GetTokenOrThrow();
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImpl(requestContext, cancellationToken);
        }

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ManagedIdentityCredential.GetToken", requestContext);

            try
            {
                MsiType msiType = await _client.GetMsiTypeAsync(cancellationToken).ConfigureAwait(false);

                // if msi is unavailable or we were unable to determine the type return a default access token
                if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
                {
                    return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(MsiUnavailableError)));
                }

                AccessToken token = await _client.AuthenticateAsync(msiType, requestContext.Scopes, _clientId, cancellationToken).ConfigureAwait(false);

                return new ExtendedAccessToken(scope.Succeeded(token));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

        private ExtendedAccessToken GetTokenImpl(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.ManagedIdentityCredential.GetToken", requestContext);

            try
            {
                MsiType msiType = _client.GetMsiType(cancellationToken);

                // if msi is unavailable or we were unable to determine the type return a default access token
                if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
                {
                    return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(MsiUnavailableError)));
                }

                AccessToken token = _client.Authenticate(msiType, requestContext.Scopes, _clientId, cancellationToken);

                return new ExtendedAccessToken(scope.Succeeded(token));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                return new ExtendedAccessToken(scope.Failed(e));
            }
        }

    }
}
