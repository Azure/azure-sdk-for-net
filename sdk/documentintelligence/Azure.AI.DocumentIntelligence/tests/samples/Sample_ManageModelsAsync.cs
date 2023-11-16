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
        public async Task ManageModelsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Build to make sure that there is at least one custom model.
            string setupModelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var content = new BuildDocumentModelContent(setupModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
            };

            await client.BuildDocumentModelAsync(WaitUntil.Completed, content);

            #region Snippet:DocumentIntelligenceSampleManageModelsAsync
            // Check number of custom models in the Document Intelligence resource, and the maximum number
            // of custom models that can be stored.

            ResourceDetails resourceDetails = await client.GetResourceInfoAsync();

            Console.WriteLine($"Resource has {resourceDetails.CustomDocumentModels.Count} custom models.");
            Console.WriteLine($"It can have at most {resourceDetails.CustomDocumentModels.Limit} custom models.");

            // Get a model by ID.
#if SNIPPET
            string modelId = "<modelId>";
#else
            string modelId = setupModelId;
#endif
            DocumentModelDetails model = await client.GetModelAsync(modelId);

            Console.WriteLine($"Details about model with ID '{model.ModelId}':");
            Console.WriteLine($"  Created on: {model.CreatedDateTime}");
            Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

            // List up to 10 models currently stored in the resource.
            int count = 0;

            await foreach (DocumentModelDetails modelItem in client.GetModelsAsync())
            {
                Console.WriteLine($"Model details:");
                Console.WriteLine($"  Model ID: {modelItem.ModelId}");
                Console.WriteLine($"  Description: {modelItem.Description}");
                Console.WriteLine($"  Created on: {modelItem.CreatedDateTime}");
                Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

                if (++count == 10)
                {
                    break;
                }
            }
            #endregion

            // Delete the model from the resource.
            await client.DeleteModelAsync(modelId);
        }
    }
}
