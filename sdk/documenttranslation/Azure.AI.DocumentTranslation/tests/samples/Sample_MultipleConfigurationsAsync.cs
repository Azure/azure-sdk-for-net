// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task MultipleConfigurationsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUri1 = new Uri("");
            Uri sourceUri2 = new Uri("");
            Uri targetUri1_1 = new Uri("");
            Uri targetUri1_2 = new Uri("");
            Uri targetUri2_1 = new Uri("");
            Uri targetUri2_2 = new Uri("");
            Uri glossaryUrl = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:MultipleConfigurationsAsync

            var configuration1 = new TranslationConfiguration(sourceUri1, targetUri1_1, "es", new TranslationGlossary(glossaryUrl));
            configuration1.AddTarget(targetUri1_2, "it");

            var configuration2 = new TranslationConfiguration(sourceUri2, targetUri2_1, "it");
            configuration2.AddTarget(targetUri2_2, "es", new TranslationGlossary(glossaryUrl));

            var inputs = new List<TranslationConfiguration>()
                {
                    configuration1,
                    configuration2
                };

            DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

            TimeSpan pollingInterval = new TimeSpan(1000);

            while (!operation.HasCompleted)
            {
                await Task.Delay(pollingInterval);
                await operation.UpdateStatusAsync();

                Console.WriteLine($"  Status: {operation.Status}");
                Console.WriteLine($"  Created on: {operation.CreatedOn}");
                Console.WriteLine($"  Last modified: {operation.LastModified}");
                Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
                Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
                Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
                Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
                Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
            }

            await foreach (DocumentStatusDetail document in operation.GetValuesAsync())
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
