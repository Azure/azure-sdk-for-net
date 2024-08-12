// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="Operation{T}"/> subclasses.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class OperationsLiveTests : DocumentAnalysisLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public OperationsLiveTests(bool isAsync, DocumentAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task BuildModelOperationPercentageCompletedValue()
        {
            var client = CreateDocumentModelAdministrationClient();
            var trainingFilesUri = new Uri(TestEnvironment.BlobContainerSasUrl);
            var modelId = Recording.GenerateId();

            var operation = await client.BuildDocumentModelAsync(WaitUntil.Started, trainingFilesUri, DocumentBuildMode.Template, modelId);
            Assert.Throws<InvalidOperationException>(() => _ = operation.PercentCompleted);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(100, operation.PercentCompleted);
        }

        [RecordedTest]
        public async Task CopyModelToOperationPercentageCompletedValue()
        {
            var client = CreateDocumentModelAdministrationClient();

            await using var trainedModel = await BuildDisposableDocumentModelAsync();

            var targetModelId = Recording.GenerateId();
            DocumentModelCopyAuthorization targetAuth = await client.GetCopyAuthorizationAsync(targetModelId);

            var operation = await client.CopyDocumentModelToAsync(WaitUntil.Started, trainedModel.ModelId, targetAuth);
            Assert.Throws<InvalidOperationException>(() => _ = operation.PercentCompleted);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(100, operation.PercentCompleted);
        }

        [RecordedTest]
        [ServiceVersion(Min = DocumentAnalysisClientOptions.ServiceVersion.V2023_07_31)]
        public async Task BuildClassifierOperationPercentageCompletedValue()
        {
            var client = CreateDocumentModelAdministrationClient(out var nonInstrumentedClient);
            var classifierId = Recording.GenerateId();

            var trainingFilesUri = new Uri(TestEnvironment.ClassifierTrainingSasUrl);
            var sourceA = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-A/train" };
            var sourceB = new BlobContentSource(trainingFilesUri) { Prefix = "IRS-1040-B/train" };

            var documentTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
            {
                { "IRS-1040-A", new ClassifierDocumentTypeDetails(sourceA) },
                { "IRS-1040-B", new ClassifierDocumentTypeDetails(sourceB) }
            };

            BuildDocumentClassifierOperation operation = null;

            try
            {
                operation = await client.BuildDocumentClassifierAsync(WaitUntil.Started, documentTypes, classifierId);

                Assert.Throws<InvalidOperationException>(() => _ = operation.PercentCompleted);

                await operation.WaitForCompletionAsync();
            }
            finally
            {
                if (operation != null && operation.HasValue)
                {
                    await client.DeleteDocumentClassifierAsync(classifierId);
                }
            }

            Assert.AreEqual(100, operation.PercentCompleted);
        }
    }
}
