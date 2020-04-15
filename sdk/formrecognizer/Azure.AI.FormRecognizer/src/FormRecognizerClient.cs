// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/>.
        /// </summary>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            _endpoint = endpoint;
            _credential = credential;
            var diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(_credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceClient(diagnostics, pipeline, _endpoint.ToString());
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
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContent(Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response =  ServiceClient.RestClient.AnalyzeLayoutAsync(contentType, formFileStream, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(contentType, formFileStream, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContentFromUri(Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentFromUriAsync(Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion

        #region Receipts

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="receiptLocale"></param>>
        /// <param name="recognizeOptions"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(Stream receiptFileStream, string receiptLocale = "en-US", RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receiptFileStream, nameof(receiptFileStream));

            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(contentType, receiptFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="receiptLocale"></param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceipts(Stream receiptFileStream, string receiptLocale = "en-US", RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receiptFileStream, nameof(receiptFileStream));

            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(contentType, receiptFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="receiptLocale"></param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(Uri receiptFileUri, string receiptLocale = "en-US", RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="receiptLocale"></param>
        /// <param name="recognizeOptions">Whether or not to include raw page recognition in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptFileUri, string receiptLocale="en-US", RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken);
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
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(new Guid(modelId), contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken);
            return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
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
            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken);
            return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
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
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken).ConfigureAwait(false);
            return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
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
            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeCustomFormsOperation(ServiceClient, modelId, response.Headers.OperationLocation);
        }

        #endregion

        #region Training client
        /// <summary>
        /// Get an instance of a <see cref="FormTrainingClient"/> from <see cref="FormRecognizerClient"/>.
        /// </summary>
        /// <returns>An instance of a <see cref="FormTrainingClient"/>.</returns>
        public virtual FormTrainingClient GetFormTrainingClient()
        {
            return new FormTrainingClient(_endpoint, _credential);
        }

        #endregion Training client

        /// <summary>
        /// Used as part of argument validation. Detects the <see cref="ContentType"/> of a stream and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="stream">The stream to which the content type detection attempt will be performed.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="stream"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The detected <see cref="ContentType"/>.</returns>
        /// <exception cref="ArgumentException">Happens when detection fails or cannot be performed.</exception>
        private static ContentType DetectContentType(Stream stream, string paramName)
        {
            ContentType contentType;

            if (!stream.CanSeek)
            {
                throw new ArgumentException("Content type cannot be detected because stream is not seekable.", paramName);
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException("Content type cannot be detected because stream is not readable.", paramName);
            }

            if (!stream.TryGetContentType(out contentType))
            {
                throw new ArgumentException("Content type of the stream could not be detected.", paramName);
            }

            return contentType;
        }
    }
}
