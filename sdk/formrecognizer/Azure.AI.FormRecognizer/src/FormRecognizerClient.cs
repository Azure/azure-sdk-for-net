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
    /// The client to use to connect to the Form Recognizer Azure Cognitive Service to recognize
    /// information from forms and images and extract into structured data. It provides the ability to analyze receipts,
    /// to recognize form content, and to extract fields from custom forms with models trained on custom form types.
    /// </summary>
    public class FormRecognizerClient
    {
        internal readonly ServiceClient ServiceClient;
        internal readonly ClientDiagnostics Diagnostics;

        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _credential;
        private readonly FormRecognizerClientOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI <c>string</c> and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI <c>string</c> and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _endpoint = endpoint;
            _credential = credential;
            _options = options.Clone();

            Diagnostics = new ClientDiagnostics(_options);
            var pipeline = HttpPipelineBuilder.Build(_options, new AzureKeyCredentialPolicy(_credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceClient(Diagnostics, pipeline, _endpoint.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        protected FormRecognizerClient()
        {
        }

        #region Content

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContent(Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response =  ServiceClient.RestClient.AnalyzeLayoutAsync(contentType, formFileStream, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeLayoutAsyncAsync(contentType, formFileStream, cancellationToken).ConfigureAwait(false);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContentFromUri(Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeLayoutAsyncHeaders> response = ServiceClient.RestClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            return new RecognizeContentOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation"/>.Value upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentFromUriAsync(Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

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
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(Stream receiptFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptFileStream, nameof(receiptFileStream));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receiptFileStream, nameof(receiptFileStream));

            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(contentType, receiptFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileStream">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceipts(Stream receiptFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptFileStream, nameof(receiptFileStream));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receiptFileStream, nameof(receiptFileStream));

            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(contentType, receiptFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(Uri receiptFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptFileUri, nameof(receiptFileUri));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = await ServiceClient.RestClient.AnalyzeReceiptAsyncAsync(includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptFileUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation"/>.Value upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptFileUri, nameof(receiptFileUri));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeReceiptAsyncHeaders> response = ServiceClient.RestClient.AnalyzeReceiptAsync(includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken);
            return new RecognizeReceiptsOperation(ServiceClient, response.Headers.OperationLocation);
        }

        #endregion

        #region Custom Forms

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(guid, contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken);
            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = ServiceClient.RestClient.AnalyzeWithCustomModel(guid, includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken);
            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();
            ContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(guid, contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeTextContent, cancellationToken).ConfigureAwait(false);
            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The id of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation"/>.Value upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.ToString());
            ResponseWithHeaders<ServiceAnalyzeWithCustomModelHeaders> response = await ServiceClient.RestClient.AnalyzeWithCustomModelAsync(guid, includeTextDetails: recognizeOptions.IncludeTextContent, sourcePath, cancellationToken).ConfigureAwait(false);
            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation);
        }

        #endregion

        #region Training client

        /// <summary>
        /// Gets an instance of a <see cref="FormTrainingClient"/> that shares the same endpoint, the same
        /// credentials and the same set of <see cref="FormRecognizerClientOptions"/> this client has.
        /// </summary>
        /// <returns>A new instance of a <see cref="FormTrainingClient"/>.</returns>
        public virtual FormTrainingClient GetFormTrainingClient()
        {
            return new FormTrainingClient(_endpoint, _credential, _options);
        }

        #endregion Training client

        /// <summary>
        /// Used as part of argument validation. Detects the <see cref="ContentType"/> of a stream and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="stream">The stream to which the content type detection attempt will be performed.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="stream"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The detected <see cref="ContentType"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when detection fails or cannot be performed.</exception>
        private static ContentType DetectContentType(Stream stream, string paramName)
        {
            ContentType contentType;

            if (!stream.CanSeek)
            {
                throw new ArgumentException($"Content type cannot be detected because stream is not seekable. It can be manually set in the {nameof(RecognizeOptions)}.", paramName);
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException($"Content type cannot be detected because stream is not readable. It can be manually set in the {nameof(RecognizeOptions)}.", paramName);
            }

            if (!stream.TryGetContentType(out contentType))
            {
                throw new ArgumentException($"Content type of the stream could not be detected. It can be manually set in the {nameof(RecognizeOptions)}.", paramName);
            }

            return contentType;
        }
    }
}
