// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.IO;
using Azure.Storage.Blobs;

namespace Azure.AI.Translation.Document.Tests
{
    public class TranslationOperationLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationOperationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public TranslationOperationLiveTests(bool isAsync)
            : base(isAsync)
            //: base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SingleSourceSingleTargetTest(bool usetokenCredential)
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        [Ignore("Flaky test. Enable once service provides fix/information")]
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

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 3)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(3, operation.DocumentsTotal);
            Assert.AreEqual(3, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
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

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 2)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(2, operation.DocumentsTotal);
            Assert.AreEqual(2, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceSingleTargetWithPrefixTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(twoTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var source = new TranslationSource(sourceUri)
            {
                Prefix = "File"
            };

            var targets = new List<TranslationTarget> { new TranslationTarget(targetUri, "fr") };
            var input = new DocumentTranslationInput(source, targets);
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task SingleSourceSingleTargetWithSuffixTest()
        {
            Uri sourceUri = await CreateSourceContainerAsync(twoTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var source = new TranslationSource(sourceUri)
            {
                Suffix = "1.txt"
            };

            var targets = new List<TranslationTarget> { new TranslationTarget(targetUri, "fr") };
            var input = new DocumentTranslationInput(source, targets);
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
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

            AsyncPageable<DocumentStatusResult> documentsFromOperation = await operation.WaitForCompletionAsync();
            List<DocumentStatusResult> documentsFromOperationList = await documentsFromOperation.ToEnumerableAsync();

            Assert.AreEqual(1, documentsFromOperationList.Count);
            CheckDocumentStatus(documentsFromOperationList[0], translateTo);

            AsyncPageable<DocumentStatusResult> documentsFromGetDocStatuses = operation.GetDocumentStatusesAsync();
            List<DocumentStatusResult> documentsFromGetDocStatusesList = await documentsFromGetDocStatuses.ToEnumerableAsync();

            Assert.AreEqual(documentsFromOperationList[0].Status, documentsFromGetDocStatusesList[0].Status);
            Assert.AreEqual(documentsFromOperationList[0].Id, documentsFromGetDocStatusesList[0].Id);
            Assert.AreEqual(documentsFromOperationList[0].SourceDocumentUri, documentsFromGetDocStatusesList[0].SourceDocumentUri);
            Assert.AreEqual(documentsFromOperationList[0].TranslatedDocumentUri, documentsFromGetDocStatusesList[0].TranslatedDocumentUri);
            Assert.AreEqual(documentsFromOperationList[0].TranslationProgressPercentage, documentsFromGetDocStatusesList[0].TranslationProgressPercentage);
            Assert.AreEqual(documentsFromOperationList[0].TranslatedToLanguageCode, documentsFromGetDocStatusesList[0].TranslatedToLanguageCode);
            Assert.AreEqual(documentsFromOperationList[0].CreatedOn, documentsFromGetDocStatusesList[0].CreatedOn);
            Assert.AreEqual(documentsFromOperationList[0].LastModified, documentsFromGetDocStatusesList[0].LastModified);
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

            await operation.WaitForCompletionAsync();
            AsyncPageable<DocumentStatusResult> documents = operation.GetDocumentStatusesAsync();

            List<DocumentStatusResult> documentsList = await documents.ToEnumerableAsync();

            Assert.AreEqual(1, documentsList.Count);

            DocumentStatusResult document = await operation.GetDocumentStatusAsync(documentsList[0].Id);

            CheckDocumentStatus(document, translateTo);
        }

        [RecordedTest]
        public async Task WrongSourceRightTarget()
        {
            Uri source = new("https://idont.ex.ist");
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);
            Thread.Sleep(2000);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());

            Assert.AreEqual("InvalidRequest", ex.ErrorCode);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(DocumentTranslationStatus.ValidationFailed, operation.Status);
        }

        [RecordedTest]
        public async Task RightSourceWrongTarget()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = new("https://idont.ex.ist");

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());

            Assert.AreEqual("InvalidRequest", ex.ErrorCode);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(DocumentTranslationStatus.ValidationFailed, operation.Status);
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

            await operation.WaitForCompletionAsync();

            if (operation.DocumentsSucceeded < 1)
            {
                await PrintNotSucceededDocumentsAsync(operation);
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        public async Task EmptyDocumentError()
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

            AsyncPageable<DocumentStatusResult> documents = await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(DocumentTranslationStatus.Failed, operation.Status);

            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(0, operation.DocumentsSucceeded);
            Assert.AreEqual(1, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);

            List<DocumentStatusResult> documentsList = await documents.ToEnumerableAsync();
            Assert.AreEqual(1, documentsList.Count);
            Assert.AreEqual(DocumentTranslationStatus.Failed, documentsList[0].Status);
            Assert.AreEqual("InvalidRequest", documentsList[0].Error.Code);
        }

        [RecordedTest]
        public async Task ExistingFileInTargetContainer()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = await CreateTargetContainerAsync(oneTestDocuments);

            DocumentTranslationClient client = GetClient();

            var input = new DocumentTranslationInput(source, target, "fr");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());

            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(DocumentTranslationStatus.ValidationFailed, operation.Status);

            Assert.AreEqual(0, operation.DocumentsTotal);
            Assert.AreEqual(0, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCanceled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
        }

        [RecordedTest]
        [TestCase("Foo Bar", typeof(ArgumentException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase(null, typeof(ArgumentNullException))]
        public void DocumentTranslationOperationWithInvalidGuidTest(string invalidGuid, Type expectedException)
        {
            var client = GetClient();
            Assert.Throws(expectedException, () => new DocumentTranslationOperation(invalidGuid, client));
        }

        [RecordedTest]
        [TestCase("Foo Bar", typeof(ArgumentException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase(null, typeof(ArgumentNullException))]
        public async Task GetDocumentStatusWithInvalidGuidTest(string invalidGuid, Type expectedException)
        {
            var sourceUri = await CreateSourceContainerAsync(oneTestDocuments);
            var targetUri = await CreateTargetContainerAsync();
            string translateTo = "fr";

            var client = GetClient();

            var input = new DocumentTranslationInput(sourceUri, targetUri, translateTo);
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.Throws(expectedException, () => operation.GetDocumentStatus(invalidGuid));
        }

        [RecordedTest]
        [Ignore("Test is failing and needs to be recorded.  Tracking: #50669")]
        public async Task DocumentTranslationWithGlossary()
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            var targetUriAndClient = await CreateTargetContainerWithClientAsync();
            Uri target = targetUriAndClient.Item1;

            //We will need this client later for reading the output translated document
            BlobContainerClient targetContainerClient = targetUriAndClient.Item2;

            //Constructing and uploading glossary on the fly
            string glossaryName = "validGlossary.csv";

            //changing the word test --> glossaryTest
            string glossaryContent = "test, glossaryTest";

            var glossarySasUri = await CreateGlossaryAsync(new TestDocument (glossaryName, glossaryContent));

            //Perform Translation Process
            DocumentTranslationClient client = GetClient();
            var input = new DocumentTranslationInput(source, target, "es", new TranslationGlossary(glossarySasUri, "csv"));
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);
            await operation.WaitForCompletionAsync();

            //stream translated text into string
            var blobClient = targetContainerClient.GetBlobClient(oneTestDocuments[0].Name);
            var translatedResultStream = await blobClient.OpenReadAsync();
            StreamReader streamReader = new StreamReader(translatedResultStream);
            string translatedText = streamReader.ReadToEnd();

            //Assert glossary has taken effect
            var translatedTextSplitBySpaces = translatedText.Split(' ');
            CollectionAssert.Contains(translatedTextSplitBySpaces, "glossaryTest");
        }

        private async Task PrintNotSucceededDocumentsAsync(DocumentTranslationOperation operation)
        {
            await foreach (var document in operation.GetValuesAsync())
            {
                if (document.Status != DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document: {document.Id}");
                    Console.WriteLine($"    Status: {document.Status}");
                    Console.WriteLine($"    ErrorCode: {document.Error.Code}");
                    Console.WriteLine($"    Message: {document.Error.Message}");
                }
            }
        }

        private void CheckDocumentStatus(DocumentStatusResult document, string translateTo)
        {
            Assert.AreEqual(DocumentTranslationStatus.Succeeded, document.Status);
            Assert.IsFalse(string.IsNullOrEmpty(document.Id));
            Assert.IsNotNull(document.SourceDocumentUri);
            Assert.IsNotNull(document.TranslatedDocumentUri);
            Assert.AreEqual(100f, document.TranslationProgressPercentage);
            Assert.AreEqual(translateTo, document.TranslatedToLanguageCode);
            Assert.AreNotEqual(new DateTimeOffset(), document.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), document.LastModified);
        }
    }
}
