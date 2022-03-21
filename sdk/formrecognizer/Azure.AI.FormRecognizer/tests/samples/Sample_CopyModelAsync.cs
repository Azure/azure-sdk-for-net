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
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = await sourceClient.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel model = operationResponse.Value;

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
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync();
            #endregion

            #region Snippet:FormRecognizerSampleCreateCopyModel
#if SNIPPET
            string modelId = "<source_modelId>";
#else
            string modelId = model.ModelId;
#endif
            CopyModelOperation newModelOperation = await sourceClient.StartCopyModelToAsync(modelId, targetAuth);
            await newModelOperation.WaitForCompletionAsync();
            DocumentModel newModel = newModelOperation.Value;

            Console.WriteLine($"Original model ID => {modelId}");
            Console.WriteLine($"Copied model ID => {newModel.ModelId}");
            #endregion
        }
    }
}
