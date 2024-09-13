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
        public void StartTranslationwithSourceInput()
        {
            /**
            FILE: SampleTranslationWithAzureBlob.cs
            DESCRIPTION:
                This sample demonstrates how to start batch document translation by specifying some of the sourceInput options like
                source language, storage source and DocumentFilter prefix and suffix
            **/
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
#if SNIPPET
            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");
#else
            Uri sourceUri = CreateSourceContainer(oneTestDocuments);
            Uri targetUri = CreateTargetContainer();
#endif
            //Creating a TranslationSource object with sourceURI, sourceLanguage, storageSource, DocumentFilterPrefix and DocumentFilterSuffix
            TranslationSource translationSource = new TranslationSource(sourceUri, "en", "AzureBlob", "Document", "txt");
            TranslationTarget translationTarget = new TranslationTarget(targetUri, "fr");
            List<TranslationTarget> targets = new List<TranslationTarget> { translationTarget };
            var input = new DocumentTranslationInput(translationSource, targets);
            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new(1000);

            while (true)
            {
                operation.UpdateStatus();

                Console.WriteLine($"Status: {operation.Status}");
                Console.WriteLine($"Created on: {operation.CreatedOn}");
                Console.WriteLine($"Last modified: {operation.LastModified}");
                Console.WriteLine($"Total documents: {operation.DocumentsTotal}");
                Console.WriteLine($"Succeeded: {operation.DocumentsSucceeded}");
                Console.WriteLine($"Failed: {operation.DocumentsFailed}");
                Console.WriteLine($"In Progress: {operation.DocumentsInProgress}");
                Console.WriteLine($"Not started: {operation.DocumentsNotStarted}");

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
                Console.WriteLine($"Status:{document.Status}");
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Translated Document Uri: {document.TranslatedDocumentUri}");
                    Console.WriteLine($"Translated to language code: {document.TranslatedToLanguageCode}.");
                    Console.WriteLine($"Document source Uri: {document.SourceDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"Document source Uri: {document.SourceDocumentUri}");
                    Console.WriteLine($"Error Code: {document.Error.Code}");
                    Console.WriteLine($"Message: {document.Error.Message}");
                }
            }
        }
    }
}
