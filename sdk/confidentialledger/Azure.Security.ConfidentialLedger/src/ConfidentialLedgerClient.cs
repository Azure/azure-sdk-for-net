// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerUri"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerUri, TokenCredential credential, ConfidentialLedgerClientOptions options)
            : this(ledgerUri, credential: credential, options: options, identityServiceCert: default)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerUri"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="clientCertificate"> A <see cref="X509Certificate2"/> used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerUri, X509Certificate2 clientCertificate, ConfidentialLedgerClientOptions options = null)
            : this(ledgerUri, clientCertificate: clientCertificate, options: options, identityServiceCert: null)
        { }

        internal ConfidentialLedgerClient(Uri ledgerUri, TokenCredential credential = null, X509Certificate2 clientCertificate = null, ConfidentialLedgerClientOptions options = null, X509Certificate2 identityServiceCert = null)
        {
            if (ledgerUri == null)
            {
                throw new ArgumentNullException(nameof(ledgerUri));
            }
            if (clientCertificate == null && credential == null)
            {
                if (clientCertificate == null)
                    throw new ArgumentNullException(nameof(clientCertificate));
                if (credential == null)
                    throw new ArgumentNullException(nameof(credential));
            }
            var actualOptions = options ?? new ConfidentialLedgerClientOptions();
            X509Certificate2 serviceCert = identityServiceCert ?? GetIdentityServerTlsCert(ledgerUri, actualOptions);

            var transportOptions = GetIdentityServerTlsCertAndTrust(serviceCert);
            if (clientCertificate != null)
            {
                transportOptions.ClientCertificates.Add(clientCertificate);
            }
            ClientDiagnostics = new ClientDiagnostics(actualOptions);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(
                actualOptions,
                Array.Empty<HttpPipelinePolicy>(),
                _tokenCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) },
                transportOptions,
                new ResponseClassifier());
            _ledgerUri = ledgerUri;
            _apiVersion = actualOptions.Version;
        }

        /// <summary> Posts a new entry to the ledger. A collection id may optionally be specified. </summary>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        ///
        /// Request Body:
        ///
        /// Schema for <c>LedgerEntry</c>:
        /// <code>{
        ///   contents: string, # Required. Contents of the ledger entry.
        ///   collectionId: {
        ///     collectionId: string, # Required.
        ///   }, # Optional. Identifier for collections.
        ///   transactionId: string, # Optional. A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.
        /// }
        /// </code>
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="waitForCompletion"> If <c>true</c>, the <see cref="PostLedgerEntryOperation"/> will not be returned until the ledger entry is committed.
        /// If <c>false</c>,<see cref="Operation.WaitForCompletionResponse(System.Threading.CancellationToken)"/> must be called to ensure the operation has completed.</param>
        /// <param name="context"> The request context. </param>
#pragma warning disable AZC0002
        public virtual PostLedgerEntryOperation PostLedgerEntry(
            RequestContent content,
            string collectionId = null,
            bool waitForCompletion = true,
            RequestContext context = null)
#pragma warning restore AZC0002
        {
            var response = PostLedgerEntry(content, collectionId, context);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                operation.WaitForCompletionResponse(context?.CancellationToken ?? default);
            }
            return operation;
        }

        /// <summary> Posts a new entry to the ledger. A collection id may optionally be specified. </summary>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        ///
        /// Request Body:
        ///
        /// Schema for <c>LedgerEntry</c>:
        /// <code>{
        ///   contents: string, # Required. Contents of the ledger entry.
        ///   collectionId: {
        ///     collectionId: string, # Required.
        ///   }, # Optional. Identifier for collections.
        ///   transactionId: string, # Optional. A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.
        /// }
        /// </code>
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="waitForCompletion"> If <c>true</c>, the <see cref="PostLedgerEntryOperation"/>
        /// will automatically poll for status until the ledger entry is committed before it is returned.
        /// If <c>false</c>,<see cref="Operation.WaitForCompletionResponseAsync(System.Threading.CancellationToken)"/>
        /// must be called to ensure the operation has completed.</param>
        /// <param name="context"> The request context. </param>
#pragma warning disable AZC0002
        public virtual async Task<PostLedgerEntryOperation> PostLedgerEntryAsync(
            RequestContent content,
            string collectionId = null,
            bool waitForCompletion = true,
            RequestContext context = null)
#pragma warning restore AZC0002
        {
            var response = await PostLedgerEntryAsync(content, collectionId, context).ConfigureAwait(false);
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

            var operation = new PostLedgerEntryOperation(this, transactionId);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionResponseAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        internal static X509Certificate2 GetIdentityServerTlsCert(Uri ledgerUri, ConfidentialLedgerClientOptions options, ConfidentialLedgerIdentityServiceClient client = null)
        {
            var identityClient = client ?? new ConfidentialLedgerIdentityServiceClient(new Uri("https://identity.confidential-ledger.core.azure.com"), options);

            // Get the ledger's  TLS certificate for our ledger.
            var ledgerId = ledgerUri.Host.Substring(0, ledgerUri.Host.IndexOf('.'));
            Response response = identityClient.GetLedgerIdentity(ledgerId, new());

            // extract the ECC PEM value from the response.
            var eccPem = JsonDocument.Parse(response.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            return GetCertFromPEM(eccPem);
        }

        private static HttpPipelineTransportOptions GetIdentityServerTlsCertAndTrust(X509Certificate2 identityServiceCert = null)
        {
            X509Chain certificateChain = new();
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
            certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
            certificateChain.ChainPolicy.ExtraStore.Add(identityServiceCert);

            // Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(X509Certificate2 cert)
            {
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                var isCertSignedByTheTlsCert = certificateChain.ChainElements.Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == identityServiceCert.Thumbprint);
                return isCertSignedByTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }

        private static X509Certificate2 GetCertFromPEM(string eccPem)
        {
            var span = new ReadOnlySpan<char>(eccPem.ToCharArray());
            return PemReader.LoadCertificate(span, null, PemReader.KeyType.Auto, true);
        }
    }
}
