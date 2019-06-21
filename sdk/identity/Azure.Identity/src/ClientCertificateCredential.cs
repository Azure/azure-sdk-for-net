// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ClientCertificateCredential : TokenCredential
    {
        private string _tenantId;
        private string _clientId;
        private X509Certificate2 _clientCertificate;
        private IdentityClient _client;

        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate)
            : this(tenantId, clientId, clientCertificate, null)
        {
        }

        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, IdentityClientOptions options)
        {
            _tenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));

            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _clientCertificate = clientCertificate ?? throw new ArgumentNullException(nameof(clientCertificate));

            _client = (options != null) ? new IdentityClient(options) : IdentityClient.SharedClient;
        }

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return _client.Authenticate(_tenantId, _clientId, _clientCertificate, scopes, cancellationToken);
        }

        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await _client.AuthenticateAsync(_tenantId, _clientId, _clientCertificate, scopes, cancellationToken);
        }
    }
}
