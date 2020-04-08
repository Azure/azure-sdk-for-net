// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// The client to use to with the Form Recognizer Azure Cognitive Service to train custom models from forms,
    /// and to extract values from forms using those custom models.  It also supports listing and deleting trained
    /// models.
    /// </summary>
    public class FormTrainingClient
    {
        internal readonly ServiceClient ServiceClient;

        /// <summary>
        /// </summary>
        protected FormTrainingClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/>.
        /// </summary>
        public FormTrainingClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new FormRecognizerClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClient"/>.
        /// </summary>
        public FormTrainingClient(Uri endpoint, AzureKeyCredential credential, FormRecognizerClientOptions options)
        {
            var diagnostics = new ClientDiagnostics(options);
            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            ServiceClient = new ServiceClient(diagnostics, pipeline, endpoint.ToString());
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
        [ForwardsClientCalls]
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
        [ForwardsClientCalls]
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
        [ForwardsClientCalls]
        public virtual Response<CustomFormModel> GetCustomModel(string modelId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<CustomFormModel>> GetCustomModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        #endregion
    }
}
