// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Microsoft Entra ID using a client secret or certificate.
    /// <para>
    /// Configuration is attempted in this order, using these environment variables:
    /// </para>
    ///
    /// <b>Service principal with secret:</b>
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Microsoft Entra tenant (directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client (application) ID of an App Registration in the tenant.</description></item>
    /// <item><term>AZURE_CLIENT_SECRET</term><description>A client secret that was generated for the App Registration.</description></item>
    /// </list>
    ///
    /// <b>Service principal with certificate:</b>
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Microsoft Entra tenant (directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client (application) ID of an App Registration in the tenant.</description></item>
    /// <item><term>AZURE_CLIENT_CERTIFICATE_PATH</term><description>A path to certificate and private key pair in PEM or PFX format, which can authenticate the App Registration.</description></item>
    /// <item><term>AZURE_CLIENT_CERTIFICATE_PASSWORD</term><description>(Optional) The password protecting the certificate file (currently only supported for PFX (PKCS12) certificates).</description></item>
    /// <item><term>AZURE_CLIENT_SEND_CERTIFICATE_CHAIN</term><description>(Optional) Specifies whether an authentication request will include an x5c header to support subject name / issuer based authentication. When set to `true` or `1`, authentication requests include the x5c header.</description></item>
    /// </list>
    ///
    /// <b>Username and password:</b>
    /// <list type="table">
    /// <listheader><term>Variable</term><description>Description</description></listheader>
    /// <item><term>AZURE_TENANT_ID</term><description>The Microsoft Entra tenant (directory) ID.</description></item>
    /// <item><term>AZURE_CLIENT_ID</term><description>The client (application) ID of an App Registration in the tenant.</description></item>
    /// </list>
    ///
    /// This credential ultimately uses a <see cref="ClientSecretCredential"/> or <see cref="ClientCertificateCredential"/> to
    /// perform the authentication using these details. Please consult the
    /// documentation of those classes for more details.
    /// </summary>
    public class EnvironmentCredential : TokenCredential
    {
        private const string UnavailableErrorMessage = "EnvironmentCredential authentication unavailable. Environment variables are not fully configured. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/environmentcredential/troubleshoot";
        private readonly CredentialPipeline _pipeline;

        internal TokenCredential Credential { get; }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        public EnvironmentCredential()
            : this(CredentialPipeline.GetInstance(null))
        { }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EnvironmentCredential(TokenCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options), options)
        { }

        /// <summary>
        /// Creates an instance of the EnvironmentCredential class and reads client secret details from environment variables.
        /// If the expected environment variables are not found at this time, the GetToken method will return the default <see cref="AccessToken"/> when invoked.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public EnvironmentCredential(EnvironmentCredentialOptions options)
            : this(CredentialPipeline.GetInstance(options), options)
        { }

        internal EnvironmentCredential(CredentialPipeline pipeline, TokenCredentialOptions options = null)
        {
            _pipeline = pipeline;
            options = options ?? new EnvironmentCredentialOptions();

            EnvironmentCredentialOptions envCredOptions = (options as EnvironmentCredentialOptions) ?? options.Clone<EnvironmentCredentialOptions>();

            string tenantId = envCredOptions.TenantId;
            string clientId = envCredOptions.ClientId;
            string clientSecret = envCredOptions.ClientSecret;
            string clientCertificatePath = envCredOptions.ClientCertificatePath;
            string clientCertificatePassword = envCredOptions.ClientCertificatePassword;
            bool sendCertificateChain = envCredOptions.SendCertificateChain;
            string username = envCredOptions.Username;
            string password = envCredOptions.Password;

            if (!string.IsNullOrEmpty(tenantId) && !string.IsNullOrEmpty(clientId))
            {
                if (!string.IsNullOrEmpty(clientSecret))
                {
                    Credential = new ClientSecretCredential(tenantId, clientId, clientSecret, envCredOptions, _pipeline, envCredOptions.MsalConfidentialClient);
                }
                else if (!string.IsNullOrEmpty(clientCertificatePath))
                {
                    ClientCertificateCredentialOptions clientCertificateCredentialOptions = envCredOptions.Clone<ClientCertificateCredentialOptions>();

                    clientCertificateCredentialOptions.SendCertificateChain = sendCertificateChain;

                    Credential = new ClientCertificateCredential(tenantId, clientId, clientCertificatePath, clientCertificatePassword, clientCertificateCredentialOptions, _pipeline, envCredOptions.MsalConfidentialClient);
                }
                else if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    Credential = new UsernamePasswordCredential(username, password, tenantId, clientId, envCredOptions, _pipeline, envCredOptions.MsalPublicClient);
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
        }

        internal EnvironmentCredential(CredentialPipeline pipeline, TokenCredential credential)
        {
            _pipeline = pipeline;
            Credential = credential;
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential
        /// instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specified, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        /// <exception cref="CredentialUnavailableException">Thrown when the credential is unavailable because the environment is not properly configured.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the client details specified in the environment variables
        /// AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET to authenticate.
        /// Acquired tokens are <see href="https://aka.ms/azsdk/net/identity/token-cache">cached</see> by the credential
        /// instance. Token lifetime and refreshing is handled automatically. Where possible, <see href="https://aka.ms/azsdk/net/identity/credential-reuse">reuse credential instances</see>
        /// to optimize cache effectiveness.
        /// </summary>
        /// <remarks>
        /// If the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET are not specified, the default <see cref="AccessToken"/>
        /// </remarks>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/>.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        /// <exception cref="CredentialUnavailableException">Thrown when the credential is unavailable because the environment is not properly configured.</exception>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("EnvironmentCredential.GetToken", requestContext);

            if (Credential is null)
            {
                throw scope.FailWrapAndThrow(new CredentialUnavailableException(UnavailableErrorMessage));
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
