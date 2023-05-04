// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
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
    public class FormRecognizerOperationsLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerOperationsLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerOperationsLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task RecognizeContentOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeContentFromUriAsync(uri);

            var sameOperation = InstrumentOperation(new RecognizeContentOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [RecordedTest]
        public async Task RecognizeReceiptsOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeReceiptsFromUriAsync(uri);

            var sameOperation = InstrumentOperation(new RecognizeReceiptsOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task RecognizeInvoicesOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeInvoicesFromUriAsync(uri);

            var sameOperation = InstrumentOperation(new RecognizeInvoicesOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task RecognizeIdentityDocumentsOperationCanPollFromNewObject()
        {
            var client = CreateFormRecognizerClient(out var nonInstrumentedClient);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Blank);
            var operation = await client.StartRecognizeIdentityDocumentsFromUriAsync(uri);

            var sameOperation = InstrumentOperation(new RecognizeIdentityDocumentsOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(0, sameOperation.Value.Count);
        }

        [RecordedTest]
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

            var sameOperation = InstrumentOperation(new RecognizeCustomFormsOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(1, sameOperation.Value.Count);
        }

        [RecordedTest]
        public async Task TrainingOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);

            var sameOperation = InstrumentOperation(new TrainingOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, sameOperation.Value.Status);
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public async Task CreateComposedModelOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var operation = await client.StartCreateComposedModelAsync(new List<string> { trainedModelA.ModelId, trainedModelB.ModelId });

            var sameOperation = InstrumentOperation(new CreateComposedModelOperation(operation.Id, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, sameOperation.Value.Status);
        }

        [RecordedTest]
        public async Task CopyModelOperationCanPollFromNewObject()
        {
            var client = CreateFormTrainingClient(out var nonInstrumentedClient);
            var resourceId = TestEnvironment.ResourceId;
            var region = TestEnvironment.ResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false);
            CopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(resourceId, region);

            var operation = await client.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            var sameOperation = InstrumentOperation(new CopyModelOperation(operation.Id, targetAuth.ModelId, nonInstrumentedClient));
            await sameOperation.WaitForCompletionAsync();

            Assert.IsTrue(sameOperation.HasValue);
            Assert.AreEqual(targetAuth.ModelId, sameOperation.Value.ModelId);
        }
    }
}
