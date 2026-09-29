// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.ConfidentialLedger.Certificate;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("ConfidentialLedgerClient", typeof(Uri))]
    [CodeGenSuppress("ConfidentialLedgerClient", typeof(Uri), typeof(ConfidentialLedgerClientOptions))]
    [CodeGenSuppress("PostLedgerEntry", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("PostLedgerEntryAsync", typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLedgerEntry", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLedgerEntryAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetCurrentLedgerEntry", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetCurrentLedgerEntryAsync", typeof(string), typeof(RequestContext))]
    public partial class ConfidentialLedgerClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://confidential-ledger.azure.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly Uri _ledgerEndpoint;
        internal const string Default_Certificate_Endpoint = "https://identity.confidential-ledger.core.azure.com";
        private readonly bool _useLedgerGateway;
        private readonly ConfidentialLedgerFailoverService _failoverService;
        private readonly bool _enableArchivedCollectionFallback;
        private readonly int _maxLoadingRetries;
        private readonly TimeSpan _loadingPollDelay;

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

            HttpPipelineTransportOptions transportOptions;
            HttpPipelinePolicy[] perRetryPolicies;
            ClientDiagnostics = new ClientDiagnostics(actualOptions);
            _tokenCredential = credential;
            _useLedgerGateway = actualOptions.UseLedgerGateway;

            if (actualOptions.UseLedgerGateway)
            {
                // The Ledger Gateway terminates TLS with a publicly-rooted certificate
                // (e.g. DigiCert Global Root G2 -> Microsoft Azure RSA TLS Issuing CA), which is
                // already present in every client's OS trust store. As a result, none of the CCF
                // identity-service bootstrap is required: we do not need to fetch the per-ledger
                // self-signed network certificate, pin it as a custom trust root, or install a
                // custom server-certificate validation callback. Bearer-token authentication is
                // also the only auth mode supported by the gateway (no client-side mTLS).
                if (clientCertificate != null)
                {
                    throw new ArgumentException(
                        $"Client certificate (mTLS) authentication is not supported when {nameof(ConfidentialLedgerClientOptions.UseLedgerGateway)} is enabled. Use a {nameof(TokenCredential)} instead.",
                        nameof(clientCertificate));
                }

                // HttpPipelineBuilder.Build requires a non-null transportOptions; supplying an
                // empty instance preserves the system-default trust chain and validation policy.
                transportOptions = new HttpPipelineTransportOptions();
                perRetryPolicies = new HttpPipelinePolicy[]
                {
                    new ConfidentialLedgerRedirectPolicy(ledgerEndpoint, cachePrimaryNode: false)
                };
            }
            else
            {
                var actualCertificateClientOptions = certificateClientOptions ?? new ConfidentialLedgerCertificateClientOptions();
                X509Certificate2 serviceCert = identityServiceCert ?? GetIdentityServerTlsCert(ledgerEndpoint, actualCertificateClientOptions, ledgerOptions: actualOptions).Cert;
                var trustStore = new ConfidentialLedgerCertificateTrustStore(actualOptions.VerifyConnection);
                trustStore.Trust(GetLedgerId(ledgerEndpoint), serviceCert);
                transportOptions = CreateTransportOptions(trustStore, clientCertificate, GetLedgerId(ledgerEndpoint));

                // Discovery and certificate lookup use normal public-PKI validation, never the ledger
                // pipeline whose transport is pinned to a specific CCF network certificate.
                HttpPipeline discoveryPipeline = HttpPipelineBuilder.Build(actualOptions);
                Uri identityServiceEndpoint = actualOptions.CertificateEndpoint ?? new Uri(Default_Certificate_Endpoint);
                _failoverService = new ConfidentialLedgerFailoverService(
                    discoveryPipeline,
                    identityServiceEndpoint,
                    trustStore,
                    endpoint => GetIdentityServerTlsCert(
                        endpoint,
                        actualCertificateClientOptions,
                        new ConfidentialLedgerCertificateClient(identityServiceEndpoint, actualCertificateClientOptions)).Cert,
                    endpoint => CreateEndpointPipeline(actualOptions, trustStore, clientCertificate, endpoint),
                    actualOptions.Failover);
                perRetryPolicies = new HttpPipelinePolicy[]
                {
                    new ConfidentialLedgerRedirectPolicy(ledgerEndpoint),
                    new FailoverPolicy(_failoverService, actualOptions.FailoverNetworkTimeout)
                };
            }
            Pipeline = HttpPipelineBuilder.Build(
                actualOptions,
                perRetryPolicies,
                _tokenCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) },
                transportOptions,
                new ConfidentialLedgerResponseClassifier());
            _ledgerEndpoint = ledgerEndpoint;
            _endpoint = ledgerEndpoint;
            _apiVersion = actualOptions.Version;
            _enableArchivedCollectionFallback = actualOptions.EnableArchivedCollectionFallback;
            _maxLoadingRetries = actualOptions.Retry.MaxRetries;
            _loadingPollDelay = actualOptions.Retry.Delay;
        }

        private static string GetLedgerId(Uri endpoint)
        {
            string host = endpoint.Host;
            int dotIndex = host.IndexOf('.');
            return dotIndex > 0 ? host.Substring(0, dotIndex) : host;
        }

        internal class ConfidentialLedgerResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableException(Exception exception)
            {
                return base.IsRetriableException(exception) ||
                    exception is System.Net.Http.HttpRequestException ||
                    exception is System.Net.Sockets.SocketException ||
                    exception is System.Security.Authentication.AuthenticationException ||
                    exception is TimeoutException;
            }

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
                if (_useLedgerGateway)
                {
                    // The Ledger Gateway can respond with either 200 (synchronous commit, mirrors
                    // legacy CCF behavior) or 202 (write was queued and an operation id was returned
                    // for polling). Both must flow back to the caller without throwing. Layer "202 is a
                    // success" over the message's existing classifier so any RequestContext.AddClassifier
                    // the caller supplied is preserved rather than replaced.
                    message.ResponseClassifier = new LedgerGatewayAccept202Classifier(message.ResponseClassifier);
                }
                var response = Pipeline.ProcessMessage(message, context);

                var operation = CreatePostLedgerEntryOperation(response);
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
                if (_useLedgerGateway)
                {
                    // Layer "202 is a success" over the message's existing classifier so any
                    // RequestContext.AddClassifier the caller supplied is preserved rather than replaced.
                    message.ResponseClassifier = new LedgerGatewayAccept202Classifier(message.ResponseClassifier);
                }
                var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);

                var operation = CreatePostLedgerEntryOperation(response);
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

        private PostLedgerEntryOperation CreatePostLedgerEntryOperation(Response response)
        {
            // 202 indicates the Ledger Gateway has queued the write and returned an operation
            // id for asynchronous polling. The operation id is published in the
            // x-ms-webfe-operation-id header; if absent for any reason, fall back to the response
            // body (a JSON object containing an "operationId" property).
            if (response.Status == 202)
            {
                if (!response.Headers.TryGetValue(ConfidentialLedgerConstants.OperationIdHeaderName, out string operationId)
                    || string.IsNullOrEmpty(operationId))
                {
                    operationId = TryReadOperationIdFromBody(response);
                }

                if (string.IsNullOrEmpty(operationId))
                {
                    throw new RequestFailedException(
                        response.Status,
                        $"The Confidential Ledger Gateway returned HTTP 202 without a '{ConfidentialLedgerConstants.OperationIdHeaderName}' header or a body-level 'operationId' field, so the write cannot be tracked.");
                }

                return new PostLedgerEntryOperation(this, operationId, PostLedgerEntryOperation.PollingMode.LedgerGateway, response);
            }

            // Standard synchronous-commit path. Works for both legacy CCF and the Ledger Gateway
            // when the latter chooses to commit synchronously (returning 200).
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);
            return new PostLedgerEntryOperation(this, transactionId, PostLedgerEntryOperation.PollingMode.Direct, response);
        }

        private static string TryReadOperationIdFromBody(Response response)
        {
            try
            {
                if (response.Content == null || response.Content.ToMemory().Length == 0)
                {
                    return null;
                }

                using JsonDocument document = JsonDocument.Parse(response.Content);
                if (document.RootElement.ValueKind == JsonValueKind.Object
                    && document.RootElement.TryGetProperty("operationId", out JsonElement op)
                    && op.ValueKind == JsonValueKind.String)
                {
                    return op.GetString();
                }
            }
            catch (JsonException)
            {
                // Body wasn't JSON or didn't contain operationId; fall through to null.
            }

            return null;
        }

        /// <summary> Gets the ledger entry at the specified transaction id. </summary>
        public virtual async Task<Response> GetLedgerEntryAsync(string transactionId, string collectionId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(transactionId, nameof(transactionId));
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetLedgerEntry");
            scope.Start();
            try
            {
                System.Threading.CancellationToken cancellationToken = context?.CancellationToken ?? default;
                for (int attempt = 0; ; attempt++)
                {
                    using HttpMessage message = CreateFailoverGetLedgerEntryRequest(transactionId, collectionId, context);
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    if (!IsLoadingResponse(response) || attempt >= _maxLoadingRetries)
                    {
                        return response;
                    }
                    await Task.Delay(_loadingPollDelay, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                scope.Failed(exception);
                throw;
            }
        }

        /// <summary> Gets the ledger entry at the specified transaction id. </summary>
        public virtual Response GetLedgerEntry(string transactionId, string collectionId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(transactionId, nameof(transactionId));
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetLedgerEntry");
            scope.Start();
            try
            {
                System.Threading.CancellationToken cancellationToken = context?.CancellationToken ?? default;
                for (int attempt = 0; ; attempt++)
                {
                    using HttpMessage message = CreateFailoverGetLedgerEntryRequest(transactionId, collectionId, context);
                    Response response = Pipeline.ProcessMessage(message, context);
                    if (!IsLoadingResponse(response) || attempt >= _maxLoadingRetries)
                    {
                        return response;
                    }
                    cancellationToken.WaitHandle.WaitOne(_loadingPollDelay);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            catch (Exception exception)
            {
                scope.Failed(exception);
                throw;
            }
        }

        /// <summary> Gets the current value available in the ledger. </summary>
        public virtual async Task<Response> GetCurrentLedgerEntryAsync(string collectionId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetCurrentLedgerEntry");
            scope.Start();
            try
            {
                try
                {
                    using HttpMessage message = CreateFailoverGetCurrentLedgerEntryRequest(collectionId, context);
                    return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                }
                catch (RequestFailedException exception) when (_enableArchivedCollectionFallback && collectionId != null && IsArchivedCollectionNotFound(exception))
                {
                    Response archived = await TryGetArchivedCurrentEntryAsync(collectionId, context).ConfigureAwait(false);
                    if (archived != null)
                    {
                        return archived;
                    }
                    throw;
                }
            }
            catch (Exception exception)
            {
                scope.Failed(exception);
                throw;
            }
        }

        /// <summary> Gets the current value available in the ledger. </summary>
        public virtual Response GetCurrentLedgerEntry(string collectionId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConfidentialLedgerClient.GetCurrentLedgerEntry");
            scope.Start();
            try
            {
                try
                {
                    using HttpMessage message = CreateFailoverGetCurrentLedgerEntryRequest(collectionId, context);
                    return Pipeline.ProcessMessage(message, context);
                }
                catch (RequestFailedException exception) when (_enableArchivedCollectionFallback && collectionId != null && IsArchivedCollectionNotFound(exception))
                {
                    Response archived = TryGetArchivedCurrentEntry(collectionId, context);
                    if (archived != null)
                    {
                        return archived;
                    }
                    throw;
                }
            }
            catch (Exception exception)
            {
                scope.Failed(exception);
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

        private HttpMessage CreateFailoverGetLedgerEntryRequest(string transactionId, string collectionId, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, new ConfidentialLedgerResponseClassifier());
            FailoverPolicy.MarkEligible(message);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_ledgerEndpoint);
            uri.AppendPath("/app/transactions/", false);
            uri.AppendPath(transactionId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (collectionId != null)
            {
                uri.AppendQuery("collectionId", collectionId, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private HttpMessage CreateFailoverGetCurrentLedgerEntryRequest(string collectionId, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, new ConfidentialLedgerResponseClassifier());
            FailoverPolicy.MarkEligible(message);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_ledgerEndpoint);
            uri.AppendPath("/app/transactions/current", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (collectionId != null)
            {
                uri.AppendQuery("collectionId", collectionId, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private HttpPipeline CreateEndpointPipeline(
            ConfidentialLedgerClientOptions options,
            ConfidentialLedgerCertificateTrustStore trustStore,
            X509Certificate2 clientCertificate,
            Uri endpoint)
        {
            // A custom transport (for example playback or a user-supplied handler) remains authoritative.
            // For the default transport, each endpoint gets its own handler and certificate callback, which
            // prevents HTTP connection pooling or concurrent requests from widening certificate trust.
            HttpPipelineTransportOptions transportOptions = CreateTransportOptions(trustStore, clientCertificate, GetLedgerId(endpoint));
            return HttpPipelineBuilder.Build(
                options,
                new HttpPipelinePolicy[] { new ConfidentialLedgerRedirectPolicy(endpoint) },
                _tokenCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) },
                transportOptions,
                new ConfidentialLedgerResponseClassifier());
        }

        private static HttpPipelineTransportOptions CreateTransportOptions(
            ConfidentialLedgerCertificateTrustStore trustStore,
            X509Certificate2 clientCertificate,
            string ledgerId)
        {
            // Validation is delegated to the trust store for this endpoint's ledger id only.
            var options = new HttpPipelineTransportOptions
            {
                ServerCertificateCustomValidationCallback = args => trustStore.Validate(ledgerId, args.Certificate)
            };
            if (clientCertificate != null)
            {
                options.ClientCertificates.Add(clientCertificate);
            }
            return options;
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

        private static readonly byte[] s_loadingToken = System.Text.Encoding.UTF8.GetBytes("Loading");

        private static bool IsLoadingResponse(Response response)
        {
            if (response == null || response.Status != (int)HttpStatusCode.OK || response.Content == null)
            {
                return false;
            }

            ReadOnlySpan<byte> bytes = response.Content.ToMemory().Span;
            if (bytes.Length == 0 || bytes.IndexOf(s_loadingToken) < 0)
            {
                return false;
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(response.Content);
                JsonElement root = document.RootElement;
                return root.ValueKind == JsonValueKind.Object
                    && !root.TryGetProperty("entry", out _)
                    && root.TryGetProperty("state", out JsonElement state)
                    && state.ValueKind == JsonValueKind.String
                    && string.Equals(state.GetString(), "Loading", StringComparison.Ordinal);
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static bool IsArchivedCollectionNotFound(RequestFailedException exception)
            => exception != null && exception.Status == (int)HttpStatusCode.NotFound;

        private static Response FormatArchivedCurrentEntry(BinaryData latestEntry)
            => new ArchivedCurrentEntryResponse(latestEntry.ToArray());

        private async Task<Response> TryGetArchivedCurrentEntryAsync(string collectionId, RequestContext context)
        {
            BinaryData latest = null;
            Uri nextPage = null;
            int loadingRetries = 0;
            CancellationToken cancellationToken = context?.CancellationToken ?? default;

            while (true)
            {
                using HttpMessage message = nextPage == null
                    ? CreateGetLedgerEntriesRequest(collectionId, null, null, null, context)
                    : CreateNextGetLedgerEntriesRequest(nextPage, collectionId, null, null, null, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                using JsonDocument document = JsonDocument.Parse(response.Content);
                JsonElement root = document.RootElement;

                if (IsLoadingPage(root))
                {
                    if (loadingRetries++ >= _maxLoadingRetries)
                    {
                        return null;
                    }
                    nextPage = GetNextPage(root);
                    await Task.Delay(_loadingPollDelay, cancellationToken).ConfigureAwait(false);
                    continue;
                }

                loadingRetries = 0;
                latest = GetLatestEntry(root, latest);
                nextPage = GetNextPage(root);
                if (nextPage == null)
                {
                    break;
                }
            }

            return latest == null ? null : FormatArchivedCurrentEntry(latest);
        }

        private Response TryGetArchivedCurrentEntry(string collectionId, RequestContext context)
        {
            BinaryData latest = null;
            Uri nextPage = null;
            int loadingRetries = 0;
            CancellationToken cancellationToken = context?.CancellationToken ?? default;

            while (true)
            {
                using HttpMessage message = nextPage == null
                    ? CreateGetLedgerEntriesRequest(collectionId, null, null, null, context)
                    : CreateNextGetLedgerEntriesRequest(nextPage, collectionId, null, null, null, context);
                Response response = Pipeline.ProcessMessage(message, context);
                using JsonDocument document = JsonDocument.Parse(response.Content);
                JsonElement root = document.RootElement;

                if (IsLoadingPage(root))
                {
                    if (loadingRetries++ >= _maxLoadingRetries)
                    {
                        return null;
                    }
                    nextPage = GetNextPage(root);
                    cancellationToken.WaitHandle.WaitOne(_loadingPollDelay);
                    cancellationToken.ThrowIfCancellationRequested();
                    continue;
                }

                loadingRetries = 0;
                latest = GetLatestEntry(root, latest);
                nextPage = GetNextPage(root);
                if (nextPage == null)
                {
                    break;
                }
            }

            return latest == null ? null : FormatArchivedCurrentEntry(latest);
        }

        private static bool IsLoadingPage(JsonElement root) =>
            root.TryGetProperty("state", out JsonElement state) &&
            state.ValueKind == JsonValueKind.String &&
            string.Equals(state.GetString(), "Loading", StringComparison.Ordinal);

        private static Uri GetNextPage(JsonElement root)
        {
            if (!root.TryGetProperty("nextLink", out JsonElement nextLink) ||
                nextLink.ValueKind != JsonValueKind.String ||
                string.IsNullOrEmpty(nextLink.GetString()))
            {
                return null;
            }

            return new Uri(nextLink.GetString(), UriKind.RelativeOrAbsolute);
        }

        private static BinaryData GetLatestEntry(JsonElement root, BinaryData latest)
        {
            if (root.TryGetProperty("entries", out JsonElement entries) && entries.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement entry in entries.EnumerateArray())
                {
                    latest = BinaryData.FromString(entry.GetRawText());
                }
            }
            return latest;
        }

        private sealed class ArchivedCurrentEntryResponse : Response
        {
            private MemoryStream _stream;

            public ArchivedCurrentEntryResponse(byte[] content)
            {
                _stream = new MemoryStream(content ?? Array.Empty<byte>(), writable: false);
            }

            public override int Status => (int)HttpStatusCode.OK;
            public override string ReasonPhrase => "OK";
            public override Stream ContentStream
            {
                get => _stream;
                set => _stream = value as MemoryStream ?? new MemoryStream();
            }
            public override string ClientRequestId { get; set; } = string.Empty;
            public override void Dispose() => _stream?.Dispose();
            protected override bool ContainsHeader(string name) => false;
            protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();
            protected override bool TryGetHeader(string name, out string value)
            {
                value = null;
                return false;
            }
            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                values = null;
                return false;
            }
        }
    }
}
