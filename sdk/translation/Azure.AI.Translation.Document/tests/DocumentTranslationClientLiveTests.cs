// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    public partial class DocumentTranslationClientLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentTranslationClientLiveTests(bool isAsync)
            : base(isAsync)
            //: base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetTranslationStatusesTestWithSourceInputOptions(bool usetokenCredential)
        {
            Uri sourceUri = await CreateSourceContainerAsync(oneTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            TranslationSource translationSource = new TranslationSource(sourceUri, "en");
            TranslationTarget translationTarget = new TranslationTarget(targetUri, "fr");
            List<TranslationTarget> targets = new List<TranslationTarget> { translationTarget };
            var input = new DocumentTranslationInput(translationSource, targets);
            var translationOp = await client.StartTranslationAsync(input);
            await translationOp.WaitForCompletionAsync();

            // list translations with ID filter
            var options = new GetTranslationStatusesOptions
            {
                Ids = { translationOp.Id }
            };
            var translations = await client.GetTranslationStatusesAsync(options: options).ToEnumerableAsync();

            // assert
            Assert.GreaterOrEqual(translations.Count, 1);
            TranslationStatusResult oneTranslation = translations[0];
            Assert.That(oneTranslation.CreatedOn, Is.Not.EqualTo(new DateTimeOffset()));
            Assert.That(oneTranslation.LastModified, Is.Not.EqualTo(new DateTimeOffset()));
            Assert.GreaterOrEqual(oneTranslation.DocumentsCanceled, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsFailed, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsInProgress, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsNotStarted, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsSucceeded, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsTotal, 0);

            if (oneTranslation.Status == DocumentTranslationStatus.Succeeded)
            {
                Assert.Greater(oneTranslation.TotalCharactersCharged, 0);
            }
            else
            {
                Assert.That(oneTranslation.TotalCharactersCharged, Is.EqualTo(0));
            }
        }

        [RecordedTest]
        public void ClientCannotAuthenticateWithFakeApiKey()
        {
            DocumentTranslationClient client = GetClient(credential: new AzureKeyCredential("fakeKey"));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetSupportedFormatsAsync("document"));

            Assert.That(ex.ErrorCode, Is.EqualTo("401"));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDocumentFormatsTest(bool usetokenCredential)
        {
            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            var documentFormats = await client.GetSupportedFormatsAsync(FileFormatType.Document);

            Assert.GreaterOrEqual(documentFormats.Value.Value.Count, 0);
            foreach (DocumentTranslationFileFormat fileFormat in documentFormats.Value.Value)
            {
                Assert.That(string.IsNullOrEmpty(fileFormat.Format), Is.False);
                Assert.IsNotNull(fileFormat.FileExtensions);
                Assert.IsNotNull(fileFormat.FormatVersions);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetGlossaryFormatsTest(bool usetokenCredential)
        {
            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            var glossaryFormats = await client.GetSupportedFormatsAsync(FileFormatType.Glossary);

            Assert.GreaterOrEqual(glossaryFormats.Value.Value.Count, 0);
            foreach (DocumentTranslationFileFormat glossaryFormat in glossaryFormats.Value.Value)
            {
                Assert.That(string.IsNullOrEmpty(glossaryFormat.Format), Is.False);
                Assert.IsNotNull(glossaryFormat.FileExtensions);
                Assert.IsNotNull(glossaryFormat.FormatVersions);

                if (glossaryFormat.Format == "XLIFF")
                {
                    Assert.That(string.IsNullOrEmpty(glossaryFormat.DefaultFormatVersion), Is.False);
                }
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetTranslationStatusesTest(bool usetokenCredential)
        {
            Uri source = await CreateSourceContainerAsync(oneTestDocuments);
            Uri target = await CreateTargetContainerAsync();

            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            var input = new DocumentTranslationInput(source, target, "fr");
            await client.StartTranslationAsync(input);

            List<TranslationStatusResult> translations = await client.GetTranslationStatusesAsync().ToEnumerableAsync();

            Assert.GreaterOrEqual(translations.Count, 1);
            TranslationStatusResult oneTranslation = translations[0];
            Assert.That(oneTranslation.CreatedOn, Is.Not.EqualTo(new DateTimeOffset()));
            Assert.That(oneTranslation.LastModified, Is.Not.EqualTo(new DateTimeOffset()));
            Assert.GreaterOrEqual(oneTranslation.DocumentsCanceled, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsFailed, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsInProgress, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsNotStarted, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsSucceeded, 0);
            Assert.GreaterOrEqual(oneTranslation.DocumentsTotal, 0);

            if (oneTranslation.Status == DocumentTranslationStatus.Succeeded)
            {
                Assert.Greater(oneTranslation.TotalCharactersCharged, 0);
            }
            else
            {
                Assert.That(oneTranslation.TotalCharactersCharged, Is.EqualTo(0));
            }
        }
    }
}
