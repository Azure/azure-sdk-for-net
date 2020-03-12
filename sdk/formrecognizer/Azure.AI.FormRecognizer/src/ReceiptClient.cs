// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer
{
    public class ReceiptClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceClient _operations;

        internal const string ReceiptsRoute = "/prebuilt/receipt";

        protected ReceiptClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public ReceiptClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public ReceiptClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        public virtual Operation<IReadOnlyList<ExtractedReceipt>> ExtractReceipt(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        public virtual Operation<IReadOnlyList<ExtractedReceipt>> ExtractReceipt(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.RestClient.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        public virtual async Task<Operation<IReadOnlyList<ExtractedReceipt>>> ExtractReceiptAsync(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await _operations.AnalyzeReceiptAsyncAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        public virtual async Task<Operation<IReadOnlyList<ExtractedReceipt>>> ExtractReceiptAsync(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await _operations.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);
        }
    }
}
