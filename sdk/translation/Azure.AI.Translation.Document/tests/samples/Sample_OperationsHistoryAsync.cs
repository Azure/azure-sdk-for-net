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
        public async Task OperationsHistoryAsync()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:OperationsHistoryAsync

            int operationsCount = 0;
            int totalDocs = 0;
            int docsCanceled = 0;
            int docsSucceeded = 0;
            int docsFailed = 0;

            DateTimeOffset lastWeekTimestamp = DateTimeOffset.Now.AddDays(-7);

            var options = new GetTranslationStatusesOptions
            {
                CreatedAfter = lastWeekTimestamp
            };

            await foreach (TranslationStatusResult translationStatus in client.GetTranslationStatusesAsync(options))
            {
                if (translationStatus.Status == DocumentTranslationStatus.NotStarted ||
                    translationStatus.Status == DocumentTranslationStatus.Running)
                {
                    DocumentTranslationOperation operation = new DocumentTranslationOperation(translationStatus.Id, client);
                    await operation.WaitForCompletionAsync();
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
            Console.WriteLine($"Canceled Documents: {docsCanceled}");

            #endregion
        }
    }
}
