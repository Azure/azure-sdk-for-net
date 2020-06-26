// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public OperationsLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task RecognizeContentOperationCanPollFromNewObject()
        {
            // Skip instrumenting here because the internal service client passed to the operation object would be made null otherwise,
            // making the test fail.

            var client = CreateFormRecognizerClient(skipInstrumenting: true);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeContentFromUriAsync(uri);

            var sameOperation = new RecognizeContentOperation(operation.Id, client);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task RecognizeReceiptsOperationCanPollFromNewObject()
        {
            // Skip instrumenting here because the internal service client passed to the operation object would be made null otherwise,
            // making the test fail.

            var client = CreateFormRecognizerClient(skipInstrumenting: true);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeReceiptsFromUriAsync(uri);

            var sameOperation = new RecognizeReceiptsOperation(operation.Id, client);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task RecognizeCustomFormsOperationCanPollFromNewObject()
        {
            // Skip instrumenting here because the internal service client passed to the operation object would be made null otherwise,
            // making the test fail.

            var client = CreateFormRecognizerClient(skipInstrumenting: true);
            RecognizeCustomFormsOperation operation;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.Blank);
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartRecognizeCustomFormsAsync(trainedModel.ModelId, stream);
            }

            var sameOperation = new RecognizeCustomFormsOperation(operation.Id, client);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [Test]
        public async Task TrainingOperationCanPollFromNewObject()
        {
            // Skip instrumenting here because the internal service client passed to the operation object would be made null otherwise,
            // making the test fail.

            var client = CreateFormTrainingClient(skipInstrumenting: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);

            var sameOperation = new TrainingOperation(operation.Id, client);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, sameOperation.Value.Status);
        }

        [Test]
        public async Task CopyModelOperationCanPollFromNewObject()
        {
            // Skip instrumenting here because the internal service client passed to the operation object would be made null otherwise,
            // making the test fail.

            var client = CreateFormTrainingClient(skipInstrumenting: true);
            var resourceID = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);
            CopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(resourceID, region);

            var operation = await client.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            var sameOperation = new CopyModelOperation(operation.Id, targetAuth.ModelId, client);
            await sameOperation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(targetAuth.ModelId, sameOperation.Value.ModelId);
        }
    }
}
