// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.DocumentTranslation.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public void StartTranslation()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUrl = new Uri("");
            Uri targetUrl = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartTranslation

            var input = new TranslationConfiguration(sourceUrl, targetUrl, "es");

            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new TimeSpan(1000);

            while (!operation.HasCompleted)
            {
                Thread.Sleep(pollingInterval);
                operation.UpdateStatus();

                Console.WriteLine($"  Status: {operation.Status}");
                Console.WriteLine($"  Created on: {operation.CreatedOn}");
                Console.WriteLine($"  Last modified: {operation.LastModified}");
                Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
                Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
                Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
                Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
                Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
            }

            foreach (DocumentStatusDetail document in operation.GetValues())
            {
                Console.WriteLine($"Document with Id: {document.DocumentId}");
                Console.WriteLine($"  Status:{document.Status}");
                if (document.Status == TranslationStatus.Succeeded)
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
