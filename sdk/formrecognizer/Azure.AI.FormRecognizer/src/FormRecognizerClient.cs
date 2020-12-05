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
    /// business cards, and invoices, to recognize form content, and to extract fields from custom forms with models trained on custom form types.
    /// </summary>
    public class FormRecognizerClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly FormRecognizerRestClient ServiceClient;

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
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
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
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="diagnostics">Provides tools for exception creation in case of failure.</param>
        /// <param name="serviceClient">Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        internal FormRecognizerClient(ClientDiagnostics diagnostics, FormRecognizerRestClient serviceClient)
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
        /// <param name="recognizeContentOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the language of the form, and which pages in a multi-page document to analyze.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual RecognizeContentOperation StartRecognizeContent(Stream form, RecognizeContentOptions recognizeContentOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(form, nameof(form));

            recognizeContentOptions ??= new RecognizeContentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeContent)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeContentOptions.ContentType ?? DetectContentType(form, nameof(form));

                Response response = ServiceClient.AnalyzeLayoutAsync(
                    formContentType.ConvertToContentType1(),
                    form,
                    recognizeContentOptions.Language == null ? (Language?)null : recognizeContentOptions.Language,
                    recognizeContentOptions.Pages,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="form">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeContentOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the language of the form, and which pages in a multi-page document to analyze.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentAsync(Stream form, RecognizeContentOptions recognizeContentOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(form, nameof(form));

            recognizeContentOptions ??= new RecognizeContentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeContent)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeContentOptions.ContentType ?? DetectContentType(form, nameof(form));

                Response response = await ServiceClient.AnalyzeLayoutAsyncAsync(
                    formContentType.ConvertToContentType1(),
                    form,
                    recognizeContentOptions.Language == null ? (Language?)null : recognizeContentOptions.Language,
                    recognizeContentOptions.Pages,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeContentOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the language of the form, and which pages in a multi-page document to analyze.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual RecognizeContentOperation StartRecognizeContentFromUri(Uri formUri, RecognizeContentOptions recognizeContentOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formUri, nameof(formUri));

            recognizeContentOptions ??= new RecognizeContentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeContentFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = formUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeLayoutAsync(
                    recognizeContentOptions.Language == null ? (Language?)null : recognizeContentOptions.Language,
                    recognizeContentOptions.Pages,
                    sourcePath,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes layout elements from one or more passed-in forms.
        /// </summary>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeContentOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the language of the form, and which pages in a multi-page document to analyze.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeContentOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeContentOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<RecognizeContentOperation> StartRecognizeContentFromUriAsync(Uri formUri, RecognizeContentOptions recognizeContentOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(formUri, nameof(formUri));

            recognizeContentOptions ??= new RecognizeContentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeContentFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = formUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeLayoutAsyncAsync(
                    recognizeContentOptions.Language == null ? (Language?)null : recognizeContentOptions.Language,
                    recognizeContentOptions.Pages,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeContentOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Receipts

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// <para>See <a href="https://aka.ms/formrecognizer/receiptfields"/> for a list of available fields on a receipt.</para>
        /// </summary>
        /// <param name="receipt">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="recognizeReceiptsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsAsync(Stream receipt, RecognizeReceiptsOptions recognizeReceiptsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receipt, nameof(receipt));

            recognizeReceiptsOptions ??= new RecognizeReceiptsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeReceipts)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeReceiptsOptions.ContentType ?? DetectContentType(receipt, nameof(receipt));

                Response response = await ServiceClient.AnalyzeReceiptAsyncAsync(
                    formContentType.ConvertToContentType1(),
                    receipt,
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale == null ? (Locale?)null : recognizeReceiptsOptions.Locale,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// <para>See <a href="https://aka.ms/formrecognizer/receiptfields"/> for a list of available fields on a receipt.</para>
        /// </summary>
        /// <param name="receipt">The stream containing the one or more receipts to recognize values from.</param>
        /// <param name="recognizeReceiptsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual RecognizeReceiptsOperation StartRecognizeReceipts(Stream receipt, RecognizeReceiptsOptions recognizeReceiptsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receipt, nameof(receipt));

            recognizeReceiptsOptions ??= new RecognizeReceiptsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeReceipts)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeReceiptsOptions.ContentType ?? DetectContentType(receipt, nameof(receipt));

                Response response = ServiceClient.AnalyzeReceiptAsync(
                    formContentType.ConvertToContentType1(),
                    receipt,
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale == null ? (Locale?)null : recognizeReceiptsOptions.Locale,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// <para>See <a href="https://aka.ms/formrecognizer/receiptfields"/> for a list of available fields on a receipt.</para>
        /// </summary>
        /// <param name="receiptUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeReceiptsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual async Task<RecognizeReceiptsOperation> StartRecognizeReceiptsFromUriAsync(Uri receiptUri, RecognizeReceiptsOptions recognizeReceiptsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptUri, nameof(receiptUri));

            recognizeReceiptsOptions ??= new RecognizeReceiptsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeReceiptsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = receiptUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeReceiptAsyncAsync(
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale == null ? (Locale?)null : recognizeReceiptsOptions.Locale,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more receipts.
        /// <para>See <a href="https://aka.ms/formrecognizer/receiptfields"/> for a list of available fields on a receipt.</para>
        /// </summary>
        /// <param name="receiptUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeReceiptsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeReceiptsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeReceiptsOperation.Value"/> upon successful
        /// completion will contain the extracted receipt.</returns>
        public virtual RecognizeReceiptsOperation StartRecognizeReceiptsFromUri(Uri receiptUri, RecognizeReceiptsOptions recognizeReceiptsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(receiptUri, nameof(receiptUri));

            recognizeReceiptsOptions ??= new RecognizeReceiptsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeReceiptsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = receiptUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeReceiptAsync(
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale == null ? (Locale?)null : recognizeReceiptsOptions.Locale,
                    sourcePath,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeReceiptsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Business Cards

        /// <summary>
        /// Recognizes values from one or more business cards.
        /// <para>See <a href="https://aka.ms/formrecognizer/businesscardfields"/> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCard">The stream containing the one or more business cards to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation.Value"/> upon successful
        /// completion will contain the extracted business cards.</returns>
        public virtual async Task<RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsAsync(Stream businessCard, RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(businessCard, nameof(businessCard));

            recognizeBusinessCardsOptions ??= new RecognizeBusinessCardsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeBusinessCards)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeBusinessCardsOptions.ContentType ?? DetectContentType(businessCard, nameof(businessCard));

                Response response = await ServiceClient.AnalyzeBusinessCardAsyncAsync(
                    formContentType.ConvertToContentType1(),
                    businessCard,
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale == null ? (Locale?)null : recognizeBusinessCardsOptions.Locale,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeBusinessCardsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more business cards.
        /// <para>See <a href="https://aka.ms/formrecognizer/businesscardfields"/> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCard">The stream containing the one or more business cards to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation.Value"/> upon successful
        /// completion will contain the extracted business cards.</returns>
        public virtual RecognizeBusinessCardsOperation StartRecognizeBusinessCards(Stream businessCard, RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(businessCard, nameof(businessCard));

            recognizeBusinessCardsOptions ??= new RecognizeBusinessCardsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeBusinessCards)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeBusinessCardsOptions.ContentType ?? DetectContentType(businessCard, nameof(businessCard));

                Response response = ServiceClient.AnalyzeBusinessCardAsync(
                    formContentType.ConvertToContentType1(),
                    businessCard,
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale == null ? (Locale?)null : recognizeBusinessCardsOptions.Locale,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeBusinessCardsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more business cards.
        /// <para>See <a href="https://aka.ms/formrecognizer/businesscardfields"/> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCardUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation.Value"/> upon successful
        /// completion will contain the extracted business cards.</returns>
        public virtual async Task<RecognizeBusinessCardsOperation> StartRecognizeBusinessCardsFromUriAsync(Uri businessCardUri, RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(businessCardUri, nameof(businessCardUri));

            recognizeBusinessCardsOptions ??= new RecognizeBusinessCardsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeBusinessCardsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = businessCardUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeBusinessCardAsyncAsync(
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale == null ? (Locale?)null : recognizeBusinessCardsOptions.Locale,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeBusinessCardsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more business cards.
        /// <para>See <a href="https://aka.ms/formrecognizer/businesscardfields"/> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCardUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeBusinessCardsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeBusinessCardsOperation.Value"/> upon successful
        /// completion will contain the extracted business cards.</returns>
        public virtual RecognizeBusinessCardsOperation StartRecognizeBusinessCardsFromUri(Uri businessCardUri, RecognizeBusinessCardsOptions recognizeBusinessCardsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(businessCardUri, nameof(businessCardUri));

            recognizeBusinessCardsOptions ??= new RecognizeBusinessCardsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeBusinessCardsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = businessCardUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeBusinessCardAsync(
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale == null ? (Locale?)null : recognizeBusinessCardsOptions.Locale,
                    sourcePath,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeBusinessCardsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Invoices

        /// <summary>
        /// Recognizes values from one or more invoices.
        /// <para>See <a href="https://aka.ms/formrecognizer/invoicefields"/> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoice">The stream containing the one or more invoices to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeInvoicesOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeInvoicesOperation.Value"/> upon successful
        /// completion will contain the extracted invoices.</returns>
        public virtual async Task<RecognizeInvoicesOperation> StartRecognizeInvoicesAsync(Stream invoice, RecognizeInvoicesOptions recognizeInvoicesOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(invoice, nameof(invoice));

            recognizeInvoicesOptions ??= new RecognizeInvoicesOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeInvoices)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeInvoicesOptions.ContentType ?? DetectContentType(invoice, nameof(invoice));

                Response response = await ServiceClient.AnalyzeInvoiceAsyncAsync(
                    formContentType.ConvertToContentType1(),
                    invoice,
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale == null ? (Locale?)null : recognizeInvoicesOptions.Locale,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeInvoicesOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more invoices.
        /// <para>See <a href="https://aka.ms/formrecognizer/invoicefields"/> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoice">The stream containing the one or more invoices to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeInvoicesOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeInvoicesOperation.Value"/> upon successful
        /// completion will contain the extracted invoices.</returns>
        public virtual RecognizeInvoicesOperation StartRecognizeInvoices(Stream invoice, RecognizeInvoicesOptions recognizeInvoicesOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(invoice, nameof(invoice));

            recognizeInvoicesOptions ??= new RecognizeInvoicesOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeInvoices)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeInvoicesOptions.ContentType ?? DetectContentType(invoice, nameof(invoice));

                Response response = ServiceClient.AnalyzeInvoiceAsync(
                    formContentType.ConvertToContentType1(),
                    invoice,
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale == null ? (Locale?)null : recognizeInvoicesOptions.Locale,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeInvoicesOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more invoices.
        /// <para>See <a href="https://aka.ms/formrecognizer/invoicefields"/> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoiceUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeInvoicesOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeInvoicesOperation.Value"/> upon successful
        /// completion will contain the extracted invoices.</returns>
        public virtual async Task<RecognizeInvoicesOperation> StartRecognizeInvoicesFromUriAsync(Uri invoiceUri, RecognizeInvoicesOptions recognizeInvoicesOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(invoiceUri, nameof(invoiceUri));

            recognizeInvoicesOptions ??= new RecognizeInvoicesOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeInvoicesFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = invoiceUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeInvoiceAsyncAsync(
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale == null ? (Locale?)null : recognizeInvoicesOptions.Locale,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeInvoicesOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes values from one or more invoices.
        /// <para>See <a href="https://aka.ms/formrecognizer/invoicefields"/> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoiceUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeInvoicesOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeInvoicesOperation.Value"/> upon successful
        /// completion will contain the extracted invoices.</returns>
        public virtual RecognizeInvoicesOperation StartRecognizeInvoicesFromUri(Uri invoiceUri, RecognizeInvoicesOptions recognizeInvoicesOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(invoiceUri, nameof(invoiceUri));

            recognizeInvoicesOptions ??= new RecognizeInvoicesOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeInvoicesFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = invoiceUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeInvoiceAsync(
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale == null ? (Locale?)null : recognizeInvoicesOptions.Locale,
                    sourcePath,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeInvoicesOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion

        #region Custom Forms

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="form">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeCustomFormsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomForms(string modelId, Stream form, RecognizeCustomFormsOptions recognizeCustomFormsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(form, nameof(form));

            recognizeCustomFormsOptions ??= new RecognizeCustomFormsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeCustomForms)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                FormContentType formContentType = recognizeCustomFormsOptions.ContentType ?? DetectContentType(form, nameof(form));

                Response response = ServiceClient.AnalyzeWithCustomModel(guid, formContentType, form, includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements, cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeCustomFormsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        public virtual RecognizeCustomFormsOperation StartRecognizeCustomFormsFromUri(string modelId, Uri formUri, RecognizeCustomFormsOptions recognizeCustomFormsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formUri, nameof(formUri));

            recognizeCustomFormsOptions ??= new RecognizeCustomFormsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeCustomFormsFromUri)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

                SourcePath sourcePath = new SourcePath() { Source = formUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeWithCustomModel(guid, includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements, sourcePath, cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="form">The stream containing one or more forms to recognize elements from.</param>
        /// <param name="recognizeCustomFormsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsAsync(string modelId, Stream form, RecognizeCustomFormsOptions recognizeCustomFormsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(form, nameof(form));

            recognizeCustomFormsOptions ??= new RecognizeCustomFormsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeCustomForms)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                FormContentType formContentType = recognizeCustomFormsOptions.ContentType ?? DetectContentType(form, nameof(form));

                Response response = await ServiceClient.AnalyzeWithCustomModelAsync(guid, formContentType, form, includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements, cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recognizes pages from one or more forms, using a model trained with custom forms.
        /// </summary>
        /// <param name="modelId">The ID of the model to use for recognizing form values.</param>
        /// <param name="formUri">The absolute URI of the remote file to recognize elements from.</param>
        /// <param name="recognizeCustomFormsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecognizeCustomFormsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeCustomFormsOperation.Value"/> upon successful
        /// completion will contain recognized pages from the input document.</returns>
        public virtual async Task<RecognizeCustomFormsOperation> StartRecognizeCustomFormsFromUriAsync(string modelId, Uri formUri, RecognizeCustomFormsOptions recognizeCustomFormsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(formUri, nameof(formUri));

            recognizeCustomFormsOptions ??= new RecognizeCustomFormsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeCustomFormsFromUri)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

                SourcePath sourcePath = new SourcePath() { Source = formUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeWithCustomModelAsync(guid, includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements, sourcePath, cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeCustomFormsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                throw new ArgumentException($"Content type cannot be detected because stream is not seekable. It can be manually set in the options parameter of the start operation method.", paramName);
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException($"Content type cannot be detected because stream is not readable. It can be manually set in the options parameter of the start operation method.", paramName);
            }

            if (!stream.TryGetContentType(out contentType))
            {
                throw new ArgumentException($"Content type of the stream could not be detected. It can be manually set in the options parameter of the start operation method.", paramName);
            }

            return contentType;
        }
    }
}
