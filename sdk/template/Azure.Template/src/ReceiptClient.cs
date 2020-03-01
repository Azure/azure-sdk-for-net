// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private readonly AllOperations _operations;

        internal const string CustomModelsRoute = "/prebuilt/receipt";

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
            _operations = new AllOperations(_diagnostics, _pipeline, endpoint.ToString());
        }

        // TODO: Implement these:
        //public virtual Response<ExtractedReceipt> ExtractReceipt(Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Response<ExtractedReceipt> ExtractReceipt(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Task<Response<ExtractedReceipt>> ExtractReceiptAsync(Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Task<Response<ExtractedReceipt>> ExtractReceiptAsync(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);

        public virtual Response<ExtractedReceipt> ExtractReceipt(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            var operation = new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);

            ValueTask<Response<ExtractedReceipt>> task = operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));

            // TODO: this feels very bad.  Better way?
            task.AsTask().Wait();

            if (!operation.HasValue)
            {
                throw new RequestFailedException("Failed to retrieve response from ExtractReceipt Long-Running Operation");
            }

            // TODO: this is also a mess. Reconcile these together.
            return Response.FromValue(operation.Value, task.AsTask().Result.GetRawResponse());
        }

        public virtual async Task<Response<ExtractedReceipt>> ExtractReceiptAsync(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            var operation = new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);

            var operationResponse = await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            if (!operation.HasValue)
            {
                throw new RequestFailedException("Failed to retrieve response from ExtractReceipt Long-Running Operation");
            }

            // TODO: Is this the best way?
            return Response.FromValue(operation.Value, operationResponse.GetRawResponse());
        }

        //public virtual Response<AnalyzeResult_internal> ExtractReceipt(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        //{
        //    // TODO: automate content-type detection
        //    ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
        //    var operation = new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);

        //    ValueTask<Response<AnalyzeResult_internal>> task = operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1));

        //    // TODO: this feels very bad.  Better way?
        //    task.AsTask().Wait();

        //    if (!operation.HasValue)
        //    {
        //        throw new RequestFailedException("Failed to retrieve response from ExtractReceipt Long-Running Operation");
        //    }

        //    // TODO: this is also a mess. Reconcile these together.
        //    return Response.FromValue(operation.Value, task.AsTask().Result.GetRawResponse());
        //}

        //public virtual async Task<Response<AnalyzeResult_internal>> ExtractReceiptAsync(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        //{
        //    // TODO: automate content-type detection
        //    ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
        //    var operation = new ExtractReceiptOperation(_operations, response.Headers.OperationLocation);

        //    var operationResponse = await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

        //    if (!operation.HasValue)
        //    {
        //        throw new RequestFailedException("Failed to retrieve response from ExtractReceipt Long-Running Operation");
        //    }

        //    // TODO: Is this the best way?
        //    return Response.FromValue(operation.Value, operationResponse.GetRawResponse());
        //}
    }
}
