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

    /// <summary>
    /// The client to use to with the Form Recognizer Azure Cognitive Service, to extract layout elements like tables from forms.
    /// </summary>
    public class FormLayoutClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceClient _operations;

        internal const string LayoutRoute = "/layout";

        /// <summary>
        /// </summary>
        protected FormLayoutClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormLayoutClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormLayoutClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormLayoutClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormLayoutClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual Operation<IReadOnlyList<ExtractedLayoutPage>> StartExtractLayouts(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = _operations.AnalyzeLayoutAsync(stream, contentType, cancellationToken);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedLayoutPage>>> StartExtractLayoutsAsync(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await _operations.AnalyzeLayoutAsyncAsync(stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual Operation<IReadOnlyList<ExtractedLayoutPage>> StartExtractLayouts(Uri uri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = _operations.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedLayoutPage>>> StartExtractLayoutsAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await _operations.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractLayoutOperation(_operations, response.Headers.OperationLocation);
        }
    }
}
