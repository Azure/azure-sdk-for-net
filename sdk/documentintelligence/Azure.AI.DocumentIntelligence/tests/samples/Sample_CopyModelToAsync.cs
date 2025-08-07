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
        public async Task CopyModelToAsync()
        {
            #region Snippet:DocumentIntelligenceSampleCreateCopySourceClient
#if SNIPPET
            string sourceEndpoint = "<sourceEndpoint>";
            var sourceResourceCredential = new DefaultAzureCredential();
#else
            string sourceEndpoint = TestEnvironment.Endpoint;
            var sourceResourceCredential = TestEnvironment.Credential;
#endif
            var sourceClient = new DocumentIntelligenceAdministrationClient(new Uri(sourceEndpoint), sourceResourceCredential);
            #endregion

            // For the purpose of this sample, we are going to create a model to copy. Note that
            // if you already have a model, this is not necessary.

            string setupModelId = Guid.NewGuid().ToString();
            Uri blobContainerUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var blobSource = new BlobContentSource(blobContainerUri);
            var buildOptions = new BuildDocumentModelOptions(setupModelId, DocumentBuildMode.Template, blobSource);

            await sourceClient.BuildDocumentModelAsync(WaitUntil.Completed, buildOptions);

            #region Snippet:DocumentIntelligenceSampleCreateCopyTargetClient
#if SNIPPET
            string targetEndpoint = "<targetEndpoint>";
            var targetResourceCredential = new DefaultAzureCredential();
#else
            string targetEndpoint = TestEnvironment.Endpoint;
            var targetResourceCredential = TestEnvironment.Credential;
#endif
            var targetClient = new DocumentIntelligenceAdministrationClient(new Uri(targetEndpoint), targetResourceCredential);
            #endregion

            #region Snippet:DocumentIntelligenceSampleGetCopyAuthorization
#if SNIPPET
            string targetModelId = "<targetModelId>";
#else
            string targetModelId = Guid.NewGuid().ToString();
#endif
            var authorizeCopyOptions = new AuthorizeModelCopyOptions(targetModelId);
            ModelCopyAuthorization copyAuthorization = await targetClient.AuthorizeModelCopyAsync(authorizeCopyOptions);
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
