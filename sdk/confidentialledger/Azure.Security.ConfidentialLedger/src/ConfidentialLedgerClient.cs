// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("PostLedgerEntry", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("PostLedgerEntryAsync", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    public partial class ConfidentialLedgerClient
    {
        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential)
            : this(ledgerEndpoint, credential: credential, options: new ConfidentialLedgerClientOptions(), identityServiceCert: default)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential, ConfidentialLedgerClientOptions options)
            : this(ledgerEndpoint, credential: credential, options: options, identityServiceCert: default)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="clientCertificate"> A <see cref="X509Certificate2"/> used to authenticate to an Azure Service. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, X509Certificate2 clientCertificate)
            : this(ledgerEndpoint, clientCertificate: clientCertificate, options: new ConfidentialLedgerClientOptions(), identityServiceCert: null)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="clientCertificate"> A <see cref="X509Certificate2"/> used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, X509Certificate2 clientCertificate, ConfidentialLedgerClientOptions options)
            : this(ledgerEndpoint, clientCertificate: clientCertificate, options: options, identityServiceCert: null)
        { }

        internal ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential = null, X509Certificate2 clientCertificate = null, ConfidentialLedgerClientOptions options = null, X509Certificate2 identityServiceCert = null)
        {
            if (ledgerEndpoint == null)
            {
                throw new ArgumentNullException(nameof(ledgerEndpoint));
            }
            if (clientCertificate == null && credential == null)
            {
                if (clientCertificate == null)
                    throw new ArgumentNullException(nameof(clientCertificate));
                if (credential == null)
                    throw new ArgumentNullException(nameof(credential));
            }
            var actualOptions = options ?? new ConfidentialLedgerClientOptions();
            X509Certificate2 serviceCert = identityServiceCert ?? GetIdentityServerTlsCert(ledgerEndpoint, actualOptions);

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
            _ledgerUri = ledgerEndpoint;
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
        ///   collectionId: string, # Optional.
        ///   transactionId: string, # Optional. A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.
        /// }
        /// </code>
        /// </remarks>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context. </param>
        public virtual Operation PostLedgerEntry(
            WaitUntil waitUntil,
            RequestContent content,
            string collectionId = null,
            RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostLedgerEntryRequest(content, collectionId, context);
                var response = _pipeline.ProcessMessage(message, context);
                response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

                var operation = new PostLedgerEntryOperation(this, transactionId);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(context?.CancellationToken ?? default);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        ///   collectionId: string, # Optional.
        ///   transactionId: string, # Optional. A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.
        /// }
        /// </code>
        /// </remarks>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context. </param>
        public virtual async Task<Operation> PostLedgerEntryAsync(
            WaitUntil waitUntil,
            RequestContent content,
            string collectionId = null,
            RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostLedgerEntryRequest(content, collectionId, context);
                var response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);

                var operation = new PostLedgerEntryOperation(this, transactionId);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
