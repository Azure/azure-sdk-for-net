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
            string sourceEndpoint = TestEnvironment.Endpoint;
            string sourceApiKey = TestEnvironment.ApiKey;
            string targetEndpoint = "targetEndpoint";
            string targetApiKey = "targetApiKey";
            string targetResourceId = "/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourcegroups/test-rg/providers/Microsoft.CognitiveServices/accounts/formreco-copy-test";
            string targetResourceRegion = "westus2";

            FormTrainingClient client = new FormTrainingClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));

            CustomFormModelInfo modelInfo = await client.StartCopyModelAsync(sourceEndpoint,
                new Uri(targetEndpoint),
                new AzureKeyCredential(targetApiKey),
                targetResourceId,
                targetResourceRegion).WaitForCompletionAsync();

            Console.WriteLine($"Model copied to {targetEndpoint} with new modelId {modelInfo.ModelId}.");
        }
    }
}
