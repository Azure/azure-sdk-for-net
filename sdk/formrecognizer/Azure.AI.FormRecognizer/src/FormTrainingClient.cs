// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// The client to use to connect with the Form Recognizer Azure Cognitive Service to train models from
    /// custom forms.  It also supports listing and deleting
    /// trained models, as well as accessing account properties.
    /// </summary>
    public class FormTrainingClient
    {
        internal readonly ServiceClient ServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        protected FormTrainingClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service. The URI is likely to be similar to <c>{protocol}://{resourcename}.cognitiveservices.azure.com</c>.</param>
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
        /// <param name="endpoint">The endpoint to use for connecting to the Form Recognizer Azure Cognitive Service. The URI is likely to be similar to <c>{protocol}://{resourcename}.cognitiveservices.azure.com</c>.</param>
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

            var diagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceClient(diagnostics, pipeline, endpoint.ToString());
        }

        #region Training

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TrainingOperation"/> to wait on this long-running operation.  Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        [ForwardsClientCalls]
        public virtual TrainingOperation StartTraining(Uri trainingFiles, bool useLabels = false, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFiles, nameof(trainingFiles));

            var trainRequest = new TrainRequest_internal(trainingFiles.AbsoluteUri, filter, useLabels);

            ResponseWithHeaders<ServiceTrainCustomModelAsyncHeaders> response = ServiceClient.RestClient.TrainCustomModelAsync(trainRequest);
            return new TrainingOperation(response.Headers.Location, ServiceClient);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TrainingOperation"/> to wait on this long-running operation.  Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        [ForwardsClientCalls]
        public virtual async Task<TrainingOperation> StartTrainingAsync(Uri trainingFiles, bool useLabels = false, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(trainingFiles, nameof(trainingFiles));

            var trainRequest = new TrainRequest_internal(trainingFiles.AbsoluteUri, filter, useLabels);

            ResponseWithHeaders<ServiceTrainCustomModelAsyncHeaders> response = await ServiceClient.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingOperation(response.Headers.Location, ServiceClient);
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
        public virtual Pageable<CustomFormModelInfo> GetModelInfos(CancellationToken cancellationToken = default)
        {
            return ServiceClient.GetCustomModelsPageableModelInfo(cancellationToken);
        }

        /// <summary>
        /// Gets a collection of items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="CustomFormModelInfo"/> items.</returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<CustomFormModelInfo> GetModelInfosAsync(CancellationToken cancellationToken = default)
        {
            return ServiceClient.GetCustomModelsPageableModelInfoAsync(cancellationToken);
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
            Response<Models_internal> response = ServiceClient.RestClient.GetCustomModels(cancellationToken);
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
            Response<Models_internal> response = await ServiceClient.RestClient.GetCustomModelsAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
        }

        #endregion
    }
}
