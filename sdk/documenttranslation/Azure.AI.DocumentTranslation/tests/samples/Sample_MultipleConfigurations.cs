// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public void MultipleConfigurations()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUrl1 = new Uri("");
            Uri sourceUrl2 = new Uri("");
            Uri targetUrl1_1 = new Uri("");
            Uri targetUrl1_2 = new Uri("");
            Uri targetUrl2_1 = new Uri("");
            Uri targetUrl2_2 = new Uri("");
            Uri glossaryUrl = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:MultipleConfigurations

            var configuration1 = new TranslationConfiguration(sourceUrl1, targetUrl1_1, "es", new TranslationGlossary(glossaryUrl));
            configuration1.AddTarget(targetUrl1_2, "it");

            var configuration2 = new TranslationConfiguration(sourceUrl2, targetUrl2_1, "it");
            configuration2.AddTarget(targetUrl2_2, "es", new TranslationGlossary(glossaryUrl));

            var inputs = new List<TranslationConfiguration>()
                {
                    configuration1,
                    configuration2
                };

            DocumentTranslationOperation operation = client.StartTranslation(inputs);

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
