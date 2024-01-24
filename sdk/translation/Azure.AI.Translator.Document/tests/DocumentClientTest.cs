// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.Translator.Document.Tests
{
    public class DocumentClientTest: RecordedTestBase<DocumentClientTestEnvironment>
    {
        public DocumentClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public void TranslateTextDocument()
        {
            var client = new DocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            string testOutputFileName = "test-output.txt";
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var translateContent = new DocumentContent(new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html"));
            var response = client.DocumentTranslate("hi", translateContent);
            File.WriteAllBytes(Path.Combine("D:\\Test\\SDT", testOutputFileName), response.Value.ToArray());
        }

        [RecordedTest]
        public async Task TranslateTextDocumentWithCsvGlossary()
        {
            var client = new DocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            string testOutputFileName = "test-glossay-output.txt";
            string filePath = Path.Combine("TestData", "test-input.txt");
            using Stream fileStream = File.OpenRead(filePath);

            var translateContent = new DocumentContent(new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html"));
            filePath = Path.Combine("TestData", "test-glossary.csv");
            using Stream glossaryStream = File.OpenRead(filePath);
            translateContent.Glossary.Add(new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(glossaryStream), "text/csv"));
            var response = await client.DocumentTranslateAsync("hi", translateContent).ConfigureAwait(false);
            File.WriteAllBytes(Path.Combine("D:\\Test\\SDT", testOutputFileName), response.Value.ToArray());
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
