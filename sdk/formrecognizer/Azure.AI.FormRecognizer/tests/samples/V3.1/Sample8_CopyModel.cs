// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples
    {
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task CopyModel()
        {
            #region Snippet:FormRecognizerSampleCreateCopySourceClientV3
#if SNIPPET
            string sourceEndpoint = "<source_endpoint>";
            string sourceApiKey = "<source_apiKey>";
#else
            string sourceEndpoint = TestEnvironment.Endpoint;
            string sourceApiKey = TestEnvironment.ApiKey;
#endif
            var sourcecredential = new AzureKeyCredential(sourceApiKey);
            var sourceClient = new FormTrainingClient(new Uri(sourceEndpoint), sourcecredential);
            #endregion

            // For the purpose of this sample, we are going to create a trained model to copy. Please note that
            // if you already have a model, this is not necessary.
#if SNIPPET
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            TrainingOperation operation = await sourceClient.StartTrainingAsync(trainingFileUri, useTrainingLabels: false);
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            #region Snippet:FormRecognizerSampleCreateCopyTargetClientV3
#if SNIPPET
            string targetEndpoint = "<target_endpoint>";
            string targetApiKey = "<target_apiKey>";
#else
            string targetEndpoint = TestEnvironment.Endpoint;
            string targetApiKey = TestEnvironment.ApiKey;
#endif
            var targetCredential = new AzureKeyCredential(targetApiKey);
            var targetClient = new FormTrainingClient(new Uri(targetEndpoint), targetCredential);
            #endregion

            #region Snippet:FormRecognizerSampleGetCopyAuthorizationV3
#if SNIPPET
            string resourceId = "<resourceId>";
            string resourceRegion = "<region>";
#else
            string resourceId = TestEnvironment.ResourceId;
            string resourceRegion = TestEnvironment.ResourceRegion;
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
