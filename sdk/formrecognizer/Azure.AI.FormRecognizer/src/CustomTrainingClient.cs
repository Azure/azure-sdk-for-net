// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomTrainingClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceClient _operations;

        internal const string CustomModelsRoute = "/custom/models";

        /// <summary>
        /// </summary>
        protected CustomTrainingClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTrainingClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomTrainingClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTrainingClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomTrainingClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Training

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;CustomModel&gt; to wait on this long-running operation.  Its Operation &lt; CustomModel &gt; .Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        public virtual Operation<CustomModel> StartTraining(Uri trainingFiles, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/autorest.csharp/issues/467
            // When this is complete, we will be able to default filter.Path to "".
            // Decision to make, do we always send filter, or only if needed?
            // Tracking with https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = _operations.RestClient.TrainCustomModelAsync(trainRequest);
            return new TrainingOperation(_operations, response.Headers.Location);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;CustomModel&gt; to wait on this long-running operation.  Its Operation &lt; CustomModel &gt; .Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
        public virtual async Task<Operation<CustomModel>> StartTrainingAsync(Uri trainingFiles, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingOperation(_operations, response.Headers.Location);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms and a label file in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Operation{T}"/> to wait on this long-running operation.</returns>
        public virtual Operation<CustomLabeledModel> StartTrainingWithLabels(Uri trainingFiles, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = _operations.RestClient.TrainCustomModelAsync(trainRequest);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
        }

        /// <summary>
        /// Trains a model from a collection of custom forms and a label file in a blob storage container.
        /// </summary>
        /// <param name="trainingFiles">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Operation{T}"/> to wait on this long-running operation.</returns>
        public virtual async Task<Operation<CustomLabeledModel>> StartTrainingWithLabelsAsync(Uri trainingFiles, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = trainingFiles.AbsoluteUri, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
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
            return _operations.DeleteCustomModel(new Guid(modelId), cancellationToken);
        }

        /// <summary>
        /// Delete the model with the specified model ID.
        /// </summary>
        /// <param name="modelId">The ID of the model to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return await _operations.DeleteCustomModelAsync(new Guid(modelId), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a collection of <see cref="CustomModelInfo"/> items describing the models trained on this subscription
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<CustomModelInfo> GetModelInfos(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfo(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// Get a collection of <see cref="CustomModelInfo"/> items describing the models trained on this subscription
        /// and their training status.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<CustomModelInfo> GetModelInfosAsync(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfoAsync(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// Get the number of models trained on this subscription and the subscription limits.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<SubscriptionProperties> GetSubscriptionProperties(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = _operations.RestClient.GetCustomModels(GetModelOptions.Summary, cancellationToken);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        /// <summary>
        /// Get the number of models trained on this subscription and the subscription limits.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<SubscriptionProperties>> GetSubscriptionPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = await _operations.RestClient.GetCustomModelsAsync(GetModelOptions.Summary, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        #endregion

        #region Compose Model

        /// <summary>
        /// </summary>
        /// <param name="modelIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Operation<CustomComposedModel> StartComposeModel(IEnumerable<string> modelIds, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="modelIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Operation<CustomComposedModel>> StartComposeModelAsync(IEnumerable<string> modelIds, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        #endregion
    }
}
