// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task CopyModel()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleCreateCopySourceClientV3
#if SNIPPET
            string endpoint = "<source_endpoint>";
            string apiKey = "<source_apiKey>";
#endif
            var sourcecredential = new AzureKeyCredential(apiKey);
            var sourceClient = new FormTrainingClient(new Uri(endpoint), sourcecredential);
            #endregion

            // For the purpose of this sample, we are going to create a trained model to copy. Please note that
            // if you already have a model, this is not necessary.
#if SNIPPET
            Uri trainingFileUri = <trainingFileUri>;
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrlV2);
#endif
            TrainingOperation operation = await sourceClient.StartTrainingAsync(trainingFileUri, useTrainingLabels: false);
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            #region Snippet:FormRecognizerSampleCreateCopyTargetClientV3
#if SNIPPET
            string endpoint = "<target_endpoint>";
            string apiKey = "<target_apiKey>";
#endif
            var targetCredential = new AzureKeyCredential(apiKey);
            var targetClient = new FormTrainingClient(new Uri(endpoint), targetCredential);
            #endregion

            #region Snippet:FormRecognizerSampleGetCopyAuthorizationV3
#if SNIPPET
            string resourceId = "<resourceId>";
            string resourceRegion = "<region>";
#else
            string resourceId = TestEnvironment.TargetResourceId;
            string resourceRegion = TestEnvironment.TargetResourceRegion;
#endif
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, resourceRegion);
            #endregion

            #region Snippet:FormRecognizerSampleToJson
            string jsonTargetAuth = targetAuth.ToJson();
            #endregion

            #region Snippet:FormRecognizerSampleFromJson
            CopyAuthorization targetCopyAuth = CopyAuthorization.FromJson(jsonTargetAuth);
            #endregion

            #region Snippet:FormRecognizerSampleCopyModel
#if SNIPPET
            string modelId = "<source_modelId>";
#else
            string modelId = model.ModelId;
#endif
            CustomFormModelInfo newModel = await sourceClient.StartCopyModelAsync(modelId, targetCopyAuth).WaitForCompletionAsync();

            Console.WriteLine($"Original model ID => {modelId}");
            Console.WriteLine($"Copied model ID => {newModel.ModelId}");
            #endregion
        }
    }
}
