// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task CopyModelAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleCreateCopySourceClient
#if SNIPPET
            string endpoint = "<source_endpoint>";
            string apiKey = "<source_apiKey>";
#endif
            var sourcecredential = new AzureKeyCredential(apiKey);
            var sourceClient = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            // For the purpose of this sample, we are going to create a model to copy. Please note that
            // if you already have a model, this is not necessary.
#if SNIPPET
            Uri trainingFileUri = <trainingFileUri>;
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = await sourceClient.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel model = operationResponse.Value;

            #region Snippet:FormRecognizerSampleCreateCopyTargetClient
#if SNIPPET
            string endpoint = "<target_endpoint>";
            string apiKey = "<target_apiKey>";
#endif
            var targetCredential = new AzureKeyCredential(apiKey);
            var targetClient = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:FormRecognizerSampleGetCopyAuthorization
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync();
            #endregion

            #region Snippet:FormRecognizerSampleCreateCopyModel
#if SNIPPET
            string modelId = "<source_modelId>";
#else
            string modelId = model.ModelId;
#endif
            CopyModelOperation newModelOperation = await sourceClient.StartCopyModelAsync(modelId, targetAuth);
            await newModelOperation.WaitForCompletionAsync();
            DocumentModel newModel = newModelOperation.Value;

            Console.WriteLine($"Original model ID => {modelId}");
            Console.WriteLine($"Copied model ID => {newModel.ModelId}");
            #endregion
        }
    }
}
