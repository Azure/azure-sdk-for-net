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
    public class FormLayoutClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly AllOperations _operations;

        internal const string LayoutRoute = "/layout";

        protected FormLayoutClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormLayoutClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormLayoutClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new AllOperations(_diagnostics, _pipeline, endpoint.ToString());
        }

        // TODO: Implement these:
        //public virtual Response<IReadOnlyList<ExtractedLayoutPage>> ExtractLayout(Stream stream, CancellationToken cancellationToken = default);
        //public virtual Response<IReadOnlyList<ExtractedLayoutPage>> ExtractLayout(Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Response<IReadOnlyList<ExtractedLayoutPage>> ExtractLayout(Uri uri, CancellationToken cancellationToken = default);
        //public virtual Response<IReadOnlyList<ExtractedLayoutPage>> ExtractLayout(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Task<Response<IReadOnlyList<ExtractedLayoutPage>>> ExtractLayoutAsync(Stream stream, CancellationToken cancellationToken = default);
        //public virtual Task<Response<IReadOnlyList<ExtractedLayoutPage>>> ExtractLayoutAsync(Stream stream, FormContentType? contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        //public virtual Task<Response<IReadOnlyList<ExtractedLayoutPage>>> ExtractLayoutAsync(Uri uri, CancellationToken cancellationToken = default);
        //public virtual Task<Response<IReadOnlyList<ExtractedLayoutPage>>> ExtractLayoutAsync(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);

        public virtual ExtractLayoutOperation StartExtractLayout(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = _operations.AnalyzeLayoutAsync(stream, contentType , cancellationToken);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);
        }

        public virtual async Task<ExtractLayoutOperation> StartExtractLayoutAsync(Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await _operations.AnalyzeLayoutAsyncAsync(stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);

        }
    }
}
