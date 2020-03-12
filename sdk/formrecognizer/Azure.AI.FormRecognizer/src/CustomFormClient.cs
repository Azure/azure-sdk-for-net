// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// The sample client.
    /// </summary>
    public class CustomFormClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceClient _operations;

        internal const string CustomModelsRoute = "/custom/models";

        /// <summary>
        /// Mocking ctor only.
        /// </summary>
        protected CustomFormClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormClient"/>.
        /// </summary>
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormClient"/>.
        /// </summary>
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Training
        public virtual Operation<CustomModel> StartTraining(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source };

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

        public virtual async Task<Operation<CustomModel>> StartTrainingAsync(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingOperation(_operations, response.Headers.Location);
        }

        public virtual Operation<CustomLabeledModel> StartTrainingWithLabels(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = _operations.RestClient.TrainCustomModelAsync(trainRequest);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
        }

        public virtual async Task<Operation<CustomLabeledModel>> StartTrainingWithLabelsAsync(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            // https://github.com/Azure/azure-sdk-for-net/issues/10359
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.RestClient.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
        }

        #endregion Training

        #region Analyze
        public virtual Operation<ExtractedForm> StartExtractForm(string modelId, Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        public virtual Operation<ExtractedForm> StartExtractForm(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        public virtual async Task<Operation<ExtractedForm>> StartExtractFormAsync(string modelId, Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        public virtual async Task<Operation<ExtractedForm>> StartExtractFormAsync(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        #endregion Analyze

        #region CRUD Ops
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            return _operations.DeleteCustomModel(new Guid(modelId), cancellationToken);
        }

        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return await _operations.DeleteCustomModelAsync(new Guid(modelId), cancellationToken).ConfigureAwait(false);
        }

        public virtual Pageable<CustomModelInfo> GetModelInfos(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfo(GetModelOptions.Full, cancellationToken);
        }

        public virtual AsyncPageable<CustomModelInfo> GetModelInfosAsync(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfoAsync(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// </summary>
        public virtual Response<SubscriptionProperties> GetSubscriptionProperties(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = _operations.RestClient.GetCustomModels(GetModelOptions.Summary, cancellationToken);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        /// <summary>
        /// </summary>
        public virtual async Task<Response<SubscriptionProperties>> GetSubscriptionPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = await _operations.RestClient.GetCustomModelsAsync(GetModelOptions.Summary, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        #endregion CRUD Ops
    }
}
