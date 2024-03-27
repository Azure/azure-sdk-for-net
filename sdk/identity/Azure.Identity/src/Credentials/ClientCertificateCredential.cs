// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication of a service principal to Microsoft Entra ID using a X509 certificate that is assigned to its App Registration. More information
    /// on how to configure certificate authentication can be found at
    /// <see href="https://learn.microsoft.com/entra/identity-platform/certificate-credentials#register-your-certificate-with-microsoft-identity-platform"/>.
    /// </summary>
    public class ClientCertificateCredential : TokenCredential
    {
        internal const string Troubleshooting = "See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/clientcertificatecredential/troubleshoot";

        /// <summary>
        /// Gets the Microsoft Entra tenant (directory) ID of the service principal
        /// </summary>
        internal string TenantId { get; }

        /// <summary>
        /// Gets the client (application) ID of the service principal
        /// </summary>
        internal string ClientId { get; }

        internal IX509Certificate2Provider ClientCertificateProvider { get; }

        internal MsalConfidentialClient Client { get; }

        private readonly CredentialPipeline _pipeline;

        internal readonly string[] AdditionallyAllowedTenantIds;
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ClientCertificateCredential()
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath)
            : this(tenantId, clientId, clientCertificatePath, null, null, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, TokenCredentialOptions options)
            : this(tenantId, clientId, clientCertificatePath, null, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, ClientCertificateCredentialOptions options)
            : this(tenantId, clientId, clientCertificatePath, null, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate)
            : this(tenantId, clientId, clientCertificate, null, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, TokenCredentialOptions options)
            : this(tenantId, clientId, clientCertificate, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Microsoft Entra ID with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, ClientCertificateCredentialOptions options)
            : this(tenantId, clientId, clientCertificate, options, null, null)
        { }

        internal ClientCertificateCredential(
            string tenantId,
            string clientId,
            string certificatePath,
            string certificatePassword,
            TokenCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
            : this(
                tenantId,
                clientId,
                new X509Certificate2FromFileProvider(certificatePath ?? throw new ArgumentNullException(nameof(certificatePath)), certificatePassword),
                options,
                pipeline,
                client)
        { }

        internal ClientCertificateCredential(
            string tenantId,
            string clientId,
            X509Certificate2 certificate,
            TokenCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
            : this(
                tenantId,
                clientId,
                new X509Certificate2FromObjectProvider(certificate ?? throw new ArgumentNullException(nameof(certificate))),
                options,
                pipeline,
                client)
        { }

        internal ClientCertificateCredential(
            string tenantId,
            string clientId,
            IX509Certificate2Provider certificateProvider,
            TokenCredentialOptions options,
            CredentialPipeline pipeline,
            MsalConfidentialClient client)
        {
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            ClientCertificateProvider = certificateProvider;
            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);
            ClientCertificateCredentialOptions certCredOptions = options as ClientCertificateCredentialOptions;

            Client = client ??
                     new MsalConfidentialClient(
                         _pipeline,
                         tenantId,
                         clientId,
                         certificateProvider,
                         certCredOptions?.SendCertificateChain ?? false,
                         options);

            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the specified X509 certificate to authenticate. Acquired tokens are
        /// cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientCertificateCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);
                AuthenticationResult result = Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, false, cancellationToken).EnsureCompleted();

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e, Troubleshooting);
            }
        }

        /// <summary>
        /// Obtains a token from Microsoft Entra ID, using the specified X509 certificate to authenticate. Acquired tokens are
        /// cached by the credential instance. Token lifetime and refreshing is handled automatically. Where possible, reuse credential
        /// instances to optimize cache effectiveness.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientCertificateCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);
                AuthenticationResult result = await Client
                    .AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, true, cancellationToken)
                    .ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
