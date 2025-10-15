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
    [CodeGenSuppress("CreateEntry", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateEntryAsync", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateEntry", typeof(BinaryData), typeof(CancellationToken))]
    [CodeGenSuppress("CreateEntryAsync", typeof(BinaryData), typeof(CancellationToken))]
    [CodeGenSuppress("CreateGetTransparencyConfigCborRequest", typeof(RequestContext))]
    [CodeGenSuppress("CreateGetPublicKeysRequest", typeof(RequestContext))]
    [CodeGenSuppress("CreateGetOperationRequest", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetEntryRequest", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetEntryStatementRequest", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CreateCreateEntryRequest", typeof(RequestContent), typeof(RequestContext))]
    public partial class CodeTransparencyClient
    {
        /// <summary>
        /// Expected tree algorithm value in the receipt.
        /// </summary>
        public static readonly string UnknownIssuerPrefix = "unknown-issuer";

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
            string name = endpoint.Host.Split('.')[0];
            CodeTransparencyCertificateClient certificateClient = options.CreateCertificateClient();
            HttpPipelineTransportOptions transportOptions = CreateTlsCertAndTrustVerifier(name, certificateClient);

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
        /// Initializes a new instance of CodeTransparencyClient. The client will download its own
        /// TLS CA cert to perform server cert authentication.
        /// If the CA changes then there is a TTL which will help healing the long lived clients.
        /// </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public CodeTransparencyClient(Uri endpoint, CodeTransparencyClientOptions options = default) : this(endpoint, null, options)
        {
        }

        private static List<(string IssuerHost, byte[] ReceiptBytes)> GetReceiptsFromTransparentStatementStatic(byte[] transparentStatementCoseSign1Bytes)
        {
            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(transparentStatementCoseSign1Bytes);

            if (!coseSign1Message.UnprotectedHeaders.
            TryGetValue(new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts),
            out CoseHeaderValue embeddedReceipts))
            {
                throw new InvalidOperationException("embeddedReceipts not found");
            }

            CborReader cborReader = new CborReader(embeddedReceipts.EncodedValue);
            cborReader.ReadStartArray();

            var receiptList = new List<(string, byte[])>();
            while (cborReader.PeekState() != CborReaderState.EndArray)
            {
                var receipt = cborReader.ReadByteString();
                // the receipt could be from any other system and we can only validate the ones
                // that originate in our service instances and have an issuer we can parse
                // identify receipts with unknown issuers with appended index to avoid clashes
                // verification logic has a separate path to handle unknown issuers
                string issuer = string.Empty;
                try
                {
                    issuer = GetReceiptIssuerHostStatic(receipt);
                }
                catch (InvalidOperationException)
                {
                    issuer = UnknownIssuerPrefix + receiptList.Count;
                }
                receiptList.Add((issuer, receipt));
            }
            cborReader.ReadEndArray();

            return receiptList;
        }

        private static string GetReceiptIssuerHostStatic(byte[] receiptBytes)
        {
            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(receiptBytes);

            if (!coseSign1Message.ProtectedHeaders.TryGetValue(new CoseHeaderLabel(CcfReceipt.CoseReceiptCwtMapLabel), out CoseHeaderValue cwtMap))
            {
                throw new InvalidOperationException("CWT-MAP not found in receipt.");
            }
            string issuer = CborUtils.GetStringValueFromCborMapByKey(cwtMap.EncodedValue.ToArray(), CcfReceipt.CoseReceiptCwtIssLabel);
            if (string.IsNullOrEmpty(issuer))
            {
                throw new InvalidOperationException("Issuer not found in receipt.");
            }
            return issuer;
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

                // Ensure that the presented certificate chain passes validation only if it is rooted in the ledger identity TLS certificate.
                X509Certificate2 rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
                bool isChainRootedInTheTlsCert = rootCert.Thumbprint.Equals(identityServiceCert.Thumbprint);
                return isChainRootedInTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }

        /// <summary> Post an entry to be registered on the CodeTransparency instance, mandatory in IETF SCITT draft. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="body"> CoseSign1 signature envelope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Operation<BinaryData> CreateEntry(WaitUntil waitUntil, BinaryData body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = body ?? throw new ArgumentNullException(nameof(body));
            RequestContext context = FromCancellationToken(cancellationToken);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyClient.CreateEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateEntryRequest(content, context);
                Response response = _pipeline.ProcessMessage(message, context, cancellationToken);

                string operationId = string.Empty;
                try
                {
                    operationId = CborUtils.GetStringValueFromCborMapByKey(response.Content.ToArray(), "OperationId");
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException("Failed to parse the Cbor response.", ex);
                }

                if (string.IsNullOrEmpty(operationId))
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    var entryOperation = new CreateEntryOperation(this, operationId);

                    if (waitUntil == WaitUntil.Completed)
                    {
                        entryOperation.WaitForCompletionResponse(cancellationToken);
                    }

                    return entryOperation;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post an entry to be registered on the CodeTransparency instance, mandatory in IETF SCITT draft. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="body"> CoseSign1 signature envelope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Operation<BinaryData>> CreateEntryAsync(WaitUntil waitUntil, BinaryData body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = body ?? throw new ArgumentNullException(nameof(body));
            RequestContext context = FromCancellationToken(cancellationToken);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyClient.CreateEntryAsync");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateEntryRequest(content, context);
                Response response = await _pipeline.ProcessMessageAsync(message, context, cancellationToken).ConfigureAwait(false);

                string operationId = string.Empty;
                try
                {
                    operationId = CborUtils.GetStringValueFromCborMapByKey(response.Content.ToArray(), "OperationId");
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException("Failed to parse the Cbor response.", ex);
                }

                if (string.IsNullOrEmpty(operationId))
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    var entryOperation = new CreateEntryOperation(this, operationId);

                    if (waitUntil == WaitUntil.Completed)
                    {
                        await entryOperation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                    }

                    return entryOperation;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope
        /// and check if receipt was endorsed by the given service certificate.
        /// In the case of multiple receipts being embedded in the signature then verify
        /// all of them.
        /// </summary>
        /// <param name="transparentStatementCoseSign1Bytes">Receipt cbor or Cose_Sign1 (with an embedded receipt) bytes.</param>
        [Obsolete("Use the static VerifyTransparentStatement method with options instead.")]
        public virtual void RunTransparentStatementVerification(byte[] transparentStatementCoseSign1Bytes)
        {
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AllowedIssuerDomains = new string[] { _endpoint.Host },
                AllowedDomainVerificationBehavior = AllowedDomainVerificationBehavior.EachAllowListedDomainMustHaveValidReceipt,
                NonAllowListedReceiptBehavior = NonAllowListedReceiptBehavior.FailIfPresent
            };
            VerifyTransparentStatement(transparentStatementCoseSign1Bytes, verificationOptions);
        }

        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope
        /// and check if receipt was endorsed by the service public keys.
        /// This method expects the issuer in the receipt to match the CodeTransparencyClient client endpoint.
        /// Calls <!-- see cref="CcfReceiptVerifier.VerifyTransparentStatementReceipt(JsonWebKey, byte[], byte[])"/> for each receipt found in the transparent statement.-->
        /// </summary>
        /// <param name="signedStatementCoseSign1Bytes">Signed statement in Cose_Sign1 cbor bytes.</param>
        /// <param name="receiptCoseSign1Bytes">Receipt in COSE_Sign1 cbor bytes.</param>
        /// <exception cref="InvalidOperationException">Thrown when the verification fails.</exception>
        public virtual void RunTransparentStatementVerification(byte[] signedStatementCoseSign1Bytes, byte[] receiptCoseSign1Bytes)
        {
            CoseSign1Message inputSignedStatement = CoseMessage.DecodeSign1(signedStatementCoseSign1Bytes);
            inputSignedStatement.UnprotectedHeaders.Clear();
            JsonWebKey jsonWebKey = GetServiceCertificateKey(receiptCoseSign1Bytes);
            CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, receiptCoseSign1Bytes, inputSignedStatement.Encode());
        }

        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope and (optionally) enforce issuer domain allow-list rules.
        /// It will create an instance of CodeTransparencyClient for each issuer domain encountered in the verification process.
        /// </summary>
        /// <param name="transparentStatementCoseSign1Bytes">Receipt cbor or Cose_Sign1 (with an embedded receipt) bytes.</param>
        /// <param name="verificationOptions">Optional verification options. If null or if <see cref="CodeTransparencyVerificationOptions.AllowedIssuerDomains"/> is empty, all receipts are verified (original behavior).</param>
        /// <param name="clientOptions"> The options for configuring the client instances that download public keys required for verification. </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when: no receipts exist; allow-list is provided and no receipt matches any allowed domain; a disallowed receipt exists while <see cref="NonAllowListedReceiptBehavior.FailIfPresent"/> is selected.
        /// </exception>
        /// <exception cref="AggregateException">Thrown containing individual failures encountered during verification.</exception>
        public static void VerifyTransparentStatement(byte[] transparentStatementCoseSign1Bytes, CodeTransparencyVerificationOptions verificationOptions = default, CodeTransparencyClientOptions clientOptions = default)
        {
            verificationOptions ??= new CodeTransparencyVerificationOptions();

            List<Exception> failures = new List<Exception>();

            List<(string, byte[])> receiptList = GetReceiptsFromTransparentStatementStatic(transparentStatementCoseSign1Bytes);
            if (receiptList.Count == 0)
            {
                throw new InvalidOperationException("No receipts found in the transparent statement.");
            }

            Dictionary<string, CodeTransparencyClient> clientInstances = new Dictionary<string, CodeTransparencyClient>();

            // Prepare allow list state. If no allow list provided, implicitly allow all detected issuer domains encountered in receipts.
            var configuredAllowList = verificationOptions?.AllowedIssuerDomains ?? Array.Empty<string>();
            bool userProvidedAllowList = configuredAllowList.Count > 0;
            HashSet<string> allowListNormalized = new(StringComparer.OrdinalIgnoreCase);
            if (userProvidedAllowList)
            {
                foreach (var domain in configuredAllowList)
                {
                    if (!string.IsNullOrWhiteSpace(domain) && !domain.StartsWith(UnknownIssuerPrefix))
                    {
                        allowListNormalized.Add(domain.Trim());
                    }
                }
            }
            else
            {
                // Implicit allow list derived from receipts
                foreach ((string issuer, byte[] receiptBytes) in receiptList)
                {
                    // Skip unknown issuers for implicit allow list
                    if (!issuer.StartsWith(UnknownIssuerPrefix))
                    {
                        allowListNormalized.Add(issuer);
                    }
                }
            }

            // Tracking for behaviors
            HashSet<string> validAllowedDomainsEncountered = new(StringComparer.OrdinalIgnoreCase);
            HashSet<string> allowedDomainsWithReceipt = new(StringComparer.OrdinalIgnoreCase);

            // Early failure if we must fail on presence of non-allow-listed receipts
            if (verificationOptions.NonAllowListedReceiptBehavior == NonAllowListedReceiptBehavior.FailIfPresent)
            {
                foreach ((string issuer, byte[] receiptBytes) in receiptList)
                {
                    if (!allowListNormalized.Contains(issuer))
                    {
                        throw new InvalidOperationException($"Receipt issuer '{issuer}' is not in the allowed domain list.");
                    }
                }
            }

            foreach ((string issuer, byte[] receiptBytes) in receiptList)
            {
                bool isAllowedIssuer = allowListNormalized.Contains(issuer);
                if (isAllowedIssuer)
                {
                    allowedDomainsWithReceipt.Add(issuer);
                }

                // Determine if this receipt should be verified
                bool shouldVerify;
                if (isAllowedIssuer)
                {
                    // Always verify receipts from allowed issuers; enforcement comes later.
                    shouldVerify = true;
                }
                else
                {
                    // Non-allow-listed receipts handled per options
                    shouldVerify = verificationOptions?.NonAllowListedReceiptBehavior switch
                    {
                        NonAllowListedReceiptBehavior.Verify => true,
                        NonAllowListedReceiptBehavior.Ignore => false,
                        NonAllowListedReceiptBehavior.FailIfPresent => false, // already handled in early phase
                        _ => true
                    };
                }

                if (!shouldVerify)
                {
                    continue;
                }

                if (issuer.StartsWith(UnknownIssuerPrefix))
                {
                    // Cannot verify receipts with unknown issuers
                    failures.Add(new InvalidOperationException($"Cannot verify receipt with unknown issuer '{issuer}'."));
                    continue;
                }

                try
                {
                    if (!clientInstances.TryGetValue(issuer, out CodeTransparencyClient clientInstance))
                    {
                        clientInstance = new CodeTransparencyClient(new Uri($"https://{issuer}"), clientOptions);
                        clientInstances[issuer] = clientInstance;
                    }
                    clientInstance.RunTransparentStatementVerification(transparentStatementCoseSign1Bytes, receiptBytes);

                    if (isAllowedIssuer)
                    {
                        validAllowedDomainsEncountered.Add(issuer);
                    }
                }
                catch (Exception e)
                {
                    failures.Add(e);
                }
            }

            // Post-processing based on allowed domain verification behavior (only applies to user-provided allow list)
            switch (verificationOptions.AllowedDomainVerificationBehavior)
            {
                case AllowedDomainVerificationBehavior.AnyAllowedDomainPresentAndValid:
                    if (validAllowedDomainsEncountered.Count == 0)
                    {
                        failures.Add(new InvalidOperationException("No valid receipts found for any allowed issuer domain."));
                    }
                    break;
                case AllowedDomainVerificationBehavior.AllAllowListedReceiptsMustBeValid:
                    // All receipts from allowed domains must be valid: i.e., any receipt from an allowed domain that failed adds failure (already captured) -> if any allowed domain had receipt but not all successful? We check failures now.
                    foreach (var domain in allowedDomainsWithReceipt)
                    {
                        if (!validAllowedDomainsEncountered.Contains(domain))
                        {
                            failures.Add(new InvalidOperationException($"A receipt from the required domain '{domain}' failed verification."));
                        }
                    }
                    break;
                case AllowedDomainVerificationBehavior.EachAllowListedDomainMustHaveValidReceipt:
                    foreach (var domain in allowListNormalized)
                    {
                        if (!validAllowedDomainsEncountered.Contains(domain))
                        {
                            failures.Add(new InvalidOperationException($"No valid receipt found for a required domain '{domain}'."));
                        }
                    }
                    break;
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
            string issuer = GetReceiptIssuerHostStatic(receiptBytes);

            // Validate issuer and CTS instance are matching
            if (!issuer.Equals(_endpoint.Host, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Issuer and service instance name are not matching.");
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

            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(receiptBytes);

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

        internal HttpMessage CreateGetTransparencyConfigCborRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/.well-known/transparency-configuration", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/cbor");
            return message;
        }

        internal HttpMessage CreateGetPublicKeysRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/jwks", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateEntryRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier201202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/entries", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/cose; application/cbor");
            request.Headers.Add("Content-Type", "application/cose");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetOperationRequest(string operationId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200202);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/operations/", false);
            uri.AppendPath(operationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/cbor");
            return message;
        }

        internal HttpMessage CreateGetEntryRequest(string entryId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/entries/", false);
            uri.AppendPath(entryId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/cose");
            return message;
        }

        internal HttpMessage CreateGetEntryStatementRequest(string entryId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/entries/", false);
            uri.AppendPath(entryId, true);
            uri.AppendPath("/statement", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/cose");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier201202;
        private static ResponseClassifier ResponseClassifier201202 => _responseClassifier201202 ??= new StatusCodeClassifier(stackalloc ushort[] { 201, 202 });
        private static ResponseClassifier _responseClassifier200202;
        private static ResponseClassifier ResponseClassifier200202 => _responseClassifier200202 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 202 });
    }
}
