// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class OperationWithIdLiveTests : DocumentIntelligenceLiveTestBase
    {
        // Example: 3eb2e5b5-b9d3-4b5a-ac31-90d945f4b4e4
        private const string AnalysisOperationIdPattern = @"^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$";

        // Example: 31466498286_3eb2e5b5-b9d3-4b5a-ac31-90d945f4b4e4
        private const string TrainingOperationIdPattern = @"^[0-9]+_[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$";

        public OperationWithIdLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task AnalyzeDocumentOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceClient();

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt);
            var options = new AnalyzeDocumentOptions("prebuilt-receipt", uriSource);

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(waitUntil, options);
            string operationId = operation.Id;

            var match = Regex.Match(operationId, AnalysisOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task AnalyzeBatchDocumentsOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceClient();

            var sourceContainerUri = new Uri(TestEnvironment.BatchSourceBlobSasUrl);
            var resultContainerUri = new Uri(TestEnvironment.BatchResultBlobSasUrl);
            var blobSource = new BlobContentSource(sourceContainerUri);
            var options = new AnalyzeBatchDocumentsOptions("prebuilt-read", blobSource, resultContainerUri)
            {
                OverwriteExisting = true
            };

            var operation = await client.AnalyzeBatchDocumentsAsync(waitUntil, options);
            string operationId = operation.Id;

            var match = Regex.Match(operationId, AnalysisOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task ClassifyDocumentOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceClient();

            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync();

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Irs1040);
            var options = new ClassifyDocumentOptions(disposableClassifier.ClassifierId, uriSource);

            var operation = await client.ClassifyDocumentAsync(waitUntil, options);
            string operationId = operation.Id;

            var match = Regex.Match(operationId, AnalysisOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task BuildDocumentModelOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var modelId = Recording.GenerateId();

            var containerUrl = new Uri(TestEnvironment.BlobContainerSasUrl);
            var source = new BlobContentSource(containerUrl);
            var options = new BuildDocumentModelOptions(modelId, DocumentBuildMode.Template, source);

            Operation<DocumentModelDetails> operation = null;
            string operationId = null;

            try
            {
                operation = await client.BuildDocumentModelAsync(waitUntil, options);
                operationId = operation.Id;

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operationId, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task CopyModelToOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var modelId = Recording.GenerateId();

            await using var disposableModel = await BuildDisposableDocumentModelAsync(TestEnvironment.BlobContainerSasUrl);

            var authorizeCopyOptions = new AuthorizeModelCopyOptions(modelId);

            ModelCopyAuthorization copyAuthorization = await client.AuthorizeModelCopyAsync(authorizeCopyOptions);

            Operation<DocumentModelDetails> operation = null;
            string operationId = null;

            try
            {
                operation = await client.CopyModelToAsync(waitUntil, disposableModel.ModelId, copyAuthorization);
                operationId = operation.Id;

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operationId, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task ComposeModelOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var modelId = Recording.GenerateId();

            // Note: this will fail once we implement model caching. We'll need to set different containers to make it work.
            await using var disposableModel0 = await BuildDisposableDocumentModelAsync(TestEnvironment.BlobContainerSasUrl);
            await using var disposableModel1 = await BuildDisposableDocumentModelAsync(TestEnvironment.BlobContainerSasUrl);
            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync();

            var docTypes = new Dictionary<string, DocumentTypeDetails>()
            {
                { "model0", new DocumentTypeDetails() { ModelId = disposableModel0.ModelId } },
                { "model1", new DocumentTypeDetails() { ModelId = disposableModel1.ModelId } }
            };

            var options = new ComposeModelOptions(modelId, disposableClassifier.ClassifierId, docTypes);

            Operation<DocumentModelDetails> operation = null;
            string operationId = null;

            try
            {
                operation = await client.ComposeModelAsync(waitUntil, options);
                operationId = operation.Id;

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operationId, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task BuildClassifierOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var classifierId = Recording.GenerateId();

            var containerUrl = new Uri(TestEnvironment.ClassifierTrainingSasUrl);
            var sourceA = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(containerUrl) { Prefix = "IRS-1040-B/train" };
            var docTypeA = new ClassifierDocumentTypeDetails(sourceA);
            var docTypeB = new ClassifierDocumentTypeDetails(sourceB);
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB }
            };

            var options = new BuildClassifierOptions(classifierId, docTypes);

            Operation<DocumentClassifierDetails> operation = null;
            string operationId = null;

            try
            {
                operation = await client.BuildClassifierAsync(waitUntil, options);
                operationId = operation.Id;

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteClassifierAsync(classifierId);
                }
            }

            var match = Regex.Match(operationId, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }

        [RecordedTest]
        [TestCase(WaitUntil.Started)]
        [TestCase(WaitUntil.Completed)]
        public async Task CopyClassifierToOperationCanParseOperationId(WaitUntil waitUntil)
        {
            var client = CreateDocumentIntelligenceAdministrationClient();
            var classifierId = Recording.GenerateId();

            await using var disposableClassifier = await BuildDisposableDocumentClassifierAsync();

            var authorizeCopyOptions = new AuthorizeClassifierCopyOptions(classifierId);

            ClassifierCopyAuthorization copyAuthorization = await client.AuthorizeClassifierCopyAsync(authorizeCopyOptions);

            Operation<DocumentClassifierDetails> operation = null;
            string operationId = null;

            try
            {
                operation = await client.CopyClassifierToAsync(waitUntil, disposableClassifier.ClassifierId, copyAuthorization);
                operationId = operation.Id;

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteClassifierAsync(classifierId);
                }
            }

            var match = Regex.Match(operationId, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }
    }
}
