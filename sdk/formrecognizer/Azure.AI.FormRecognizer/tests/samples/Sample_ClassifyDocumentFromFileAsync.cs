// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task ClassifyDocumentFromFileAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri trainingFilesUri = new Uri(TestEnvironment.ClassifierTrainingSasUrl);

            var sourceA = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-B/train" };

            var documentTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", new ClassifierDocumentTypeDetails(sourceA) },
                { "IRS-1040-B", new ClassifierDocumentTypeDetails(sourceB) }
            };

            // Firstly, create a document classifier we can use to classify the custom document. Please note
            // that classifiers can also be built using a graphical user interface such as the Document Intelligence
            // Studio found here:
            // https://aka.ms/azsdk/formrecognizer/formrecognizerstudio

            var adminClient = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            BuildDocumentClassifierOperation buildOperation = await adminClient.BuildDocumentClassifierAsync(WaitUntil.Completed, documentTypes);
            DocumentClassifierDetails classifier = buildOperation.Value;

            // Proceed with the document classification.

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerClassifyDocumentFromFileAsync
#if SNIPPET
            string classifierId = "<classifierId>";
            string filePath = "<filePath>";
#else
            string filePath = DocumentAnalysisTestEnvironment.CreatePath("IRS-1040_2.pdf");
            string classifierId = classifier.ClassifierId;
#endif

            using var stream = new FileStream(filePath, FileMode.Open);

            ClassifyDocumentOperation operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, stream);
            AnalyzeResult result = operation.Value;

            Console.WriteLine($"Document was classified by classifier with ID: {result.ModelId}");

            foreach (AnalyzedDocument document in result.Documents)
            {
                Console.WriteLine($"Document of type: {document.DocumentType}");
            }
            #endregion

            // Delete the classifier on completion to clean environment.
            await adminClient.DeleteDocumentClassifierAsync(classifier.ClassifierId);
        }
    }
}
