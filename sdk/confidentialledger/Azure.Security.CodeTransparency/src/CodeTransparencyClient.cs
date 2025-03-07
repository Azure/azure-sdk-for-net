// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Formats.Cbor;
using System.Security.Cryptography.Cose;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.CodeTransparency.Receipt;

namespace Azure.Security.CodeTransparency
{
    public partial class CodeTransparencyClient
    {
        private readonly string _serviceName;

        /// <summary>
        /// Initializes a new instance of CodeTransparencyClient. The client will download its own
        /// TLS CA cert to perform server cert authentication.
        /// If the CA changes then there is a TTL which will help healing the long lived clients.
        /// </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A JWT based credential used to authenticate to the Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public CodeTransparencyClient(Uri endpoint, AzureKeyCredential credential, CodeTransparencyClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CodeTransparencyClientOptions();
            _serviceName = endpoint.Host.Split('.')[0];
            CodeTransparencyCertificateClient certificateClient = options.CreateCertificateClient();
            HttpPipelineTransportOptions transportOptions = CreateTlsCertAndTrustVerifier(_serviceName, certificateClient);

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                _keyCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) },
                transportOptions,
                new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Creates the transport option which will pull a custom TLS CA for the verification purposes.
        /// The CA is hosted in the confidential ledger identity service which in turn gets populated
        /// with the cert when the CCF enclave application boots.
        /// The client is expected to cache the CA cert as the verification will try to get this cert
        /// on each invocation.
        /// </summary>
        /// <param name="serviceName">which service to use to pull the cert from</param>
        /// <param name="certificateClient">identity service client to use for getting the CA cert</param>
        private static HttpPipelineTransportOptions CreateTlsCertAndTrustVerifier(string serviceName, CodeTransparencyCertificateClient certificateClient)
        {
            Argument.AssertNotNullOrEmpty(serviceName, nameof(serviceName));
            Argument.AssertNotNull(certificateClient, nameof(certificateClient));

            X509Chain certificateChain = new();
            // Revocation is not required by CCF. Hence revocation checks must be skipped to avoid validation failing unnecessarily.
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // AllowUnknownCertificateAuthority will NOT allow validation of all unknown self-signed certificates.
            // It extends trust to the ExtraStore, which in this case contains the trusted ledger identity TLS certificate.
            // This makes it possible for validation of certificate chains terminating in the ledger identity TLS certificate to pass.
            // Note: .NET 5 introduced `CustomTrustStore` but we cannot use that here as we must support older versions of .NET.
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;

            // Define a validation function to ensure that certificates presented to the client only pass validation if
            // they are trusted by the ledger identity TLS certificate.
            // will yield AuthenticationException if cert is invalid
            bool CertValidationCheck(X509Certificate2 cert)
            {
                // Pull the TLS cert or get it from the cache
                ServiceIdentityResult identity = certificateClient.GetServiceIdentity(serviceName);
                X509Certificate2 identityServiceCert = identity.GetCertificate();

                // Add the ledger identity TLS certificate to the ExtraStore.
                X509Certificate2Collection existingCerts = certificateChain.ChainPolicy.ExtraStore;
                if (!existingCerts.Contains(identityServiceCert))
                {
                    certificateChain.ChainPolicy.ExtraStore.Clear();
                    certificateChain.ChainPolicy.ExtraStore.Add(identityServiceCert);
                }
                // Validate the presented certificate chain, using the ChainPolicy defined above.
                // Note: this check will allow certificates signed by standard CAs as well as those signed by the ledger identity TLS certificate.
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                // Ensure that the presented certificate chain passes validation only if it is rooted in the the ledger identity TLS certificate.
                X509Certificate2 rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
                bool isChainRootedInTheTlsCert = rootCert.Thumbprint.Equals(identityServiceCert.Thumbprint);
                return isChainRootedInTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }

        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope
        /// and check if receipt was endorsed by the given service certificate.
        /// In the case of receipts being embedded in the signature then verify
        /// all of them.
        /// Calls <!-- see cref="CcfReceiptVerifier.VerifyTransparentStatementReceipt(JsonWebKey, byte[], byte[])"/> for each receipt found in the transparent statement.-->
        /// </summary>
        /// <param name="transparentStatementCoseSign1Bytes">Receipt cbor or Cose_Sign1 (with an embedded receipt) bytes.</param>
        /// <param name="signedStatement">The input signed statement in Cose_Sign1 cbor bytes.</param>
        public void RunTransparentStatementVerification(byte[] transparentStatementCoseSign1Bytes, byte[] signedStatement)
        {
            List<Exception> failures = new List<Exception>();

            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(transparentStatementCoseSign1Bytes);

            // Embedded receipt bytes contain receipt under the map with key as 394 and the value as the receipt bytes
            // See https://www.ietf.org/archive/id/draft-ietf-scitt-architecture-10.html#name-transparent-statements
            if (!coseSign1Message.UnprotectedHeaders.
                TryGetValue(new CoseHeaderLabel(CcfReceipt.COSE_HEADER_EMBEDDED_RECEIPTS),
                out CoseHeaderValue embeddedReceipts))
            {
                throw new InvalidOperationException("embeddedReceipts not found");
            }

            CborReader cborReader = new CborReader(embeddedReceipts.EncodedValue);
            cborReader.ReadStartArray();

            var receiptList = new List<byte[]>();
            while (cborReader.PeekState() != CborReaderState.EndArray)
            {
                receiptList.Add(cborReader.ReadByteString());
            }
            cborReader.ReadEndArray();

            // Verify each receipt and keep failure counter
            foreach (var receipt in receiptList)
            {
                try
                {
                    JsonWebKey jsonWebKey = GetServiceCertificateKey(receipt);
                    CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, receipt, signedStatement);
                }
                catch (Exception e)
                {
                    failures.Add(e);
                }
            }
            if (failures.Count > 0)
            {
                throw new AggregateException(failures);
            }
        }

        /// <summary>
        /// Get the service certificate key from the JWKs service endpoint.
        /// </summary>
        /// <param name="receiptBytes">the COSE receipt bytes,
        /// see https://www.ietf.org/archive/id/draft-ietf-cose-merkle-tree-proofs-08.html#name-verifiable-data-structures-</param>
        /// <returns>The service certificate key (JWK)</returns>
        private JsonWebKey GetServiceCertificateKey(byte[] receiptBytes)
        {
            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(receiptBytes);

            if (!coseSign1Message.ProtectedHeaders.TryGetValue(new CoseHeaderLabel(CcfReceipt.COSE_RECEIPT_CWT_MAP_LABEL), out CoseHeaderValue cwtMap))
            {
                throw new InvalidOperationException("CWT-MAP not found in receipt.");
            }

            string issuer = string.Empty;

            CborReader cborReader = new CborReader(cwtMap.EncodedValue.ToArray());
            cborReader.ReadStartMap();
            while (cborReader.PeekState() != CborReaderState.EndMap)
            {
                int key = cborReader.ReadInt32();
                if (key == CcfReceipt.COSE_RECEIPT_CWT_ISS_LABEL)
                    issuer = cborReader.ReadTextString();
                else
                    cborReader.SkipValue();
            }
            cborReader.ReadEndMap();

            // Validate issuer and CTS instance are matching
            if (!issuer.Equals(_serviceName, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Issuer and CTS instance name are not matching.");
            }

            // Get all the public keys from the JWKS endpoint
            JwksDocument jwksDocument = GetPublicKeys().Value;

            // Ensure there is at least one entry in the JWKS document
            if (jwksDocument.Keys.Count == 0)
            {
                throw new InvalidOperationException("No keys found in JWKS document.");
            }

            // Store all the keys in a new Dictionary to simplify lookup
            var keysDict = new Dictionary<string, JsonWebKey>();
            foreach (JsonWebKey jsonWebKey in jwksDocument.Keys)
            {
                keysDict[jsonWebKey.Kid] = jsonWebKey;
            }

            if (!coseSign1Message.ProtectedHeaders.TryGetValue(CoseHeaderLabel.KeyIdentifier, out CoseHeaderValue receiptKid))
            {
                throw new InvalidOperationException("KID not found.");
            }

            string kidAsString = Encoding.UTF8.GetString(receiptKid.GetValueAsBytes());
            if (!keysDict.TryGetValue(kidAsString, out JsonWebKey matchingKey))
            {
                throw new InvalidOperationException($"Key with ID '{kidAsString}' not found.");
            }

            return matchingKey;
        }
    }
}
