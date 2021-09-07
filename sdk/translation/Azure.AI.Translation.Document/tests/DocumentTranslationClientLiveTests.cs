// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        {
        }

        [RecordedTest]
        public void ClientCannotAuthenticateWithFakeApiKey()
        {
            DocumentTranslationClient client = GetClient(credential: new AzureKeyCredential("fakeKey"));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetSupportedDocumentFormatsAsync());

            Assert.AreEqual("401", ex.ErrorCode);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDocumentFormatsTest(bool usetokenCredential)
        {
            DocumentTranslationClient client = GetClient(useTokenCredential: usetokenCredential);

            var documentFormats = await client.GetSupportedDocumentFormatsAsync();

            Assert.GreaterOrEqual(documentFormats.Value.Count, 0);
            foreach (DocumentTranslationFileFormat fileFormat in documentFormats.Value)
            {
                Assert.IsFalse(string.IsNullOrEmpty(fileFormat.Format));
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

            var glossaryFormats = await client.GetSupportedGlossaryFormatsAsync();

            Assert.GreaterOrEqual(glossaryFormats.Value.Count, 0);
            foreach (DocumentTranslationFileFormat glossaryFormat in glossaryFormats.Value)
            {
                Assert.IsFalse(string.IsNullOrEmpty(glossaryFormat.Format));
                Assert.IsNotNull(glossaryFormat.FileExtensions);
                Assert.IsNotNull(glossaryFormat.FormatVersions);

                if (glossaryFormat.Format == "XLIFF")
                {
                    Assert.IsFalse(string.IsNullOrEmpty(glossaryFormat.DefaultFormatVersion));
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
            Assert.AreNotEqual(new DateTimeOffset(), oneTranslation.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), oneTranslation.LastModified);
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
                Assert.AreEqual(0, oneTranslation.TotalCharactersCharged);
            }
        }
    }
}
