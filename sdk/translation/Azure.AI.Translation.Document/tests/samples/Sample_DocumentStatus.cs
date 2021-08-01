// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public void DocumentStatus()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>")
#else
            DocumentTranslationSampleHelper.TestEnvironment = TestEnvironment;
            Uri sourceUri = DocumentTranslationSampleHelper.CreateSourceContainer(DocumentTranslationSampleHelper.oneTestDocuments);
            Uri targetUri = DocumentTranslationSampleHelper.CreateTargetContainer();
#endif

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");
            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new(1000);

            var documentscompleted = new HashSet<string>();

            while (true)
            {
                operation.UpdateStatus();

                Pageable<DocumentStatus> documentsStatus = operation.GetAllDocumentStatuses();
                foreach (DocumentStatus docStatus in documentsStatus)
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
                    Thread.Sleep(pollingInterval);
                }
            }
        }
    }
}
