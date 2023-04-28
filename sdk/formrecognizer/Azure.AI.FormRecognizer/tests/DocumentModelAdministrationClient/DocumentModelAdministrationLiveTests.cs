// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the document model methods in the <see cref="DocumentModelAdministrationClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [IgnoreServiceError(400, "InvalidRequest", Message = "Content is not accessible: Invalid data URL", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28923")]
    public class DocumentModelAdministrationLiveTests : DocumentAnalysisLiveTestBase
    {
        private readonly IReadOnlyDictionary<string, string> _testingTags = new Dictionary<string, string>()
        {
            { "ordinary tag", "an ordinary tag" },
            { "crazy tag", "a CRAZY tag 123!@#$%^&*()[]{}\\/?.,<>" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentModelAdministrationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentModelAdministrationLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        #region Build

        [RecordedTest]
        public async Task BuildDocumentModelCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential: true);
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            var modelId = Recording.GenerateId();
            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId);

            // Sanity check to make sure we got an actual response back from the service.
            Assert.IsNotNull(operation.Value.ModelId);

            await client.DeleteDocumentModelAsync(modelId);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task BuildDocumentModel(bool singlePage)
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
        public async Task BuildDocumentModelWithNeuralBuildMode()
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
        public async Task BuildDocumentModelSucceedsWithValidPrefix()
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
        public void BuildDocumentModelFailsWithInvalidPrefix()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId, "subfolder"));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        [RecordedTest]
        public async Task BuildDocumentModelWithTags()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var options = new BuildDocumentModelOptions();

            foreach (var tag in _testingTags)
            {
                options.Tags.Add(tag);
            }

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, trainingFilesUri, DocumentBuildMode.Template, modelId, options: options);

            DocumentModelDetails model = operation.Value;

            CollectionAssert.AreEquivalent(_testingTags, model.Tags);
        }

        [RecordedTest]
        public void BuildDocumentModelError()
        {
            var client = CreateDocumentModelAdministrationClient();
            var modelId = Recording.GenerateId();

            var containerUrl = new Uri("https://someUrl");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.BuildDocumentModelAsync(WaitUntil.Started, containerUrl, DocumentBuildMode.Template, modelId));
            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
        }

        #endregion

        #region Copy

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CopyDocumentModelTo(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var sourceModelId = Recording.GenerateId();
            var modelId = Recording.GenerateId();
            var description = $"This model was generated by a .NET test: {nameof(CopyDocumentModelTo)}";
            var tags = new Dictionary<string, string>() { { "tag1", "value1" }, { "tag2", "value2" } };
            var startTime = Recording.UtcNow;

            await using var disposableModel = await BuildDisposableDocumentModelAsync(sourceModelId);

            DocumentModelCopyAuthorization copyAuthorization = await client.GetCopyAuthorizationAsync(modelId, description, tags);
            CopyDocumentModelToOperation operation = null;

            try
            {
                operation = await client.CopyDocumentModelToAsync(WaitUntil.Completed, sourceModelId, copyAuthorization);
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteDocumentModelAsync(modelId);
                }
            }

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails sourceModel = disposableModel.Value;
            DocumentModelDetails model = operation.Value;

            Assert.AreEqual(modelId, model.ModelId);
            Assert.AreEqual(description, model.Description);
            Assert.AreEqual(ServiceVersionString, model.ApiVersion);
            Assert.Greater(model.CreatedOn, startTime);
            Assert.Greater(model.ExpiresOn, model.CreatedOn);

            CollectionAssert.AreEquivalent(tags, model.Tags);

            AssertDocumentTypeDictionariesAreEquivalent(sourceModel.DocumentTypes, model.DocumentTypes);
        }

        #endregion Copy

        #region Compose

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ComposeDocumentModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var componentModelIds = new string[] { Recording.GenerateId(), Recording.GenerateId() };
            var modelId = Recording.GenerateId();
            var description = $"This model was generated by a .NET test: {nameof(ComposeDocumentModel)}";
            var tags = new Dictionary<string, string>() { { "tag1", "value1" }, { "tag2", "value2" } };
            var startTime = Recording.UtcNow;

            await using var disposableModel0 = await BuildDisposableDocumentModelAsync(componentModelIds[0], ContainerType.Singleforms);
            await using var disposableModel1 = await BuildDisposableDocumentModelAsync(componentModelIds[1], ContainerType.SelectionMarks);

            ComposeDocumentModelOperation operation = null;

            try
            {
                operation = await client.ComposeDocumentModelAsync(WaitUntil.Completed, componentModelIds, modelId, description, tags);
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteDocumentModelAsync(modelId);
                }
            }

            Assert.IsTrue(operation.HasValue);

            DocumentModelDetails componentModel0 = disposableModel0.Value;
            DocumentModelDetails componentModel1 = disposableModel1.Value;
            DocumentModelDetails model = operation.Value;

            Assert.AreEqual(modelId, model.ModelId);
            Assert.AreEqual(description, model.Description);
            Assert.AreEqual(ServiceVersionString, model.ApiVersion);
            Assert.Greater(model.CreatedOn, startTime);
            Assert.Greater(model.ExpiresOn, model.CreatedOn);

            CollectionAssert.AreEquivalent(tags, model.Tags);

            Assert.AreEqual(2, model.DocumentTypes.Count);

            DocumentTypeDetails expectedDocumentType0 = componentModel0.DocumentTypes[componentModel0.ModelId];
            DocumentTypeDetails expectedDocumentType1 = componentModel1.DocumentTypes[componentModel1.ModelId];
            DocumentTypeDetails documentType0 = model.DocumentTypes[componentModel0.ModelId];
            DocumentTypeDetails documentType1 = model.DocumentTypes[componentModel1.ModelId];

            AssertDocumentTypesAreEqual(expectedDocumentType0, documentType0);
            AssertDocumentTypesAreEqual(expectedDocumentType1, documentType1);
        }

        [RecordedTest]
        public void ComposeDocumentModelThrowsWhenComponentModelDoesNotExist()
        {
            var client = CreateDocumentModelAdministrationClient();
            var fakeComponentModelIds = new string[] { "00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001" };
            var modelId = Recording.GenerateId();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.ComposeDocumentModelAsync(WaitUntil.Started, fakeComponentModelIds, modelId));
            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
        }

        #endregion

        #region Get

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDocumentModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelId = Recording.GenerateId();
            var options = new BuildDocumentModelOptions()
            {
                Description = $"This model was generated by a .NET test: {nameof(GetDocumentModel)}",
                Tags = { { "tag1", "value1" }, { "tag2", "value2" } }
            };
            await using var disposableModel = await BuildDisposableDocumentModelAsync(modelId, options: options);

            DocumentModelDetails expected = disposableModel.Value;
            DocumentModelDetails model = await client.GetDocumentModelAsync(modelId);

            Assert.AreEqual(expected.ModelId, model.ModelId);
            Assert.AreEqual(expected.Description, model.Description);
            Assert.AreEqual(expected.ApiVersion, model.ApiVersion);
            Assert.AreEqual(expected.CreatedOn, model.CreatedOn);
            Assert.AreEqual(expected.ExpiresOn, model.ExpiresOn);

            CollectionAssert.AreEquivalent(expected.Tags, model.Tags);

            AssertDocumentTypeDictionariesAreEquivalent(expected.DocumentTypes, model.DocumentTypes);
        }

        [RecordedTest]
        public void GetDocumentModelThrowsWhenModelDoesNotExist()
        {
            var client = CreateDocumentModelAdministrationClient();
            var fakeId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetDocumentModelAsync(fakeId));
            Assert.AreEqual("NotFound", ex.ErrorCode);
        }

        #endregion

        #region List

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDocumentModels(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelIds = new string[] { Recording.GenerateId(), Recording.GenerateId() };
            var options = new BuildDocumentModelOptions()
            {
                Description = $"This model was generated by a .NET test: {nameof(GetDocumentModels)}",
                Tags = { { "tag1", "value1" }, { "tag2", "value2" } }
            };

            await using var disposableModel0 = await BuildDisposableDocumentModelAsync(modelIds[0], options: options);
            await using var disposableModel1 = await BuildDisposableDocumentModelAsync(modelIds[1], options: options);

            var idMapping = new Dictionary<string, DocumentModelSummary>();
            var expectedIdMapping = new Dictionary<string, DocumentModelDetails>()
            {
                { modelIds[0], disposableModel0.Value },
                { modelIds[1], disposableModel1.Value }
            };

            await foreach (DocumentModelSummary model in client.GetDocumentModelsAsync())
            {
                if (expectedIdMapping.ContainsKey(model.ModelId))
                {
                    idMapping.Add(model.ModelId, model);
                }

                if (idMapping.Count == expectedIdMapping.Count)
                {
                    break;
                }
            }

            foreach (string id in expectedIdMapping.Keys)
            {
                Assert.True(idMapping.ContainsKey(id));

                DocumentModelSummary model = idMapping[id];
                DocumentModelDetails expected = expectedIdMapping[id];

                Assert.AreEqual(expected.ModelId, model.ModelId);
                Assert.AreEqual(expected.Description, model.Description);
                Assert.AreEqual(expected.ApiVersion, model.ApiVersion);
                Assert.AreEqual(expected.CreatedOn, model.CreatedOn);
                Assert.AreEqual(expected.ExpiresOn, model.ExpiresOn);

                CollectionAssert.AreEquivalent(expected.Tags, model.Tags);
            }
        }

        #endregion List

        #region Delete

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteDocumentModel(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);
            var modelId = Recording.GenerateId();

            await BuildDisposableDocumentClassifierAsync(modelId);

            var response = await client.DeleteDocumentClassifierAsync(modelId);

            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [RecordedTest]
        public void DeleteDocumentModelThrowsWhenModelDoesNotExist()
        {
            var client = CreateDocumentModelAdministrationClient();
            var fakeModelId = "00000000-0000-0000-0000-000000000000";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DeleteDocumentModelAsync(fakeModelId));
            Assert.AreEqual("NotFound", ex.ErrorCode);
        }

        #endregion

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

        private void AssertFieldSchemasAreEqual(DocumentFieldSchema fieldSchema1, DocumentFieldSchema fieldSchema2)
        {
            if (fieldSchema1 == null)
            {
                Assert.Null(fieldSchema2);
            }
            else
            {
                Assert.NotNull(fieldSchema2);

                Assert.AreEqual(fieldSchema1.Type, fieldSchema2.Type);
                Assert.AreEqual(fieldSchema1.Description, fieldSchema2.Description);
                Assert.AreEqual(fieldSchema1.Example, fieldSchema2.Example);

                AssertFieldSchemasAreEqual(fieldSchema1.Items, fieldSchema2.Items);
                AssertFieldSchemaDictionariesAreEquivalent(fieldSchema1.Properties, fieldSchema2.Properties);
            }
        }

        private void AssertFieldSchemaDictionariesAreEquivalent(IReadOnlyDictionary<string, DocumentFieldSchema> fieldSchemas1, IReadOnlyDictionary<string, DocumentFieldSchema> fieldSchemas2)
        {
            Assert.AreEqual(fieldSchemas1.Count, fieldSchemas2.Count);

            foreach (string key in fieldSchemas1.Keys)
            {
                DocumentFieldSchema fieldSchema1 = fieldSchemas1[key];
                DocumentFieldSchema fieldSchema2 = fieldSchemas2[key];

                AssertFieldSchemasAreEqual(fieldSchema1, fieldSchema2);
            }
        }

        private void AssertDocumentTypesAreEqual(DocumentTypeDetails docType1, DocumentTypeDetails docType2)
        {
            Assert.AreEqual(docType1.Description, docType2.Description);
            Assert.AreEqual(docType1.BuildMode, docType2.BuildMode);

            CollectionAssert.AreEquivalent(docType1.FieldConfidence, docType2.FieldConfidence);

            AssertFieldSchemaDictionariesAreEquivalent(docType1.FieldSchema, docType2.FieldSchema);
        }

        private void AssertDocumentTypeDictionariesAreEquivalent(IReadOnlyDictionary<string, DocumentTypeDetails> docTypes1, IReadOnlyDictionary<string, DocumentTypeDetails> docTypes2)
        {
            Assert.AreEqual(docTypes1.Count, docTypes2.Count);

            foreach (string key in docTypes1.Keys)
            {
                DocumentTypeDetails docType1 = docTypes1[key];
                DocumentTypeDetails docType2 = docTypes2[key];

                AssertDocumentTypesAreEqual(docType1, docType2);
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

            if (_serviceVersion >= DocumentAnalysisClientOptions.ServiceVersion.V2023_02_28_Preview)
            {
                if (model.ExpiresOn.HasValue)
                {
                    Assert.Greater(model.ExpiresOn, model.CreatedOn);
                }
            }
            else
            {
                // We have changed the following validation because of a service bug. This needs to be updated once the bug is fixed.
                // More information: https://github.com/Azure/azure-sdk-for-net/issues/35809

                /* The expected behavior. This must be added back once the service bug is fixed.
                Assert.Null(model.ExpiresOn);
                */

                // The current behavior. This 'if' block must be completely removed once the service bug is fixed.
                if (model.ExpiresOn.HasValue)
                {
                    Assert.Greater(model.ExpiresOn, model.CreatedOn);
                }
            }
        }
    }
}
