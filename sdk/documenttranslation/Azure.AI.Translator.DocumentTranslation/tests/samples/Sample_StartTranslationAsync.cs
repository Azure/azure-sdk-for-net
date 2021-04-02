// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Translator.DocumentTranslation.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.DocumentTranslation.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        [Ignore("Samples not working yet")]
        public async Task StartTranslationAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");

            #region Snippet:StartTranslationAsync

            //@@ Uri sourceUri = <source SAS URI>;
            //@@ Uri targetUri = <target SAS URI>;

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            Response<AsyncPageable<DocumentStatusResult>> operationResult = await operation.WaitForCompletionAsync();

            Console.WriteLine($"  Status: {operation.Status}");
            Console.WriteLine($"  Created on: {operation.CreatedOn}");
            Console.WriteLine($"  Last modified: {operation.LastModified}");
            Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
            Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
            Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
            Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
            Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

            await foreach (DocumentStatusResult document in operationResult.Value)
            {
                Console.WriteLine($"Document with Id: {document.DocumentId}");
                Console.WriteLine($"  Status:{document.Status}");
                if (document.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
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
