// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task GetAndListOperationsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Build a custom model to make sure that there is at least one operation.
            string modelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var content = new BuildDocumentModelContent(modelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
            };

            Operation<DocumentModelDetails> buildOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, content);

            #region Snippet:DocumentIntelligenceSampleGetAndListOperations
            // Get an operation by ID.
#if SNIPPET
            string operationId = "<operationId>";
#else
            string operationId = buildOperation.Id;
#endif
            OperationDetails operationDetails = await client.GetOperationAsync(operationId);

            if (operationDetails.Status == OperationStatus.Succeeded)
            {
                Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has succeeded.");

                // Extract the result based on the kind of operation.
                switch (operationDetails)
                {
                    case DocumentModelBuildOperationDetails modelOperation:
                        Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
                        break;

                    case DocumentModelCopyToOperationDetails modelOperation:
                        Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
                        break;

                    case DocumentModelComposeOperationDetails modelOperation:
                        Console.WriteLine($"Model ID: {modelOperation.Result.ModelId}");
                        break;

                    case DocumentClassifierBuildOperationDetails classifierOperation:
                        Console.WriteLine($"Classifier ID: {classifierOperation.Result.ClassifierId}");
                        break;
                }
            }
            else if (operationDetails.Status == OperationStatus.Failed)
            {
                Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has failed.");
                Console.WriteLine($"Error code: {operationDetails.Error.Code}");
                Console.WriteLine($"Error message: {operationDetails.Error.Message}");
            }
            else
            {
                Console.WriteLine($"Operation with ID '{operationDetails.OperationId}' has status '{operationDetails.Status}'.");
            }

            // List up to 10 operations that have been executed in the last 24 hours.
            int count = 0;

            await foreach (OperationDetails operationItem in client.GetOperationsAsync())
            {
                Console.WriteLine($"Operation details:");
                Console.WriteLine($"  Operation ID: {operationItem.OperationId}");
                Console.WriteLine($"  Status: {operationItem.Status}");
                Console.WriteLine($"  Completion: {operationItem.PercentCompleted}%");
                Console.WriteLine($"  Created on: {operationItem.CreatedDateTime}");
                Console.WriteLine($"  Last updated on: {operationItem.LastUpdatedDateTime}");
                Console.WriteLine($"  Resource location: {operationItem.ResourceLocation}");

                if (++count == 10)
                {
                    break;
                }
            }
#endregion

            // Delete the model on completion to clean the environment.
            await client.DeleteModelAsync(modelId);
        }
    }
}
