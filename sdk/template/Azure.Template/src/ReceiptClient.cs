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

        internal const string CustomModelsRoute = "/custom/models";


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

        //public virtual Response<AnalyzeResult_internal> ExtractReceipt(Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        //{

        //}

    }
}
