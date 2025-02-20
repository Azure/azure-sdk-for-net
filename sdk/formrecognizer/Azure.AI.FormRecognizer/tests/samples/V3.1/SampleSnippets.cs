// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class FormRecognizerSamples
    {
        [RecordedTest]
        public void CreateFormRecognizerClient()
        {
            #region Snippet:CreateFormRecognizerClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public void CreateFormTrainingClient()
        {
            #region Snippet:CreateFormTrainingClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormTrainingClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public void CreateFormRecognizerClients()
        {
            #region Snippet:CreateFormRecognizerClients
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);

            var formRecognizerClient = new FormRecognizerClient(new Uri(endpoint), credential);
            var formTrainingClient = new FormTrainingClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task StartLongRunningOperation()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormTrainingClient(new Uri(endpoint), credential);

            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation trainingOperation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false);
            Response<CustomFormModel> operationResponse = await trainingOperation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            string resourceId = TestEnvironment.ResourceId;
            string resourceRegion = TestEnvironment.ResourceRegion;
            string modelId = model.ModelId;
            CopyAuthorization authorization = await client.GetCopyAuthorizationAsync(resourceId, resourceRegion);

            #region Snippet:WaitForLongRunningOperationV2
            CopyModelOperation operation = await client.StartCopyModelAsync(modelId, authorization);
            await operation.WaitForCompletionAsync();
            #endregion
        }
    }
}
