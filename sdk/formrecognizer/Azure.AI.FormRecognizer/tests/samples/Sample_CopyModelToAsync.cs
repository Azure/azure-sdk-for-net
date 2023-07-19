// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task CopyModelToAsync()
        {
            #region Snippet:FormRecognizerSampleCreateCopySourceClient
#if SNIPPET
            string sourceEndpoint = "<source_endpoint>";
            string sourceApiKey = "<source_apiKey>";
#else
            string sourceEndpoint = TestEnvironment.Endpoint;
            string sourceApiKey = TestEnvironment.ApiKey;
#endif
            var sourcecredential = new AzureKeyCredential(sourceApiKey);
            var sourceClient = new DocumentModelAdministrationClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));
            #endregion

            // For the purpose of this sample, we are going to create a model to copy. Please note that
            // if you already have a model, this is not necessary.
#if SNIPPET
            Uri blobContainerUri = new Uri("<blobContainerUri>");
#else
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildDocumentModelOperation operation = await sourceClient.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
            DocumentModelDetails model = operation.Value;

            #region Snippet:FormRecognizerSampleCreateCopyTargetClient
#if SNIPPET
            string targetEndpoint = "<target_endpoint>";
            string targetApiKey = "<target_apiKey>";
#else
            string targetEndpoint = TestEnvironment.Endpoint;
            string targetApiKey = TestEnvironment.ApiKey;
#endif
            var targetCredential = new AzureKeyCredential(targetApiKey);
            var targetClient = new DocumentModelAdministrationClient(new Uri(targetEndpoint), new AzureKeyCredential(targetApiKey));
            #endregion

            #region Snippet:FormRecognizerSampleGetCopyAuthorization
            DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync();
            #endregion

            #region Snippet:FormRecognizerSampleCreateCopyModel
#if SNIPPET
            string modelId = "<source_modelId>";
#else
            string modelId = model.ModelId;
#endif
            CopyDocumentModelToOperation newModelOperation = await sourceClient.CopyDocumentModelToAsync(WaitUntil.Completed, modelId, targetAuth);
            DocumentModelDetails newModel = newModelOperation.Value;

            Console.WriteLine($"Original model ID => {modelId}");
            Console.WriteLine($"Copied model ID => {newModel.ModelId}");
            #endregion
        }
    }
}
