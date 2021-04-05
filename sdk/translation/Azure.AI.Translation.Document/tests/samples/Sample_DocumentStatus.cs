﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
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
        public void DocumentStatus()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUri = new Uri("");
            Uri targetUri = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");
            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new(1000);

            var documentscompleted = new HashSet<string>();

            while (!operation.HasCompleted)
            {
                if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                {
                    pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                }

                Thread.Sleep(pollingInterval);
                operation.UpdateStatus();

                Pageable<DocumentStatusResult> documentsStatus = operation.GetAllDocumentStatuses();
                foreach (DocumentStatusResult docStatus in documentsStatus)
                {
                    if (documentscompleted.Contains(docStatus.DocumentId))
                        continue;
                    if (docStatus.Status == TranslationStatus.Succeeded || docStatus.Status == TranslationStatus.Failed)
                    {
                        documentscompleted.Add(docStatus.DocumentId);
                        Console.WriteLine($"Document {docStatus.TranslatedDocumentUri} completed with status ${docStatus.Status}");
                    }
                }
            }
        }
    }
}
