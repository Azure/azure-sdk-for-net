// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task PollIndividualDocumentsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUri = new Uri("");
            Uri targetUri = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var input = new TranslationConfiguration(sourceUri, targetUri, "es");

            #region Snippet:PollIndividualDocumentsAsync

            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            TimeSpan pollingInterval = new TimeSpan(1000);

            AsyncPageable<DocumentStatusDetail> documents = operation.GetAllDocumentsStatusAsync();
            await foreach (DocumentStatusDetail document in documents)
            {
                Console.WriteLine($"Polling Status for document{document.LocationUri}");

                Response<DocumentStatusDetail> status = await operation.GetDocumentStatusAsync(document.DocumentId);

                while (!status.Value.HasCompleted)
                {
                    await Task.Delay(pollingInterval);
                    status = await operation.GetDocumentStatusAsync(document.DocumentId);
                }

                if (status.Value.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Location: {document.LocationUri}");
                    Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
                }
                else
                {
                    Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }

            #endregion
        }
    }
}
