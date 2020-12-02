// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
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
        public FormTrainingClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public void FormTrainingClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateFormTrainingClient(apiKey: "fakeKey");
            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetAccountPropertiesAsync());
        }

        [Test]
        public async Task StartTrainingCanAuthenticateWithTokenCredential()
        {
            var client = CreateFormTrainingClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false);

            CustomFormModel model = await operation.WaitForCompletionAsync(PollingInterval);

            // Sanity check to make sure we got an actual response back from the service.
            Assert.IsNotNull(model.ModelId);
            Assert.AreEqual(CustomFormModelStatus.Ready, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(0, model.Errors.Count);
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task StartTraining(bool singlePage, bool labeled)
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(singlePage ? TestEnvironment.BlobContainerSasUrl : TestEnvironment.MultipageBlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            CustomFormModel model = operation.Value;

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.Properties);
            Assert.IsFalse(model.Properties.IsComposedModel);
            Assert.IsNotNull(model.TrainingStartedOn);
            Assert.IsNotNull(model.TrainingCompletedOn);
            Assert.AreEqual(CustomFormModelStatus.Ready, model.Status);
            Assert.IsNotNull(model.Errors);
            Assert.AreEqual(0, model.Errors.Count);

            foreach (TrainingDocumentInfo doc in model.TrainingDocuments)
            {
                Assert.IsNotNull(doc.Name);
                Assert.IsNotNull(doc.ModelId);
                Assert.IsNotNull(doc.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, doc.Status);
                Assert.IsNotNull(doc.Errors);
                Assert.AreEqual(0, doc.Errors.Count);
            }

            foreach (var submodel in model.Submodels)
            {
                Assert.IsNotNull(submodel.FormType);
                Assert.IsNotNull(submodel.ModelId);
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CheckFormTypeinSubmodelAndRecognizedForm(bool labeled)
        {
            var client = CreateFormTrainingClient();
            var formClient = client.GetFormRecognizerClient();

            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation trainingOperation = await client.StartTrainingAsync(trainingFilesUri, labeled);
            await trainingOperation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(trainingOperation.HasValue);

            CustomFormModel model = trainingOperation.Value;
            Assert.IsNotNull(model.Submodels.FirstOrDefault().FormType);

            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.Form1);
            RecognizeCustomFormsOperation recognizeOperation = await formClient.StartRecognizeCustomFormsFromUriAsync(model.ModelId, uri);
            await recognizeOperation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(recognizeOperation.HasValue);

            RecognizedForm form = recognizeOperation.Value.Single();
            Assert.IsNotNull(form.FormType);
            Assert.AreEqual(form.FormType, model.Submodels.FirstOrDefault().FormType);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task StartCreateComposedModel(bool useTokenCredential)
        {
            var client = CreateFormTrainingClient(useTokenCredential);

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            CreateComposedModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, "My composed model");
            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            CustomFormModel composedModel = operation.Value;

            Assert.IsNotNull(composedModel.ModelId);
            Assert.IsNotNull(composedModel.Properties);
            Assert.IsTrue(composedModel.Properties.IsComposedModel);
            Assert.IsNotNull(composedModel.TrainingStartedOn);
            Assert.IsNotNull(composedModel.TrainingCompletedOn);
            Assert.AreEqual(CustomFormModelStatus.Ready, composedModel.Status);
            Assert.IsNotNull(composedModel.Errors);
            Assert.AreEqual(0, composedModel.Errors.Count);

            Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel = composedModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

            Assert.AreEqual(2, trainingDocsPerModel.Count);
            Assert.IsTrue(trainingDocsPerModel.ContainsKey(trainedModelA.ModelId));
            Assert.IsTrue(trainingDocsPerModel.ContainsKey(trainedModelB.ModelId));

            //Check training documents in modelA
            foreach (TrainingDocumentInfo doc in trainingDocsPerModel[trainedModelA.ModelId])
            {
                Assert.IsNotNull(doc.Name);
                Assert.AreEqual(trainedModelA.ModelId, doc.ModelId);
                Assert.IsNotNull(doc.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, doc.Status);
                Assert.IsNotNull(doc.Errors);
                Assert.AreEqual(0, doc.Errors.Count);
            }

            //Check training documents in modelB
            foreach (TrainingDocumentInfo doc in trainingDocsPerModel[trainedModelB.ModelId])
            {
                Assert.IsNotNull(doc.Name);
                Assert.AreEqual(trainedModelB.ModelId, doc.ModelId);
                Assert.IsNotNull(doc.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, doc.Status);
                Assert.IsNotNull(doc.Errors);
                Assert.AreEqual(0, doc.Errors.Count);
            }

            Assert.AreEqual(2, composedModel.Submodels.Count);
            foreach (var submodel in composedModel.Submodels)
            {
                Assert.IsNotNull(submodel.FormType);
                Assert.IsNotNull(submodel.ModelId);
                Assert.IsTrue(modelIds.Contains(submodel.ModelId));
                foreach (var fields in submodel.Fields)
                {
                    Assert.IsNotNull(fields.Value.Name);
                    Assert.IsNotNull(fields.Value.Accuracy);
                }
            }
        }

        [Test]
        public async Task StartCreateComposedModelFailsWithInvalidId()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var modelIds = new List<string> { trainedModelA.ModelId, "00000000-0000-0000-0000-000000000000" };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartCreateComposedModelAsync(modelIds, "My composed model"));
            Assert.AreEqual("1001", ex.ErrorCode);
        }

        [Test]
        public async Task StartTrainingSucceedsWithValidPrefix()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var filter = new TrainingFileFilter { IncludeSubfolders = true, Prefix = "subfolder" };
            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, new TrainingOptions() { TrainingFileFilter = filter});

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(CustomFormModelStatus.Ready, operation.Value.Status);
        }

        [Test]
        public async Task StartTrainingFailsWithInvalidPrefix()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var filter = new TrainingFileFilter { IncludeSubfolders = true, Prefix = "invalidPrefix" };
            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, new TrainingOptions() { TrainingFileFilter = filter });

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync(PollingInterval));
            Assert.AreEqual("2014", ex.ErrorCode);
        }

        [Test]
        public async Task StartTrainingWithLabelsModelName()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelName = "My training";

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: true, modelName);

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(modelName, operation.Value.ModelName);
        }

        [Test]
        [Ignore("Current bug on the service side returns null for model name.")]
        public async Task StartTrainingWithNoLabelsModelName()
        {
            var client = CreateFormTrainingClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelName = "My training";

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, useTrainingLabels: false, modelName);

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(modelName, operation.Value.ModelName);
        }

        [Test]
        public async Task StartTrainingError()
        {
            var client = CreateFormTrainingClient();

            var containerUrl = new Uri("https://someUrl");

            TrainingOperation operation = await client.StartTrainingAsync(containerUrl, useTrainingLabels: false);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync(PollingInterval));
            Assert.AreEqual("2001", ex.ErrorCode);

            Assert.False(operation.HasValue);
            Assert.Throws<RequestFailedException>(() => operation.Value.GetType());
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        public async Task TrainingOps(bool labeled, bool useTokenCredential)
        {
            var client = CreateFormTrainingClient(useTokenCredential);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            TrainingOperation operation = await client.StartTrainingAsync(trainingFilesUri, labeled);

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasValue);

            CustomFormModel trainedModel = operation.Value;

            CustomFormModel resultModel = await client.GetCustomModelAsync(trainedModel.ModelId);

            Assert.AreEqual(trainedModel.ModelId, resultModel.ModelId);
            Assert.AreEqual(trainedModel.Properties.IsComposedModel, resultModel.Properties.IsComposedModel);
            Assert.AreEqual(trainedModel.TrainingStartedOn, resultModel.TrainingStartedOn);
            Assert.AreEqual(trainedModel.TrainingCompletedOn, resultModel.TrainingCompletedOn);
            Assert.AreEqual(CustomFormModelStatus.Ready, resultModel.Status);
            Assert.AreEqual(trainedModel.Status, resultModel.Status);
            Assert.AreEqual(trainedModel.Errors.Count, resultModel.Errors.Count);

            for (int i = 0; i < resultModel.TrainingDocuments.Count; i++)
            {
                var tm = trainedModel.TrainingDocuments[i];
                var rm = resultModel.TrainingDocuments[i];

                Assert.AreEqual(tm.Name, rm.Name);
                Assert.AreEqual(tm.ModelId, rm.ModelId);
                Assert.AreEqual(tm.PageCount, rm.PageCount);
                Assert.AreEqual(TrainingStatus.Succeeded, rm.Status);
                Assert.AreEqual(tm.Status, rm.Status);
                Assert.AreEqual(tm.Errors.Count, rm.Errors.Count);
            }

            for (int i = 0; i < resultModel.Submodels.Count; i++)
            {
                Assert.AreEqual(trainedModel.Submodels[i].FormType, resultModel.Submodels[i].FormType);
                Assert.AreEqual(trainedModel.Submodels[i].ModelId, resultModel.Submodels[i].ModelId);
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
            Assert.IsNotNull(modelInfo.TrainingStartedOn);
            Assert.IsNotNull(modelInfo.TrainingCompletedOn);
            Assert.IsNotNull(modelInfo.Status);
            Assert.IsNotNull(modelInfo.Properties);

            AccountProperties accountP = await client.GetAccountPropertiesAsync();

            Assert.IsNotNull(accountP.CustomModelCount);
            Assert.IsNotNull(accountP.CustomModelLimit);

            await client.DeleteModelAsync(trainedModel.ModelId);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.GetCustomModelAsync(trainedModel.ModelId));
            Assert.AreEqual("1022", ex.ErrorCode);
        }

        [Test]
        public void DeleteModelFailsWhenModelDoesNotExist()
        {
            var client = CreateFormTrainingClient();
            var fakeModelId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteModelAsync(fakeModelId));
            Assert.AreEqual("1022", ex.ErrorCode);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CopyModel(bool useTokenCredential)
        {
            var sourceClient = CreateFormTrainingClient(useTokenCredential);
            var targetClient = CreateFormTrainingClient(useTokenCredential);
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);

            CustomFormModelInfo modelCopied = operation.Value;

            Assert.IsNotNull(modelCopied.TrainingCompletedOn);
            Assert.IsNotNull(modelCopied.TrainingStartedOn);
            Assert.AreEqual(targetAuth.ModelId, modelCopied.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, modelCopied.ModelId);
        }

        [Test]
        public async Task CopyModelWithLabelsAndModelName()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            string modelName = "My model to copy";

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true, modelName: modelName);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);

            CustomFormModelInfo modelCopied = operation.Value;

            Assert.AreEqual(targetAuth.ModelId, modelCopied.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, modelCopied.ModelId);

            CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId).ConfigureAwait(false);
            Assert.AreEqual(modelName, modelCopiedFullInfo.ModelName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CopyComposedModel(bool useTokenCredential)
        {
            var sourceClient = CreateFormTrainingClient(useTokenCredential);
            var targetClient = CreateFormTrainingClient(useTokenCredential);
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            await using var trainedModelA = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            await using var trainedModelB = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            string modelName = "My composed model";
            CreateComposedModelOperation operation = await sourceClient.StartCreateComposedModelAsync(modelIds, modelName);
            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);
            CustomFormModel composedModel = operation.Value;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation copyOperation = await sourceClient.StartCopyModelAsync(composedModel.ModelId, targetAuth);
            await copyOperation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(copyOperation.HasValue);
            CustomFormModelInfo modelCopied = copyOperation.Value;

            Assert.AreEqual(targetAuth.ModelId, modelCopied.ModelId);
            Assert.AreNotEqual(composedModel.ModelId, modelCopied.ModelId);

            CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId).ConfigureAwait(false);
            Assert.AreEqual(modelName, modelCopiedFullInfo.ModelName);
            foreach (var submodel in modelCopiedFullInfo.Submodels)
            {
                Assert.IsTrue(modelIds.Contains(submodel.ModelId));
            }
        }

        [Test]
        [Ignore("Current bug on the service side returns null for model name.")]
        public async Task CopyModelWithoutLabelsAndModelName()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            string modelName = "My model to copy";

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: false, modelName: modelName);

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync(PollingInterval);
            Assert.IsTrue(operation.HasValue);

            CustomFormModelInfo modelCopied = operation.Value;

            Assert.AreEqual(targetAuth.ModelId, modelCopied.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, modelCopied.ModelId);

            CustomFormModel modelCopiedFullInfo = await sourceClient.GetCustomModelAsync(modelCopied.ModelId).ConfigureAwait(false);
            Assert.AreEqual(modelName, modelCopiedFullInfo.ModelName);
        }

        [Test]
        public void CopyModelError()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = CopyAuthorization.FromJson("{\"modelId\":\"328c3b7d - a563 - 4ba2 - 8c2f - 2f26d664486a\",\"accessToken\":\"5b5685e4 - 2f24 - 4423 - ab18 - 000000000000\",\"expirationDateTimeTicks\":1591932653,\"resourceId\":\"resourceId\",\"resourceRegion\":\"westcentralus\"}");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.StartCopyModelAsync("00000000-0000-0000-0000-000000000000", targetAuth));

            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("1002", ex.ErrorCode);
        }

        [Test]
        public async Task StartCopyModelFailsWithWrongRegion()
        {
            var sourceClient = CreateFormTrainingClient();
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var wrongRegion = TestEnvironment.TargetResourceRegion == "westcentralus" ? "eastus2" : "westcentralus";

            await using var trainedModel = await CreateDisposableTrainedModelAsync(useTrainingLabels: true);
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, wrongRegion);

            var operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync(PollingInterval));
            Assert.AreEqual("AuthorizationError", ex.ErrorCode);
        }

        [Test]
        public async Task GetCopyAuthorization()
        {
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            Assert.IsNotNull(targetAuth.ModelId);
            Assert.IsNotNull(targetAuth.AccessToken);
            Assert.IsNotNull(targetAuth.ExpiresOn);
            Assert.AreEqual(resourceId, targetAuth.ResourceId);
            Assert.AreEqual(region, targetAuth.Region);
        }

        [Test]
        public async Task SerializeDeserializeCopyAuthorizationAsync()
        {
            var targetClient = CreateFormTrainingClient();
            var resourceId = TestEnvironment.TargetResourceId;
            var region = TestEnvironment.TargetResourceRegion;

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(resourceId, region);

            string jsonTargetAuth = targetAuth.ToJson();

            CopyAuthorization targetAuthFromJson = CopyAuthorization.FromJson(jsonTargetAuth);

            Assert.AreEqual(targetAuth.ModelId, targetAuthFromJson.ModelId);
            Assert.AreEqual(targetAuth.ExpiresOn, targetAuthFromJson.ExpiresOn);
            Assert.AreEqual(targetAuth.AccessToken, targetAuthFromJson.AccessToken);
            Assert.AreEqual(targetAuth.ResourceId, targetAuthFromJson.ResourceId);
            Assert.AreEqual(targetAuth.Region, targetAuthFromJson.Region);
        }
    }
}
