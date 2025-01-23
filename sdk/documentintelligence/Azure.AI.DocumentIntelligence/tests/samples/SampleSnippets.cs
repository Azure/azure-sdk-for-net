// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public void CreateDocumentIntelligenceClient()
        {
            #region Snippet:CreateDocumentIntelligenceClient
#if SNIPPET
            string endpoint = "<endpoint>";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new DocumentIntelligenceClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentIntelligenceClientApiKey()
        {
            #region Snippet:CreateDocumentIntelligenceClientApiKey
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentIntelligenceAdministrationClient()
        {
            #region Snippet:CreateDocumentIntelligenceAdministrationClient
#if SNIPPET
            string endpoint = "<endpoint>";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public void CreateBothDocumentIntelligenceClients()
        {
            #region Snippet:Migration_CreateBothDocumentIntelligenceClients
#if SNIPPET
            string endpoint = "<endpoint>";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif

            var documentIntelligenceClient = new DocumentIntelligenceClient(new Uri(endpoint), credential);
            var documentIntelligenceAdministrationClient = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public async Task BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), TestEnvironment.Credential);

            #region Snippet:DocumentIntelligenceBadRequest
            var uriSource = new Uri("http://invalid.uri");
            var options = new AnalyzeDocumentOptions("prebuilt-receipt", uriSource);

            try
            {
                Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [RecordedTest]
        public async Task GetWordsSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), TestEnvironment.Credential);

            #region Snippet:Migration_DocumentIntelligenceGetWordsUsage
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var options = new AnalyzeDocumentOptions("prebuilt-invoice", uriSource);

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
            AnalyzeResult result = operation.Value;

            DocumentPage firstPage = result.Pages[0];

            foreach (DocumentLine line in firstPage.Lines)
            {
                IReadOnlyList<DocumentWord> words = GetWords(line, firstPage);

                Console.WriteLine(line.Content);
                Console.WriteLine("The line above contains the following words:");

                foreach (DocumentWord word in words)
                {
                    Console.WriteLine($"  {word.Content}");
                }
            }
            #endregion
        }

        #region Snippet:Migration_DocumentIntelligenceGetWords
        private IReadOnlyList<DocumentWord> GetWords(DocumentLine line, DocumentPage containingPage)
        {
            var words = new List<DocumentWord>();

            foreach (DocumentWord word in containingPage.Words)
            {
                DocumentSpan wordSpan = word.Span;

                foreach (DocumentSpan lineSpan in line.Spans)
                {
                    if (wordSpan.Offset >= lineSpan.Offset
                        && wordSpan.Offset + wordSpan.Length <= lineSpan.Offset + lineSpan.Length)
                    {
                        words.Add(word);
                    }
                }
            }

            return words;
        }
        #endregion
    }
}
