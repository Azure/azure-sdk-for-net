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
    /// The suite of tests for miscellaneous operations in the <see cref="DocumentModelAdministrationClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [IgnoreServiceError(400, "InvalidRequest", Message = "Content is not accessible: Invalid data URL", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28923")]
    public class MiscellaneousOperationsLiveTests : DocumentAnalysisLiveTestBase
    {
        private readonly IReadOnlyDictionary<string, string> _testingTags = new Dictionary<string, string>()
        {
            { "ordinary tag", "an ordinary tag" },
            { "crazy tag", "a CRAZY tag 123!@#$%^&*()[]{}\\/?.,<>" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="MiscellaneousOperationsLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public MiscellaneousOperationsLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task GetResourceDetails()
        {
            var client = CreateDocumentModelAdministrationClient();

            ResourceDetails resourceDetails = await client.GetResourceDetailsAsync();

            Assert.IsNotNull(resourceDetails.CustomDocumentModelCount);
            Assert.IsNotNull(resourceDetails.CustomDocumentModelLimit);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAndListOperations(bool useTokenCredential)
        {
            var client = CreateDocumentModelAdministrationClient(useTokenCredential);

            // Guarantee there is going to be at least one operation
            var modelId = Recording.GenerateId();
            await using var trainedModel = await BuildDisposableDocumentModelAsync(modelId);

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

            foreach (var tag in _testingTags)
            {
                options.Tags.Add(tag);
            }

            BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId, options: options);

            OperationSummary operationSummary = client.GetOperationsAsync().ToEnumerableAsync().Result
                .FirstOrDefault(op => op.OperationId == operation.Id);

            Assert.NotNull(operationSummary);

            CollectionAssert.AreEquivalent(_testingTags, operationSummary.Tags);

            OperationDetails operationDetails = await client.GetOperationAsync(operation.Id);

            CollectionAssert.AreEquivalent(_testingTags, operationDetails.Tags);

            await client.DeleteDocumentModelAsync(modelId);
        }

        [RecordedTest]
        public void GetOperationWrongId()
        {
            var client = CreateDocumentModelAdministrationClient();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.GetOperationAsync("0000000000000000"));
            Assert.AreEqual("NotFound", ex.ErrorCode);
        }

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

            // TODO add validation for Doctypes https://github.com/Azure/azure-sdk-for-net-pr/issues/1432
        }
    }
}
