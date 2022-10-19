// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

using TestFile = Azure.AI.FormRecognizer.Tests.TestFile;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [IgnoreServiceError(400, "InvalidRequest", Message = "Content is not accessible: Invalid data URL", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28923")]
    public class OperationsLiveTests : DocumentAnalysisLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task AnalyzeDocumentOperationCanPollFromNewObject()
        {
            var client = CreateDocumentAnalysisClient(out var nonInstrumentedClient);

            var uri = DocumentAnalysisTestEnvironment.CreateUri(TestFile.ReceiptJpg);
            var operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, "prebuilt-receipt", uri);
            Assert.IsNotNull(operation.GetRawResponse());

            var sameOperation = InstrumentOperation(new AnalyzeDocumentOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Pages.Count);
        }

        [RecordedTest]
        public async Task BuildModelOperationCanPollFromNewObject()
        {
            var client = CreateDocumentModelAdministrationClient(out var nonInstrumentedClient);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId);
            Assert.IsNotNull(operation.GetRawResponse());

            var sameOperation = InstrumentOperation(new BuildDocumentModelOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(modelId, sameOperation.Value.ModelId);
        }

        [RecordedTest]
        public async Task BuildModelOperationPercentageCompletedValue()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId);
            Assert.Throws<InvalidOperationException>(() => _ = operation.PercentCompleted);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(100, operation.PercentCompleted);
        }

        [RecordedTest]
        public async Task CopyModelToOperationCanPollFromNewObject()
        {
            var client = CreateDocumentModelAdministrationClient(out var nonInstrumentedClient);
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var targetModelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(targetModelId);

            var operation = await client.CopyDocumentModelToAsync(WaitUntil.Started, trainedModel.ModelId, targetAuth);
            Assert.IsNotNull(operation.GetRawResponse());

            var sameOperation = InstrumentOperation(new CopyDocumentModelToOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(targetModelId, sameOperation.Value.ModelId);
        }

        [RecordedTest]
        public async Task CopyModelToOperationPercentageCompletedValue()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var targetModelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(targetModelId);

            var operation = await client.CopyDocumentModelToAsync(WaitUntil.Started, trainedModel.ModelId, targetAuth);
            Assert.Throws<InvalidOperationException>(() => _ = operation.PercentCompleted);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(100, operation.PercentCompleted);
        }
    }
}
