﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// The client to use to connect with the Form Recognizer Azure Cognitive Service to train models from
    /// custom forms.  It also supports listing and deleting trained models, as well as accessing account
    /// properties.
    /// </summary>
    public class FormTrainingClient
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        internal readonly ServiceRestClient ServiceClient;

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
        /// Both the <paramref name="endpoint"/> URI <c>string</c> and the <paramref name="credential"/> <c>string</c> key
        /// can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <remarks>
        /// Both the <paramref name="endpoint"/> URI <c>string</c> and the <paramref name="credential"/> <c>string</c> key
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
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to an Azure Service.</param>
        /// <remarks>
        /// The <paramref name="endpoint"/> URI <c>string</c> can be found in the Azure Portal.
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
        /// The <paramref name="endpoint"/> URI <c>string</c> can be found in the Azure Portal.
        /// </remarks>
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md#authenticate-a-form-recognizer-client"/>
        public FormTrainingClient(Uri endpoint, TokenCredential credential, FormRecognizerClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));
            ServiceClient = new ServiceRestClient(Diagnostics, pipeline, endpoint.AbsoluteUri);
        }

        #region Training

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="trainingFileFilter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        [ForwardsClientCalls]
        public virtual TrainingOperation StartTraining(Uri trainingFilesUri, bool useTrainingLabels, TrainingFileFilter trainingFileFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));

            var trainRequest = new TrainRequest_internal(trainingFilesUri.AbsoluteUri, trainingFileFilter, useTrainingLabels);

            ResponseWithHeaders<ServiceTrainCustomModelAsyncHeaders> response = ServiceClient.TrainCustomModelAsync(trainRequest);
            return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFilesUri">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="trainingFileFilter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// <para>A <see cref="TrainingOperation"/> to wait on this long-running operation. Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</para>
        /// <para>Even if training fails, a model is created in the Form Recognizer account with an "invalid" status.
        /// A <see cref="RequestFailedException"/> will be raised containing the modelId to access this invalid model.</para>
        /// </returns>
        [ForwardsClientCalls]
        public virtual async Task<TrainingOperation> StartTrainingAsync(Uri trainingFilesUri, bool useTrainingLabels, TrainingFileFilter trainingFileFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFilesUri, nameof(trainingFilesUri));

            var trainRequest = new TrainRequest_internal(trainingFilesUri.AbsoluteUri, trainingFileFilter, useTrainingLabels);

            ResponseWithHeaders<ServiceTrainCustomModelAsyncHeaders> response = await ServiceClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingOperation(response.Headers.Location, ServiceClient, Diagnostics);
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
        [ForwardsClientCalls]
        public virtual Response<CustomFormModel> GetCustomModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            Response<Model_internal> response = ServiceClient.GetCustomModel(guid, includeKeys: true, cancellationToken);
            return Response.FromValue(new CustomFormModel(response.Value), response.GetRawResponse());
        }

        /// <summary>
        /// Gets a description of a custom model, including the types of forms it can recognize and the fields it will extract for each form type.
        /// </summary>
        /// <param name="modelId">The ID of the model to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to a <see cref="CustomFormModel"/> containing
        /// information about the requested model.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<CustomFormModel>> GetCustomModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            Response<Model_internal> response = await ServiceClient.GetCustomModelAsync(guid, includeKeys: true, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new CustomFormModel(response.Value), response.GetRawResponse());
        }

        /// <summary>
        /// Deletes the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            return ServiceClient.DeleteCustomModel(guid, cancellationToken);
        }

        /// <summary>
        /// Deletes the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response"/> representing the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));

            return await ServiceClient.DeleteCustomModelAsync(guid, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="CustomFormModelInfo"/> items.</returns>
        [ForwardsClientCalls]
        public virtual Pageable<CustomFormModelInfo> GetCustomModels(CancellationToken cancellationToken = default)
        {
            Page<CustomFormModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                Response<Models_internal> response =  ServiceClient.ListCustomModels(cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<CustomFormModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                Response<Models_internal> response = ServiceClient.ListCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="CustomFormModelInfo"/> items.</returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<CustomFormModelInfo> GetCustomModelsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CustomFormModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                Response<Models_internal> response = await ServiceClient.ListCustomModelsAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<CustomFormModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                Response<Models_internal> response = await ServiceClient.ListCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomFormModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        [ForwardsClientCalls]
        public virtual Response<AccountProperties> GetAccountProperties(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = ServiceClient.GetCustomModels(cancellationToken);
            return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
        }

        /// <summary>
        /// Gets the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to an <see cref="AccountProperties"/> containing
        /// the account properties.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<AccountProperties>> GetAccountPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = await ServiceClient.GetCustomModelsAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
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
        /// <returns>A <see cref="CopyModelOperation"/> to wait on this long-running operation.  Its <see cref="CopyModelOperation"/>.Value upon successful
        /// completion will contain meta-data about the model copied.</returns>
        [ForwardsClientCalls]
        public virtual CopyModelOperation StartCopyModel(string modelId, CopyAuthorization target, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(target, nameof(target));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
            var request = new CopyRequest(target.ResourceId,
                                          target.Region,
                                          new CopyAuthorizationResult(target.ModelId, target.AccessToken, target.ExpiresOn/*.ToUnixTimeSeconds()*/));

            Response response = ServiceClient.CopyCustomModel(guid, request, cancellationToken);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new CopyModelOperation(ServiceClient, Diagnostics, location, target.ModelId);
        }

        /// <summary>
        /// Copy a custom model stored in this resource (the source) to the user specified
        /// target Form Recognizer resource.
        /// </summary>
        /// <param name="modelId">Model identifier of the model to copy to the target Form Recognizer resource.</param>
        /// <param name="target">A <see cref="CopyAuthorization"/> with the copy authorization to the target Form Recognizer resource.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CopyModelOperation"/> to wait on this long-running operation.  Its <see cref="CopyModelOperation"/>.Value upon successful
        /// completion will contain meta-data about the model copied.</returns>
        [ForwardsClientCalls]
        public virtual async Task<CopyModelOperation> StartCopyModelAsync(string modelId, CopyAuthorization target, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(target, nameof(target));

            Guid guid = ClientCommon.ValidateModelId(modelId, nameof(modelId));
            var request = new CopyRequest(target.ResourceId,
                                          target.Region,
                                          new CopyAuthorizationResult(target.ModelId, target.AccessToken, target.ExpiresOn/*.ToUnixTimeSeconds()*/));

            Response response = await ServiceClient.CopyCustomModelAsync(guid, request, cancellationToken).ConfigureAwait(false);
            string location = ClientCommon.GetResponseHeader(response.Headers, Constants.OperationLocationHeader);

            return new CopyModelOperation(ServiceClient, Diagnostics, location, target.ModelId);
        }

        /// <summary>
        /// Generate authorization for copying a custom model into the target Form Recognizer resource.
        /// </summary>
        /// <param name="resourceId">Azure Resource Id of the target Form Recognizer resource where the model will be copied to.</param>
        /// <param name="resourceRegion">Location of the target Form Recognizer resource</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information neccesary to copy a custom model into a target Form Recognizer resource.</returns>
        [ForwardsClientCalls]
        public virtual Response<CopyAuthorization> GetCopyAuthorization(string resourceId, string resourceRegion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));
            Argument.AssertNotNullOrEmpty(resourceRegion, nameof(resourceRegion));

            Response<CopyAuthorizationResult> response = ServiceClient.GenerateModelCopyAuthorization(cancellationToken);
            return Response.FromValue(new CopyAuthorization(response.Value, resourceId, resourceRegion), response.GetRawResponse());
        }

        /// <summary>
        /// Generate authorization for copying a custom model into the target Form Recognizer resource.
        /// </summary>
        /// <param name="resourceId">Azure Resource Id of the target Form Recognizer resource where the model will be copied to.</param>
        /// <param name="resourceRegion">Location of the target Form Recognizer resource</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{T}"/> representing the result of the operation. It can be cast to <see cref="CopyAuthorization"/> containing
        /// the authorization information neccesary to copy a custom model into a target Form Recognizer resource.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<CopyAuthorization>> GetCopyAuthorizationAsync(string resourceId, string resourceRegion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));
            Argument.AssertNotNullOrEmpty(resourceRegion, nameof(resourceRegion));

            Response<CopyAuthorizationResult> response = await ServiceClient.GenerateModelCopyAuthorizationAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new CopyAuthorization(response.Value, resourceId, resourceRegion), response.GetRawResponse());
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
