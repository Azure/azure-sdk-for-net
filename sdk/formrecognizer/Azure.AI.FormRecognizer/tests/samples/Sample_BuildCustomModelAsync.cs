// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
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
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // We are selecting the Template build mode in this sample. For more information about the available
            // build modes and their differences, please see:
            // https://aka.ms/azsdk/formrecognizer/buildmode

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel model = operationResponse.Value;

            Console.WriteLine($"  Model Id: {model.ModelId}");
            if (string.IsNullOrEmpty(model.Description))
                Console.WriteLine($"  Model description: {model.Description}");
            Console.WriteLine($"  Created on: {model.CreatedOn}");
            Console.WriteLine("  Doc types the model can recognize:");
            foreach (KeyValuePair<string, DocTypeInfo> docType in model.DocTypes)
            {
                Console.WriteLine($"    Doc type: {docType.Key} which has the following fields:");
                foreach (KeyValuePair<string, DocumentFieldSchema> schema in docType.Value.FieldSchema)
                {
                    Console.WriteLine($"    Field: {schema.Key} with confidence {docType.Value.FieldConfidence[schema.Key]}");
                }
            }
            #endregion

            // Delete the model on completion to clean environment.
            await client.DeleteModelAsync(model.ModelId);
        }
    }
}
