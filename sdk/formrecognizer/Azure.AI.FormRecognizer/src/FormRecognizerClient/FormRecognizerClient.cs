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
    /// Note that this client can only be used with service version <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> or lower.
    /// In order to use later versions and their new features, see <see cref="DocumentAnalysis.DocumentAnalysisClient"/>.
    /// </summary>
    /// <remarks>
    /// Client is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and older.
    /// </remarks>
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
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"> here</see>.
        /// </remarks>
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
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"> here</see>.
        /// </remarks>
        public FormRecognizerClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri, FormRecognizerClientOptions.GetVersionString(options.Version));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"> here</see>.
        /// </remarks>
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
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"> here</see>.
        /// </remarks>
        public FormRecognizerClient(Uri endpoint, TokenCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            string defaultScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? FormRecognizerAudience.AzurePublicCloud : options.Audience)}/.default";

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, defaultScope));
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri, FormRecognizerClientOptions.GetVersionString(options.Version));
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
                    GetInternalContentType(formContentType),
                    recognizeContentOptions.Pages.Count == 0 ? null : recognizeContentOptions.Pages,
                    recognizeContentOptions.Language,
                    recognizeContentOptions.ReadingOrder,
                    form,
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
                    GetInternalContentType(formContentType),
                    recognizeContentOptions.Pages.Count == 0 ? null : recognizeContentOptions.Pages,
                    recognizeContentOptions.Language,
                    recognizeContentOptions.ReadingOrder,
                    form,
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
                    recognizeContentOptions.Pages.Count == 0 ? null : recognizeContentOptions.Pages,
                    recognizeContentOptions.Language,
                    recognizeContentOptions.ReadingOrder,
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
                    recognizeContentOptions.Pages.Count == 0 ? null : recognizeContentOptions.Pages,
                    recognizeContentOptions.Language,
                    recognizeContentOptions.ReadingOrder,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/receiptfields">receipt fields</see> for a list of available fields on a receipt.</para>
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
                    GetInternalContentType(formContentType),
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale,
                    recognizeReceiptsOptions.Pages.Count == 0 ? null : recognizeReceiptsOptions.Pages,
                    receipt,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/receiptfields">receipt fields</see> for a list of available fields on a receipt.</para>
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
                    GetInternalContentType(formContentType),
                    recognizeReceiptsOptions.IncludeFieldElements,
                    recognizeReceiptsOptions.Locale,
                    recognizeReceiptsOptions.Pages.Count == 0 ? null : recognizeReceiptsOptions.Pages,
                    receipt,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/receiptfields">receipt fields</see> for a list of available fields on a receipt.</para>
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
                    recognizeReceiptsOptions.Locale,
                    recognizeReceiptsOptions.Pages.Count == 0 ? null : recognizeReceiptsOptions.Pages,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/receiptfields">receipt fields</see> for a list of available fields on a receipt.</para>
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
                    recognizeReceiptsOptions.Locale,
                    recognizeReceiptsOptions.Pages.Count == 0 ? null : recognizeReceiptsOptions.Pages,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/businesscardfields">business card fields</see> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCard">The stream containing the one or more business cards to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    GetInternalContentType(formContentType),
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale,
                    recognizeBusinessCardsOptions.Pages.Count == 0 ? null : recognizeBusinessCardsOptions.Pages,
                    businessCard,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/businesscardfields">business card fields</see> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCard">The stream containing the one or more business cards to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    GetInternalContentType(formContentType),
                    recognizeBusinessCardsOptions.IncludeFieldElements,
                    recognizeBusinessCardsOptions.Locale,
                    recognizeBusinessCardsOptions.Pages.Count == 0 ? null : recognizeBusinessCardsOptions.Pages,
                    businessCard,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/businesscardfields">business card fields</see> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCardUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    recognizeBusinessCardsOptions.Locale,
                    recognizeBusinessCardsOptions.Pages.Count == 0 ? null : recognizeBusinessCardsOptions.Pages,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/businesscardfields">business card fields</see> for a list of available fields on a business card.</para>
        /// </summary>
        /// <param name="businessCardUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeBusinessCardsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    recognizeBusinessCardsOptions.Locale,
                    recognizeBusinessCardsOptions.Pages.Count == 0 ? null : recognizeBusinessCardsOptions.Pages,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/invoicefields">invoice fields</see> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoice">The stream containing the one or more invoices to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    GetInternalContentType(formContentType),
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale,
                    recognizeInvoicesOptions.Pages.Count == 0 ? null : recognizeInvoicesOptions.Pages,
                    invoice,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/invoicefields">invoice fields</see> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoice">The stream containing the one or more invoices to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    GetInternalContentType(formContentType),
                    recognizeInvoicesOptions.IncludeFieldElements,
                    recognizeInvoicesOptions.Locale,
                    recognizeInvoicesOptions.Pages.Count == 0 ? null : recognizeInvoicesOptions.Pages,
                    invoice,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/invoicefields">invoice fields</see> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoiceUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    recognizeInvoicesOptions.Locale,
                    recognizeInvoicesOptions.Pages.Count == 0 ? null : recognizeInvoicesOptions.Pages,
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
        /// <para>See <see href="https://aka.ms/formrecognizer/invoicefields">invoice fields</see> for a list of available fields on an invoice.</para>
        /// </summary>
        /// <param name="invoiceUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeInvoicesOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, the locale of the form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
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
                    recognizeInvoicesOptions.Locale,
                    recognizeInvoicesOptions.Pages.Count == 0 ? null : recognizeInvoicesOptions.Pages,
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

        #region Identity Documents

        /// <summary>
        /// Analyze identity documents using optical character recognition (OCR) and a prebuilt model trained on identity documents
        /// to extract key information from passports and US driver licenses.
        /// <para>See <see href="https://aka.ms/formrecognizer/iddocumentfields">identity document fields</see> for a list of available fields on an identity document.</para>
        /// </summary>
        /// <param name="identityDocument">The stream containing the one or more identity documents to recognize values from.</param>
        /// <param name="recognizeIdentityDocumentsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
        /// <returns>A <see cref="RecognizeIdentityDocumentsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeIdentityDocumentsOperation.Value"/> upon successful
        /// completion will contain the extracted identity document information.</returns>
        public virtual async Task<RecognizeIdentityDocumentsOperation> StartRecognizeIdentityDocumentsAsync(Stream identityDocument, RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identityDocument, nameof(identityDocument));

            recognizeIdentityDocumentsOptions ??= new RecognizeIdentityDocumentsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeIdentityDocuments)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeIdentityDocumentsOptions.ContentType ?? DetectContentType(identityDocument, nameof(identityDocument));

                Response response = await ServiceClient.AnalyzeIdDocumentAsyncAsync(
                    GetInternalContentType(formContentType),
                    recognizeIdentityDocumentsOptions.IncludeFieldElements,
                    recognizeIdentityDocumentsOptions.Pages.Count == 0 ? null : recognizeIdentityDocumentsOptions.Pages,
                    identityDocument,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeIdentityDocumentsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyze identity documents using optical character recognition (OCR) and a prebuilt model trained on identity documents
        /// to extract key information from passports and US driver licenses.
        /// <para>See <see href="https://aka.ms/formrecognizer/iddocumentfields">identity document fields</see> for a list of available fields on an identity document.</para>
        /// </summary>
        /// <param name="identityDocument">The stream containing the one or more identity documents to recognize values from.</param>
        /// <param name="recognizeIdentityDocumentsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
        /// <returns>A <see cref="RecognizeIdentityDocumentsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeIdentityDocumentsOperation.Value"/> upon successful
        /// completion will contain the extracted identity document information.</returns>
        public virtual RecognizeIdentityDocumentsOperation StartRecognizeIdentityDocuments(Stream identityDocument, RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identityDocument, nameof(identityDocument));

            recognizeIdentityDocumentsOptions ??= new RecognizeIdentityDocumentsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeIdentityDocuments)}");
            scope.Start();

            try
            {
                FormContentType formContentType = recognizeIdentityDocumentsOptions.ContentType ?? DetectContentType(identityDocument, nameof(identityDocument));

                Response response = ServiceClient.AnalyzeIdDocumentAsync(
                    GetInternalContentType(formContentType),
                    recognizeIdentityDocumentsOptions.IncludeFieldElements,
                    recognizeIdentityDocumentsOptions.Pages.Count == 0 ? null : recognizeIdentityDocumentsOptions.Pages,
                    identityDocument,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeIdentityDocumentsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyze identity documents using optical character recognition (OCR) and a prebuilt model trained on identity documents
        /// to extract key information from passports and US driver licenses.
        /// <para>See <see href="https://aka.ms/formrecognizer/iddocumentfields">identity document fields</see> for a list of available fields on an identity document.</para>
        /// </summary>
        /// <param name="identityDocumentUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeIdentityDocumentsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
        /// <returns>A <see cref="RecognizeIdentityDocumentsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeIdentityDocumentsOperation.Value"/> upon successful
        /// completion will contain the extracted identity document information.</returns>
        public virtual async Task<RecognizeIdentityDocumentsOperation> StartRecognizeIdentityDocumentsFromUriAsync(Uri identityDocumentUri, RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identityDocumentUri, nameof(identityDocumentUri));

            recognizeIdentityDocumentsOptions ??= new RecognizeIdentityDocumentsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeIdentityDocumentsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = identityDocumentUri.AbsoluteUri };
                Response response = await ServiceClient.AnalyzeIdDocumentAsyncAsync(
                    recognizeIdentityDocumentsOptions.IncludeFieldElements,
                    recognizeIdentityDocumentsOptions.Pages.Count == 0 ? null : recognizeIdentityDocumentsOptions.Pages,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeIdentityDocumentsOperation(ServiceClient, Diagnostics, location);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyze identity documents using optical character recognition (OCR) and a prebuilt model trained on identity documents
        /// to extract key information from passports and US driver licenses.
        /// <para>See <see href="https://aka.ms/formrecognizer/iddocumentfields">identity document fields</see> for a list of available fields on an identity document.</para>
        /// </summary>
        /// <param name="identityDocumentUri">The absolute URI of the remote file to recognize values from.</param>
        /// <param name="recognizeIdentityDocumentsOptions">A set of options available for configuring the recognize request. For example, specify the content type of the
        /// form, or whether or not to include form elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <remarks>
        /// Method is only available for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/>.
        /// </remarks>
        /// <returns>A <see cref="RecognizeIdentityDocumentsOperation"/> to wait on this long-running operation.  Its <see cref="RecognizeIdentityDocumentsOperation.Value"/> upon successful
        /// completion will contain the extracted identity document information.</returns>
        public virtual RecognizeIdentityDocumentsOperation StartRecognizeIdentityDocumentsFromUri(Uri identityDocumentUri, RecognizeIdentityDocumentsOptions recognizeIdentityDocumentsOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(identityDocumentUri, nameof(identityDocumentUri));

            recognizeIdentityDocumentsOptions ??= new RecognizeIdentityDocumentsOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormRecognizerClient)}.{nameof(StartRecognizeIdentityDocumentsFromUri)}");
            scope.Start();

            try
            {
                SourcePath sourcePath = new SourcePath() { Source = identityDocumentUri.AbsoluteUri };
                Response response = ServiceClient.AnalyzeIdDocumentAsync(
                    recognizeIdentityDocumentsOptions.IncludeFieldElements,
                    recognizeIdentityDocumentsOptions.Pages.Count == 0 ? null : recognizeIdentityDocumentsOptions.Pages,
                    sourcePath,
                    cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new RecognizeIdentityDocumentsOperation(ServiceClient, Diagnostics, location);
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

                Response response = ServiceClient.AnalyzeWithCustomModel(
                    guid,
                    GetInternalContentType(formContentType),
                    includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements,
                    recognizeCustomFormsOptions.Pages.Count == 0 ? null : recognizeCustomFormsOptions.Pages,
                    form,
                    cancellationToken);
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
                Response response = ServiceClient.AnalyzeWithCustomModel(
                    guid,
                    includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements,
                    recognizeCustomFormsOptions.Pages.Count == 0 ? null : recognizeCustomFormsOptions.Pages,
                    sourcePath,
                    cancellationToken);
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

                Response response = await ServiceClient.AnalyzeWithCustomModelAsync(
                    guid,
                    GetInternalContentType(formContentType),
                    includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements,
                    recognizeCustomFormsOptions.Pages.Count == 0 ? null : recognizeCustomFormsOptions.Pages,
                    form,
                    cancellationToken).ConfigureAwait(false);
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
                Response response = await ServiceClient.AnalyzeWithCustomModelAsync(
                    guid,
                    includeTextDetails: recognizeCustomFormsOptions.IncludeFieldElements,
                    recognizeCustomFormsOptions.Pages.Count == 0 ? null : recognizeCustomFormsOptions.Pages,
                    sourcePath,
                    cancellationToken).ConfigureAwait(false);
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

        private static InternalContentType GetInternalContentType(FormContentType type)
        {
            return type switch
            {
                FormContentType.Pdf => InternalContentType.ApplicationPdf,
                FormContentType.Png => InternalContentType.ImagePng,
                FormContentType.Jpeg => InternalContentType.ImageJpeg,
                FormContentType.Tiff => InternalContentType.ImageTiff,
                FormContentType.Bmp => InternalContentType.ImageBmp,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown ContentType value.")
            };
        }

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
