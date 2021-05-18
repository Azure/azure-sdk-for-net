// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        [Ignore("Samples not working yet")]
        public async Task PollIndividualDocumentsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:PollIndividualDocumentsAsync
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            TimeSpan pollingInterval = new(1000);

            await foreach (DocumentStatusResult document in operation.GetAllDocumentStatusesAsync())
            {
                Console.WriteLine($"Polling Status for document{document.SourceDocumentUri}");

                Response<DocumentStatusResult> responseDocumentStatus = await operation.GetDocumentStatusAsync(document.DocumentId);

                while (!responseDocumentStatus.Value.HasCompleted)
                {
                    if (responseDocumentStatus.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                    {
                        pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                    }

                    await Task.Delay(pollingInterval);
                    responseDocumentStatus = await operation.GetDocumentStatusAsync(document.DocumentId);
                }

                if (responseDocumentStatus.Value.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }

            #endregion
        }
    }
}
