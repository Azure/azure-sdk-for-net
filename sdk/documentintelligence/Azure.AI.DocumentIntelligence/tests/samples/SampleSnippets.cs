// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentIntelligenceClientTokenCredential()
        {
            #region Snippet:CreateDocumentIntelligenceClientTokenCredential
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = TestEnvironment.Endpoint;
#endif
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentIntelligenceAdministrationClient()
        {
            #region Snippet:CreateDocumentIntelligenceAdministrationClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [RecordedTest]
        public void CreateBothDocumentIntelligenceClients()
        {
            #region Snippet:Migration_CreateBothDocumentIntelligenceClients
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);

            var documentIntelligenceClient = new DocumentIntelligenceClient(new Uri(endpoint), credential);
            var documentIntelligenceAdministrationClient = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public async Task BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceBadRequest
            var content = new AnalyzeDocumentContent()
            {
                UrlSource = new Uri("http://invalid.uri")
            };

            try
            {
                Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", content);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}
