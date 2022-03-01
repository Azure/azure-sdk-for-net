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
        public async Task AnalyzeWithCustomModelFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            // Firstly, create a custom built model we can use to recognize the custom document. Please note
            // that models can also be built using a graphical user interface such as the Form Recognizer
            // Labeling Tool found here:
            // https://aka.ms/azsdk/formrecognizer/labelingtool

            var adminClient = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            BuildModelOperation buildOperation = await adminClient.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);

            await buildOperation.WaitForCompletionAsync();

            DocumentModel customModel = buildOperation.Value;

            // Proceed with the custom document recognition.

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerAnalyzeWithCustomModelFromUriAsync
#if SNIPPET
            string modelId = "<modelId>";
            string fileUri = "<fileUri>";
#else
            Uri fileUri = DocumentAnalysisTestEnvironment.CreateUri("Form_1.jpg");
            string modelId = customModel.ModelId;
#endif

            AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync(modelId, fileUri);

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;

            Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

            foreach (AnalyzedDocument document in result.Documents)
            {
                Console.WriteLine($"Document of type: {document.DocType}");

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
            await adminClient.DeleteModelAsync(customModel.ModelId);
        }
    }
}
