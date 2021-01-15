// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class OperationsLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task RecognizeContentOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeContentFromUriAsync(uri);

            var sameOperation = new RecognizeContentOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task RecognizeReceiptsOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeReceiptsFromUriAsync(uri);

            var sameOperation = new RecognizeReceiptsOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task RecognizeInvoicesOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeInvoicesFromUriAsync(uri);

            var sameOperation = new RecognizeInvoicesOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task RecognizeCustomFormsOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            var sameOperation = new RecognizeCustomFormsOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task TrainingOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);

            var sameOperation = new TrainingOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, sameOperation.Value.Status);
        }

        [Test]
        public async Task CreateComposedModelOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var operation = await client.StartCreateComposedModelAsync(new List<string> { trainedModelA.ModelId, trainedModelB.ModelId });

            var sameOperation = new CreateComposedModelOperation(operation.Id, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, sameOperation.Value.Status);
        }

        [Test]
        public async Task CopyModelOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);
            CopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(resourceId, region);

            var operation = await client.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            var sameOperation = new CopyModelOperation(operation.Id, targetAuth.ModelId, nonInstrumentedClient);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(targetAuth.ModelId, sameOperation.Value.ModelId);
        }
    }
}
