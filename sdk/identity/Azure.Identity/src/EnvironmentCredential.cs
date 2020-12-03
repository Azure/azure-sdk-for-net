// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using client secret, or username and password,
    /// details configured in the following environment variables:
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Azure Active Directory tenant(directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client(application) ID of an App Registration in the tenant.</description></item>
    /// <item><term>AZURE_CLIENT_SECRET</term><description>A client secret that was generated for the App Registration.</description></item>
    /// <item><term>AZURE_CLIENT_CERTIFICATE_PATH</term><description>A path to certificate and private key pair in PEM or PFX format, which can authenticate the App Registration.</description></item>
    /// <item><term>AZURE_USERNAME</term><description>The username, also known as upn, of an Azure Active Directory user account.</description></item>
    /// <item><term>AZURE_PASSWORD</term><description>The password of the Azure Active Directory user account. Note this does not support accounts with MFA enabled.</description></item>
    /// </list>
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/> or <see cref="UsernamePasswordCredential"/> to
    /// perform the authentication using these details. Please consult the
    /// documentation of that class for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential
    {
        private const string UnavailbleErrorMessage = "EnvironmentCredential authentication unavailable. Environment variables are not fully configured.";
        private readonly CredentialPipeline _pipeline;

        internal TokenCredential Credential { get; }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        public EnvironmentCredential()
            : this(CredentialPipeline.GetInstance(null))
        {
        }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public EnvironmentCredential(TokenCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options))
        {
        }

        internal EnvironmentCredential(CredentialPipeline pipeline)
        {
            _pipeline = pipeline;

            string tenantId = EnvironmentVariables.TenantId;
            string clientId = EnvironmentVariables.ClientId;
            string clientSecret = EnvironmentVariables.ClientSecret;
            string clientCertificatePath = EnvironmentVariables.ClientCertificatePath;
            string username = EnvironmentVariables.Username;
            string password = EnvironmentVariables.Password;

            if (tenantId != null && clientId != null)
            {
                if (clientSecret != null)
                {
                    Credential = new ClientSecretCredential(tenantId, clientId, clientSecret, null, _pipeline, null);
                }
                else if (username != null && password != null)
                {
                    Credential = new UsernamePasswordCredential(username, password, tenantId, clientId, null, _pipeline, null);
                }
                else if (clientCertificatePath != null)
                {
                    Credential = new ClientCertificateCredential(tenantId, clientId, clientCertificatePath, null, _pipeline, null);
                }
            }
        }

        internal EnvironmentCredential(CredentialPipeline pipeline, TokenCredential credential)
        {
            _pipeline = pipeline;
            Credential = credential;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD to authenticate.
        /// This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specified, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD to authenticate.
        /// This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specifeid, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("EnvironmentCredential.GetToken", requestContext);

            if (Credential is null)
            {
                throw scope.FailWrapAndThrow(new CredentialUnavailableException(UnavailbleErrorMessage));
            }

            try
            {
                AccessToken token = async
                    ? await Credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                    : Credential.GetToken(requestContext, cancellationToken);

                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                 throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
