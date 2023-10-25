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
        public async Task BuildDocumentClassifierAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleBuildClassifier
            // For this sample, you can use the training documents found in the `classifierTrainingFiles` folder.
            // Upload the documents to your storage container and then generate a container SAS URL. Note
            // that a container URI without SAS is accepted only when the container is public or has a
            // managed identity configured.
            //
            // For instructions to set up documents for training in an Azure Blob Storage Container, please see:
            // https://aka.ms/azsdk/formrecognizer/buildclassifiermodel

#if SNIPPET
            Uri trainingFilesUri = new Uri("<trainingFilesUri>");
#else
            Uri trainingFilesUri = new Uri(TestEnvironment.ClassifierTrainingSasUrl);
#endif
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var sourceA = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-B/train" };

            var documentTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", new ClassifierDocumentTypeDetails(sourceA) },
                { "IRS-1040-B", new ClassifierDocumentTypeDetails(sourceB) }
            };

            BuildDocumentClassifierOperation operation = await client.BuildDocumentClassifierAsync(WaitUntil.Completed, documentTypes);
            DocumentClassifierDetails classifier = operation.Value;

            Console.WriteLine($"  Classifier Id: {classifier.ClassifierId}");
            Console.WriteLine($"  Created on: {classifier.CreatedOn}");

            Console.WriteLine("  Document types the classifier can recognize:");
            foreach (KeyValuePair<string, ClassifierDocumentTypeDetails> documentType in classifier.DocumentTypes)
            {
                Console.WriteLine($"    {documentType.Key}");
            }
            #endregion

            // Delete the classifier on completion to clean environment.
            await client.DeleteDocumentClassifierAsync(classifier.ClassifierId);
        }
    }
}
