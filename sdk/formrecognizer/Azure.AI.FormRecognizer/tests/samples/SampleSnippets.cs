// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public void CreateDocumentAnalysisClient()
        {
            #region Snippet:CreateDocumentAnalysisClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);
            var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentAnalysisClientTokenCredential()
        {
            #region Snippet:CreateDocumentAnalysisClientTokenCredential
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = TestEnvironment.Endpoint;
#endif
            var client = new DocumentAnalysisClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentModelAdministrationClient()
        {
            #region Snippet:CreateDocumentModelAdministrationClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public async Task BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credential = new AzureKeyCredential(apiKey);
            var client = new DocumentAnalysisClient(new Uri(endpoint), credential);

            #region Snippet:DocumentAnalysisBadRequest
            try
            {
                AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-receipt", new Uri("http://invalid.uri"));
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [RecordedTest]
        public void CreateDocumentAnalysisClients()
        {
            #region Snippet:CreateDocumentAnalysisClients
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var credential = new AzureKeyCredential(apiKey);

            var documentAnalysisClient = new DocumentAnalysisClient(new Uri(endpoint), credential);
            var documentModelAdministrationClient = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
            #endregion
        }

        [RecordedTest]
        public async Task StartLongRunningOperation()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var credential = new AzureKeyCredential(apiKey);
            var client = new DocumentModelAdministrationClient(new Uri(endpoint), credential);

            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            BuildDocumentModelOperation buildOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
            Response<DocumentModelDetails> operationResponse = await buildOperation.WaitForCompletionAsync();
            DocumentModelDetails model = operationResponse.Value;

            string modelId = model.ModelId;
            DocumentModelCopyAuthorization authorization = await client.GetCopyAuthorizationAsync();

            #region Snippet:WaitForLongRunningOperationV3
            CopyDocumentModelToOperation operation = await client.CopyDocumentModelToAsync(WaitUntil.Completed, modelId, authorization);
            #endregion
        }
    }
}
