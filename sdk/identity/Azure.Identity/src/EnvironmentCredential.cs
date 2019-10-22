// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using client secret
    /// details configured in the following environment variables:
    /// - AZURE_TENANT_ID: The Azure Active Directory tenant(directory) ID.
    /// - AZURE_CLIENT_ID: The client(application) ID of an App Registration in the tenant.
    /// - AZURE_CLIENT_SECRET: A client secret that was generated for the App Registration.
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/> to
    /// perform the authentication using these details. Please consult the
    /// documentation of that class for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential, IExtendedTokenCredential
    {
        private readonly CredentialPipeline _pipeline;
        private readonly TokenCredential _credential;
        private readonly string _unavailbleErrorMessage;

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
            string username = EnvironmentVariables.Username;
            string password = EnvironmentVariables.Password;

            if (tenantId != null && clientId != null)
            {
                if (clientSecret != null)
                {
                    _credential = new ClientSecretCredential(tenantId, clientId, clientSecret, _pipeline);
                }
                else if (username != null && password != null && tenantId != null && clientId != null)
                {
                    _credential = new UsernamePasswordCredential(username, password, clientId, tenantId, _pipeline);
                }
            }

            if (_credential is null)
            {
                StringBuilder builder = new StringBuilder("EnvironmentCredential is unavailable, environment variables not fully configured.");

                builder.Append(Environment.NewLine).Append($"  AZURE_TENANT_ID specified {!(tenantId is null)}");
                builder.Append(Environment.NewLine).Append($"  AZURE_CLIENT_ID specified {!(clientId is null)}");
                builder.Append(Environment.NewLine).Append($"  AZURE_CLIENT_SECRET specified {!(clientSecret is null)}");
                builder.Append(Environment.NewLine).Append($"  AZURE_USERNAME specified {!(username is null)}");
                builder.Append(Environment.NewLine).Append($"  AZURE_PASSWORD specified {!(password is null)}");

                _unavailbleErrorMessage = builder.ToString();
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specified, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? _credential.GetToken(requestContext, cancellationToken) : default;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specifeid, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (_credential != null) ? await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) : default;
        }

        (AccessToken, Exception) IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            Exception ex = null;

            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            if (_credential is null)
            {
                ex = scope.Failed(new CredentialUnavailableException(_unavailbleErrorMessage));

                return (default, ex);
            }

            try
            {
                AccessToken token = _credential.GetToken(requestContext, cancellationToken);

                return (token, null);
            }
            catch (Exception e)
            {
                ex = scope.Failed(e);

                return (default, ex);
            }
        }

        async Task<(AccessToken, Exception)> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            Exception ex = null;

            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            if (_credential is null)
            {
                ex = scope.Failed(new CredentialUnavailableException(_unavailbleErrorMessage));

                return (default, ex);
            }

            try
            {
                AccessToken token = await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);

                return (token, null);
            }
            catch (Exception e)
            {
                ex = scope.Failed(e);

                return (default, ex);
            }
        }
    }
}
