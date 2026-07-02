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
        public void StartTranslationWithImageTranslation()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartTranslationWithImageTranslation
#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");
#else
            Uri sourceUri = CreateSourceContainer(oneTestDocuments);
            Uri targetUri = CreateTargetContainer();
#endif
            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

            // Enable translation of text embedded within images for the batch.
            DocumentTranslationOperation operation = client.StartTranslation(new[] { input }, translateTextWithinImage: true);

            TimeSpan pollingInterval = new(1000);
            while (true)
            {
                operation.UpdateStatus();
                if (operation.HasCompleted)
                {
                    break;
                }

                if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
                {
                    pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
                }
                Thread.Sleep(pollingInterval);
            }

            foreach (DocumentStatusResult document in operation.GetValues())
            {
                Console.WriteLine($"Document with Id: {document.Id}");
                Console.WriteLine($"  Status: {document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Characters charged: {document.CharactersCharged}");
                    // Image scan usage is reported when image translation is enabled.
                    Console.WriteLine($"  Total image scans succeeded: {document.TotalImageScansSucceeded}");
                    Console.WriteLine($"  Total image scans failed: {document.TotalImageScansFailed}");
                    Console.WriteLine($"  Images charged: {document.ImageCharged}");
                    Console.WriteLine($"  Characters detected within images: {document.ImageCharacterDetected}");
                }
                else
                {
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"  Error Code: {document.Error.Code}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }
            #endregion
        }
    }
}
