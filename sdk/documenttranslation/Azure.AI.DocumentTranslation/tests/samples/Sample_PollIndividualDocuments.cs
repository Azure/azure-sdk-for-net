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
        [Ignore("Samples not working yet")]
        public void PollIndividualDocuments()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            Uri sourceUri = new Uri("<source SAS URI>");
            Uri targetUri = new Uri("<target SAS URI>");

            #region Snippet:PollIndividualDocuments

            //@@ Uri sourceUri = <source SAS URI>;
            //@@ Uri targetUri = <target SAS URI>;

            var input = new DocumentTranslationInput(sourceUri, targetUri, "es");
            DocumentTranslationOperation operation = client.StartTranslation(input);

            TimeSpan pollingInterval = new TimeSpan(1000);

            Pageable<DocumentStatusResult> documents = operation.GetAllDocumentStatuses();
            foreach (DocumentStatusResult document in documents)
            {
                Console.WriteLine($"Polling Status for document{document.TranslatedDocumentUri}");

                Response<DocumentStatusResult> status = operation.GetDocumentStatus(document.DocumentId);

                while (!status.Value.HasCompleted)
                {
                    Thread.Sleep(pollingInterval);
                    status = operation.GetDocumentStatus(document.DocumentId);
                }

                if (status.Value.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"  URI: {document.TranslatedDocumentUri}");
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
