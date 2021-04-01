// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.DocumentTranslation.Tests
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

        [RecordedTest]
        public async Task SingleSourceSingleTargetTest()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri targetFrench = await CreateTargetContainerAsync();
            Uri targetSpanish = await CreateTargetContainerAsync();
            Uri targetArabic = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, targetFrench, "fr");
            input.AddTarget(targetSpanish, "es");
            input.AddTarget(targetArabic, "ar");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 3)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
            Uri source1 = await CreateSourceContainerAsync(oneTestDocuments);
            Uri source2 = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target1 = await CreateTargetContainerAsync();
            Uri target2 = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var inputs = new List<DocumentTranslationInput>
            {
                new DocumentTranslationInput(source1, target1, "fr"),
                new DocumentTranslationInput(source2, target2, "es")
            };

            DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 2)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
            Uri sourceUri = await CreateSourceContainerAsync(twoTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

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
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
            Uri sourceUri = await CreateSourceContainerAsync(twoTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

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
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
            Uri sourceUri = await CreateSourceContainerAsync(oneTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();
            string translateTo = "fr";

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(sourceUri, targetUri, translateTo);
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            AsyncPageable<DocumentStatusResult> documentsFromOperation = await operation.WaitForCompletionAsync(PollingInterval);
            List<DocumentStatusResult> documentsFromOperationList = await documentsFromOperation.ToEnumerableAsync();

            Assert.AreEqual(1, documentsFromOperationList.Count);
            CheckDocumentStatusResult(documentsFromOperationList[0], translateTo);

            AsyncPageable<DocumentStatusResult> documentsFromGetAll = operation.GetAllDocumentStatusesAsync();
            List<DocumentStatusResult> documentsFromGetAllList = await documentsFromGetAll.ToEnumerableAsync();

            Assert.AreEqual(documentsFromOperationList[0].Status, documentsFromGetAllList[0].Status);
            Assert.AreEqual(documentsFromOperationList[0].HasCompleted, documentsFromGetAllList[0].HasCompleted);
            Assert.AreEqual(documentsFromOperationList[0].DocumentId, documentsFromGetAllList[0].DocumentId);
            Assert.AreEqual(documentsFromOperationList[0].SourceDocumentUri, documentsFromGetAllList[0].SourceDocumentUri);
            Assert.AreEqual(documentsFromOperationList[0].TranslatedDocumentUri, documentsFromGetAllList[0].TranslatedDocumentUri);
            Assert.AreEqual(documentsFromOperationList[0].TranslationProgressPercentage, documentsFromGetAllList[0].TranslationProgressPercentage);
            Assert.AreEqual(documentsFromOperationList[0].TranslateTo, documentsFromGetAllList[0].TranslateTo);
            Assert.AreEqual(documentsFromOperationList[0].CreatedOn, documentsFromGetAllList[0].CreatedOn);
            Assert.AreEqual(documentsFromOperationList[0].LastModified, documentsFromGetAllList[0].LastModified);
        }

        [RecordedTest]
        public async Task GetDocumentStatusTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(oneTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();
            string translateTo = "fr";

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(sourceUri, targetUri, translateTo);
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);
            AsyncPageable<DocumentStatusResult> documents = operation.GetAllDocumentStatusesAsync();

            List<DocumentStatusResult> documentsList = await documents.ToEnumerableAsync();

            Assert.AreEqual(1, documentsList.Count);

            DocumentStatusResult document = await operation.GetDocumentStatusAsync(documentsList[0].DocumentId);

            CheckDocumentStatusResult(document, translateTo);
        }

        [RecordedTest]
        public async Task WrongSourceRightTarget()
        {
            Uri source = new("https://idont.ex.ist");
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());

            Assert.AreEqual("InvalidDocumentAccessLevel", ex.ErrorCode);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(TranslationStatus.ValidationFailed, operation.Status);
        }

        [RecordedTest]
        public async Task RightSourceWrongTarget()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = new("https://idont.ex.ist");

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());

            Assert.AreEqual("InvalidDocumentAccessLevel", ex.ErrorCode);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(TranslationStatus.ValidationFailed, operation.Status);
        }

        [RecordedTest]
        public async Task ContainerWithSupportedAndUnsupportedFiles()
        {
            var documentsList = new List<TestDocument>
            {
                new TestDocument("Document1.txt", "First english test document"),
                new TestDocument("File2.jpg", "jpg"),
            };

            Uri source = await CreateSourceContainerAsync(documentsList);
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync(PollingInterval);

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

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
        public async Task WrongDocumentEncoding()
        {
            var document = new List<TestDocument>
            {
                new TestDocument("Document1.txt", string.Empty),
            };

            Uri source = await CreateSourceContainerAsync(document);
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            AsyncPageable<DocumentStatusResult> documents = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(TranslationStatus.Failed, operation.Status);

            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(0, operation.DocumentsSucceeded);
            Assert.AreEqual(1, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);

            List<DocumentStatusResult> documentsList = await documents.ToEnumerableAsync();
            Assert.AreEqual(1, documentsList.Count);
            Assert.AreEqual(TranslationStatus.Failed, documentsList[0].Status);
            Assert.AreEqual(new DocumentTranslationErrorCode("WrongDocumentEncoding"), documentsList[0].Error.ErrorCode);
        }

        [RecordedTest]
        public async Task ExistingFileInTargetContainer()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = await CreateTargetContainerAsync(oneTestDocuments);

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            AsyncPageable<DocumentStatusResult> documents = await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(TranslationStatus.Failed, operation.Status);

            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(0, operation.DocumentsSucceeded);
            Assert.AreEqual(1, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);

            List<DocumentStatusResult> documentsList = await documents.ToEnumerableAsync();
            Assert.AreEqual(1, documentsList.Count);
            Assert.AreEqual(TranslationStatus.Failed, documentsList[0].Status);
            Assert.AreEqual(new DocumentTranslationErrorCode("TargetFileAlreadyExists"), documentsList[0].Error.ErrorCode);
        }

        private async Task PrintNotSucceededDocumentsAsync(DocumentTranslationOperation operation)
        {
            await foreach (var document in operation.GetValuesAsync())
            {
                if (document.Status != TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document: {document.DocumentId}");
                    Console.WriteLine($"    Status: {document.Status}");
                    Console.WriteLine($"    ErrorCode: {document.Error.ErrorCode}");
                    Console.WriteLine($"    Message: {document.Error.Message}");
                }
            }
        }

        private void CheckDocumentStatusResult(DocumentStatusResult document, string translateTo)
        {
            Assert.AreEqual(TranslationStatus.Succeeded, document.Status);
            Assert.IsTrue(document.HasCompleted);
            Assert.IsFalse(string.IsNullOrEmpty(document.DocumentId));
            Assert.IsNotNull(document.SourceDocumentUri);
            Assert.IsNotNull(document.TranslatedDocumentUri);
            Assert.AreEqual(100f, document.TranslationProgressPercentage);
            Assert.AreEqual(translateTo, document.TranslateTo);
            Assert.AreNotEqual(new DateTimeOffset(), document.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), document.LastModified);
        }
    }
}
