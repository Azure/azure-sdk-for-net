// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        [SyncOnly]
        public void OperationsHistory()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            int operationsCount = 0;
            int totalDocs = 0;
            int docsCanceled = 0;
            int docsSucceeded = 0;
            int docsFailed = 0;

            TimeSpan pollingInterval = new(1000);

            DateTimeOffset lastWeekTimestamp = DateTimeOffset.Now.AddDays(-7);

            var options = new GetTranslationStatusesOptions
            {
                CreatedAfter = lastWeekTimestamp
            };

            foreach (TranslationStatusResult translationStatus in client.GetTranslationStatuses(options))
            {
                if (translationStatus.Status == DocumentTranslationStatus.NotStarted ||
                    translationStatus.Status == DocumentTranslationStatus.Running)
                {
                    DocumentTranslationOperation operation = new DocumentTranslationOperation(translationStatus.Id, client);
                    operation.UpdateStatus();

                    while (!operation.HasCompleted)
                    {
                        if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                        {
                            pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                        }

                        Thread.Sleep(pollingInterval);
                        operation.UpdateStatus();
                    }
                }

                operationsCount++;
                totalDocs += translationStatus.DocumentsTotal;
                docsCanceled += translationStatus.DocumentsCanceled;
                docsSucceeded += translationStatus.DocumentsSucceeded;
                docsFailed += translationStatus.DocumentsFailed;
            }

            Console.WriteLine($"# of operations: {operationsCount}");
            Console.WriteLine($"Total Documents: {totalDocs}");
            Console.WriteLine($"Succeeded Document: {docsSucceeded}");
            Console.WriteLine($"Failed Document: {docsFailed}");
            Console.WriteLine($"Cancelled Documents: {docsCanceled}");
        }
    }
}
