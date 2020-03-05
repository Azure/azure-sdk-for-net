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
        private readonly AllOperations _operations;

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
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormClient"/>.
        /// </summary>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public CustomFormClient(Uri endpoint, FormRecognizerApiKeyCredential credential, FormRecognizerClientOptions options)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _operations = new AllOperations(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Training

        // XX public virtual LabeledTrainingOperation StartLabeledTraining(string source, TrainingFileFilter filter, CancellationToken cancellationToken = default);
        // XX public virtual Task<LabeledTrainingOperation> StartLabeledTrainingAsync(string source, TrainingFileFilter filter, CancellationToken cancellationToken = default);
        // XX public virtual TrainingOperation StartTraining(string source, TrainingFileFilter filter, CancellationToken cancellationToken = default);
        // XX public virtual Task<TrainingOperation> StartTrainingAsync(string source, TrainingFileFilter filter, CancellationToken cancellationToken = default);

        public virtual TrainingOperation StartTraining(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            // TODO: do we need to set prefix to an empty string in filter? -- looks like yes.
            //filter ??= new TrainingFileFilter();

            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = _operations.TrainCustomModelAsync(trainRequest);
            return new TrainingOperation(_operations, response.Headers.Location);
        }

        public virtual async Task<TrainingOperation> StartTrainingAsync(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            // TODO: do we need to set prefix to an empty string in filter? -- looks like yes.
            //filter ??= new TrainingFileFilter();

            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingOperation(_operations, response.Headers.Location);
        }

        public virtual TrainingWithLabelsOperation StartTrainingWithLabels(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = _operations.TrainCustomModelAsync(trainRequest);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
        }

        public virtual async Task<TrainingWithLabelsOperation> StartTrainingWithLabelsAsync(string source, TrainingFileFilter filter = default, CancellationToken cancellationToken = default)
        {
            TrainRequest_internal trainRequest = new TrainRequest_internal() { Source = source, UseLabelFile = true };

            // TODO: Q1 - if there's a way to default a property value, set filter.Path ="" and set it here in a nicer way.
            if (filter != default)
            {
                trainRequest.SourceFilter = filter;
            }

            ResponseWithHeaders<TrainCustomModelAsyncHeaders> response = await _operations.TrainCustomModelAsyncAsync(trainRequest).ConfigureAwait(false);
            return new TrainingWithLabelsOperation(_operations, response.Headers.Location);
        }

        #endregion Training

        #region Analyze

        // XX public virtual Response<ExtractedForm> ExtractForm(string modelId, Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        // XX - broken (service issue?) public virtual Response<ExtractedForm> ExtractForm(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        // XX public virtual Task<Response<ExtractedForm>> ExtractFormAsync(string modelId, Stream stream, FormContentType? contentType = null, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);
        // XX - broken (service issue?) public virtual Task<Response<ExtractedForm>> ExtractFormAsync(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default);

        public virtual ExtractFormOperation StartExtractForm(string modelId, Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        public virtual ExtractFormOperation StartExtractForm(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        public virtual async Task<ExtractFormOperation> StartExtractFormAsync(string modelId, Stream stream, FormContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        #endregion Analyze

        #region CRUD Ops

        // XX public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default);
        // XX public virtual Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default);
        // XX public virtual Response<ModelsSummary> GetModelsSummary(CancellationToken cancellationToken = default);
        // XX public virtual Task<Response<ModelsSummary>> GetModelsSummaryAsync(CancellationToken cancellationToken = default);
        // XX public virtual Pageable<ModelTrainingStatus> GetModelsTrainingStatus(CancellationToken cancellationToken = default);
        // XX public virtual AsyncPageable<ModelTrainingStatus> GetModelsTrainingStatusAsync(CancellationToken cancellationToken = default);

        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            return _operations.DeleteCustomModel(new Guid(modelId), cancellationToken);
        }

        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return await _operations.DeleteCustomModelAsync(new Guid(modelId), cancellationToken).ConfigureAwait(false);
        }

        // TODO: Q8 - How to convert ModelInfo_internal to ModelInfo for Pageables?
        public virtual Pageable<ModelInfo> GetModels(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfo(GetModelOptions.Full, cancellationToken);
        }

        public virtual AsyncPageable<ModelInfo> GetModelsAsync(CancellationToken cancellationToken = default)
        {
            return _operations.GetCustomModelsPageableModelInfoAsync(GetModelOptions.Full, cancellationToken);
        }

        /// <summary>
        /// </summary>
        public virtual Response<SubscriptionProperties> GetModelSubscriptionProperties(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = _operations.GetCustomModels(GetModelOptions.Summary, cancellationToken);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        /// <summary>
        /// </summary>
        public virtual async Task<Response<SubscriptionProperties>> GetModelSubscriptionPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response<Models_internal> response = await _operations.GetCustomModelsAsync(GetModelOptions.Summary, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SubscriptionProperties(response.Value.Summary), response.GetRawResponse());
        }

        #endregion CRUD Ops
    }
}
