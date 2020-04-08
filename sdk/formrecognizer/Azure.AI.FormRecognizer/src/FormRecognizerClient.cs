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
    /// </summary>
    public class FormRecognizerClient
    {
        internal readonly ServiceClient ServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            var diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceClient(diagnostics, pipeline, endpoint.ToString());
        }

        /// <summary>
        /// </summary>
        protected FormRecognizerClient()
        {
        }

        #region Content

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements recognized from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Operation<IReadOnlyList<ExtractedLayoutPage>>> StartRecognizeContentAsync(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(contentType, formFileStream, cancellationToken).ConfigureAwait(false);
            return new ExtractLayoutOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements recognized from the form.</returns>
        [ForwardsClientCalls]
        public virtual Operation<IReadOnlyList<ExtractedLayoutPage>> StartRecognizeContent(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(contentType, formFileStream, cancellationToken);
            return new ExtractLayoutOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements recognized from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Operation<IReadOnlyList<ExtractedLayoutPage>>> StartRecognizeContentFromUriAsync(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractLayoutOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements recognized from the form.</returns>
        [ForwardsClientCalls]
        public virtual Operation<IReadOnlyList<ExtractedLayoutPage>> StartRecognizeContentFromUri(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new ExtractLayoutOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion

        #region Receipts

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the recognized receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(Stream receiptFileStream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(contentType, receiptFileStream, includeTextDetails: includeRawPageExtractions, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the recognized receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceipts(Stream receiptFileStream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(contentType, receiptFileStream, includeTextDetails: includeRawPageExtractions, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the recognized receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(Uri receiptFileUri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = receiptFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the recognized receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptFileUri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = receiptFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion
    }
}
