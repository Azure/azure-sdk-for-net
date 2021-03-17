// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task DocumentStatusAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUrl = new Uri("");
            Uri targetUrl = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var input = new TranslationConfiguration(sourceUrl, targetUrl, "es");
            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            var documentscompleted = new HashSet<string>();

            while (!operation.HasCompleted)
            {
                await operation.UpdateStatusAsync();

                AsyncPageable<DocumentStatusDetail> documentsStatus = operation.GetAllDocumentsStatusAsync();
                await foreach (DocumentStatusDetail docStatus in documentsStatus)
                {
                    if (documentscompleted.Contains(docStatus.DocumentId))
                        continue;
                    if (docStatus.Status == TranslationStatus.Succeeded || docStatus.Status == TranslationStatus.Failed)
                    {
                        documentscompleted.Add(docStatus.DocumentId);
                        Console.WriteLine($"Document {docStatus.LocationUri} completed with status ${docStatus.Status}");
                    }
                }
            }
        }
    }
}
