// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The client to use to connect with the Form Recognizer Azure Cognitive Service to build models from
    /// custom documents. It also supports listing, copying, and deleting models, creating composed models, and accessing account
    /// properties.
    /// </summary>
    /// <remarks>
    /// This client only works with <see cref="DocumentAnalysisClientOptions.ServiceVersion.V2021_09_30_preview"/> and up.
    /// If you want to use a lower version, please use the <see cref="Training.FormTrainingClient"/>.
    /// </remarks>
    public class DocumentModelAdministrationClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly DocumentAnalysisRestClient ServiceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        internal readonly ClientDiagnostics Diagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClient"/> class.
        /// </summary>
        protected DocumentModelAdministrationClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentModelAdministrationClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new DocumentAnalysisClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentModelAdministrationClient(Uri endpoint, AzureKeyCredential credential, DocumentAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new DocumentAnalysisClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new DocumentAnalysisRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentModelAdministrationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new DocumentAnalysisClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// For more information see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-the-client"> here</see>.
        /// </remarks>
        public DocumentModelAdministrationClient(Uri endpoint, TokenCredential credential, DocumentAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new DocumentAnalysisClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            ServiceClient = new DocumentAnalysisRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        #region Build
        /// <summary>
        /// Build a custom document analysis model from a collection of documents in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri pointing to the container that has your training files.
        /// For more information see <see href="https://docs.microsoft.com/azure/applied-ai-services/form-recognizer/build-training-data-set">here</see>.</param>
        /// <param name="modelId">A unique ID for your model. If not specified, a model ID will be created for you.</param>
        /// <param name="buildModelOptions">A set of options available for configuring the request. For example, set a model description or set a filter to apply
        /// to the documents in the source path.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="BuildModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the created custom model.
        /// </returns>
        public virtual BuildModelOperation StartBuildModel(Uri trainingFilesUri, string modelId = default, BuildModelOptions buildModelOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));

            buildModelOptions ??= new BuildModelOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartBuildModel)}");
            scope.Start();

            try
            {
                var source = new AzureBlobContentSource(trainingFilesUri.AbsoluteUri);
                if (!string.IsNullOrEmpty(buildModelOptions.Prefix))
                {
                    source.Prefix = buildModelOptions.Prefix;
                }

                modelId ??= Guid.NewGuid().ToString();
                var request = new BuildDocumentModelRequest(modelId)
                {
                    AzureBlobSource = source,
                    Description = buildModelOptions.ModelDescription
                };

                var response = ServiceClient.DocumentAnalysisBuildDocumentModel(request, cancellationToken);
                return new BuildModelOperation(response.Headers.OperationLocation, response.GetRawResponse(), ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Build a custom model from a collection of documents in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.
        /// For more information see <see href="https://docs.microsoft.com/azure/applied-ai-services/form-recognizer/build-training-data-set">here</see>.</param>
        /// <param name="modelId">A unique ID for your model. If not specified, a model ID will be created for you.</param>
        /// <param name="buildModelOptions">A set of options available for configuring the request. For example, set a model description or set a filter to apply
        /// to the documents in the source path.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="BuildModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the created custom model.
        /// </returns>
        public virtual async Task<BuildModelOperation> StartBuildModelAsync(Uri trainingFilesUri, string modelId = default, BuildModelOptions buildModelOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));
            buildModelOptions ??= new BuildModelOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartBuildModel)}");
            scope.Start();

            try
            {
                var source = new AzureBlobContentSource(trainingFilesUri.AbsoluteUri);
                if (!string.IsNullOrEmpty(buildModelOptions.Prefix))
                {
                    source.Prefix = buildModelOptions.Prefix;
                }

                modelId ??= Guid.NewGuid().ToString();
                var request = new BuildDocumentModelRequest(modelId)
                {
                    AzureBlobSource = source,
                    Description = buildModelOptions.ModelDescription
                };

                var response = await ServiceClient.DocumentAnalysisBuildDocumentModelAsync(request, cancellationToken).ConfigureAwait(false);
                return new BuildModelOperation(response.Headers.OperationLocation, response.GetRawResponse(), ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion Build

        #region Management Ops

        /// <summary>
        /// Gets a description of a model, including the types of documents it can recognize and the fields it will extract for each document type.
        /// </summary>
        /// <param name="modelId">The ID of the model to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="DocumentModel"/> containing
        /// information about the requested model.</returns>
        public virtual Response<DocumentModel> GetModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModel)}");
            scope.Start();

            try
            {
                Response<DocumentModel> response = ServiceClient.DocumentAnalysisGetModel(modelId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a description of a model, including the types of documents it can recognize and the fields it will extract for each document type.
        /// </summary>
        /// <param name="modelId">The ID of the model to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="DocumentModel"/> containing
        /// information about the requested model.</returns>
        public virtual async Task<Response<DocumentModel>> GetModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModel)}");
            scope.Start();

            try
            {
                Response<DocumentModel> response = await ServiceClient.DocumentAnalysisGetModelAsync(modelId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(DeleteModel)}");
            scope.Start();

            try
            {
                return ServiceClient.DocumentAnalysisDeleteModel(modelId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(DeleteModel)}");
            scope.Start();

            try
            {
                return await ServiceClient.DocumentAnalysisDeleteModelAsync(modelId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the models available on this Cognitive Services Account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="DocumentModelInfo"/> items.</returns>
        public virtual Pageable<DocumentModelInfo> GetModels(CancellationToken cancellationToken = default)
        {
            Page<DocumentModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModels)}");
                scope.Start();

                try
                {
                    Response<GetModelsResponse> response = ServiceClient.DocumentAnalysisGetModels(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DocumentModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModels)}");
                scope.Start();

                try
                {
                    Response<GetModelsResponse> response = ServiceClient.DocumentAnalysisGetModelsNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the models available on this Cognitive Services Account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="DocumentModelInfo"/> items.</returns>
        public virtual AsyncPageable<DocumentModelInfo> GetModelsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DocumentModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModels)}");
                scope.Start();

                try
                {
                    Response<GetModelsResponse> response = await ServiceClient.DocumentAnalysisGetModelsAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DocumentModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetModels)}");
                scope.Start();

                try
                {
                    Response<GetModelsResponse> response = await ServiceClient.DocumentAnalysisGetModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the number of built models on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        public virtual Response<AccountProperties> GetAccountProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetAccountProperties)}");
            scope.Start();

            try
            {
                Response<GetInfoResponse> response = ServiceClient.DocumentAnalysisGetInfo(cancellationToken);
                return Response.FromValue(response.Value.CustomDocumentModels, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the number of built models on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        public virtual async Task<Response<AccountProperties>> GetAccountPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetAccountProperties)}");
            scope.Start();

            try
            {
                Response<GetInfoResponse> response = await ServiceClient.DocumentAnalysisGetInfoAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.CustomDocumentModels, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a document model operation by its ID. Note that operation information only persists for 24 hours.
        /// </summary>
        /// <param name="operationId">The operation ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="DocumentModel"/> containing
        /// information about the requested model.</returns>
        public virtual Response<ModelOperation> GetOperation(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperation)}");
            scope.Start();

            try
            {
                var response = ServiceClient.DocumentAnalysisGetOperation(operationId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a document model operation by its ID. Note that operation information only persists for 24 hours.
        /// </summary>
        /// <param name="operationId">The operation ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="DocumentModel"/> containing
        /// information about the requested model.</returns>
        public virtual async Task<Response<ModelOperation>> GetOperationAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperation)}");
            scope.Start();

            try
            {
                var response = await ServiceClient.DocumentAnalysisGetOperationAsync(operationId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all document model operations associated with the Form Recognizer resource. Note that operation information only persists for 24 hours.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="ModelOperationInfo"/> items.</returns>
        public virtual Pageable<ModelOperationInfo> GetOperations(CancellationToken cancellationToken = default)
        {
            Page<ModelOperationInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperations)}");
                scope.Start();

                try
                {
                    var response = ServiceClient.DocumentAnalysisGetOperations(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ModelOperationInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperations)}");
                scope.Start();

                try
                {
                    var response = ServiceClient.DocumentAnalysisGetOperationsNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all document model operations associated with the Form Recognizer resource. Note that operation information only persists for 24 hours.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="ModelOperationInfo"/> items.</returns>
        public virtual AsyncPageable<ModelOperationInfo> GetOperationsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ModelOperationInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperations)}");
                scope.Start();

                try
                {
                    var response = await ServiceClient.DocumentAnalysisGetOperationsAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ModelOperationInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetOperations)}");
                scope.Start();

                try
                {
                    var response = await ServiceClient.DocumentAnalysisGetOperationsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion

        #region Copy
        /// <summary>
        /// Copy a custom model stored in this resource (the source) to the user specified
        /// target Form Recognizer resource.
        /// </summary>
        /// <param name="modelId">Model identifier of the model to copy to the target Form Recognizer resource.</param>
        /// <param name="target">A <see cref="CopyAuthorization"/> with the copy authorization to the target Form Recognizer resource.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CopyModelOperation"/> to wait on this long-running operation.  Its <see cref="CopyModelOperation.Value"/> upon successful
        /// completion will contain meta-data about the model copied.</returns>
        public virtual CopyModelOperation StartCopyModel(string modelId, CopyAuthorization target, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(target, nameof(target));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartCopyModel)}");
            scope.Start();

            try
            {
                var response = ServiceClient.DocumentAnalysisCopyDocumentModelTo(modelId, target, cancellationToken);
                return new CopyModelOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Copy a custom model stored in this resource (the source) to the user specified
        /// target Form Recognizer resource.
        /// </summary>
        /// <param name="modelId">Model identifier of the model to copy to the target Form Recognizer resource.</param>
        /// <param name="target">A <see cref="CopyAuthorization"/> with the copy authorization to the target Form Recognizer resource.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CopyModelOperation"/> to wait on this long-running operation.  Its <see cref="CopyModelOperation.Value"/> upon successful
        /// completion will contain meta-data about the model copied.</returns>
        public virtual async Task<CopyModelOperation> StartCopyModelAsync(string modelId, CopyAuthorization target, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(target, nameof(target));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartCopyModel)}");
            scope.Start();

            try
            {
                var response = await ServiceClient.DocumentAnalysisCopyDocumentModelToAsync(modelId, target, cancellationToken).ConfigureAwait(false);
                return new CopyModelOperation(ServiceClient, Diagnostics, response.Headers.OperationLocation, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generate authorization for copying a custom model into the target Form Recognizer resource.
        /// </summary>
        /// <param name="modelId">A unique ID for your copied model. If not specified, a model ID will be created for you.</param>
        /// <param name="modelDescription">An optional description to add to the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information necessary to copy a custom model into a target Form Recognizer resource.</returns>
        public virtual Response<CopyAuthorization> GetCopyAuthorization(string modelId = default, string modelDescription = default, CancellationToken cancellationToken = default)
        {
            modelId ??= Guid.NewGuid().ToString();

            var request = new AuthorizeCopyRequest(modelId)
            {
                Description = modelDescription
            };

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetCopyAuthorization)}");
            scope.Start();

            try
            {
                var response = ServiceClient.DocumentAnalysisAuthorizeCopyDocumentModel(request, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generate authorization for copying a custom model into the target Form Recognizer resource.
        /// </summary>
        /// <param name="modelId">A unique ID for your copied model. If not specified, a model ID will be created for you.</param>
        /// <param name="modelDescription">An optional description to add to the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information necessary to copy a custom model into a target Form Recognizer resource.</returns>
        public virtual async Task<Response<CopyAuthorization>> GetCopyAuthorizationAsync(string modelId = default, string modelDescription = default, CancellationToken cancellationToken = default)
        {
            modelId ??= Guid.NewGuid().ToString();

            var request = new AuthorizeCopyRequest(modelId)
            {
                Description = modelDescription
            };

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(GetCopyAuthorization)}");
            scope.Start();

            try
            {
                var response = await ServiceClient.DocumentAnalysisAuthorizeCopyDocumentModelAsync(request, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Copy

        #region Composed Model

        /// <summary>
        /// Creates a composed model from a collection of existing models.
        /// A composed model allows multiple models to be called with a single model ID. When a document is
        /// submitted to be analyzed with a composed model ID, a classification step is first performed to
        /// route it to the correct custom model.
        /// </summary>
        /// <param name="modelIds">List of model ids to use in the composed model.</param>
        /// <param name="modelId">A unique ID for your composed model. If not specified, a model ID will be created for you.</param>
        /// <param name="modelDescription">An optional description to add to the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="BuildModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the composed model.</para>
        /// </returns>
        public virtual BuildModelOperation StartCreateComposedModel(IEnumerable<string> modelIds, string modelId = default, string modelDescription = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelIds, nameof(modelIds));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartCreateComposedModel)}");
            scope.Start();

            try
            {
                modelId ??= Guid.NewGuid().ToString();
                var composeRequest = new ComposeDocumentModelRequest(modelId, ConvertToComponentModelInfo(modelIds))
                {
                    Description = modelDescription
                };

                var response = ServiceClient.DocumentAnalysisComposeDocumentModel(composeRequest, cancellationToken);
                return new BuildModelOperation(response.Headers.OperationLocation, response.GetRawResponse(), ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a composed model from a collection of existing models.
        /// A composed model allows multiple models to be called with a single model ID. When a document is
        /// submitted to be analyzed with a composed model ID, a classification step is first performed to
        /// route it to the correct custom model.
        /// </summary>
        /// <param name="modelIds">List of model ids to use in the composed model.</param>
        /// <param name="modelId">A unique ID for your composed model. If not specified, a model ID will be created for you.</param>
        /// <param name="modelDescription">An optional description to add to the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="BuildModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the composed model.</para>
        /// </returns>
        public virtual async Task<BuildModelOperation> StartCreateComposedModelAsync(IEnumerable<string> modelIds, string modelId = default, string modelDescription = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelIds, nameof(modelIds));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(DocumentModelAdministrationClient)}.{nameof(StartCreateComposedModel)}");
            scope.Start();

            try
            {
                modelId ??= Guid.NewGuid().ToString();
                var composeRequest = new ComposeDocumentModelRequest(modelId, ConvertToComponentModelInfo(modelIds))
                {
                    Description = modelDescription
                };

                var response = await ServiceClient.DocumentAnalysisComposeDocumentModelAsync(composeRequest, cancellationToken).ConfigureAwait(false);
                return new BuildModelOperation(response.Headers.OperationLocation, response.GetRawResponse(), ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal static List<ComponentModelInfo> ConvertToComponentModelInfo(IEnumerable<string> modelIds)
            => modelIds.Select((modelId) => new ComponentModelInfo(modelId)).ToList();

        #endregion Composed Model
    }
}
