// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task StartTranslationAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartTranslationAsync
#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>")
#else
            DocumentTranslationSampleHelper.TestEnvironment = TestEnvironment;
            Uri sourceUri = await DocumentTranslationSampleHelper.CreateSourceContainerAsync(DocumentTranslationSampleHelper.oneTestDocuments);
            Uri targetUri = await DocumentTranslationSampleHelper.CreateTargetContainerAsync();
#endif
            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

            DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

#if SNIPPET
            Console.WriteLine($"  Status: {operation.Status}");
            Console.WriteLine($"  Created on: {operation.CreatedOn}");
            Console.WriteLine($"  Last modified: {operation.LastModified}");
            Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
            Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
            Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
            Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
            Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
#else
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(1, operation.DocumentsTotal);
            Assert.AreEqual(1, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
            Assert.AreEqual(0, operation.DocumentsCancelled);
            Assert.AreEqual(0, operation.DocumentsInProgress);
            Assert.AreEqual(0, operation.DocumentsNotStarted);
#endif

            await foreach (DocumentStatus document in operation.Value)
            {
                Console.WriteLine($"Document with Id: {document.Id}");
                Console.WriteLine($"  Status:{document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language: {document.TranslatedTo}.");
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
