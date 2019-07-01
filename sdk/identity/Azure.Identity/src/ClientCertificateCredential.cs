// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using Azure.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication of a service principal in to Azure Active Directory using a X509 certificate that is assigned to it's App Registration. More information
    /// on how to configure certificate authentication can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-certificate-credentials#register-your-certificate-with-azure-ad
    /// </summary>
    public class ClientCertificateCredential : TokenCredential
    {
        private string _tenantId;
        private string _clientId;
        private X509Certificate2 _clientCertificate;
        private AadIdentityClient _client;

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate)
            : this(tenantId, clientId, clientCertificate, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, IdentityClientOptions options)
        {
            _tenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));

            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _clientCertificate = clientCertificate ?? throw new ArgumentNullException(nameof(clientCertificate));

            _client = (options != null) ? new AadIdentityClient(options) : AadIdentityClient.SharedClient;
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified X509 certificate to authenticate.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return _client.Authenticate(_tenantId, _clientId, _clientCertificate, scopes, cancellationToken);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified X509 certificate to authenticate.
        /// </summary>
        /// <param name="scopes">The list of scopes for which the token will have access.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await _client.AuthenticateAsync(_tenantId, _clientId, _clientCertificate, scopes, cancellationToken).ConfigureAwait(false);
        }
    }
}
