﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormTrainingClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class FormTrainingClientLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormTrainingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormTrainingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task FormTrainingClientCanAuthenticateWithTokenCredential()
        {
            var client = CreateInstrumentedFormTrainingClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation operation;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);
            }

            // Sanity check to make sure we got an actual response back from the service.

            CustomFormModel model = await operation.WaitForCompletionAsync();

            Assert.IsNotNull(model.ModelId);
            Assert.AreEqual(CustomFormModelStatus.Ready, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(0, model.Errors.Count);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartTraining(bool labeled)
        {
            var client = CreateInstrumentedFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation operation;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel model = operation.Value;

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.RequestedOn);
            Assert.IsNotNull(model.CompletedOn);
            Assert.AreEqual(CustomFormModelStatus.Ready, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(0, model.Errors.Count);

            foreach (TrainingDocumentInfo doc in model.TrainingDocuments)
            {
                Assert.IsNotNull(doc.DocumentName);
                Assert.IsNotNull(doc.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, doc.Status);
                Assert.IsNotNull(doc.Errors);
                Assert.AreEqual(0, doc.Errors.Count);
            }

            foreach (var submodel in model.Submodels)
            {
                Assert.IsNotNull(submodel.FormType);
                foreach (var fields in submodel.Fields)
                {
                    Assert.IsNotNull(fields.Value.Name);
                    if (labeled)
                        Assert.IsNotNull(fields.Value.Accuracy);
                    else
                        Assert.IsNotNull(fields.Value.Label);
                }
            }
        }

        [Test]
        public async Task StartTrainingError()
        {
            var client = CreateInstrumentedFormTrainingClient();

            var containerUrl = new Uri("https://someUrl");

            TrainingOperation operation = await client.StartTrainingAsync(containerUrl);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel model = operation.Value;

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.RequestedOn);
            Assert.IsNotNull(model.CompletedOn);
            Assert.IsNotNull(model.Status);
            Assert.AreEqual(CustomFormModelStatus.Invalid, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(1, model.Errors.Count);
            Assert.IsNotNull(model.Errors.FirstOrDefault().ErrorCode);
            Assert.IsNotNull(model.Errors.FirstOrDefault().Message);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task TrainingOps(bool labeled)
        {
            var client = CreateInstrumentedFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            TrainingOperation operation;

            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            }

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            CustomFormModel trainedModel = operation.Value;

            CustomFormModel resultModel = await client.GetCustomModelAsync(trainedModel.ModelId);

            Assert.AreEqual(trainedModel.ModelId, resultModel.ModelId);
            Assert.AreEqual(trainedModel.RequestedOn, resultModel.RequestedOn);
            Assert.AreEqual(trainedModel.CompletedOn, resultModel.CompletedOn);
            Assert.AreEqual(CustomFormModelStatus.Ready, resultModel.Status);
            Assert.AreEqual(trainedModel.Status, resultModel.Status);
            Assert.AreEqual(trainedModel.Errors.Count, resultModel.Errors.Count);

            for (int i = 0; i < resultModel.TrainingDocuments.Count; i++)
            {
                var tm = trainedModel.TrainingDocuments[i];
                var rm = resultModel.TrainingDocuments[i];

                Assert.AreEqual(tm.DocumentName, rm.DocumentName);
                Assert.AreEqual(tm.PageCount, rm.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, rm.Status);
                Assert.AreEqual(tm.Status, rm.Status);
                Assert.AreEqual(tm.Errors.Count, rm.Errors.Count);
            }

            for (int i = 0; i < resultModel.Submodels.Count; i++)
            {
                Assert.AreEqual(trainedModel.Submodels[i].FormType, resultModel.Submodels[i].FormType);

                foreach (var fields in resultModel.Submodels[i].Fields)
                {
                    Assert.AreEqual(trainedModel.Submodels[i].Fields[fields.Key].Name, fields.Value.Name);
                    if (labeled)
                        Assert.AreEqual(trainedModel.Submodels[i].Fields[fields.Key].Accuracy, fields.Value.Accuracy);
                    else
                        Assert.AreEqual(trainedModel.Submodels[i].Fields[fields.Key].Label, fields.Value.Label);
                }
            }

            CustomFormModelInfo modelInfo = client.GetCustomModelsAsync().ToEnumerableAsync().Result.FirstOrDefault();

            Assert.IsNotNull(modelInfo.ModelId);
            Assert.IsNotNull(modelInfo.RequestedOn);
            Assert.IsNotNull(modelInfo.CompletedOn);
            Assert.IsNotNull(modelInfo.Status);

            AccountProperties accountP = await client.GetAccountPropertiesAsync();

            Assert.IsNotNull(accountP.CustomModelCount);
            Assert.IsNotNull(accountP.CustomModelLimit);

            await client.DeleteModelAsync(trainedModel.ModelId);

            Assert.ThrowsAsync<RequestFailedException>(() => client.GetCustomModelAsync(trainedModel.ModelId));
        }

        [Test]
        [Ignore("Tracked by issue: https://github.com/Azure/azure-sdk-for-net/issues/12193")]
        public async Task CopyModel()
        {
            var sourceClient = CreateInstrumentedFormTrainingClient();
            var targetClient = CreateInstrumentedFormTrainingClient();
            var resourceID = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceID, region);

            CopyModelOperation operation;
            // TODO: sanitize body and enable body recording here.
            using (Recording.DisableRequestBodyRecording())
            {
                operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);
            }

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            CustomFormModelInfo modelCopied = operation.Value;

            Assert.IsNotNull(modelCopied.CompletedOn);
            Assert.IsNotNull(modelCopied.RequestedOn);
            Assert.AreEqual(targetAuth.ModelId, modelCopied.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, modelCopied.ModelId);
        }

        [Test]
        [Ignore("Tracked by issue: https://github.com/Azure/azure-sdk-for-net/issues/12193")]
        public async Task CopyModelError()
        {
            var sourceClient = CreateInstrumentedFormTrainingClient();
            var targetClient = CreateInstrumentedFormTrainingClient();
            var resourceID = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceID, region);

            Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.StartCopyModelAsync("00000000-0000-0000-0000-000000000000", targetAuth));
        }

        [Test]
        [Ignore("Tracked by issue: https://github.com/Azure/azure-sdk-for-net/issues/12193")]
        public async Task GetCopyAuthorization()
        {
            var targetClient = CreateInstrumentedFormTrainingClient();
            var resourceID = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceID, region);

            Assert.IsNotNull(targetAuth.ModelId);
            Assert.IsNotNull(targetAuth._accessToken);
            Assert.IsNotNull(targetAuth.ExpiresOn);
            Assert.AreEqual(resourceID, targetAuth._resourceId);
            Assert.AreEqual(region, targetAuth._region);
        }

        [Test]
        [Ignore("Tracked by issue: https://github.com/Azure/azure-sdk-for-net/issues/12193")]
        public async Task SerializeDeserializeCopyAuthorizationAsync()
        {
            var targetClient = CreateInstrumentedFormTrainingClient();
            var resourceID = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceID, region);

            string jsonTargetAuth = targetAuth.ToJson();

            CopyAuthorization targetAuthFromJson = CopyAuthorization.FromJson(jsonTargetAuth);

            Assert.AreEqual(targetAuth.ModelId, targetAuthFromJson.ModelId);
            Assert.AreEqual(targetAuth.ExpiresOn, targetAuthFromJson.ExpiresOn);
            Assert.AreEqual(targetAuth._accessToken, targetAuthFromJson._accessToken);
            Assert.AreEqual(targetAuth._resourceId, targetAuthFromJson._resourceId);
            Assert.AreEqual(targetAuth._region, targetAuthFromJson._region);
        }
    }
}
