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
        public async Task BuildModelCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var modelId = Recording.GenerateId();
            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId);

            // Sanity check to make sure we got an actual response back from the service.
            Assert.IsNotNull(operation.Value.ModelId);

            await client.DeleteDocumentModelAsync(modelId);
        }

        #region BuildModel

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task BuildModel(bool singlePage)
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(singlePage ? TestEnvironment.BlobContainerSasUrl : TestEnvironment.MultipageBlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId);

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails model = operation.Value;

            ValidateDocumentModelDetails(model);

            Assert.AreEqual(1, model.DocumentTypes.Count);
            Assert.IsTrue(model.DocumentTypes.ContainsKey(modelId));

            DocumentTypeDetails documentType = model.DocumentTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Template, documentType.BuildMode);
        }

        [RecordedTest]
        public async Task BuildModelWithNeuralBuildMode()
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

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Neural, modelId);

            await operation.WaitForCompletionAsync(TimeSpan.FromMinutes(1));

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails model = operation.Value;

            ValidateDocumentModelDetails(model);

            Assert.AreEqual(1, model.DocumentTypes.Count);
            Assert.IsTrue(model.DocumentTypes.ContainsKey(modelId));

            DocumentTypeDetails documentType = model.DocumentTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Neural, documentType.BuildMode);
        }

        [RecordedTest]
        public async Task BuildModelSucceedsWithValidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId, "subfolder/");

            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(operation.Value.ModelId);
        }

        [RecordedTest]
        [Ignore("https://github.com/azure/azure-sdk-for-net/issues/28272")]
        public void BuildModelFailsWithInvalidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId, "subfolder"));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public async Task BuildModelWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var options = new BuildDocumentModelOptions();

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId, options: options);

            DocumentModelDetails model = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, model.Tags);
        }

        [RecordedTest]
        public void BuildModelError()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            var containerUrl = new Uri("https://someUrl");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.BuildDocumentModelAsync(WaitUntil.Started, containerUrl, DocumentBuildMode.Template, modelId));
            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
        }

        #endregion BuildModel

        #region management ops

        [RecordedTest]
        public async Task GetResourceDetails()
        {
            var client = CreateDocumentModelAdministrationClient();

            ResourceDetails resourceDetails = await client.GetResourceDetailsAsync();

            Assert.IsNotNull(resourceDetails.CustomDocumentModelCount);
            Assert.IsNotNull(resourceDetails.CustomDocumentModelLimit);
        }

        [RecordedTest]
        public async Task GetPrebuiltModel()
        {
            var client = CreateDocumentModelAdministrationClient();

            DocumentModelDetails model = await client.GetDocumentModelAsync("prebuilt-businessCard");

            ValidateDocumentModelDetails(model);
            Assert.NotNull(model.Description);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AdminOps(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();
            var description = "This is a test model.";

            var options = new BuildDocumentModelOptions()
            {
                Description = description
            };

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId, options: options);
            DocumentModelDetails resultModel = await client.GetDocumentModelAsync(modelId);

            ValidateDocumentModelDetails(resultModel, description, TestingTags);

            DocumentModelSummary modelSummary = client.GetDocumentModelsAsync().ToEnumerableAsync().Result
                .FirstOrDefault(m => m.ModelId == modelId);

            Assert.NotNull(modelSummary);

            ValidateDocumentModelSummary(modelSummary, description, TestingTags);

            await client.DeleteDocumentModelAsync(modelId);

            Assert.ThrowsAsync<RequestFailedException>(() => client.GetDocumentModelAsync(modelId));
        }

        [RecordedTest]
        public void DeleteModelFailsWhenModelDoesNotExist()
        {
            var client = CreateDocumentModelAdministrationClient();
            var fakeModelId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteDocumentModelAsync(fakeModelId));
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

            ValidateOperationSummary(modelOperationFromList.FirstOrDefault());

            OperationDetails operationDetails = await client.GetOperationAsync(modelOperationFromList.FirstOrDefault().OperationId);

            ValidateOperationDetails(operationDetails);
        }

        [RecordedTest]
        public async Task GetAndListOperationsWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();
            var options = new BuildDocumentModelOptions();

            foreach (var tag in TestingTags)
            {
                options.Tags.Add(tag);
            }

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId, options: options);

            OperationSummary operationSummary = client.GetOperationsAsync().ToEnumerableAsync().Result
                .FirstOrDefault(op => op.OperationId == operation.Id);

            Assert.NotNull(operationSummary);

            CollectionAssert.AreEquivalent(TestingTags, operationSummary.Tags);

            OperationDetails operationDetails = await client.GetOperationAsync(operation.Id);

            CollectionAssert.AreEquivalent(TestingTags, operationDetails.Tags);

            await client.DeleteDocumentModelAsync(modelId);
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
        public async Task CopyModelTo(bool useTokenCredential)
        {
            var sourceClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var targetClient = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var targetModelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(targetModelId);

            CopyDocumentModelToOperation operation = await sourceClient.CopyDocumentModelToAsync(WaitUntil.Completed, trainedModel.ModelId, targetAuth);

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails copiedModel = operation.Value;

            ValidateDocumentModelDetails(copiedModel);
            Assert.AreEqual(targetAuth.TargetModelId, copiedModel.ModelId);
            Assert.AreNotEqual(trainedModel.ModelId, copiedModel.ModelId);

            Assert.AreEqual(1, copiedModel.DocumentTypes.Count);
            Assert.IsTrue(copiedModel.DocumentTypes.ContainsKey(modelId));

            DocumentTypeDetails documentType = copiedModel.DocumentTypes[modelId];

            Assert.AreEqual(DocumentBuildMode.Template, documentType.BuildMode);
        }

        [RecordedTest]
        public async Task GetCopyAuthorization()
        {
            var targetClient = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(modelId);

            Assert.IsNotNull(targetAuth.TargetModelId);
            Assert.AreEqual(modelId, targetAuth.TargetModelId);
            Assert.IsNotNull(targetAuth.AccessToken);
            Assert.IsNotNull(targetAuth.TargetResourceId);
            Assert.IsNotNull(targetAuth.TargetResourceRegion);
        }

        [RecordedTest]
        public async Task CopyModelToWithTags()
        {
            var sourceClient = CreateDocumentModelAdministrationClient();
            var targetClient = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var tags = TestingTags.ToDictionary(t => t.Key, t => t.Value);

            var targetModelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(targetModelId, tags: tags);
            CopyDocumentModelToOperation operation = await sourceClient.CopyDocumentModelToAsync(WaitUntil.Completed, trainedModel.ModelId, targetAuth);

            DocumentModelDetails copiedModel = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, copiedModel.Tags);

            await sourceClient.DeleteDocumentModelAsync(targetModelId);
        }

        [RecordedTest]
        public async Task CopyModelToErrorAsync()
        {
            var sourceClient = CreateDocumentModelAdministrationClient();
            var targetClient = CreateDocumentModelAdministrationClient();

            var modelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await targetClient.GetCopyAuthorizationAsync(modelId);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sourceClient.CopyDocumentModelToAsync(WaitUntil.Started, modelId, targetAuth));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion copy

        #region Compose model

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ComposeModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);

            var modelAId = Recording.GenerateId();
            var modelBId = Recording.GenerateId();

            await using var trainedModelA = await CreateDisposableBuildModelAsync(modelAId);
            await using var trainedModelB = await CreateDisposableBuildModelAsync(modelBId);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };

            var composedModelId = Recording.GenerateId();
            ComposeDocumentModelOperation operation = await client.ComposeDocumentModelAsync(WaitUntil.Completed, modelIds, composedModelId);

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails composedModel = operation.Value;

            ValidateDocumentModelDetails(composedModel);

            Assert.AreEqual(2, composedModel.DocumentTypes.Count);
            Assert.IsTrue(composedModel.DocumentTypes.ContainsKey(modelAId));
            Assert.IsTrue(composedModel.DocumentTypes.ContainsKey(modelBId));

            DocumentTypeDetails documentTypeA = composedModel.DocumentTypes[modelAId];
            DocumentTypeDetails documentTypeB = composedModel.DocumentTypes[modelBId];

            Assert.AreEqual(DocumentBuildMode.Template, documentTypeA.BuildMode);
            Assert.AreEqual(DocumentBuildMode.Template, documentTypeB.BuildMode);
        }

        [RecordedTest]
        public async Task ComposeModelWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();

            var modelAId = Recording.GenerateId();
            var modelBId = Recording.GenerateId();

            await using var trainedModelA = await CreateDisposableBuildModelAsync(modelAId);
            await using var trainedModelB = await CreateDisposableBuildModelAsync(modelBId);

            var modelIds = new List<string> { trainedModelA.ModelId, trainedModelB.ModelId };
            var tags = TestingTags.ToDictionary(t => t.Key, t => t.Value);

            var composedModelId = Recording.GenerateId();
            ComposeDocumentModelOperation operation = await client.ComposeDocumentModelAsync(WaitUntil.Completed, modelIds, composedModelId, tags: tags);

            DocumentModelDetails composedModel = operation.Value;

            CollectionAssert.AreEquivalent(TestingTags, composedModel.Tags);

            await client.DeleteDocumentModelAsync(composedModelId);
        }

        [RecordedTest]
        public async Task ComposeModelFailsWithInvalidId()
        {
            var client = CreateDocumentModelAdministrationClient();

            var modelId = Recording.GenerateId();

            await using var trainedModel = await CreateDisposableBuildModelAsync(modelId);

            var modelIds = new List<string> { trainedModel.ModelId, "00000000-0000-0000-0000-000000000000" };

            var composedModelId = Recording.GenerateId();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.ComposeDocumentModelAsync(WaitUntil.Started, modelIds, composedModelId));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion Composed model

        private void ValidateOperationSummary(OperationSummary operationSummary)
        {
            Assert.NotNull(operationSummary.OperationId);
            Assert.AreNotEqual(default(DateTimeOffset), operationSummary.CreatedOn);
            Assert.AreNotEqual(default(DateTimeOffset), operationSummary.LastUpdatedOn);
            Assert.AreNotEqual(default(DocumentOperationKind), operationSummary.Kind);
            Assert.NotNull(operationSummary.ResourceLocation);

            if (operationSummary.Status == DocumentOperationStatus.Succeeded)
            {
                Assert.AreEqual(100, operationSummary.PercentCompleted);
            }
        }

        private void ValidateOperationDetails(OperationDetails operationDetails)
        {
            Assert.NotNull(operationDetails.OperationId);
            Assert.AreNotEqual(default(DateTimeOffset), operationDetails.CreatedOn);
            Assert.AreNotEqual(default(DateTimeOffset), operationDetails.LastUpdatedOn);
            Assert.AreNotEqual(default(DocumentOperationKind), operationDetails.Kind);
            Assert.NotNull(operationDetails.ResourceLocation);

            if (operationDetails.Status == DocumentOperationStatus.Succeeded)
            {
                Assert.AreEqual(100, operationDetails.PercentCompleted);

                DocumentModelDetails result = operationDetails switch
                {
                    DocumentModelBuildOperationDetails buildOp => buildOp.Result,
                    DocumentModelCopyToOperationDetails copyToOp => copyToOp.Result,
                    DocumentModelComposeOperationDetails composeOp => composeOp.Result,
                    _ => null
                };

                if (result != null)
                {
                    ValidateDocumentModelDetails(result);
                }
            }
            else if (operationDetails.Status == DocumentOperationStatus.Failed)
            {
                Assert.NotNull(operationDetails.Error);
                Assert.NotNull(operationDetails.Error.Code);
                Assert.NotNull(operationDetails.Error.Message);
            }
        }

        private void ValidateDocumentModelDetails(DocumentModelDetails model, string description = null, IReadOnlyDictionary<string, string> tags = null)
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
            Assert.AreNotEqual(default(DateTimeOffset), model.CreatedOn);

            // TODO add validation for Doctypes https://github.com/Azure/azure-sdk-for-net-pr/issues/1432
        }

        private void ValidateDocumentModelSummary(DocumentModelSummary model, string description = null, IReadOnlyDictionary<string, string> tags = null)
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
            Assert.AreNotEqual(default(DateTimeOffset), model.CreatedOn);
        }
    }
}
