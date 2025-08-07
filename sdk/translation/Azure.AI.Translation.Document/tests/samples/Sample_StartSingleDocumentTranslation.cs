// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.AI.Translation.Document.Tests;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Translation.Document.Samples
{
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        public void CreateSingleDocumentTranslationClient()
        {
            #region Snippet:CreateSingleDocumentTranslationClient

#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [Test]
        public async Task StartSingleDocumentTranslation()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartSingleDocumentTranslation
            try
            {
                string filePath = Path.Combine("TestData", "test-input.txt");
                using Stream fileStream = File.OpenRead(filePath);
                var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
                DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);
                var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);

                var requestString = File.ReadAllText(filePath);
                var responseString = Encoding.UTF8.GetString(response.Value.ToArray());

                Console.WriteLine($"Request string for translation: {requestString}");
                Console.WriteLine($"Response string after translation: {responseString}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }
    }
}
