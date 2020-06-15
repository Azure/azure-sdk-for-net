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
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;
            string resourceId = TestEnvironment.TargetResourceId;
            string resourceRegion = TestEnvironment.TargetResourceRegion;


            #region Snippet:FormRecognizerSample6CreateCopySourceClient
            //@@ string endpoint = "<source_endpoint>";
            //@@ string apiKey = "<source_apiKey>";
            var sourcecredential = new AzureKeyCredential(apiKey);
            var sourceClient = new FormTrainingClient(new Uri(endpoint), sourcecredential);
            #endregion

            // For the purpose of this sample, we are going to create a trained model to copy. Please note that
            // if you already have a model, this is not neccesary.
            CustomFormModel model = await sourceClient.StartTraining(new Uri(trainingFileUrl), useTrainingLabels: false).WaitForCompletionAsync();
            string modelId = model.ModelId;

            #region Snippet:FormRecognizerSample6CreateCopyTargetClient
            //@@ string endpoint = "<target_endpoint>";
            //@@ string apiKey = "<target_apiKey>";
            var targetCredential = new AzureKeyCredential(apiKey);
            var targetClient = new FormTrainingClient(new Uri(endpoint), targetCredential);
            #endregion

            #region Snippet:FormRecognizerSample6GetCopyAuthorization
            //@@ string resourceId = "<resourceId>";
            //@@ string resourceRegion = "<region>";
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, resourceRegion);
            #endregion

            #region Snippet:FormRecognizerSample6ToJson
            string jsonTargetAuth = targetAuth.ToJson();
            #endregion

            #region Snippet:FormRecognizerSample6FromJson
            CopyAuthorization targetCopyAuth = CopyAuthorization.FromJson(jsonTargetAuth);
            #endregion

            #region Snippet:FormRecognizerSample6CopyModel
            //@@ string modelId = "<source_modelId>";
            CustomFormModelInfo newModel = await sourceClient.StartCopyModelAsync(modelId, targetCopyAuth).WaitForCompletionAsync();

            Console.WriteLine($"Original modelID => {modelId}");
            Console.WriteLine($"Copied modelID => {newModel.ModelId}");
            #endregion
        }
    }
}
