// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class TranslationOperationLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationOperationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TranslationOperationLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        private List<TestDocument> oneDocumentList = new List<TestDocument>
        {
            new TestDocument("Document1.txt", "First english test document"),
        };

        private List<TestDocument> twoDocumentsList = new List<TestDocument>
        {
            new TestDocument("Document1.txt", "First english test document"),
            new TestDocument("File2.txt", "Second english test file"),
        };

        [RecordedTest]
        public async Task SingleSourceSingleTargetTest()
        {
            Uri source = await CreateSourceContainerAsync(oneDocumentList);
            Uri target = await CreateTargetContainerAsync();

            var client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceMultipleTargetsTest()
        {
            Uri source = await CreateSourceContainerAsync(oneDocumentList);
            Uri targetFrench = await CreateTargetContainerAsync();
            Uri targetSpanish = await CreateTargetContainerAsync();
            Uri targetArabic = await CreateTargetContainerAsync();

            var client = GetClient();

            var input = new DocumentTranslationInput(source, targetFrench, "fr");
            input.AddTarget(targetSpanish, "es");
            input.AddTarget(targetArabic, "ar");
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(3, operation.DocumentsTotal);
            Assert.AreEqual(3, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task MultipleSourcesSingleTarget()
        {
            Uri source1 = await CreateSourceContainerAsync(oneDocumentList);
            Uri source2 = await CreateSourceContainerAsync(oneDocumentList);
            Uri target1 = await CreateTargetContainerAsync();
            Uri target2 = await CreateTargetContainerAsync();

            var client = GetClient();

            var inputs = new List<DocumentTranslationInput>
            {
                new DocumentTranslationInput(source1, target1, "fr"),
                new DocumentTranslationInput(source2, target2, "es")
            };

            var operation = await client.StartTranslationAsync(inputs);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(2, operation.DocumentsTotal);
            Assert.AreEqual(2, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceSingleTargetWithPrefixTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(twoDocumentsList);
            Uri targetUri = await CreateTargetContainerAsync();

            var client = GetClient();

            var filter = new DocumentFilter
            {
                Prefix = "File"
            };
            var source = new TranslationSource(sourceUri)
            {
                Filter = filter
            };
            var targets = new List<TranslationTarget> { new TranslationTarget(targetUri, "fr") };
            var input = new DocumentTranslationInput(source, targets);
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceSingleTargetWithSuffixTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(twoDocumentsList);
            Uri targetUri = await CreateTargetContainerAsync();

            var client = GetClient();

            var filter = new DocumentFilter
            {
                Suffix = "1.txt"
            };
            var source = new TranslationSource(sourceUri)
            {
                Filter = filter
            };
            var targets = new List<TranslationTarget> { new TranslationTarget(targetUri, "fr") };
            var input = new DocumentTranslationInput(source, targets);
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceSingleTargetListDocumentsTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(oneDocumentList);
            Uri targetUri = await CreateTargetContainerAsync();

            var client = GetClient();

            var filter = new DocumentFilter
            {
                Suffix = "1.txt"
            };
            var source = new TranslationSource(sourceUri)
            {
                Filter = filter
            };
            var targets = new List<TranslationTarget> { new TranslationTarget(targetUri, "fr") };
            var input = new DocumentTranslationInput(source, targets);
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();
            var documents = operation.GetAllDocumentStatusesAsync();

            int documentsCount = 0;

            await foreach (var document in documents)
            {
                Assert.AreEqual(TranslationStatus.Succeeded, document.Status);
                Assert.IsTrue(document.HasCompleted);
                Assert.AreEqual(100f, document.TranslationProgressPercentage);
                Assert.AreEqual("fr", document.TranslateTo);
                Assert.NotNull(document.TranslatedDocumentUri);
                documentsCount++;
            }
        }
    }
}
