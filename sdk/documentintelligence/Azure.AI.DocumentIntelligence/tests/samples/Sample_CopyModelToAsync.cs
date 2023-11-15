// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task CopyModelToAsync()
        {
            #region Snippet:DocumentIntelligenceSampleCreateCopySourceClient
#if SNIPPET
            string sourceEndpoint = "<sourceEndpoint>";
            string sourceApiKey = "<sourceApiKey>";
#else
            string sourceEndpoint = TestEnvironment.Endpoint;
            string sourceApiKey = TestEnvironment.ApiKey;
#endif
            var sourceClient = new DocumentModelAdministrationClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));
            #endregion

            // For the purpose of this sample, we are going to create a model to copy. Note that
            // if you already have a model, this is not necessary.

            string sourceModelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var buildRequest = new BuildDocumentModelRequest(sourceModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
            };

            await sourceClient.BuildDocumentModelAsync(WaitUntil.Completed, buildRequest);

            #region Snippet:DocumentIntelligenceSampleCreateCopyTargetClient
#if SNIPPET
            string targetEndpoint = "<targetEndpoint>";
            string targetApiKey = "<targetApiKey>";
#else
            string targetEndpoint = TestEnvironment.Endpoint;
            string targetApiKey = TestEnvironment.ApiKey;
#endif
            var targetClient = new DocumentModelAdministrationClient(new Uri(targetEndpoint), new AzureKeyCredential(targetApiKey));
            #endregion

            #region Snippet:DocumentIntelligenceSampleGetCopyAuthorization
#if SNIPPET
            string targetModelId = "<targetModelId>";
#else
            string targetModelId = Guid.NewGuid().ToString();
#endif
            var authorizeCopyRequest = new AuthorizeCopyRequest(targetModelId);
            CopyAuthorization copyAuthorization = await targetClient.AuthorizeModelCopyAsync(authorizeCopyRequest);
            #endregion

            #region Snippet:DocumentIntelligenceSampleCreateCopyModel
#if SNIPPET
            string sourceModelId = "<sourceModelId>";
#endif
            Operation<DocumentModelDetails> copyOperation = await sourceClient.CopyModelToAsync(WaitUntil.Completed, sourceModelId, copyAuthorization);
            DocumentModelDetails copiedModel = copyOperation.Value;

            Console.WriteLine($"Original model ID: {sourceModelId}");
            Console.WriteLine($"Copied model ID: {copiedModel.ModelId}");
            #endregion

            // Delete the models on completion to clean environment.
            await sourceClient.DeleteModelAsync(sourceModelId);
            await targetClient.DeleteModelAsync(targetModelId);
        }
    }
}
