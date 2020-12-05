// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// The client to use to connect with the Form Recognizer Azure Cognitive Service to train models from
    /// custom forms. It also supports listing, copying, and deleting trained models, creating composed models, and accessing account
    /// properties.
    /// </summary>
    public class FormTrainingClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly FormRecognizerRestClient ServiceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        internal readonly ClientDiagnostics Diagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        protected FormTrainingClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI string and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI string can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, TokenCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            ServiceClient = new FormRecognizerRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        #region Training
        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.
        /// For more information see <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data"/>.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, corresponding labeled files must exist in the blob container. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="modelName">An optional, user-defined name to associate with the model.</param>
        /// <param name="trainingOptions">A set of options available for configuring the training request. For example, set a filter to apply
        /// to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        public virtual TrainingOperation StartTraining(Uri trainingFilesUri, bool useTrainingLabels, string modelName = default, TrainingOptions trainingOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));
            trainingOptions ??= new TrainingOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartTraining)}");
            scope.Start();

            try
            {
                var trainRequest = new TrainRequest(trainingFilesUri.AbsoluteUri)
                {
                    SourceFilter = trainingOptions.TrainingFileFilter,
                    UseLabelFile = useTrainingLabels,
                    ModelName = modelName
                };

                ResponseWithHeaders<FormRecognizerTrainCustomModelAsyncHeaders> response = ServiceClient.TrainCustomModelAsync(trainRequest, cancellationToken);
                return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.
        /// For more information see <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data"/>.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, corresponding labeled files must exist in the blob container. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="modelName">An optional, user-defined name to associate with the model.</param>
        /// <param name="trainingOptions">A set of options available for configuring the training request. For example, set a filter to apply
        /// to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        public virtual async Task<TrainingOperation> StartTrainingAsync(Uri trainingFilesUri, bool useTrainingLabels, string modelName = default, TrainingOptions trainingOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));
            trainingOptions ??= new TrainingOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartTraining)}");
            scope.Start();

            try
            {
                var trainRequest = new TrainRequest(trainingFilesUri.AbsoluteUri)
                {
                    SourceFilter = trainingOptions.TrainingFileFilter,
                    UseLabelFile = useTrainingLabels,
                    ModelName = modelName
                };

                ResponseWithHeaders<FormRecognizerTrainCustomModelAsyncHeaders> response = await ServiceClient.TrainCustomModelAsyncAsync(trainRequest, cancellationToken).ConfigureAwait(false);
                return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.
        /// For more information see <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data"/>.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, corresponding labeled files must exist in the blob container. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="trainingOptions">A set of options available for configuring the training request. For example, set a filter to apply
        /// to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TrainingOperation StartTraining(Uri trainingFilesUri, bool useTrainingLabels, TrainingOptions trainingOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));
            trainingOptions ??= new TrainingOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartTraining)}");
            scope.Start();

            try
            {
                var trainRequest = new TrainRequest(trainingFilesUri.AbsoluteUri) {
                    SourceFilter = trainingOptions.TrainingFileFilter,
                    UseLabelFile = useTrainingLabels
                };

                ResponseWithHeaders<FormRecognizerTrainCustomModelAsyncHeaders> response = ServiceClient.TrainCustomModelAsync(trainRequest, cancellationToken);
                return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.
        /// For more information see <a href="https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data"/>.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, corresponding labeled files must exist in the blob container. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="trainingOptions">A set of options available for configuring the training request. For example, set a filter to apply
        /// to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<TrainingOperation> StartTrainingAsync(Uri trainingFilesUri, bool useTrainingLabels, TrainingOptions trainingOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));
            trainingOptions ??= new TrainingOptions();

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartTraining)}");
            scope.Start();

            try
            {
                var trainRequest = new TrainRequest(trainingFilesUri.AbsoluteUri) {
                    SourceFilter = trainingOptions.TrainingFileFilter,
                    UseLabelFile = useTrainingLabels
                };

                ResponseWithHeaders<FormRecognizerTrainCustomModelAsyncHeaders> response = await ServiceClient.TrainCustomModelAsyncAsync(trainRequest, cancellationToken).ConfigureAwait(false);
                return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Composed model

        /// <summary>
        /// Creates a composed model from a collection of existing models trained with labels.
        /// </summary>
        /// <param name="modelIds">List of model ids to use in the composed model.</param>
        /// <param name="modelName">An optional, user-defined name to associate with the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="CreateComposedModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the composed model.</para>
        /// </returns>
        public virtual CreateComposedModelOperation StartCreateComposedModel(IEnumerable<string> modelIds, string modelName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelIds, nameof(modelIds));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartCreateComposedModel)}");
            scope.Start();

            try
            {
                var modelIdsGuid = new List<Guid>();
                foreach (var modelId in modelIds)
                {
                    modelIdsGuid.Add(ClientCommon.ValidateModelId(modelId, nameof(modelId)));
                }

                var composeRequest = new ComposeRequest(modelIdsGuid);
                composeRequest.ModelName = modelName;

                ResponseWithHeaders<FormRecognizerComposeCustomModelsAsyncHeaders> response = ServiceClient.ComposeCustomModelsAsync(composeRequest, cancellationToken);
                return new CreateComposedModelOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a composed model from a collection of existing trained models with labels.
        /// </summary>
        /// <param name="modelIds">List of model ids to use in the composed model.</param>
        /// <param name="modelName">An optional, user-defined name to associate with the model.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="CreateComposedModelOperation"/> to wait on this long-running operation. Its Value upon successful
        /// completion will contain meta-data about the composed model.</para>
        /// </returns>
        public virtual async Task<CreateComposedModelOperation> StartCreateComposedModelAsync(IEnumerable<string> modelIds, string modelName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelIds, nameof(modelIds));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartCreateComposedModel)}");
            scope.Start();

            try
            {
                var modelIdsGuid = new List<Guid>();
                foreach (var modelId in modelIds)
                {
                    modelIdsGuid.Add(ClientCommon.ValidateModelId(modelId, nameof(modelId)));
                }

                var composeRequest = new ComposeRequest(modelIdsGuid);
                composeRequest.ModelName = modelName;

                ResponseWithHeaders<FormRecognizerComposeCustomModelsAsyncHeaders> response = await ServiceClient.ComposeCustomModelsAsyncAsync(composeRequest, cancellationToken).ConfigureAwait(false);
                return new CreateComposedModelOperation(response.Headers.Location, ServiceClient, Diagnostics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Management Ops

        /// <summary>
        /// Gets a description of a custom model, including the types of forms it can recognize and the fields it will extract for each form type.
        /// </summary>
        /// <param name="modelId">The ID of the model to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModel"/> containing
        /// information about the requested model.</returns>
        public virtual Response<CustomFormModel> GetCustomModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

                Response<Model> response = ServiceClient.GetCustomModel(guid, includeKeys: true, cancellationToken);
                return Response.FromValue(new CustomFormModel(response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a description of a custom model, including the types of forms it can recognize and the fields it will extract for each form type.
        /// </summary>
        /// <param name="modelId">The ID of the model to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModel"/> containing
        /// information about the requested model.</returns>
        public virtual async Task<Response<CustomFormModel>> GetCustomModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

                Response<Model> response = await ServiceClient.GetCustomModelAsync(guid, includeKeys: true, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CustomFormModel(response.Value), response.GetRawResponse());
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

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(DeleteModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                return ServiceClient.DeleteCustomModel(guid, cancellationToken);
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

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(DeleteModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                return await ServiceClient.DeleteCustomModelAsync(guid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="CustomFormModelInfo"/> items.</returns>
        public virtual Pageable<CustomFormModelInfo> GetCustomModels(CancellationToken cancellationToken = default)
        {
            Page<CustomFormModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModels)}");
                scope.Start();

                try
                {
                    Response<Models.Models> response = ServiceClient.ListCustomModels(cancellationToken);
                    return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<CustomFormModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModels)}");
                scope.Start();

                try
                {
                    Response<Models.Models> response = ServiceClient.ListCustomModelsNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a collection of items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="CustomFormModelInfo"/> items.</returns>
        public virtual AsyncPageable<CustomFormModelInfo> GetCustomModelsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CustomFormModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModels)}");
                scope.Start();

                try
                {
                    Response<Models.Models> response = await ServiceClient.ListCustomModelsAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<CustomFormModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCustomModels)}");
                scope.Start();

                try
                {
                    Response<Models.Models> response = await ServiceClient.ListCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
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
        /// Gets the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        public virtual Response<AccountProperties> GetAccountProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetAccountProperties)}");
            scope.Start();

            try
            {
                Response<Models.Models> response = ServiceClient.GetCustomModels(cancellationToken);
                return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        public virtual async Task<Response<AccountProperties>> GetAccountPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetAccountProperties)}");
            scope.Start();

            try
            {
                Response<Models.Models> response = await ServiceClient.GetCustomModelsAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartCopyModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                var request = new CopyRequest(target.ResourceId,
                                              target.Region,
                                              new CopyAuthorizationResult(target.ModelId, target.AccessToken, target.ExpiresOn.ToUnixTimeSeconds()));

                Response response = ServiceClient.CopyCustomModel(guid, request, cancellationToken);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new CopyModelOperation(ServiceClient, Diagnostics, location, target.ModelId);
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

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(StartCopyModel)}");
            scope.Start();

            try
            {
                Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
                var request = new CopyRequest(target.ResourceId,
                                              target.Region,
                                              new CopyAuthorizationResult(target.ModelId, target.AccessToken, target.ExpiresOn.ToUnixTimeSeconds()));

                Response response = await ServiceClient.CopyCustomModelAsync(guid, request, cancellationToken).ConfigureAwait(false);
                string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

                return new CopyModelOperation(ServiceClient, Diagnostics, location, target.ModelId);
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
        /// <param name="resourceId">Azure Resource Id of the target Form Recognizer resource where the model will be copied to.
        /// This information can be found in the Properties section of the Form Recognizer resource in the Azure Portal.</param>
        /// <param name="resourceRegion">Location of the target Form Recognizer resource.
        /// This information can be found in the Keys and Endpoint section of the Form Recognizer resource in the Azure Portal.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information necessary to copy a custom model into a target Form Recognizer resource.</returns>
        public virtual Response<CopyAuthorization> GetCopyAuthorization(string resourceId, string resourceRegion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));
            Argument.AssertNotNullOrEmpty(resourceRegion, nameof(resourceRegion));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCopyAuthorization)}");
            scope.Start();

            try
            {
                Response<CopyAuthorizationResult> response = ServiceClient.GenerateModelCopyAuthorization(cancellationToken);
                return Response.FromValue(new CopyAuthorization(response.Value, resourceId, resourceRegion), response.GetRawResponse());
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
        /// <param name="resourceId">Azure Resource Id of the target Form Recognizer resource where the model will be copied to.
        /// This information can be found in the Properties section of the Form Recognizer resource in the Azure Portal.</param>
        /// <param name="resourceRegion">Location of the target Form Recognizer resource.
        /// This information can be found in the Keys and Endpoint section of the Form Recognizer resource in the Azure Portal.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information necessary to copy a custom model into a target Form Recognizer resource.</returns>
        public virtual async Task<Response<CopyAuthorization>> GetCopyAuthorizationAsync(string resourceId, string resourceRegion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));
            Argument.AssertNotNullOrEmpty(resourceRegion, nameof(resourceRegion));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(FormTrainingClient)}.{nameof(GetCopyAuthorization)}");
            scope.Start();

            try
            {
                Response<CopyAuthorizationResult> response = await ServiceClient.GenerateModelCopyAuthorizationAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new CopyAuthorization(response.Value, resourceId, resourceRegion), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion Copy

        #region Form Recognizer Client

        /// <summary>
        /// Gets an instance of a <see cref="FormRecognizerClient"/> that shares the same endpoint, the same
        /// credentials and the same set of <see cref="FormRecognizerClientOptions"/> this client has.
        /// </summary>
        /// <returns>A new instance of a <see cref="FormRecognizerClient"/>.</returns>
        public virtual FormRecognizerClient GetFormRecognizerClient() => new FormRecognizerClient(Diagnostics, ServiceClient);

        #endregion Form Recognizer Client
    }
}
