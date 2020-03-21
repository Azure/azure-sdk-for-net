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
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceClient _operations;

        internal const string ReceiptsRoute = "/prebuilt/receipt";
        internal const string LayoutRoute = "/layout";
        internal const string CustomModelsRoute = "/custom/models";

        /// <summary>
        /// </summary>
        protected FormRecognizerClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, FormRecognizerApiKeyCredential credential)
            : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Receipts
        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="stream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual Operation<IReadOnlyList<RecognizedReceipt>> StartRecognizeReceipts(Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new RecognizeReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual Operation<IReadOnlyList<RecognizedReceipt>> StartRecognizeReceipts(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = _operations.RestClient.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new RecognizeReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="stream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<Operation<IReadOnlyList<RecognizedReceipt>>> StartRecognizeReceiptsAsync(Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await _operations.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeRawPageExtractions, contentType, stream, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<Operation<IReadOnlyList<RecognizedReceipt>>> StartRecognizeReceiptsAsync(Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await _operations.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptOperation(_operations, response.Headers.OperationLocation);
        }
        #endregion

        #region Content

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual Operation<IReadOnlyList<FormContentPage>> StartRecognizeContent(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = _operations.AnalyzeLayoutAsync(stream, contentType, cancellationToken);
            return new RecognizeContentOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<Operation<IReadOnlyList<FormContentPage>>> StartRecognizeContentAsync(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await _operations.AnalyzeLayoutAsyncAsync(stream, contentType, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual Operation<IReadOnlyList<FormContentPage>> StartRecognizeContent(Uri uri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = _operations.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new RecognizeContentOperation(_operations, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedLayoutPage&gt;&gt;.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<Operation<IReadOnlyList<FormContentPage>>> StartRecognizeContentAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await _operations.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(_operations, response.Headers.OperationLocation);
        }

        #endregion

        #region Custom Forms

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual Operation<IReadOnlyList<CustomFormPage>> StartRecognizeForms(string customModelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new RecognizeFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual Operation<IReadOnlyList<CustomFormPage>> StartRecognizeForms(string customModelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.RestClient.AnalyzeWithCustomModel(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new RecognizeFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<CustomFormPage>>> StartRecognizeFormsAsync(string customModelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new RecognizeFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<CustomFormPage>>> StartRecognizeFormsAsync(string customModelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.RestClient.AnalyzeWithCustomModelAsync(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        #endregion

        #region Custom Labeled Forms

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual Operation<IReadOnlyList<CustomLabeledForm>> StartRecognizeLabeledForms(string customModelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new RecognizeLabeledFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual Operation<IReadOnlyList<CustomLabeledForm>> StartRecognizeLabeledForms(string customModelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.RestClient.AnalyzeWithCustomModel(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new RecognizeLabeledFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<CustomLabeledForm>>> StartRecognizeLabeledFormsAsync(string customModelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new RecognizeLabeledFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="customModelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<CustomLabeledForm>>> StartRecognizeLabeledFormsAsync(string customModelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.RestClient.AnalyzeWithCustomModelAsync(new Guid(customModelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeLabeledFormOperation(_operations, customModelId, response.Headers.OperationLocation);
        }

        #endregion
    }
}
