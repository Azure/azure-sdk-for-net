// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.Document.Tests
{
    public partial class SingleDocumentTranslationClientLiveTests : DocumentTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleDocumentTranslationClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public SingleDocumentTranslationClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Enable this test when this is fixed => https://github.com/Azure/azure-sdk-for-net/issues/41674
        //[RecordedTest]
        //[TestCase(false)]
        //[TestCase(true)]
        public async Task Translate_TextDocumentAsync(bool usetokenCredential)
        {
            var client = GetClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html");
            var response = await client.DocumentTranslateAsync("hi", sourceDocument).ConfigureAwait(false);
            var requestString = File.ReadAllText(filePath);
            var responseString = Encoding.UTF8.GetString(response.Value.ToArray());
            Assert.AreNotEqual(requestString, responseString);
        }

        // Enable this test when this is fixed => https://github.com/Azure/azure-sdk-for-net/issues/41674
        //[RecordedTest]
        //[TestCase(false)]
        //[TestCase(true)]
        public async Task Translate_TextDocument_Single_CsvGlossary(bool usetokenCredential)
        {
            var client = GetClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html");
            filePath = Path.Combine("TestData", "test-glossary.csv");
            using Stream glossaryStream = File.OpenRead(filePath);
            var sourceGlossaries = new List<MultipartFormFileData>()
            {
                new(Path.GetFileName(filePath), BinaryData.FromStream(glossaryStream), "text/csv")
            };

            var response = await client.DocumentTranslateAsync("hi", sourceDocument, sourceGlossaries).ConfigureAwait(false);

            var outputString = Encoding.UTF8.GetString(response.Value.ToArray());

            Assert.IsTrue(outputString.ToLowerInvariant().Contains("test"), $"'{outputString}' does not contain glossary 'test'");
        }

        // Enable this test when this is fixed => https://github.com/Azure/azure-sdk-for-net/issues/41674
        //[RecordedTest]
        //[TestCase(false)]
        //[TestCase(true)]
        public async Task Translate_TextDocument_Multiple_CsvGlossary(bool usetokenCredential)
        {
            var client = GetClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html");
            filePath = Path.Combine("TestData", "test-glossary.csv");
            using Stream glossaryStream = File.OpenRead(filePath);
            var sourceGlossaries = new List<MultipartFormFileData>()
            {
                new(Path.GetFileName(filePath), BinaryData.FromStream(glossaryStream), "text/csv"),
                new(Path.GetFileName(filePath), BinaryData.FromStream(glossaryStream), "text/csv")
            };

            try
            {
                var response = await client.DocumentTranslateAsync("hi", sourceDocument, sourceGlossaries).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(400, ex.Status);
            }
        }
    }
}
