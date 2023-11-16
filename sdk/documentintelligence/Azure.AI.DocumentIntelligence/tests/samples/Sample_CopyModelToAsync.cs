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
            var sourceClient = new DocumentIntelligenceAdministrationClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceApiKey));
            #endregion

            // For the purpose of this sample, we are going to create a model to copy. Note that
            // if you already have a model, this is not necessary.

            string setupModelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var buildContent = new BuildDocumentModelContent(setupModelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
            };

            await sourceClient.BuildDocumentModelAsync(WaitUntil.Completed, buildContent);

            #region Snippet:DocumentIntelligenceSampleCreateCopyTargetClient
#if SNIPPET
            string targetEndpoint = "<targetEndpoint>";
            string targetApiKey = "<targetApiKey>";
#else
            string targetEndpoint = TestEnvironment.Endpoint;
            string targetApiKey = TestEnvironment.ApiKey;
#endif
            var targetClient = new DocumentIntelligenceAdministrationClient(new Uri(targetEndpoint), new AzureKeyCredential(targetApiKey));
            #endregion

            #region Snippet:DocumentIntelligenceSampleGetCopyAuthorization
#if SNIPPET
            string targetModelId = "<targetModelId>";
#else
            string targetModelId = Guid.NewGuid().ToString();
#endif
            var authorizeCopyContent = new AuthorizeCopyContent(targetModelId);
            CopyAuthorization copyAuthorization = await targetClient.AuthorizeModelCopyAsync(authorizeCopyContent);
            #endregion

            #region Snippet:DocumentIntelligenceSampleCreateCopyModel
#if SNIPPET
            string sourceModelId = "<sourceModelId>";
#else
            string sourceModelId = setupModelId;
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
