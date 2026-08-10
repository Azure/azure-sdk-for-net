// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        [SyncOnly]
        public void StartTranslationWithCustomModel()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartTranslationWithCustomModel
#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");
#else
            Uri sourceUri = CreateSourceContainer(oneTestDocuments);
            Uri targetUri = CreateTargetContainer();
#endif
            // Set the deployment name of your custom translation model on the target.
            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");
            input.Targets[0].DeploymentName = "<custom translation model deployment name>";

            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new(1000);
            while (true)
            {
                operation.UpdateStatus();
                if (operation.HasCompleted)
                {
                    break;
                }

                if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                {
                    pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                }
                Thread.Sleep(pollingInterval);
            }

            foreach (DocumentStatusResult document in operation.GetValues())
            {
                Console.WriteLine($"Document with Id: {document.Id}");
                Console.WriteLine($"  Status: {document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Deployment name used: {document.DeploymentName}");
                    Console.WriteLine($"  Characters charged: {document.CharactersCharged}");
                }
                else
                {
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"  Error Code: {document.Error.Code}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }
            #endregion
        }

        [Test]
        public async Task SingleDocumentTranslationWithCustomModel()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:SingleDocumentTranslationWithCustomModel
            try
            {
                string filePath = Path.Combine("TestData", "test-input.txt");
                using Stream fileStream = File.OpenRead(filePath);
                var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
                DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);

                // Provide the custom model deployment name for the translation.
                Response<BinaryData> response = await client.TranslateAsync(
                    "hi",
                    content,
                    deploymentName: "<custom translation model deployment name>").ConfigureAwait(false);

                string responseString = Encoding.UTF8.GetString(response.Value.ToArray());
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
