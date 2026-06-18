// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Documents;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Documents.Tests.Samples
{
    public class Sample1_SubmitJob : SamplesBase<DocumentServiceTestEnvironment>
    {
        [SyncOnly]
        [Test]
        public void SubmitJob()
        {
            Uri endpoint = new Uri("{endpoint}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential);

            #region Snippet:DocumentsService_SubmitJob
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
            #endregion

            Assert.IsNotNull(operation);
            Assert.IsNotNull(operation.GetRawResponse());
        }

        [AsyncOnly]
        [Test]
        public async Task SubmitJobAsync()
        {
            DocumentsServiceClient client = new DocumentsServiceClient(TestEnvironment.Endpoint, new DefaultAzureCredential());

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

            #region Snippet:DocumentsService_SubmitJobAsync
            Operation operation = await client.AnalyzeDocumentsSubmitOperationAsync(
                WaitUntil.Started,
                request);
            #endregion

            Assert.IsNotNull(operation);
            Assert.IsNotNull(operation.GetRawResponse());
        }
    }
}
