// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public async Task DocumentStatusAsync()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
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

            var documentscompleted = new HashSet<string>();

            while (true)
            {
                await operation.UpdateStatusAsync();

                AsyncPageable<DocumentStatusResult> documentsStatus = operation.GetDocumentStatusesAsync();
                await foreach (DocumentStatusResult docStatus in documentsStatus)
                {
                    if (documentscompleted.Contains(docStatus.Id))
                        continue;
                    if (docStatus.Status == DocumentTranslationStatus.Succeeded || docStatus.Status == DocumentTranslationStatus.Failed)
                    {
                        documentscompleted.Add(docStatus.Id);
                        Console.WriteLine($"Document {docStatus.TranslatedDocumentUri} completed with status {docStatus.Status}");
                    }
                }

                if (operation.HasCompleted)
                {
                    break;
                }
                else
                {
                    if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                    {
                        pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                    }
                    await Task.Delay(pollingInterval);
                }
            }
        }
    }
}
