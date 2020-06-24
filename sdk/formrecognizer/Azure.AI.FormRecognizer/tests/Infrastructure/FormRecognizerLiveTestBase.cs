// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerLiveTestBase : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        protected TimeSpan PollingInterval => TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0 : 1);

        public FormRecognizerLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new FormRecognizerRecordedTestSanitizer();
        }

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="apiKey">The API key to use for authentication. Defaults to <see cref="FormRecognizerTestEnvironment.ApiKey"/>.</param>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateInstrumentedFormTrainingClient(bool useTokenCredential = false, string apiKey = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = Recording.InstrumentClientOptions(new FormRecognizerClientOptions());
            FormTrainingClient client;

            if (useTokenCredential)
            {
                client = new FormTrainingClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                var credential = new AzureKeyCredential(apiKey ?? TestEnvironment.ApiKey);
                client = new FormTrainingClient(endpoint, credential, options);
            }

            return InstrumentClient(client);
        }

        /// <summary>
        /// Trains a model and returns the associated <see cref="DisposableTrainedModel"/> instance, from which
        /// the model ID can be obtained. Upon disposal, the model will be deleted.
        /// </summary>
        /// <param name="useTrainingLabels">If <c>true</c>, use a label file created in the &lt;link-to-label-tool-doc&gt; to provide training-time labels for training a model. If <c>false</c>, the model will be trained from forms only.</param>
        /// <returns>A <see cref="DisposableTrainedModel"/> instance from which the trained model ID can be obtained.</returns>
        protected async Task<DisposableTrainedModel> CreateDisposableTrainedModelAsync(bool useTrainingLabels)
        {
            var trainingClient = CreateInstrumentedFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            return await DisposableTrainedModel.TrainModelAsync(trainingClient, trainingFilesUri, useTrainingLabels, PollingInterval);
        }
    }
}
