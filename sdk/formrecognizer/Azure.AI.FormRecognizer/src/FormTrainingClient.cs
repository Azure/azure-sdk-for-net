// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class FormTrainingClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;

        internal readonly ServiceClient ServiceClient;

        internal const string CustomModelsRoute = "/custom/models";

        /// <summary>
        /// </summary>
        protected FormTrainingClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormTrainingClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public FormTrainingClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            ServiceClient = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Training

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useLabels"></param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TrainingOperation"/> to wait on this long-running operation.  Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        public virtual TrainingOperation StartTraining(Uri trainingFiles, bool useLabels = false, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri };

            //// TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            //// https://github.com/Azure/autorest.csharp/issues/467
            //// When this is complete, we will be able to default filter.Path to "".
            //// Decision to make, do we always send filter, or only if needed?
            //// Tracking with https://github.com/Azure/azure-sdk-for-net/issues/10359
            //if (filter != default)
            //{
            //    trainRequest.SourceFilter = filter;
            //}

            //ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = ServiceClient.RestClient.TrainCustomModelAsync(trainRequest);
            //return new TrainingOperation(ServiceClient, response.Headers.Location);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="useLabels"></param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TrainingOperation"/> to wait on this long-running operation.  Its <see cref="TrainingOperation"/>.Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        public virtual async Task<TrainingOperation> StartTrainingAsync(Uri trainingFiles, bool useLabels = false, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();

            //TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri };

            //// TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            //// https://github.com/Azure/azure-sdk-for-net/issues/10359
            //if (filter != default)
            //{
            //    trainRequest.SourceFilter = filter;
            //}

            //ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await ServiceClient.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            //return new TrainingOperation(ServiceClient, response.Headers.Location);
        }

        /// <summary>
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<CustomFormModel> GetCustomModel(string modelId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<CustomFormModel>> GetCustomModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        #endregion

        #region Management Ops
        /// <summary>
        /// Delete the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            return ServiceClient.DeleteCustomModel(new Guid(modelId), cancellationToken);
        }

        /// <summary>
        /// Delete the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return await ServiceClient.DeleteCustomModelAsync(new Guid(modelId), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a collection of <see cref="CustomFormModelInfo"/> items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<CustomFormModelInfo> GetModelInfos(CancellationToken cancellationToken = default)
        {
            return ServiceClient.GetCustomModelsPageableModelInfo(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// Get a collection of <see cref="CustomFormModelInfo"/> items describing the models trained on this Cognitive Services Account
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<CustomFormModelInfo> GetModelInfosAsync(CancellationToken cancellationToken = default)
        {
            return ServiceClient.GetCustomModelsPageableModelInfoAsync(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// Get the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<AccountProperties> GetAccountProperties(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = ServiceClient.RestClient.GetCustomModels(GetModelOptions.Summary, cancellationToken);
            return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
        }

        /// <summary>
        /// Get the number of models trained on this Cognitive Services Account and the account limits.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<AccountProperties>> GetAccountPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = await ServiceClient.RestClient.GetCustomModelsAsync(GetModelOptions.Summary, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new AccountProperties(response.Value.Summary), response.GetRawResponse());
        }

        #endregion

    }
}
