// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public void PollIndividualDocuments()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri sourceUri = new Uri("");
            Uri targetUri = new Uri("");

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var input = new TranslationConfiguration(sourceUri, targetUri, "es");
            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new TimeSpan(1000);

            Pageable<DocumentStatusDetail> documents = operation.GetAllDocumentsStatus();
            foreach (DocumentStatusDetail document in documents)
            {
                Console.WriteLine($"Polling Status for document{document.LocationUri}");

                Response<DocumentStatusDetail> status = operation.GetDocumentStatus(document.DocumentId);

                while (!status.Value.HasCompleted)
                {
                    Thread.Sleep(pollingInterval);
                    status = operation.GetDocumentStatus(document.DocumentId);
                }

                if (status.Value.Status == TranslationStatus.Succeeded)
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
        }
    }
}
