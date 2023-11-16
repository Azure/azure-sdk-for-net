// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task BuildCustomModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceSampleBuildModel
            // For this sample, you can use the training documents found in the `trainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL. Note
            // that a container URI without SAS is accepted only when the container is public or has a
            // managed identity configured.

            // For instructions to set up documents for training in an Azure Blob Storage Container, please see:
            // https://aka.ms/azsdk/formrecognizer/buildcustommodel

#if SNIPPET
            string modelId = "<modelId>";
            Uri blobContainerUri = new Uri("<blobContainerUri>");
#else
            string modelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif

            // We are selecting the Template build mode in this sample. For more information about the available
            // build modes and their differences, see:
            // https://aka.ms/azsdk/formrecognizer/buildmode

            var content = new BuildDocumentModelContent(modelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
            };

            Operation<DocumentModelDetails> operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, content);
            DocumentModelDetails model = operation.Value;

            Console.WriteLine($"Model ID: {model.ModelId}");
            Console.WriteLine($"Created on: {model.CreatedDateTime}");

            Console.WriteLine("Document types the model can recognize:");
            foreach (KeyValuePair<string, DocumentTypeDetails> docType in model.DocTypes)
            {
                Console.WriteLine($"  Document type: '{docType.Key}', which has the following fields:");
                foreach (KeyValuePair<string, DocumentFieldSchema> schema in docType.Value.FieldSchema)
                {
                    Console.WriteLine($"    Field: '{schema.Key}', with confidence {docType.Value.FieldConfidence[schema.Key]}");
                }
            }
            #endregion

            // Delete the model on completion to clean the environment.
            await client.DeleteModelAsync(modelId);
        }
    }
}
