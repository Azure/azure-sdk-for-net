// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [RecordedTest]
        public async Task GetAndListOperationsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleGetAndListOperations

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Make sure there is at least one operation, so we are going to build a custom model.
#if SNIPPET
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = await client.BuildModelAsync(WaitUntil.Completed, trainingFileUri, DocumentBuildMode.Template);

            // List the first ten or fewer operations that have been executed in the last 24h.
            AsyncPageable<DocumentModelOperationSummary> operationSummaries = client.GetOperationsAsync();

            string operationId = string.Empty;
            int count = 0;
            await foreach (DocumentModelOperationSummary operationSummary in operationSummaries)
            {
                Console.WriteLine($"Model operation info:");
                Console.WriteLine($"  Id: {operationSummary.OperationId}");
                Console.WriteLine($"  Kind: {operationSummary.Kind}");
                Console.WriteLine($"  Status: {operationSummary.Status}");
                Console.WriteLine($"  Percent completed: {operationSummary.PercentCompleted}");
                Console.WriteLine($"  Created on: {operationSummary.CreatedOn}");
                Console.WriteLine($"  LastUpdated on: {operationSummary.LastUpdatedOn}");
                Console.WriteLine($"  Resource location of successful operation: {operationSummary.ResourceLocation}");

                if (count == 0)
                    operationId = operationSummary.OperationId;

                if (++count == 10)
                    break;
            }

            // Get an operation by ID
            DocumentModelOperationInfo operationInfo = await client.GetOperationAsync(operationId);

            if (operationInfo.Status == DocumentOperationStatus.Succeeded)
            {
                Console.WriteLine($"My {operationInfo.Kind} operation is completed.");
                DocumentModelDetails result = operationInfo.Result;
                Console.WriteLine($"Model ID: {result.ModelId}");
            }
            else if (operationInfo.Status == DocumentOperationStatus.Failed)
            {
                Console.WriteLine($"My {operationInfo.Kind} operation failed.");
                ResponseError error = operationInfo.Error;
                Console.WriteLine($"Code: {error.Code}: Message: {error.Message}");
            }
            else
                Console.WriteLine($"My {operationInfo.Kind} operation status is {operationInfo.Status}");
            #endregion
        }
    }
}
