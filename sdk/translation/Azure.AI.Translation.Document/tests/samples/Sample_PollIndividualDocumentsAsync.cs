// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        [AsyncOnly]
        public async Task PollIndividualDocumentsAsync()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:PollIndividualDocumentsAsync
#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");
#else
            Uri sourceUri = await CreateSourceContainerAsync(oneTestDocuments);
            Uri targetUri = await CreateTargetContainerAsync();
#endif

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            TimeSpan pollingInterval = new(1000);

            await foreach (DocumentStatusResult document in operation.GetDocumentStatusesAsync())
            {
                Console.WriteLine($"Polling Status for document{document.SourceDocumentUri}");

                Response<DocumentStatusResult> responseDocumentStatus = await operation.GetDocumentStatusAsync(document.Id);

                while (responseDocumentStatus.Value.Status != DocumentTranslationStatus.Failed &&
                          responseDocumentStatus.Value.Status != DocumentTranslationStatus.Succeeded)
                {
                    if (responseDocumentStatus.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                    {
                        pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                    }

                    await Task.Delay(pollingInterval);
                    responseDocumentStatus = await operation.GetDocumentStatusAsync(document.Id);
                }

                if (responseDocumentStatus.Value.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
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
    }
}
