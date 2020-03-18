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

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// The client to use to with the Form Recognizer Azure Cognitive Service to train custom models from forms,
    /// and to extract values from forms using those custom models.  It also supports listing and deleting trained
    /// models.
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
            _operations = new ServiceClient(_diagnostics, _pipeline, endpoint.ToString());
        }

        #region Training

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="source">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;CustomModel&gt; to wait on this long-running operation.  Its Operation &lt; CustomModel &gt; .Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
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

        /// <summary>
        /// Trains a model from a collection of custom forms in a blob storage container.
        /// </summary>
        /// <param name="source">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;CustomModel&gt; to wait on this long-running operation.  Its Operation &lt; CustomModel &gt; .Value upon successful
        /// completion will contain meta-data about the trained model.</returns>
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

        /// <summary>
        /// Trains a model from a collection of custom forms and a label file in a blob storage container.
        /// </summary>
        /// <param name="source">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Operation{T}"/> to wait on this long-running operation.</returns>
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

        /// <summary>
        /// Trains a model from a collection of custom forms and a label file in a blob storage container.
        /// </summary>
        /// <param name="source">An externally accessible Azure storage blob container Uri.</param>
        /// <param name="filter">Filter to apply to the documents in the source path for training.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Operation{T}"/> to wait on this long-running operation.</returns>
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

        #region Unsupervised

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual Operation<IReadOnlyList<ExtractedPage>> StartExtractFormPages(string modelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new ExtractPagesOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual Operation<IReadOnlyList<ExtractedPage>> StartExtractFormPages(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new ExtractPagesOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedPage>>> StartExtractFormPagesAsync(string modelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractPagesOperation(_operations, modelId, response.Headers.OperationLocation);
        }


        /// <summary>
        /// Extract pages from one or more forms, using a model trained without labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted pages from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedPage>>> StartExtractFormPagesAsync(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractPagesOperation(_operations, modelId, response.Headers.OperationLocation);
        }
        #endregion

        #region Supervised

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual Operation<IReadOnlyList<ExtractedLabeledForm>> StartExtractLabeledForms(string modelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken);
            return new ExtractLabeledFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual Operation<IReadOnlyList<ExtractedLabeledForm>> StartExtractLabeledForms(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = _operations.RestClient.AnalyzeWithCustomModel(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken);
            return new ExtractLabeledFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="stream">The stream containing one or more forms to extract elements from.</param>
        /// <param name="contentType">The content type of the input file.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedLabeledForm>>> StartExtractLabeledFormsAsync(string modelId, Stream stream, ContentType contentType, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            // TODO: automate content-type detection
            // https://github.com/Azure/azure-sdk-for-net/issues/10329
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, stream, contentType, cancellationToken).ConfigureAwait(false);
            return new ExtractLabeledFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }

        /// <summary>
        /// Extract form content from one or more forms, using a model trained with labels.
        /// </summary>
        /// <param name="modelId">The id of the model to use for extracting form values.</param>
        /// <param name="uri">The absolute URI of the remote file to extract elements from.</param>
        /// <param name="includeRawPageExtractions">Whether or not to include raw page extractions in addition to layout elements.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt; to wait on this long-running operation.  Its Operation&lt;IReadOnlyList&lt;ExtractedPage&gt;&gt;.Value upon successful
        /// completion will contain extracted forms from the input document.</returns>
        public virtual async Task<Operation<IReadOnlyList<ExtractedLabeledForm>>> StartExtractLabeledFormsAsync(string modelId, Uri uri, bool includeRawPageExtractions = false, CancellationToken cancellationToken = default)
        {
            SourcePath_internal sourcePath = new SourcePath_internal() { Source = uri.ToString() };
            ResponseWithHeaders<AnalyzeWithCustomModelHeaders> response = await _operations.RestClient.AnalyzeWithCustomModelAsync(new Guid(modelId), includeTextDetails: includeRawPageExtractions, sourcePath, cancellationToken).ConfigureAwait(false);
            return new ExtractLabeledFormOperation(_operations, modelId, response.Headers.OperationLocation);
        }
        #endregion

        #endregion Analyze

        #region CRUD Ops
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

        #endregion CRUD Ops
    }
}
