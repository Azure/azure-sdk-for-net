﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.ContosoReceipt)
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(waitUntil, "prebuilt-receipt", content);
            await operation.WaitForCompletionAsync();

            var match = Regex.Match(operation.Id, AnalysisOperationIdPattern);

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
            var source = new AzureBlobContentSource(containerUrl);

            var content = new BuildDocumentModelContent(modelId, DocumentBuildMode.Template)
            {
                AzureBlobSource = source
            };

            Operation<DocumentModelDetails> operation = null;

            try
            {
                operation = await client.BuildDocumentModelAsync(waitUntil, content);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operation.Id, TrainingOperationIdPattern);

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

            var authorizeCopyContent = new AuthorizeCopyContent(modelId);

            CopyAuthorization copyAuthorization = await client.AuthorizeModelCopyAsync(authorizeCopyContent);

            Operation<DocumentModelDetails> operation = null;

            try
            {
                operation = await client.CopyModelToAsync(waitUntil, disposableModel.ModelId, copyAuthorization);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operation.Id, TrainingOperationIdPattern);

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

            var content = new ComposeDocumentModelContent(modelId, disposableClassifier.ClassifierId, docTypes);

            Operation<DocumentModelDetails> operation = null;

            try
            {
                operation = await client.ComposeModelAsync(waitUntil, content);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteModelAsync(modelId);
                }
            }

            var match = Regex.Match(operation.Id, TrainingOperationIdPattern);

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
            var sourceA = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-A/train" };
            var sourceB = new AzureBlobContentSource(containerUrl) { Prefix = "IRS-1040-B/train" };
            var docTypeA = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceA };
            var docTypeB = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceB };
            var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", docTypeA },
                { "IRS-1040-B", docTypeB }
            };

            var content = new BuildDocumentClassifierContent(classifierId, docTypes);

            Operation<DocumentClassifierDetails> operation = null;

            try
            {
                operation = await client.BuildClassifierAsync(waitUntil, content);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteClassifierAsync(classifierId);
                }
            }

            var match = Regex.Match(operation.Id, TrainingOperationIdPattern);

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

            var authorizeCopyContent = new AuthorizeClassifierCopyContent(classifierId);

            ClassifierCopyAuthorization copyAuthorization = await client.AuthorizeClassifierCopyAsync(authorizeCopyContent);

            Operation<DocumentClassifierDetails> operation = null;

            try
            {
                operation = await client.CopyClassifierToAsync(waitUntil, disposableClassifier.ClassifierId, copyAuthorization);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasCompleted)
                {
                    await client.DeleteClassifierAsync(classifierId);
                }
            }

            var match = Regex.Match(operation.Id, TrainingOperationIdPattern);

            Assert.That(match.Success);
        }
    }
}
