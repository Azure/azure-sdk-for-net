// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Documents;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Documents.Tests.Samples
{
    public partial class DocumentsServiceClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void GetJobState()
        {
            DocumentsServiceClient client = Client;

            #region Snippet:DocumentsService_GetJobState
            string sourceLocation = "https://<storage-account>.blob.core.windows.net/input/document.txt?<sas-token>";
            string targetLocation = "https://<storage-account>.blob.core.windows.net/output/pii?<sas-token>";
#if !SNIPPET
            sourceLocation = TestEnvironment.SourceLocation;
            targetLocation = TestEnvironment.TargetLocation;
#endif

            MultiLanguageDocumentCollection documents = new MultiLanguageDocumentCollection();
            documents.Documents.Add(
                new MultiLanguageInput(
                    "1",
                    new AzureBlobDocumentLocation(sourceLocation),
                    new AzureContainerFolderDocumentLocation(targetLocation))
                {
                    Language = "en",
                });

            PiiEntityRecognitionAction piiAction = new PiiEntityRecognitionAction
            {
                Parameters = DocumentsServiceModelFactory.PiiActionContent(
                    redactionPolicies: new[]
                    {
                        new EntityMaskRedactionPolicy
                        {
                            PolicyName = "defaultPolicy",
                            IsDefault = true,
                        },
                    }),
            };

            AnalyzeDocumentsOperationInput request = new AnalyzeDocumentsOperationInput(
                documents,
                new AnalyzeDocumentsOperationAction[] { piiAction })
            {
                DisplayName = "Document Analysis.",
            };

            Operation operation = client.AnalyzeDocumentsSubmitOperation(
                WaitUntil.Started,
                request);

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string headerValue)
                ? headerValue
                : throw new InvalidOperationException("Operation-Location header was not found.");

            Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

            Response<AnalyzeDocumentsJobState> response = client.GetAnalyzeDocumentsJobState(jobId);
            #endregion

            Assert.IsNotNull(response);
            Assert.AreEqual(jobId, response.Value.JobId);
            Assert.AreNotEqual(default(DocumentActionStatus), response.Value.Status);
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task GetJobStateAsync()
        {
            DocumentsServiceClient client = Client;

            string sourceLocation = TestEnvironment.SourceLocation;
            string targetLocation = TestEnvironment.TargetLocation;

            MultiLanguageDocumentCollection documents = new MultiLanguageDocumentCollection();
            documents.Documents.Add(
                new MultiLanguageInput(
                    "1",
                    new AzureBlobDocumentLocation(sourceLocation),
                    new AzureContainerFolderDocumentLocation(targetLocation))
                {
                    Language = "en",
                });

            PiiEntityRecognitionAction piiAction = new PiiEntityRecognitionAction
            {
                Parameters = DocumentsServiceModelFactory.PiiActionContent(
                    redactionPolicies: new[]
                    {
                        new EntityMaskRedactionPolicy
                        {
                            PolicyName = "defaultPolicy",
                            IsDefault = true,
                        },
                    }),
            };

            AnalyzeDocumentsOperationInput request = new AnalyzeDocumentsOperationInput(
                documents,
                new AnalyzeDocumentsOperationAction[] { piiAction })
            {
                DisplayName = "Document Analysis.",
            };

            Operation operation = await client.AnalyzeDocumentsSubmitOperationAsync(
                WaitUntil.Started,
                request);

            string operationLocation = operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string headerValue)
                ? headerValue
                : throw new InvalidOperationException("Operation-Location header was not found.");

            Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

            #region Snippet:DocumentsService_GetJobStateAsync
            Response<AnalyzeDocumentsJobState> response = await client.GetAnalyzeDocumentsJobStateAsync(jobId);
            #endregion

            Assert.IsNotNull(response);
            Assert.AreEqual(jobId, response.Value.JobId);
            Assert.AreNotEqual(default(DocumentActionStatus), response.Value.Status);
        }
    }
}
