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
        public async Task AnalyzeWithCustomModelFromFileAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            // Firstly, create a custom built model we can use to recognize the custom document. Please note
            // that models can also be built using a graphical user interface such as the Document Intelligence
            // Studio found here:
            // https://aka.ms/azsdk/formrecognizer/formrecognizerstudio

            var adminClient = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            BuildDocumentModelOperation buildOperation = await adminClient.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
            DocumentModelDetails customModel = buildOperation.Value;

            // Proceed with the custom document recognition.

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerAnalyzeWithCustomModelFromFileAsync
#if SNIPPET
            string modelId = "<modelId>";
            string filePath = "<filePath>";
#else
            string filePath = DocumentAnalysisTestEnvironment.CreatePath("Form_1.jpg");
            string modelId = customModel.ModelId;
#endif

            using var stream = new FileStream(filePath, FileMode.Open);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelId, stream);
            AnalyzeResult result = operation.Value;

            Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

            foreach (AnalyzedDocument document in result.Documents)
            {
                Console.WriteLine($"Document of type: {document.DocumentType}");

                foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
                {
                    string fieldName = fieldKvp.Key;
                    DocumentField field = fieldKvp.Value;

                    Console.WriteLine($"Field '{fieldName}': ");

                    Console.WriteLine($"  Content: '{field.Content}'");
                    Console.WriteLine($"  Confidence: '{field.Confidence}'");
                }
            }
            #endregion

            // Iterate over lines and selection marks on each page
            foreach (DocumentPage page in result.Pages)
            {
                Console.WriteLine($"Lines found on page {page.PageNumber}");
                foreach (var line in page.Lines)
                {
                    Console.WriteLine($"  {line.Content}");
                }

                Console.WriteLine($"Selection marks found on page {page.PageNumber}");
                foreach (var selectionMark in page.SelectionMarks)
                {
                    Console.WriteLine($"  Selection mark is '{selectionMark.State}' with confidence {selectionMark.Confidence}");
                }
            }

            // Iterate over the document tables
            for (int i = 0; i < result.Tables.Count; i++)
            {
                Console.WriteLine($"Table {i + 1}");
                foreach (var cell in result.Tables[i].Cells)
                {
                    Console.WriteLine($"  Cell[{cell.RowIndex}][{cell.ColumnIndex}] has content '{cell.Content}' with kind '{cell.Kind}'");
                }
            }

            // Delete the model on completion to clean environment.
            await adminClient.DeleteDocumentModelAsync(customModel.ModelId);
        }
    }
}
