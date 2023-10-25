// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task BuildCustomModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleBuildModel
            // For this sample, you can use the training documents found in the `trainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL. Note
            // that a container URI without SAS is accepted only when the container is public or has a
            // managed identity configured.
            //
            // For instructions to set up documents for training in an Azure Blob Storage Container, please see:
            // https://aka.ms/azsdk/formrecognizer/buildcustommodel

#if SNIPPET
            Uri blobContainerUri = new Uri("<blobContainerUri>");
#else
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // We are selecting the Template build mode in this sample. For more information about the available
            // build modes and their differences, please see:
            // https://aka.ms/azsdk/formrecognizer/buildmode

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
            DocumentModelDetails model = operation.Value;

            Console.WriteLine($"  Model Id: {model.ModelId}");
            Console.WriteLine($"  Created on: {model.CreatedOn}");

            Console.WriteLine("  Document types the model can recognize:");
            foreach (KeyValuePair<string, DocumentTypeDetails> documentType in model.DocumentTypes)
            {
                Console.WriteLine($"    Document type: {documentType.Key} which has the following fields:");
                foreach (KeyValuePair<string, DocumentFieldSchema> schema in documentType.Value.FieldSchema)
                {
                    Console.WriteLine($"    Field: {schema.Key} with confidence {documentType.Value.FieldConfidence[schema.Key]}");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            await client.DeleteDocumentModelAsync(model.ModelId);
        }
    }
}
