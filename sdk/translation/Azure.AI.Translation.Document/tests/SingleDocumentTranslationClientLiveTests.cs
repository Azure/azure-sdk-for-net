// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Translation.Document;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

namespace Azure.AI.Translation.Document.Tests
{
    // These tests use multipart request body and recommendation was to run in live mode only.
    // Here is the issue created: https://github.com/Azure/azure-sdk-for-net/issues/41674
    [LiveOnly]
    public class SingleDocumentTranslationClientLiveTests : RecordedTestBase<DocumentTranslationTestEnvironment>
    {
        public SingleDocumentTranslationClientLiveTests(bool isAsync)
        : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected SingleDocumentTranslationClient GetSingleDocumentTranslationClient(
            AzureKeyCredential credential = default,
            DocumentTranslationClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new DocumentTranslationClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id", "X-RequestId", "apim-request-id" },
                    IsLoggingContentEnabled = true
                }
            };

            if (useTokenCredential)
            {
                return InstrumentClient(new SingleDocumentTranslationClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                return InstrumentClient(new SingleDocumentTranslationClient(endpoint, credential, InstrumentClientOptions(options)));
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [Ignore("Sync API test does not work because of MultipartFormDataRequestContent, enable it once it is resolved")]
        public async Task Translate_TextDocumentAsync(bool usetokenCredential)
        {
            var client = GetSingleDocumentTranslationClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
            DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);
            var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);
            var requestString = File.ReadAllText(filePath);
            var responseString = Encoding.UTF8.GetString(response.Value.ToArray());
            Assert.AreNotEqual(requestString, responseString);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [Ignore("Sync API test does not work because of MultipartFormDataRequestContent, enable it once it is resolved")]
        public async Task Translate_TextDocument_Single_CsvGlossary(bool usetokenCredential)
        {
            var client = GetSingleDocumentTranslationClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);
            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");

            filePath = Path.Combine("TestData", "test-glossary.csv");
            using Stream glossaryStream = File.OpenRead(filePath);
            var sourceGlossaries = new List<MultipartFormFileData>()
            {
                new(Path.GetFileName(filePath), glossaryStream, "text/csv")
            };
            DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument, sourceGlossaries);

            var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);

            var outputString = Encoding.UTF8.GetString(response.Value.ToArray());

            Assert.IsTrue(outputString.ToLowerInvariant().Contains("test"), $"'{outputString}' does not contain glossary 'test'");
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [Ignore("Sync API test does not work because of MultipartFormDataRequestContent, enable it once it is resolved")]
        public async Task Translate_TextDocument_Multiple_CsvGlossary(bool usetokenCredential)
        {
            var client = GetSingleDocumentTranslationClient(useTokenCredential: usetokenCredential);
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);
            var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");

            filePath = Path.Combine("TestData", "test-glossary.csv");
            using Stream glossaryStream = File.OpenRead(filePath);
            var sourceGlossaries = new List<MultipartFormFileData>()
            {
                new(Path.GetFileName(filePath), glossaryStream, "text/csv"),
                new(Path.GetFileName(filePath), glossaryStream, "text/csv")
            };
            DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument, sourceGlossaries);

            try
            {
                var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(400, ex.Status);
            }
        }
    }
}
