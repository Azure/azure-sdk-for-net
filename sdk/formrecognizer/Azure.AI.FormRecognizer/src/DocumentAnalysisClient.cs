// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The client to use to connect to the Form Recognizer Azure Cognitive Service to analyze information from documents
    /// and images and extract it into structured data. It provides the ability to use prebuilt models to analyze receipts,
    /// business cards, invoices, to extract document content, and more. It's also possible to extract fields from custom
    /// documents with models built on custom document types.
    /// </summary>
    /// <remarks>
    /// This client only supports <see cref="DocumentAnalysisClientOptions.ServiceVersion.V2022_08_31"/> and newer.
    /// To use an older service version, see <see cref="FormRecognizerClient"/>.
    /// </remarks>
    public class DocumentAnalysisClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly DocumentAnalysisRestClient ServiceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        internal readonly ClientDiagnostics Diagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentAnalysisClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new DocumentAnalysisClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentAnalysisClient(Uri endpoint, AzureKeyCredential credential, DocumentAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new DocumentAnalysisClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new DocumentAnalysisRestClient(Diagnostics, pipeline, endpoint, options.VersionString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentAnalysisClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new DocumentAnalysisClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentAnalysisClient(Uri endpoint, TokenCredential credential, DocumentAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new DocumentAnalysisClientOptions();

            string defaultScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? DocumentAnalysisAudience.AzurePublicCloud : options.Audience)}/.default";

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, defaultScope));
            ServiceClient = new DocumentAnalysisRestClient(Diagnostics, pipeline, endpoint, options.VersionString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClient"/> class.
        /// </summary>
        protected DocumentAnalysisClient()
        {
        }

        #region Document Models

        /// <summary>
        /// Analyzes pages from one or more documents, using a model built with custom documents or one of the prebuilt
        /// models provided by the Form Recognizer service.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="modelId">
        /// The ID of the model to use for analyzing the input documents. When using a custom built model
        /// for analysis, this parameter must be the ID attributed to the model during its creation. When
        /// using one of the service's prebuilt models, one of the supported prebuilt model IDs must be passed.
        /// Prebuilt model IDs can be found at <see href="https://aka.ms/azsdk/formrecognizer/models"/>.
        /// </param>
        /// <param name="document">The stream containing one or more documents to analyze.</param>
        /// <param name="options">
        /// A set of options available for configuring the analyze request. For example, specify the locale of the
        /// document, or which pages to analyze.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AnalyzeDocumentOperation"/> to wait on this long-running operation. Its <see cref="AnalyzeDocumentOperation.Value"/> upon successful
        /// completion will contain analyzed pages from the input document.
        /// </returns>
        public virtual async Task<AnalyzeDocumentOperation> AnalyzeDocumentAsync(WaitUntil waitUntil, string modelId, Stream document, AnalyzeDocumentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(document, nameof(document));

            options ??= new AnalyzeDocumentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(AnalyzeDocument)}");
            scope.Start();

            try
            {
                var response = await ServiceClient.DocumentModelsAnalyzeDocumentAsync(
                    modelId,
                    InternalContentType.ApplicationOctetStream,
                    options.Pages.Count == 0 ? null : string.Join(",", options.Pages),
                    options.Locale,
                    Constants.DefaultStringIndexType,
                    options.Features.Count == 0 ? null : options.Features,
                    document,
                    cancellationToken).ConfigureAwait(false);

                var operation = new AnalyzeDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyzes pages from one or more documents, using a model built with custom documents or one of the prebuilt
        /// models provided by the Form Recognizer service.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="modelId">
        /// The ID of the model to use for analyzing the input documents. When using a custom built model
        /// for analysis, this parameter must be the ID attributed to the model during its creation. When
        /// using one of the service's prebuilt models, one of the supported prebuilt model IDs must be passed.
        /// Prebuilt model IDs can be found at <see href="https://aka.ms/azsdk/formrecognizer/models"/>.
        /// </param>
        /// <param name="document">The stream containing one or more documents to analyze.</param>
        /// <param name="options">
        /// A set of options available for configuring the analyze request. For example, specify the locale of the
        /// document, or which pages to analyze.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AnalyzeDocumentOperation"/> to wait on this long-running operation. Its <see cref="AnalyzeDocumentOperation.Value"/> upon successful
        /// completion will contain analyzed pages from the input document.
        /// </returns>
        public virtual AnalyzeDocumentOperation AnalyzeDocument(WaitUntil waitUntil, string modelId, Stream document, AnalyzeDocumentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(document, nameof(document));

            options ??= new AnalyzeDocumentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(AnalyzeDocument)}");
            scope.Start();

            try
            {
                var response = ServiceClient.DocumentModelsAnalyzeDocument(
                    modelId,
                    InternalContentType.ApplicationOctetStream,
                    options.Pages.Count == 0 ? null : string.Join(",", options.Pages),
                    options.Locale,
                    Constants.DefaultStringIndexType,
                    options.Features.Count == 0 ? null : options.Features,
                    document,
                    cancellationToken);

                var operation = new AnalyzeDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyzes pages from one or more documents, using a model built with custom documents or one of the prebuilt
        /// models provided by the Form Recognizer service.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="modelId">
        /// The ID of the model to use for analyzing the input documents. When using a custom built model
        /// for analysis, this parameter must be the ID attributed to the model during its creation. When
        /// using one of the service's prebuilt models, one of the supported prebuilt model IDs must be passed.
        /// Prebuilt model IDs can be found at <see href="https://aka.ms/azsdk/formrecognizer/models"/>.
        /// </param>
        /// <param name="documentUri">The absolute URI of the remote file to analyze documents from.</param>
        /// <param name="options">
        /// A set of options available for configuring the analyze request. For example, specify the locale of the
        /// document, or which pages to analyze.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AnalyzeDocumentOperation"/> to wait on this long-running operation. Its <see cref="AnalyzeDocumentOperation.Value"/> upon successful
        /// completion will contain analyzed pages from the input document.
        /// </returns>
        public virtual async Task<AnalyzeDocumentOperation> AnalyzeDocumentFromUriAsync(WaitUntil waitUntil, string modelId, Uri documentUri, AnalyzeDocumentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(documentUri, nameof(documentUri));

            options ??= new AnalyzeDocumentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(AnalyzeDocumentFromUri)}");
            scope.Start();

            try
            {
                var request = new AnalyzeDocumentRequest() { UrlSource = documentUri };
                var response = await ServiceClient.DocumentModelsAnalyzeDocumentAsync(
                    modelId,
                    options.Pages.Count == 0 ? null : string.Join(",", options.Pages),
                    options.Locale,
                    Constants.DefaultStringIndexType,
                    options.Features.Count == 0 ? null : options.Features,
                    request,
                    cancellationToken).ConfigureAwait(false);

                var operation = new AnalyzeDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Analyzes pages from one or more documents, using a model built with custom documents or one of the prebuilt
        /// models provided by the Form Recognizer service.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="modelId">
        /// The ID of the model to use for analyzing the input documents. When using a custom built model
        /// for analysis, this parameter must be the ID attributed to the model during its creation. When
        /// using one of the service's prebuilt models, one of the supported prebuilt model IDs must be passed.
        /// Prebuilt model IDs can be found at <see href="https://aka.ms/azsdk/formrecognizer/models"/>.
        /// </param>
        /// <param name="documentUri">The absolute URI of the remote file to analyze documents from.</param>
        /// <param name="options">
        /// A set of options available for configuring the analyze request. For example, specify the locale of the
        /// document, or which pages to analyze.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AnalyzeDocumentOperation"/> to wait on this long-running operation. Its <see cref="AnalyzeDocumentOperation.Value"/> upon successful
        /// completion will contain analyzed pages from the input document.
        /// </returns>
        public virtual AnalyzeDocumentOperation AnalyzeDocumentFromUri(WaitUntil waitUntil, string modelId, Uri documentUri, AnalyzeDocumentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(documentUri, nameof(documentUri));

            options ??= new AnalyzeDocumentOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(AnalyzeDocumentFromUri)}");
            scope.Start();

            try
            {
                var request = new AnalyzeDocumentRequest() { UrlSource = documentUri };
                var response = ServiceClient.DocumentModelsAnalyzeDocument(
                    modelId,
                    options.Pages.Count == 0 ? null : string.Join(",", options.Pages),
                    options.Locale,
                    Constants.DefaultStringIndexType,
                    options.Features.Count == 0 ? null : options.Features,
                    request,
                    cancellationToken);

                var operation = new AnalyzeDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Document Models

        #region Document Classifiers

        /// <summary>
        /// Classifies one or more documents using a document classifier built with custom documents.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="classifierId">The ID of the document classifier to use.</param>
        /// <param name="document">The stream containing one or more documents to classify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="ClassifyDocumentOperation"/> to wait on this long-running operation. Its <see cref="ClassifyDocumentOperation.Value"/> upon successful
        /// completion will contain documents classified from the input.
        /// </returns>
        public virtual async Task<ClassifyDocumentOperation> ClassifyDocumentAsync(WaitUntil waitUntil, string classifierId, Stream document, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(document, nameof(document));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(ClassifyDocument)}");
            scope.Start();

            try
            {
                var response = await ServiceClient.DocumentClassifiersClassifyDocumentAsync(
                    classifierId,
                    InternalContentType.ApplicationOctetStream,
                    Constants.DefaultStringIndexType,
                    document,
                    cancellationToken).ConfigureAwait(false);

                var operation = new ClassifyDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Classifies one or more documents using a document classifier built with custom documents.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="classifierId">The ID of the document classifier to use.</param>
        /// <param name="document">The stream containing one or more documents to classify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="ClassifyDocumentOperation"/> to wait on this long-running operation. Its <see cref="ClassifyDocumentOperation.Value"/> upon successful
        /// completion will contain documents classified from the input.
        /// </returns>
        public virtual ClassifyDocumentOperation ClassifyDocument(WaitUntil waitUntil, string classifierId, Stream document, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(document, nameof(document));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(ClassifyDocument)}");
            scope.Start();

            try
            {
                var response = ServiceClient.DocumentClassifiersClassifyDocument(
                    classifierId,
                    InternalContentType.ApplicationOctetStream,
                    Constants.DefaultStringIndexType,
                    document,
                    cancellationToken);

                var operation = new ClassifyDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Classifies one or more documents using a document classifier built with custom documents.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="classifierId">The ID of the document classifier to use.</param>
        /// <param name="documentUri">The absolute URI of the remote file to classify documents from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="ClassifyDocumentOperation"/> to wait on this long-running operation. Its <see cref="ClassifyDocumentOperation.Value"/> upon successful
        /// completion will contain documents classified from the input.
        /// </returns>
        public virtual async Task<ClassifyDocumentOperation> ClassifyDocumentFromUriAsync(WaitUntil waitUntil, string classifierId, Uri documentUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(documentUri, nameof(documentUri));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(ClassifyDocumentFromUri)}");
            scope.Start();

            try
            {
                var request = new ClassifyDocumentRequest() { UrlSource = documentUri };
                var response = await ServiceClient.DocumentClassifiersClassifyDocumentAsync(
                    classifierId,
                    Constants.DefaultStringIndexType,
                    request,
                    cancellationToken).ConfigureAwait(false);

                var operation = new ClassifyDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Classifies one or more documents using a document classifier built with custom documents.
        /// </summary>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="classifierId">The ID of the document classifier to use.</param>
        /// <param name="documentUri">The absolute URI of the remote file to classify documents from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="ClassifyDocumentOperation"/> to wait on this long-running operation. Its <see cref="ClassifyDocumentOperation.Value"/> upon successful
        /// completion will contain documents classified from the input.
        /// </returns>
        public virtual ClassifyDocumentOperation ClassifyDocumentFromUri(WaitUntil waitUntil, string classifierId, Uri documentUri, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(documentUri, nameof(documentUri));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentAnalysisClient)}.{nameof(ClassifyDocumentFromUri)}");
            scope.Start();

            try
            {
                var request = new ClassifyDocumentRequest() { UrlSource = documentUri };
                var response = ServiceClient.DocumentClassifiersClassifyDocument(
                    classifierId,
                    Constants.DefaultStringIndexType,
                    request,
                    cancellationToken);

                var operation = new ClassifyDocumentOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Document Classifiers
    }
}
