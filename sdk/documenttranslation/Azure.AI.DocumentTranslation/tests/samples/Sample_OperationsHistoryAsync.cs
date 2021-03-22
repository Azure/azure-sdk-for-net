// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests.Samples
{
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public async Task OperationsHistoryAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:OperationsHistoryAsync

            AsyncPageable<TranslationStatusDetail> operationsStatus = client.GetTranslationsAsync();

            int operationsCount = 0;
            int totalDocs = 0;
            int docsCancelled = 0;
            int docsSucceeded = 0;
            int maxDocs = 0;
            TranslationStatusDetail largestOperation = null;

            await foreach (TranslationStatusDetail operationStatus in operationsStatus)
            {
                operationsCount++;
                totalDocs += operationStatus.DocumentsTotal;
                docsCancelled += operationStatus.DocumentsCancelled;
                docsSucceeded += operationStatus.DocumentsSucceeded;
                if (totalDocs > maxDocs)
                {
                    maxDocs = totalDocs;
                    largestOperation = operationStatus;
                }
            }

            Console.WriteLine($"# of operations: {operationsCount}");
            Console.WriteLine($"Total Documents: {totalDocs}");
            Console.WriteLine($"DocumentsSucceeded: {docsSucceeded}");
            Console.WriteLine($"Cancelled Documents: {docsCancelled}");

            Console.WriteLine($"Largest operation is {largestOperation} and has the documents:");

            DocumentTranslationOperation operation = new DocumentTranslationOperation(largestOperation.TranslationId, client);

            AsyncPageable<DocumentStatusDetail> docs = operation.GetAllDocumentsStatusAsync();

            await foreach (DocumentStatusDetail docStatus in docs)
            {
                Console.WriteLine($"Document {docStatus.LocationUri} has status {docStatus.Status}");
            }

            #endregion
        }
    }
}
