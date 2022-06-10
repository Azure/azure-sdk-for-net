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
    [IgnoreServiceError(400, "InvalidRequest", Message = "Content is not accessible: Invalid data URL", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28923")]
    public class DocumentModelAdministrationClientLiveTests : DocumentAnalysisLiveTestBase
    {
        private readonly IReadOnlyDictionary<string, string> TestingTags = new Dictionary<string, string>()
        {
            { "ordinary tag", "an ordinary tag" },
            { "crazy tag", "a CRAZY tag 123!@#$%^&*()[]{}\\/?.,<>" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentModelAdministrationClientLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net-pr/issues/1726")]
        public async Task StartBuildModelCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var modelId = Recording.GenerateId();
            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId);

            await operation.WaitForCompletionAsync();

            // Sanity check to make sure we got an actual response back from the service.
            Assert.IsNotNull(operation.Value.ModelId);

            await client.DeleteModelAsync(modelId);
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

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            DocumentModel model = operation.Value;

            ValidateDocumentModel(model);

            Assert.AreEqual(1, model.DocTypes.Count);
            Assert.IsTrue(model.DocTypes.ContainsKey(modelId));

            DocTypeInfo docType = model.DocTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Template, docType.BuildMode);
        }

        [RecordedTest]
        public async Task StartBuildModelWithNeuralBuildMode()
        {
            // Test takes too long to finish running, and seems to cause multiple failures in our
            // live test pipeline. Until we find a way to run it without flakiness, this test will
            // be ignored when running in Live mode.

            if (Recording.Mode == RecordedTestMode.Live)
            {
                Assert.Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27042");
            }

            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Neural, modelId);
            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);

            DocumentModel model = operation.Value;

            ValidateDocumentModel(model);

            Assert.AreEqual(1, model.DocTypes.Count);
            Assert.IsTrue(model.DocTypes.ContainsKey(modelId));

            DocTypeInfo docType = model.DocTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Neural, docType.BuildMode);
        }

        [RecordedTest]
        public async Task StartBuildModelSucceedsWithValidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId, new BuildModelOptions() { Prefix = "subfolder/" });

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(operation.Value.ModelId);
        }

        [RecordedTest]
        [Ignore("https://github.com/azure/azure-sdk-for-net/issues/28272")]
        public void StartBuildModelFailsWithInvalidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId, new BuildModelOptions() { Prefix = "subfolder" }));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public async Task StartBuildModelWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var options = new BuildModelOptions();

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId, options);
            await operation.WaitForCompletionAsync();

            DocumentModel model = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, model.Tags);
        }

        [RecordedTest]
        public void StartBuildModelError()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            var containerUrl = new Uri("https://someUrl");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartBuildModelAsync(containerUrl, DocumentBuildMode.Template, modelId));
            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
        }

        #endregion StartBuildModel

        #region management ops

        [RecordedTest]
        public async Task GetAccountProperties()
        {
            var client = CreateDocumentModelAdministrationClient();

            AccountProperties accountP = await client.GetAccountPropertiesAsync();

            Assert.IsNotNull(accountP.DocumentModelCount);
            Assert.IsNotNull(accountP.DocumentModelLimit);
        }

        [RecordedTest]
        public async Task GetPrebuiltModel()
        {
            var client = CreateDocumentModelAdministrationClient();

            DocumentModel model = await client.GetModelAsync("prebuilt-businessCard");

            ValidateDocumentModel(model);
            Assert.NotNull(model.Description);
        }

        [RecordedTest]
        [TestCase(true, Ignore = "https://github.com/Azure/azure-sdk-for-net-pr/issues/1726")]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/28705")]
        public async Task AdminOps(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();
            var description = "This is a test model.";

            var options = new BuildModelOptions()
            {
                ModelDescription = description
            };

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId, options);

            await operation.WaitForCompletionAsync();

            DocumentModel resultModel = await client.GetModelAsync(modelId);

            ValidateDocumentModel(resultModel, description, TestingTags);

            DocumentModelInfo modelInfo = client.GetModelsAsync().ToEnumerableAsync().Result
                .FirstOrDefault(m => m.ModelId == modelId);

            Assert.NotNull(modelInfo);

            ValidateDocumentModelInfo(modelInfo, description, TestingTags);

            await client.DeleteModelAsync(modelId);

            Assert.ThrowsAsync<RequestFailedException>(() => client.GetModelAsync(modelId));
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
        [TestCase(true, Ignore = "https://github.com/Azure/azure-sdk-for-net-pr/issues/1726")]
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
        public async Task GetAndListOperationsWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();
            var options = new BuildModelOptions();

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFilesUri, DocumentBuildMode.Template, modelId, options);

            ModelOperationInfo modelOperationInfo = client.GetOperationsAsync().ToEnumerableAsync().Result
                .FirstOrDefault(op => op.OperationId == operation.Id);

            Assert.NotNull(modelOperationInfo);

            CollectionAssert.AreEquivalent(TestingTags, modelOperationInfo.Tags);

            ModelOperation modelOperation = await client.GetOperationAsync(operation.Id);

            CollectionAssert.AreEquivalent(TestingTags, modelOperation.Tags);

            await client.DeleteModelAsync(modelId);
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
        [TestCase(true, Ignore = "https://github.com/Azure/azure-sdk-for-net-pr/issues/1726")]
        [TestCase(false)]
        public async Task CopyModel(bool useTokenCredential)
        {
            var sourceClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var targetClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var targetModelId = Recording.GenerateId();
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(targetModelId);

            CopyModelOperation operation = await sourceClient.StartCopyModelToAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasValue);

            DocumentModel copiedModel = operation.Value;

            ValidateDocumentModel(copiedModel);
            Assert.AreEqual(targetAuth.TargetModelId, copiedModel.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, copiedModel.ModelId);

            Assert.AreEqual(1, copiedModel.DocTypes.Count);
            Assert.IsTrue(copiedModel.DocTypes.ContainsKey(modelId));

            DocTypeInfo docType = copiedModel.DocTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Template, docType.BuildMode);
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
        public async Task CopyModelWithTags()
        {
            var sourceClient = CreateDocumentModelAdministrationClient();
            var targetClient = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var tags = TestingTags.ToDictionary(t => t.Key, t => t.Value);

            var targetModelId = Recording.GenerateId();
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(targetModelId, tags: tags);
            CopyModelOperation operation = await sourceClient.StartCopyModelToAsync(trainedModel.ModelId, targetAuth);

            await operation.WaitForCompletionAsync();

            DocumentModel copiedModel = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, copiedModel.Tags);

            await sourceClient.DeleteModelAsync(targetModelId);
        }

        [RecordedTest]
        public async Task CopyModelErrorAsync()
        {
            var sourceClient = CreateDocumentModelAdministrationClient();
            var targetClient = CreateDocumentModelAdministrationClient();

            var modelId = Recording.GenerateId();
            CopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(modelId);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.StartCopyModelToAsync(modelId, targetAuth));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion copy

        #region Composed model

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true, Ignore = "https://github.com/Azure/azure-sdk-for-net-pr/issues/1726")]
        public async Task StartCreateComposedModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);

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

            Assert.AreEqual(2, composedModel.DocTypes.Count);
            Assert.IsTrue(composedModel.DocTypes.ContainsKey(modelAId));
            Assert.IsTrue(composedModel.DocTypes.ContainsKey(modelBId));

            DocTypeInfo docTypeA = composedModel.DocTypes[modelAId];
            DocTypeInfo docTypeB = composedModel.DocTypes[modelBId];

            Assert.AreEqual(DocumentBuildMode.Template, docTypeA.BuildMode);
            Assert.AreEqual(DocumentBuildMode.Template, docTypeB.BuildMode);
        }

        [RecordedTest]
        public async Task StartCreateComposedModelWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();

            var modelAId = Recording.GenerateId();
            var modelBId = Recording.GenerateId();

            await using var trainedModelA = await CreateDisposableBuildModelAsync(modelAId);
            await using var trainedModelB = await CreateDisposableBuildModelAsync(modelBId);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };
            var tags = TestingTags.ToDictionary(t => t.Key, t => t.Value);

            var composedModelId = Recording.GenerateId();
            BuildModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, composedModelId, tags: tags);

            await operation.WaitForCompletionAsync();

            DocumentModel composedModel = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, composedModel.Tags);

            await client.DeleteModelAsync(composedModelId);
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

        private void ValidateDocumentModel(DocumentModel model, string description = null, IReadOnlyDictionary<string, string> tags = null)
        {
            ValidateDocumentModelInfo(model, description, tags);

            // TODO add validation for Doctypes https://github.com/Azure/azure-sdk-for-net-pr/issues/1432
        }

        private void ValidateDocumentModelInfo(DocumentModelInfo model, string description = null, IReadOnlyDictionary<string, string> tags = null)
        {
            if (description != null)
            {
                Assert.AreEqual(description, model.Description);
            }

            if (tags != null)
            {
                CollectionAssert.AreEquivalent(tags, model.Tags);
            }

            Assert.IsNotNull(model.ModelId);
            Assert.IsNotNull(model.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), model.CreatedOn);
        }
    }
}
