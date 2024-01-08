// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
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
        public async Task TestOperation()
        {
            var client = new DocumentTranslationClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            string testInputFileName = "TestInput.txt";
            string testOutputFileName = "TestOutput.txt";
            string filePath = Path.Combine("TestData", testInputFileName);
            using Stream fileStream = File.OpenRead(filePath);

            var translateContent = new DocumentTranslateContent(BinaryData.FromStream(fileStream));
            translateContent.Filename = testInputFileName;
            var response = await client.DocumentTranslateAsync("hi", translateContent).ConfigureAwait(false);
            File.WriteAllBytes(Path.Combine("TestData", testOutputFileName), response.Value.ToArray());
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
