// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
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
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(contentType, formFileStream, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContent(Stream formFileStream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(contentType, formFileStream, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentFromUriAsync(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContentFromUri(Uri formFileUri, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
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
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
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
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
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
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
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
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptFileUri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = receiptFileUri.ToString() };
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion

        #region Custom Forms

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, Stream formFileStream, /* ContentType contentType, */ RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //// TODO: automate content-type detection
            //// https://github.com/Azure/azure-sdk-for-net/issues/10329
            //ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = ServiceClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeTextElements, formFileStream, contentType, cancellationToken);
            //return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            //ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeTextElements, sourcePath, cancellationToken);
            //return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, Stream formFileStream, /* ContentType contentType, */ RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();

            //// TODO: automate content-type detection
            //// https://github.com/Azure/azure-sdk-for-net/issues/10329
            //ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await ServiceClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeTextElements, formFileStream, contentType, cancellationToken).ConfigureAwait(false);
            //return new RecognizeFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();

            //SourcePath_internal sourcePath = new SourcePath_internal() { Source = formFileUri.ToString() };
            //ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeTextElements, sourcePath, cancellationToken).ConfigureAwait(false);
            //return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        #endregion

        #region Training client
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual FormTrainingClient GetFormTrainingClient()
        {
            throw new NotImplementedException();
        }

        #endregion Training client
    }
}
