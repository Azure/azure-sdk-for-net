// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DocumentModelAdministrationClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DocumentModelAdministrationClientLiveTests : DocumentAnalysisLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentModelAdministrationClientLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [Ignore("AAd not working on V3")]
        public async Task StartBuildModelCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri);

            await operation.WaitForCompletionAsync();

            // Sanity check to make sure we got an actual response back from the service.
            Assert.IsNotNull(operation.Value.ModelId);
        }

        #region StartBuildModel

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartBuildModel(bool singlePage)
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(singlePage ? TestEnvironment.BlobContainerSasUrl : TestEnvironment.MultipageBlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, modelId);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            DocumentModel model = operation.Value;

            ValidateDocumentModel(model);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net-pr/issues/1442")]
        public async Task StartBuildModelSucceedsWithValidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, modelId, new BuildModelOptions() { Prefix = "subfolder" });

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(operation.Value.ModelId);
        }

        [RecordedTest]
        public void StartBuildModelFailsWithInvalidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartBuildModelAsync(trainingFilesUri, modelId, new BuildModelOptions() { Prefix = "subfolder" }));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public void StartBuildModelError()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            var containerUrl = new Uri("https://someUrl");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartBuildModelAsync(containerUrl, modelId));
            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
        }

        #endregion StartBuildModel

        #region management ops

        [RecordedTest]
        public async Task GetAccountProperties()
        {
            var client = CreateDocumentModelAdministrationClient();

            AccountProperties accountP = await client.GetAccountPropertiesAsync();

            Assert.IsNotNull(accountP.Count);
            Assert.IsNotNull(accountP.Limit);
        }

        [RecordedTest]
        public async Task GetPrebuildModel()
        {
            var client = CreateDocumentModelAdministrationClient();

            DocumentModel model = await client.GetModelAsync("prebuilt-businessCard");
            ValidateDocumentModel(model, true);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AdminOps(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri,
                                                                          modelId,
                                                                          new BuildModelOptions() { ModelDescription = "This is a test model." });

            await operation.WaitForCompletionAsync();

            DocumentModel resultModel = await client.GetModelAsync(modelId);

            ValidateDocumentModel(resultModel, true);

            DocumentModelInfo modelInfo = client.GetModelsAsync().ToEnumerableAsync().Result.FirstOrDefault();

            ValidateDocumentModelInfo(modelInfo);

            await client.DeleteModelAsync(modelId);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.GetModelAsync(modelId));
            Console.WriteLine(ex.ErrorCode);
        }

        [RecordedTest]
        public void DeleteModelFailsWhenModelDoesNotExist()
        {
            var client = CreateDocumentModelAdministrationClient();
            var fakeModelId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteModelAsync(fakeModelId));
            Assert.AreEqual("NotFound", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAndListOperations(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);

            // Guarantee there is going to be at least one operation
            var modelId = Recording.GenerateId();
            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var modelOperationFromList = client.GetOperationsAsync().ToEnumerableAsync().Result;
            Assert.GreaterOrEqual(modelOperationFromList.Count, 1);

            ValidateModelOperationInfo(modelOperationFromList.FirstOrDefault());

            ModelOperation modelOperationInfo = await client.GetOperationAsync(modelOperationFromList.FirstOrDefault().OperationId);

            ValidateModelOperationInfo(modelOperationInfo);
            if (modelOperationInfo.Status == DocumentOperationStatus.Failed)
            {
                Assert.NotNull(modelOperationInfo.Error);
                Assert.NotNull(modelOperationInfo.Error.Code);
                Assert.NotNull(modelOperationInfo.Error.Message);
            }
            else
            {
                ValidateDocumentModel(modelOperationInfo.Result);
            }
        }

        [RecordedTest]
        public void GetOperationWrongId()
        {
            var client = CreateDocumentModelAdministrationClient();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.GetOperationAsync("0000000000000000"));
            Assert.AreEqual("NotFound", ex.ErrorCode);
        }

        #endregion management ops

        #region copy
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CopyModel(bool useTokenCredential)
        {
            var sourceClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var targetClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var targetModelId = Recording.GenerateId();
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(targetModelId);

            CopyModelOperation operation = await sourceClient.StartCopyModelAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            DocumentModel modelCopied = operation.Value;

            ValidateDocumentModel(modelCopied);
            Assert.AreEqual(targetAuth.TargetModelId, modelCopied.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, modelCopied.ModelId);
        }

        [RecordedTest]
        public async Task GetCopyAuthorization()
        {
            var targetClient = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(modelId);

            Assert.IsNotNull(targetAuth.TargetModelId);
            Assert.AreEqual(modelId, targetAuth.TargetModelId);
            Assert.IsNotNull(targetAuth.AccessToken);
            Assert.IsNotNull(targetAuth.TargetResourceId);
            Assert.IsNotNull(targetAuth.TargetResourceRegion);
        }

        [RecordedTest]
        public async Task CopyModelErrorAsync()
        {
            var sourceClient = CreateDocumentModelAdministrationClient();
            var targetClient = CreateDocumentModelAdministrationClient();

            var modelId = Recording.GenerateId();
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(modelId);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.StartCopyModelAsync(modelId, targetAuth));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion copy

        #region Composed model

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task StartCreateComposedModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient();

            var modelAId = Recording.GenerateId();
            var modelBId = Recording.GenerateId();

            await using var trainedModelA = await CreateDisposableBuildModelAsync(modelAId);
            await using var trainedModelB = await CreateDisposableBuildModelAsync(modelBId);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            var composedModelId = Recording.GenerateId();
            BuildModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, composedModelId);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            DocumentModel composedModel = operation.Value;

            ValidateDocumentModel(composedModel);
        }

        [RecordedTest]
        public async Task StartCreateComposedModelFailsWithInvalidId()
        {
            var client = CreateDocumentModelAdministrationClient();

            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var modelIds = new List<string> { trainedModel.ModelId, "00000000-0000-0000-0000-000000000000" };

            var composedModelId = Recording.GenerateId();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartCreateComposedModelAsync(modelIds, composedModelId));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion Composed model

        private void ValidateModelOperationInfo(ModelOperationInfo model)
        {
            Assert.NotNull(model.OperationId);
            Assert.NotNull(model.Status);
            Assert.AreNotEqual(new DateTimeOffset(), model.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), model.LastUpdatedOn);
            Assert.NotNull(model.Kind);
            Assert.NotNull(model.ResourceLocation);
            if (model.Status == DocumentOperationStatus.Succeeded)
            {
                Assert.NotNull(model.PercentCompleted);
                Assert.AreEqual(100, model.PercentCompleted);
            }
        }

        private void ValidateDocumentModel(DocumentModel model, bool description = false)
        {
            if (description)
                Assert.IsNotNull(model.Description);
            else
                Assert.IsNull(model.Description);

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), model.CreatedOn);

            // TODO add validation for Doctypes https://github.com/Azure/azure-sdk-for-net-pr/issues/1432
        }

        private void ValidateDocumentModelInfo(DocumentModelInfo model)
        {
            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), model.CreatedOn);
        }
    }
}
