// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("ConfidentialLedgerIdentityServiceClient", typeof(Uri), typeof(TokenCredential), typeof(ConfidentialLedgerClientOptions))]
    public partial class ConfidentialLedgerIdentityServiceClient
    {
        /// <summary> Initializes a new instance of ConfidentialLedgerIdentityServiceClient. </summary>
        /// <param name="identityServiceUri"> The Identity Service URL, for example https://identity.accledger.azure.com. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerIdentityServiceClient(Uri identityServiceUri, ConfidentialLedgerClientOptions options = null)
        {
            if (identityServiceUri == null)
            {
                throw new ArgumentNullException(nameof(identityServiceUri));
            }

            // TODO: properly generate the client without a credential.
            _tokenCredential = null;
            if (_tokenCredential != null)
            {
                // Do nothing.
            }
            options ??= new ConfidentialLedgerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _identityServiceUri = identityServiceUri;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Parses the response from <see cref="GetLedgerIdentity"/> or <see cref="GetLedgerIdentityAsync"/>.
        /// </summary>
        /// <param name="getIdentityResponse">The response from <see cref="GetLedgerIdentity"/> or <see cref="GetLedgerIdentityAsync"/>.</param>
        /// <returns>The <see cref="X509Certificate2"/>.</returns>
        public static X509Certificate2 ParseCertificate(Response getIdentityResponse)
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
