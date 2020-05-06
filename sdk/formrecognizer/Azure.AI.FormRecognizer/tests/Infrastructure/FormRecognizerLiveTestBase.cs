// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerLiveTestBase : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        public FormRecognizerLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new FormRecognizerRecordedTestSanitizer();
            Matcher = new FormRecognizerRecordMatcher();
        }

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateInstrumentedFormTrainingClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var options = Recording.InstrumentClientOptions(new FormRecognizerClientOptions());
            var client = new FormTrainingClient(endpoint, credential, options);

            return InstrumentClient(client);
        }

        /// <summary>
        /// Trains a model and returns the associated <see cref="DisposableTrainedModel"/> instance, from which
        /// the model ID can be obtained. Upon disposal, the model will be deleted.
        /// </summary>
        /// <param name="useLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        protected async Task<DisposableTrainedModel> CreateDisposableTrainedModelAsync(bool useLabels)
        {
            var trainingClient = CreateInstrumentedFormTrainingClient();
            var trainingFiles = new Uri(TestEnvironment.BlobContainerSasUrl);

            DisposableTrainedModel trainedModel;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                trainedModel = await DisposableTrainedModel.TrainModelAsync(trainingClient, trainingFiles, useLabels);
            }

            return trainedModel;
        }
    }
}
