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
    public class TrainingOperationLiveTests : DocumentIntelligenceLiveTestBase
    {
        // Example: 31466498286_3eb2e5b5-b9d3-4b5a-ac31-90d945f4b4e4
        private const string OperationIdPattern = @"^[0-9]+_[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$";

        public TrainingOperationLiveTests(bool isAsync)
            : base(isAsync)
        {
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
            string operationId;

            try
            {
                operation = await client.BuildDocumentModelAsync(waitUntil, content);

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

            var match = Regex.Match(operation.Id, OperationIdPattern);

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
            string operationId;

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

            var match = Regex.Match(operation.Id, OperationIdPattern);

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

            var componentModels = new List<ComponentDocumentModelDetails>()
            {
                new ComponentDocumentModelDetails(disposableModel0.ModelId),
                new ComponentDocumentModelDetails(disposableModel1.ModelId)
            };

            var content = new ComposeDocumentModelContent(modelId, componentModels);

            Operation<DocumentModelDetails> operation = null;
            string operationId;

            try
            {
                operation = await client.ComposeModelAsync(waitUntil, content);

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

            var match = Regex.Match(operation.Id, OperationIdPattern);

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
            string operationId;

            try
            {
                operation = await client.BuildClassifierAsync(waitUntil, content);

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

            var match = Regex.Match(operation.Id, OperationIdPattern);

            Assert.That(match.Success);
        }
    }
}
