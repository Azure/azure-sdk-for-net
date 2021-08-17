// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    [LiveOnly]
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
            int docsCancelled = 0;
            int docsSucceeded = 0;
            int docsFailed = 0;

            foreach (TranslationStatus translationStatus in client.GetAllTranslationStatuses())
            {
                if (translationStatus.Status == DocumentTranslationStatus.NotStarted ||
                    translationStatus.Status == DocumentTranslationStatus.Running)
                {
                    DocumentTranslationOperation operation = new DocumentTranslationOperation(translationStatus.Id, client);
                    operation.WaitForCompletion();
                }

                operationsCount++;
                totalDocs += translationStatus.DocumentsTotal;
                docsCancelled += translationStatus.DocumentsCancelled;
                docsSucceeded += translationStatus.DocumentsSucceeded;
                docsFailed += translationStatus.DocumentsFailed;
            }

            Console.WriteLine($"# of operations: {operationsCount}");
            Console.WriteLine($"Total Documents: {totalDocs}");
            Console.WriteLine($"Succeeded Document: {docsSucceeded}");
            Console.WriteLine($"Failed Document: {docsFailed}");
            Console.WriteLine($"Cancelled Documents: {docsCancelled}");
        }
    }
}
