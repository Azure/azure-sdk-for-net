// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task ExtractWordsFromFieldsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleExtractWordsFromFields
#if SNIPPET
            string filePath = "filePath";
#else
            string filePath = DocumentAnalysisTestEnvironment.CreatePath("Form_1.jpg");
#endif
            using var stream = new FileStream(filePath, FileMode.Open);

            AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentAsync("prebuilt-invoice", stream);

            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;

            for (int i = 0; i < result.Documents.Count; i++)
            {
                AnalyzedDocument document = result.Documents[i];

                Console.WriteLine($"Document {i}:");

                foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
                {
                    string fieldName = fieldKvp.Key;
                    DocumentField field = fieldKvp.Value;

                    Console.WriteLine($"  Field '{fieldName}':");
                    Console.WriteLine($"    Content: {field.Content}");
                    Console.WriteLine($"    Words:");

                    foreach (DocumentWord word in GetWordsInSpans(result.Pages, field.Spans))
                    {
                        Console.WriteLine($"      {word.Content}");
                    }
                }

                Console.WriteLine();
            }
            #endregion
        }

        #region Snippet:FormRecognizerSampleGetWordsInSpans
        private IReadOnlyList<DocumentWord> GetWordsInSpans(IReadOnlyList<DocumentPage> pages, IReadOnlyList<DocumentSpan> spans)
        {
            var selectedWords = new List<DocumentWord>();

            // Very inefficient implementation for now.

            foreach (DocumentPage page in pages)
            {
                foreach (DocumentWord word in page.Words)
                {
                    foreach (DocumentSpan span in spans)
                    {
                        // Check if word.StartPos >= span.StartPos && word.EndPos <= span.StartPos (word contained in span)
                        // Is it possible for a word to be across multiple spans?
                        if (word.Span.Offset >= span.Offset
                            && word.Span.Offset + word.Span.Length <= span.Offset + span.Length)
                        {
                            selectedWords.Add(word);
                            break;
                        }
                    }
                }
            }

            return selectedWords;
        }
        #endregion
    }
}
