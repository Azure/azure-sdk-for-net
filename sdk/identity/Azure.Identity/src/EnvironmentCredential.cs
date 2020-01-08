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
    /// Enables authentication to Azure Active Directory using client secret, or username and password,
    /// details configured in the following environment variables:
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Azure Active Directory tenant(directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client(application) ID of an App Registration in the tenant.</description></item>
    /// <item><term>AZURE_CLIENT_SECRET</term><description>A client secret that was generated for the App Registration.</description></item>
    /// <item><term>AZURE_USERNAME</term><description>The username, also known as upn, of an Azure Active Directory user account.</description></item>
    /// <item><term>AZURE_PASSWORD</term><description>The password of the Azure Active Directory user account. Note this does not support accounts with MFA enabled.</description></item>
    /// <item><term>AZURE_AUTH_LOCATION</term><description>The path to an SDK Auth file which contains configuration information.</description></item>
    /// </list>
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/>, <see cref="UsernamePasswordCredential"/> or <see cref="AuthFileCredential"/>
    /// perform the authentication using these details. Please consult the documentation of that class for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential, IExtendedTokenCredential
    {
        private readonly CredentialPipeline _pipeline;
        private readonly TokenCredential _credential;
        private readonly string _unavailbleErrorMessage;

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will throw <see cref="CredentialUnavailableException"/>.
        /// </summary>
        public EnvironmentCredential()
            : this(CredentialPipeline.GetInstance(null))
        {
        }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will throw <see cref="CredentialUnavailableException"/>.
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
            string sdkAuthLocation = EnvironmentVariables.SdkAuthLocation;

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

            if (_credential is null && sdkAuthLocation != null)
            {
                _credential = new AuthFileCredential(sdkAuthLocation);
            }

            if (_credential is null)
            {
                StringBuilder builder = new StringBuilder("Environment variables not fully configured. AZURE_TENANT_ID and AZURE_CLIENT_ID must be set, along with either AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD. Alternately, AZURE_AUTH_LOCATION ca be set.  Currently set variables [");

                if (tenantId != null)
                {
                    builder.Append(" AZURE_TENANT_ID");
                }

                if (clientId != null)
                {
                    builder.Append(" AZURE_CLIENT_ID");
                }

                if (clientSecret != null)
                {
                    builder.Append(" AZURE_CLIENT_SECRET");
                }

                if (username != null)
                {
                    builder.Append(" AZURE_USERNAME");
                }

                if (password != null)
                {
                    builder.Append(" AZURE_PASSWORD");
                }

                if (sdkAuthLocation != null)
                {
                    builder.Append(" AZURE_AUTH_LOCATION");
                }

                _unavailbleErrorMessage = builder.Append(" ]").ToString();
            }
        }

        internal EnvironmentCredential(CredentialPipeline pipeline, TokenCredential credential)
        {
            _pipeline = pipeline;

            _credential = credential;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD to authenticate. Alternately,
        /// if AZURE_AUTH_LOCATION is set, that information is used.
        /// This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_AUTH_LOCATION are not specified,
        /// this method throws <see cref="CredentialUnavailableException"/>.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImpl(requestContext, cancellationToken).GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_USERNAME and AZURE_PASSWORD to authenticate. Alternately,
        /// if AZURE_AUTH_LOCATION is set, that information is used.
        /// This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET or AZURE_AUTH_LOCATION are not specified,
        /// this method throws <see cref="CredentialUnavailableException"/>.
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImpl(requestContext, cancellationToken);
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        private ExtendedAccessToken GetTokenImpl(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            if (_credential is null)
            {
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(_unavailbleErrorMessage)));
            }

            try
            {
                AccessToken token =  _credential.GetToken(requestContext, cancellationToken);

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

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.EnvironmentCredential.GetToken", requestContext);

            if (_credential is null)
            {
                return new ExtendedAccessToken(scope.Failed(new CredentialUnavailableException(_unavailbleErrorMessage)));
            }

            try
            {
                AccessToken token = await _credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);

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
