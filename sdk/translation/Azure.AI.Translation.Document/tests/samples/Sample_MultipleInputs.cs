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
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        [SyncOnly]
        public void MultipleInputs()
        {
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

#if SNIPPET
            Uri source1SasUri = new Uri("<source1 SAS URI>");
            Uri source2SasUri = new Uri("<source2 SAS URI>");
            Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
            Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
            Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
            Uri frenchGlossarySasUri = new Uri("<french glossary SAS URI>");
#else
            Uri source1SasUri = CreateSourceContainer(oneTestDocuments);
            Uri source2SasUri = CreateSourceContainer(new List<TestDocument> { new TestDocument("Document2.txt", "Second english test document") });
            Uri frenchTargetSasUri = CreateTargetContainer();
            Uri arabicTargetSasUri = CreateTargetContainer();
            Uri spanishTargetSasUri = CreateTargetContainer();
            var glossary = new TestDocument("glossary.tsv", "test\tglossarytest");
            Uri frenchGlossarySasUri = CreateGlossary(glossary);
#endif
            var glossaryFormat = "TSV";

            var input1 = new DocumentTranslationInput(source1SasUri, frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));
            input1.AddTarget(spanishTargetSasUri, "es");

            var input2 = new DocumentTranslationInput(source2SasUri, arabicTargetSasUri, "ar");
            input2.AddTarget(frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));

            var inputs = new List<DocumentTranslationInput>()
                {
                    input1,
                    input2
                };

            DocumentTranslationOperation operation = client.StartTranslation(inputs);

            TimeSpan pollingInterval = new(1000);

            while (true)
            {
                operation.UpdateStatus();

                Console.WriteLine($"  Status: {operation.Status}");
                Console.WriteLine($"  Created on: {operation.CreatedOn}");
                Console.WriteLine($"  Last modified: {operation.LastModified}");
                Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
                Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
                Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
                Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
                Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

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

            foreach (DocumentStatusResult document in operation.GetValues())
            {
                Console.WriteLine($"Document with Id: {document.Id}");
                Console.WriteLine($"  Status:{document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"  Error Code: {document.Error.Code}");
                    Console.WriteLine($"  Message: {document.Error.Message}");
                }
            }
        }
    }
}
