// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.ConfidentialLedger.Certificate;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("PostLedgerEntry", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("PostLedgerEntryAsync", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLedgerEntry", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLedgerEntryAsync", typeof(string), typeof(string), typeof(RequestContext))]
    public partial class ConfidentialLedgerClient
    {
        private const string Default_Certificate_Endpoint = "https://identity.confidential-ledger.core.azure.com";

        /// <summary>
        /// Maximum number of times <see cref="GetLedgerEntry(string, string, RequestContext)"/> will
        /// re-poll the service while the entry is still in the "Loading" state before returning the
        /// last response to the caller.
        /// </summary>
        internal const int MaxLoadingRetries = 10;

        /// <summary>
        /// Delay between polls when <see cref="GetLedgerEntry(string, string, RequestContext)"/> is
        /// waiting for an entry to transition out of the "Loading" state. Settable for tests.
        /// </summary>
        internal TimeSpan LoadingPollingInterval { get; set; } = TimeSpan.FromMilliseconds(500);

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential)
            : this(ledgerEndpoint, credential: credential, ledgerOptions: new ConfidentialLedgerClientOptions(), identityServiceCert: default)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential, ConfidentialLedgerClientOptions options)
            : this(ledgerEndpoint, credential: credential, ledgerOptions: options, identityServiceCert: default)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="clientCertificate"> A <see cref="X509Certificate2"/> used to authenticate to an Azure Service. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, X509Certificate2 clientCertificate)
            : this(ledgerEndpoint, clientCertificate: clientCertificate, ledgerOptions: new ConfidentialLedgerClientOptions(), identityServiceCert: null)
        { }

        /// <summary> Initializes a new instance of ConfidentialLedgerClient. </summary>
        /// <param name="ledgerEndpoint"> The Confidential Ledger URL, for example https://contoso.confidentialledger.azure.com. </param>
        /// <param name="clientCertificate"> A <see cref="X509Certificate2"/> used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerClient(Uri ledgerEndpoint, X509Certificate2 clientCertificate, ConfidentialLedgerClientOptions options)
            : this(ledgerEndpoint, clientCertificate: clientCertificate, ledgerOptions: options, identityServiceCert: null)
        { }

        internal ConfidentialLedgerClient(Uri ledgerEndpoint, TokenCredential credential = null, X509Certificate2 clientCertificate = null, ConfidentialLedgerCertificateClientOptions certificateClientOptions = null, ConfidentialLedgerClientOptions ledgerOptions = null, X509Certificate2 identityServiceCert = null)
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
            var actualOptions = ledgerOptions ?? new ConfidentialLedgerClientOptions();
            X509Certificate2 serviceCert = identityServiceCert ?? GetIdentityServerTlsCert(ledgerEndpoint, certificateClientOptions ?? new ConfidentialLedgerCertificateClientOptions(), ledgerOptions: ledgerOptions).Cert;

            var transportOptions = GetIdentityServerTlsCertAndTrust(serviceCert, ledgerOptions?.VerifyConnection ?? true);
            if (clientCertificate != null)
            {
                transportOptions.ClientCertificates.Add(clientCertificate);
            }
            ClientDiagnostics = new ClientDiagnostics(actualOptions);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(
                actualOptions,
                new HttpPipelinePolicy[] { new ConfidentialLedgerRedirectPolicy() },
                _tokenCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) },
                transportOptions,
                new ConfidentialLedgerResponseClassifier());
            _ledgerEndpoint = ledgerEndpoint;
            _apiVersion = actualOptions.Version;
        }

        internal class ConfidentialLedgerResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return base.IsRetriableResponse(message) || message.Response.Status == 404;
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
        ///   collectionId: string, # Required.
        ///   transactionId: string, # Required. A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.
        ///   tags: string, # Optional.
        /// }
        /// </code>
        /// </remarks>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="context"> The request context. </param>
        public virtual Operation PostLedgerEntry(
            WaitUntil waitUntil,
            RequestContent content,
            string collectionId = null,
            string tags = null,
            RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLedgerEntryRequest(content, collectionId, tags, context);
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
        /// <param name="tags"> The tags. </param>
        /// <param name="context"> The request context. </param>
        public virtual async Task<Operation> PostLedgerEntryAsync(
            WaitUntil waitUntil,
            RequestContent content,
            string collectionId = null,
            string tags = null,
            RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.PostLedgerEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLedgerEntryRequest(content, collectionId, tags, context);
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

        internal static (X509Certificate2 Cert, string PEM) GetIdentityServerTlsCert(Uri ledgerUri, ConfidentialLedgerCertificateClientOptions options, ConfidentialLedgerCertificateClient client = null, ConfidentialLedgerClientOptions ledgerOptions = null)
        {
            var identityClient = client ?? new ConfidentialLedgerCertificateClient(ledgerOptions?.CertificateEndpoint ?? new Uri(Default_Certificate_Endpoint), options);

            // Get the ledger's  TLS certificate for our ledger.
            var ledgerId = ledgerUri.Host.Substring(0, ledgerUri.Host.IndexOf('.'));
            Response response = identityClient.GetLedgerIdentity(ledgerId, new());

            // extract the ECC PEM value from the response.
            var eccPem = JsonDocument.Parse(response.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            return (GetCertFromPEM(eccPem), eccPem);
        }

        private static HttpPipelineTransportOptions GetIdentityServerTlsCertAndTrust(X509Certificate2 identityServiceCert = null, bool verifyConnection = true)
        {
            X509Chain certificateChain = new();
            // Revocation is not required by CCF. Hence revocation checks must be skipped to avoid validation failing unnecessarily.
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            // Add the ledger identity TLS certificate to the ExtraStore.
            certificateChain.ChainPolicy.ExtraStore.Add(identityServiceCert);
            // AllowUnknownCertificateAuthority will NOT allow validation of all unknown self-signed certificates.
            // It extends trust to the ExtraStore, which in this case contains the trusted ledger identity TLS certificate.
            // This makes it possible for validation of certificate chains terminating in the ledger identity TLS certificate to pass.
            // Note: .NET 5 introduced `CustomTrustStore` but we cannot use that here as we must support older versions of .NET.
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;

            // Define a validation function to ensure that certificates presented to the client only pass validation if
            // they are trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(X509Certificate2 cert)
            {
                if (!verifyConnection)
                {
                    return true;
                }

                // Validate the presented certificate chain, using the ChainPolicy defined above.
                // Note: this check will allow certificates signed by standard CAs as well as those signed by the ledger identity TLS certificate.
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                // Ensure that the presented certificate chain passes validation only if it is rooted in the the ledger identity TLS certificate.
                var rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
                var isChainRootedInTheTlsCert = rootCert.RawData.SequenceEqual(identityServiceCert.RawData);
                return isChainRootedInTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }

        private static X509Certificate2 GetCertFromPEM(string eccPem)
        {
            var span = new ReadOnlySpan<char>(eccPem.ToCharArray());
            return PemReader.LoadCertificate(span, null, PemReader.KeyType.Auto, true);
        }

        // overloads to keep backward compatibility

        /// <summary>
        /// [Protocol Method] Writes a ledger entry.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CreateLedgerEntry(RequestContent content, string collectionId, RequestContext context)
            => CreateLedgerEntry(content, collectionId: collectionId, tags: null, context: context);

        /// <summary>
        /// [Protocol Method] Writes a ledger entry.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(RequestContent content, string collectionId, RequestContext context)
            => CreateLedgerEntryAsync(content, collectionId: collectionId, tags: null, context: context);

        /// <summary>
        /// [Protocol Method] Gets all ledger entries.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="fromTransactionId"> The from transaction id. </param>
        /// <param name="toTransactionId"> The to transaction id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context)
            => GetLedgerEntries(collectionId: collectionId, fromTransactionId: fromTransactionId, toTransactionId: toTransactionId, tag: null, context: context);

        /// <summary>
        /// [Protocol Method] Gets all ledger entries.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="fromTransactionId"> The from transaction id. </param>
        /// <param name="toTransactionId"> The to transaction id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context)
            => GetLedgerEntriesAsync(collectionId: collectionId, fromTransactionId: fromTransactionId, toTransactionId: toTransactionId, tag: null, context: context);

        /// <summary>
        /// [Protocol Method] Gets all ledger entries.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context. </param>
        /// <returns> The response returned from the service. </returns>
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context)
            => PostLedgerEntry(waitUntil, content, collectionId: collectionId, tags: null, context: context);

        /// <summary>
        /// [Protocol Method] Gets all ledger entries.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>.</param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context. </param>
        /// <returns> The response returned from the service. </returns>
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context)
            => PostLedgerEntryAsync(waitUntil, content, collectionId: collectionId, tags: null, context: context);

        /// <summary>
        /// [Protocol Method] Gets the ledger entry at the specified transaction id.
        /// A collection id may optionally be specified to indicate the collection from which to fetch the value.
        /// </summary>
        /// <remarks>
        /// The ledger entry may not be immediately available after the post operation has completed
        /// (the service returns a "Loading" response while the entry is being committed across nodes).
        /// This method polls the service automatically until the entry is available, up to
        /// <see cref="MaxLoadingRetries"/> additional attempts. HTTP 307 / 308 redirects are followed
        /// transparently by the client pipeline.
        /// </remarks>
        /// <param name="transactionId"> Identifies a write transaction. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="transactionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="transactionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetLedgerEntryAsync(string transactionId, string collectionId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(transactionId, nameof(transactionId));

            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetLedgerEntry");
            scope.Start();
            try
            {
                CancellationToken cancellationToken = context?.CancellationToken ?? default;
                Response response = null;

                for (int attempt = 0; attempt <= MaxLoadingRetries; attempt++)
                {
                    using HttpMessage message = CreateGetLedgerEntryRequest(transactionId, collectionId, context);
                    response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);

                    if (!IsLoadingResponse(response))
                    {
                        return response;
                    }

                    if (attempt == MaxLoadingRetries)
                    {
                        break;
                    }

                    if (LoadingPollingInterval > TimeSpan.Zero)
                    {
                        await Task.Delay(LoadingPollingInterval, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the ledger entry at the specified transaction id.
        /// A collection id may optionally be specified to indicate the collection from which to fetch the value.
        /// </summary>
        /// <remarks>
        /// The ledger entry may not be immediately available after the post operation has completed
        /// (the service returns a "Loading" response while the entry is being committed across nodes).
        /// This method polls the service automatically until the entry is available, up to
        /// <see cref="MaxLoadingRetries"/> additional attempts. HTTP 307 / 308 redirects are followed
        /// transparently by the client pipeline.
        /// </remarks>
        /// <param name="transactionId"> Identifies a write transaction. </param>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="transactionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="transactionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetLedgerEntry(string transactionId, string collectionId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(transactionId, nameof(transactionId));

            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetLedgerEntry");
            scope.Start();
            try
            {
                CancellationToken cancellationToken = context?.CancellationToken ?? default;
                Response response = null;

                for (int attempt = 0; attempt <= MaxLoadingRetries; attempt++)
                {
                    using HttpMessage message = CreateGetLedgerEntryRequest(transactionId, collectionId, context);
                    response = _pipeline.ProcessMessage(message, context);

                    if (!IsLoadingResponse(response))
                    {
                        return response;
                    }

                    if (attempt == MaxLoadingRetries)
                    {
                        break;
                    }

                    if (LoadingPollingInterval > TimeSpan.Zero)
                    {
                        cancellationToken.WaitHandle.WaitOne(LoadingPollingInterval);
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Determines whether a <c>GetLedgerEntry</c> response represents the transient "Loading"
        /// state (entry not yet committed) and the call should therefore be retried.
        /// </summary>
        /// <remarks>
        /// The service returns a successful HTTP 200 response while the entry is being committed.
        /// In that case the body has shape <c>{ "state": "Loading" }</c> and does not yet contain
        /// the <c>"entry"</c> property. Once available the body has shape
        /// <c>{ "state": "Ready", "entry": { ... } }</c>.
        /// </remarks>
        private static bool IsLoadingResponse(Response response)
        {
            if (response.Status != (int)HttpStatusCode.OK)
            {
                return false;
            }

            BinaryData content = response.Content;
            if (content == null || content.ToMemory().Length == 0)
            {
                return false;
            }

            try
            {
                using JsonDocument doc = JsonDocument.Parse(content);
                if (doc.RootElement.ValueKind != JsonValueKind.Object)
                {
                    return false;
                }

                // Ready response always contains the "entry" property.
                if (doc.RootElement.TryGetProperty("entry", out _))
                {
                    return false;
                }

                // No "entry" yet — treat as loading regardless of whether the body
                // includes a "state": "Loading" hint.
                return true;
            }
            catch (JsonException)
            {
                // Not JSON or malformed — let the caller see the original response unmodified.
                return false;
            }
        }
    }
}
