// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task GetAndListOperationsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleGetAndListOperations

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Make sure there is at least one operation, so we are going to build a custom model.
#if SNIPPET
            Uri trainingFileUri = <trainingFileUri>;
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri);
            await operation.WaitForCompletionAsync();

            // List the first ten or fewer operations that have been executed in the last 24h.
            AsyncPageable<ModelOperationInfo> modelOperations = client.GetOperationsAsync();

            string operationId = string.Empty;
            int count = 0;
            await foreach (ModelOperationInfo modelOperationInfo in modelOperations)
            {
                Console.WriteLine($"Model operation info:");
                Console.WriteLine($"  Id: {modelOperationInfo.OperationId}");
                Console.WriteLine($"  Kind: {modelOperationInfo.Kind}");
                Console.WriteLine($"  Status: {modelOperationInfo.Status}");
                Console.WriteLine($"  Percent completed: {modelOperationInfo.PercentCompleted}");
                Console.WriteLine($"  Created on: {modelOperationInfo.CreatedOn}");
                Console.WriteLine($"  LastUpdated on: {modelOperationInfo.LastUpdatedOn}");
                Console.WriteLine($"  Resource location of successful operation: {modelOperationInfo.ResourceLocation}");

                if (count == 0)
                    operationId = modelOperationInfo.OperationId;

                if (++count == 10)
                    break;
            }

            // Get an operation by ID
            ModelOperation specificOperation = await client.GetOperationAsync(operationId);

            if (specificOperation.Status == DocumentOperationStatus.Succeeded)
            {
                Console.WriteLine($"My {specificOperation.Kind} operation is completed.");
                DocumentModel result = specificOperation.Result;
                Console.WriteLine($"Model ID: {result.ModelId}");
            }
            else if (specificOperation.Status == DocumentOperationStatus.Failed)
            {
                Console.WriteLine($"My {specificOperation.Kind} operation failed.");
                ResponseError error = specificOperation.Error;
                Console.WriteLine($"Code: {error.Code}: Message: {error.Message}");
            }
            else
                Console.WriteLine($"My {specificOperation.Kind} operation status is {specificOperation.Status}");
            #endregion
        }
    }
}
