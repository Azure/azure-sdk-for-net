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
    public class SingleDocumentTranslationClientLiveTests: RecordedTestBase<DocumentClientTestEnvironment>
    {
        public SingleDocumentTranslationClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public void Translate_TextDocument()
        {
            var client = new SingleDocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html");
            var response = client.DocumentTranslate("hi", sourceDocument);
            var requestString = File.ReadAllText(filePath);
            var responseString = Encoding.UTF8.GetString(response.Value.ToArray());
            Assert.AreNotEqual(requestString, responseString);
        }

        [RecordedTest]
        public async Task Translate_TextDocument_Single_CsvGlossary()
        {
            var client = new SingleDocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
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

        [RecordedTest]
        public async Task Translate_TextDocument_Multiple_CsvGlossary()
        {
            var client = new SingleDocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
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
