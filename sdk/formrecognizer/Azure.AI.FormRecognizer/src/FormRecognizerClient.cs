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
    /// <summary>
    /// The client to use to connect to the Form Recognizer Azure Cognitive Service to recognize
    /// information from forms and images and extract it into structured data. It provides the ability to analyze receipts,
    /// to recognize form content, and to extract fields from custom forms with models trained on custom form types.
    /// </summary>
    public class FormRecognizerClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly ServiceRestClient ServiceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        internal readonly ClientDiagnostics Diagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
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
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormRecognizerClient(Uri endpoint, TokenCredential credential)
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
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormRecognizerClient(Uri endpoint, TokenCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="diagnostics">Provides tools for exception creation in case of failure.</param>
        /// <param name="serviceClient">Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        internal FormRecognizerClient(ClientDiagnostics diagnostics, ServiceRestClient serviceClient)
        {
            Diagnostics = diagnostics;
            ServiceClient = serviceClient;
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
        /// <param name="form">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContent(Stream form, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(form, nameof(form));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(form, nameof(form));

            Response response =  ServiceClient.AnalyzeLayoutAsync(contentType, form, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="form">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream form, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(form, nameof(form));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(form, nameof(form));

            Response response = await ServiceClient.AnalyzeLayoutAsyncAsync(contentType, form, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeContentOperation StartRecognizeContentFromUri(Uri formUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formUri, nameof(formUri));

            SourcePath_internal sourcePath = new SourcePath_internal(formUri.AbsoluteUri);
            Response response = ServiceClient.AnalyzeLayoutAsync(sourcePath, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentFromUriAsync(Uri formUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formUri, nameof(formUri));

            SourcePath_internal sourcePath = new SourcePath_internal(formUri.AbsoluteUri);
            Response response = await ServiceClient.AnalyzeLayoutAsyncAsync(sourcePath, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
        }

        #endregion

        #region Receipts

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receipt">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(Stream receipt, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receipt, nameof(receipt));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receipt, nameof(receipt));

            Response response = await ServiceClient.AnalyzeReceiptAsyncAsync(contentType, receipt, includeTextDetails: recognizeOptions.IncludeFieldElements, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receipt">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceipts(Stream receipt, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receipt, nameof(receipt));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(receipt, nameof(receipt));

            Response response = ServiceClient.AnalyzeReceiptAsync(contentType, receipt, includeTextDetails: recognizeOptions.IncludeFieldElements, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(Uri receiptUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptUri, nameof(receiptUri));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptUri.AbsoluteUri);
            Response response = await ServiceClient.AnalyzeReceiptAsyncAsync(includeTextDetails: recognizeOptions.IncludeFieldElements, sourcePath, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// </summary>
        /// <param name="receiptUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptUri, nameof(receiptUri));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(receiptUri.AbsoluteUri);
            Response response = ServiceClient.AnalyzeReceiptAsync(includeTextDetails: recognizeOptions.IncludeFieldElements, sourcePath, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
        }

        #endregion

        #region Custom Forms

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            Response response = ServiceClient.AnalyzeWithCustomModel(guid, contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeFieldElements, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.AbsoluteUri);
            Response response = ServiceClient.AnalyzeWithCustomModel(guid, includeTextDetails: recognizeOptions.IncludeFieldElements, sourcePath, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formFileStream">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, Stream formFileStream, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileStream, nameof(formFileStream));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();
            FormContentType contentType = recognizeOptions.ContentType ?? DetectContentType(formFileStream, nameof(formFileStream));

            Response response = await ServiceClient.AnalyzeWithCustomModelAsync(guid, contentType, formFileStream, includeTextDetails: recognizeOptions.IncludeFieldElements, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formFileUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeOptions">A set of options available for configuring the recognize request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        [ForwardsClientCalls]
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, Uri formFileUri, RecognizeOptions recognizeOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formFileUri, nameof(formFileUri));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            recognizeOptions ??= new RecognizeOptions();

            SourcePath_internal sourcePath = new SourcePath_internal(formFileUri.AbsoluteUri);
            Response response = await ServiceClient.AnalyzeWithCustomModelAsync(guid, includeTextDetails: recognizeOptions.IncludeFieldElements, sourcePath, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
        }

        #endregion

        /// <summary>
        /// Used as part of argument validation. Detects the <see cref="FormContentType"/> of a stream and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="stream">The stream to which the content type detection attempt will be performed.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="stream"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The detected <see cref="FormContentType"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when detection fails or cannot be performed.</exception>
        private static FormContentType DetectContentType(Stream stream, string paramName)
        {
            FormContentType contentType;

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
