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

        internal readonly ServiceClient ServiceClient;

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
            ServiceClient = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Content

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual RecognizeContentOperation StartRecognizeContent(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = ServiceClient.AnalyzeLayoutAsync(formFileStream, contentType, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await ServiceClient.AnalyzeLayoutAsyncAsync(formFileStream, contentType, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual RecognizeContentOperation StartRecognizeContent(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion

        #region Custom Forms

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual RecognizeFormsOperation StartRecognizeForms(string modelId, Stream formFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = ServiceClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeTextElements, formFileStream, contentType, cancellationToken);
            return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual RecognizeFormsOperation StartRecognizeForms(string modelId, Uri formFileUri, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeTextElements, sourcePath, cancellationToken);
            return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<RecognizeFormsOperation> StartRecognizeFormsAsync(string modelId, Stream formFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await ServiceClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeTextElements, formFileStream, contentType, cancellationToken).ConfigureAwait(false);
            return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<RecognizeFormsOperation> StartRecognizeFormsAsync(string modelId, Uri formFileUri, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeTextElements, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        #endregion

        #region Receipts
        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeUSReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeUSReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual RecognizeUSReceiptsOperation StartRecognizeUSReceipts(Stream receiptFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = ServiceClient.AnalyzeReceiptAsync(includeTextDetails: includeTextElements, receiptFileStream, contentType, cancellationToken);
            return new RecognizeUSReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeUSReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeUSReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual RecognizeUSReceiptsOperation StartRecognizeUSReceipts(Uri receiptFileUri, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = receiptFileUri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(includeTextDetails: includeTextElements, sourcePath, cancellationToken);
            return new RecognizeUSReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeUSReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeUSReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<RecognizeUSReceiptsOperation> StartRecognizeUSReceiptsAsync(Stream receiptFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeTextElements, contentType, receiptFileStream, cancellationToken).ConfigureAwait(false);
            return new RecognizeUSReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeUSReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeUSReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<RecognizeUSReceiptsOperation> StartRecognizeUSReceiptsAsync(Uri receiptFileUri, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = receiptFileUri.ToString() };
            ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: includeTextElements, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeUSReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }
        #endregion

        #region Business Cards
        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="businessCardFileStream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation"/>.Value upon successful
        /// completion will contain the extracted business card.</returns>
        public virtual RecognizeBusinessCardsOperation StartRecognizeBusinessCards(Stream businessCardFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="businessCardFileStream">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation"/>.Value upon successful
        /// completion will contain the extracted business card.</returns>
        public virtual RecognizeBusinessCardsOperation StartRecognizeBusinessCards(Uri businessCardFileStream, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="businessCardFileStream">The stream containing the one or more receipts to extract values from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation"/>.Value upon successful
        /// completion will contain the extracted business card.</returns>
        public virtual async Task<RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsAsync(Stream businessCardFileStream, ContentType contentType, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts values from one or more receipts.
        /// </summary>
        /// <param name="businessCardFileStream">The absolute URI of the remote file to extract values from.</param>
        /// <param name="includeTextElements">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation"/>.Value upon successful
        /// completion will contain the extracted business card.</returns>
        public virtual async Task<RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsAsync(Uri businessCardFileStream, bool includeTextElements = false, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }
        #endregion

    }
}
