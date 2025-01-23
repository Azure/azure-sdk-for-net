// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task ClassifyDocumentFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), TestEnvironment.Credential);
            var adminClient = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), TestEnvironment.Credential);

            string setupClassifierId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.ClassifierTrainingSasUrl);

            var sourceA = new BlobContentSource(blobContainerUri) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(blobContainerUri) { Prefix = "IRS-1040-B/train" };
            var docTypeA = new ClassifierDocumentTypeDetails(sourceA);
            var docTypeB = new ClassifierDocumentTypeDetails(sourceB);
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB }
            };

            var buildOptions = new BuildClassifierOptions(setupClassifierId, docTypes);

            // Firstly, create a document classifier we can use to classify the custom document. Note that
            // classifiers can also be built using a graphical user interface such as the Document Intelligence
            // Studio found here:
            // https://aka.ms/azsdk/formrecognizer/formrecognizerstudio

            await adminClient.BuildClassifierAsync(WaitUntil.Completed, buildOptions);

            // Proceed with the document classification.

            #region Snippet:DocumentIntelligenceClassifyDocumentFromUriAsync
#if SNIPPET
            string classifierId = "<classifierId>";
            Uri uriSource = new Uri("<uriSource>");
#else
            string classifierId = setupClassifierId;
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("IRS-1040_2.pdf");
#endif

            var options = new ClassifyDocumentOptions(classifierId, uriSource);

            Operation<AnalyzeResult> operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, options);
            AnalyzeResult result = operation.Value;

            Console.WriteLine($"Input was classified by the classifier with ID '{result.ModelId}'.");

            foreach (AnalyzedDocument document in result.Documents)
            {
                Console.WriteLine($"Found a document of type: {document.DocumentType}");
            }
            #endregion

            // Delete the classifier on completion to clean environment.
            await adminClient.DeleteClassifierAsync(classifierId);
        }
    }
}
