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
        [Test]
        public void CancelJob()
        {
            DocumentsServiceClient client = Client;

            #region Snippet:DocumentsService_CancelJob
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

            Operation submitOperation = client.AnalyzeDocumentsSubmitOperation(
                WaitUntil.Started,
                request);

            string operationLocation = submitOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string headerValue)
                ? headerValue
                : throw new InvalidOperationException("Operation-Location header was not found.");

            Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

            Operation cancelOperation = client.AnalyzeDocumentsCancelOperation(
                WaitUntil.Started,
                jobId);
            #endregion

            Assert.IsNotNull(cancelOperation);
            Assert.IsNotNull(cancelOperation.GetRawResponse());
        }

        [AsyncOnly]
        [Test]
        public async Task CancelJobAsync()
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

            Operation submitOperation = await client.AnalyzeDocumentsSubmitOperationAsync(
                WaitUntil.Started,
                request);

            string operationLocation = submitOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string headerValue)
                ? headerValue
                : throw new InvalidOperationException("Operation-Location header was not found.");

            Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

            #region Snippet:DocumentsService_CancelJobAsync
            Operation cancelOperation = await client.AnalyzeDocumentsCancelOperationAsync(
                WaitUntil.Started,
                jobId);
            #endregion

            Assert.IsNotNull(cancelOperation);
            Assert.IsNotNull(cancelOperation.GetRawResponse());
        }
    }
}
