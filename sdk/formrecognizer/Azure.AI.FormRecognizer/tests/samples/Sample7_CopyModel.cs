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

            // For the purpose of this sample, we are going to create a trained model to copy. Please note that
            // if you already have a model, this is not neccesary.

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            CustomFormModel model = await client.StartTraining(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            string modelId = model.ModelId;

            FormTrainingClient targetClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync("<resourceId>", "<region>");

            // Use ToJson to share the model access token with another application.
            var jsonTargetAuth = targetAuth.ToJson();

            // Deserialize a model access token
            CopyAuthorization targetAuthFromJson = CopyAuthorization.FromJson(jsonTargetAuth);

            CustomFormModelInfo modelCopy = await client.StartCopyModelAsync(modelId, targetAuthFromJson).WaitForCompletionAsync();

            Console.WriteLine($"Original modelID => {modelId}");
            Console.WriteLine($"Copied modelID => {modelCopy.ModelId}");
        }
    }
}
