// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger.Certificate
{
    [CodeGenSuppress("ConfidentialLedgerCertificateClient", typeof(Uri), typeof(TokenCredential), typeof(ConfidentialLedgerClientOptions))]
    [CodeGenSuppress("ConfidentialLedgerCertificateClient", typeof(Uri), typeof(TokenCredential))]
    [CodeGenClient("ConfidentialLedgerCertificateClient")]
    public partial class ConfidentialLedgerCertificateClient
    {
        /// <summary> Initializes a new instance of ConfidentialLedgerCertificateClient. </summary>
        /// <param name="certificateEndpoint"> The Identity Service URL, for example https://identity.accledger.azure.com. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateEndpoint"/> </exception>
        public ConfidentialLedgerCertificateClient(Uri certificateEndpoint) : this(certificateEndpoint, new ConfidentialLedgerCertificateClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConfidentialLedgerCertificateClient. </summary>
        /// <param name="certificateEndpoint"> The Identity Service URL, for example https://identity.accledger.azure.com. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateEndpoint"/> </exception>
        public ConfidentialLedgerCertificateClient(Uri certificateEndpoint, ConfidentialLedgerCertificateClientOptions options)
        {
            Argument.AssertNotNull(certificateEndpoint, nameof(certificateEndpoint));

            // TODO: properly generate the client without a credential.
            _tokenCredential = null;
            if (_tokenCredential != null)
            {
                // Do nothing.
            }
            options ??= new ConfidentialLedgerCertificateClientOptions();
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = certificateEndpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Parses the response from <see cref="GetLedgerIdentity"/> or <see cref="GetLedgerIdentityAsync"/>.
        /// </summary>
        /// <param name="getIdentityResponse">The response from <see cref="GetLedgerIdentity"/> or <see cref="GetLedgerIdentityAsync"/>.</param>
        /// <returns>The <see cref="X509Certificate2"/>.</returns>
        internal static X509Certificate2 ParseCertificate(Response getIdentityResponse)
        {
            var eccPem = JsonDocument.Parse(getIdentityResponse.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            var span = new ReadOnlySpan<char>(eccPem.ToCharArray());
            return PemReader.LoadCertificate(span, null, PemReader.KeyType.Auto, true);
        }
    }
}
