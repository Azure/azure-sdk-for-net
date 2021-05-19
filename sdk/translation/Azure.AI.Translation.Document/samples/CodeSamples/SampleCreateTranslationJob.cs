// <copyright file="SampleCreateTranslationJob.cs" company="Microsoft Corporation">
// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>

using Azure;
using Azure.AI.Translation.Document;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/**
FILE: SampleCreateTranslationJob.cs
DESCRIPTION:
    This sample demonstrates how to create a translation job for documents in your Azure Blob
    Storage container and wait until the job is completed.
USAGE:
    Set the environment variables with your own values before running the sample:
    1) AZURE_DOCUMENT_TRANSLATION_ENDPOINT - the endpoint to your Document Translation resource.
    2) AZURE_DOCUMENT_TRANSLATION_KEY - your Document Translation API key.
    3) AZURE_SOURCE_CONTAINER_URL - the container SAS URL to your source container which has the documents
        to be translated.
    4) AZURE_TARGET_CONTAINER_URL - the container SAS URL to your target container where the translated documents
        will be written.
**/

namespace DocumentTranslatorSamples
{
    class SampleCreateTranslationJob
    {
        public async static Task RunSampleAsync()
        {
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_ENDPOINT"));
            var key = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_KEY");
            var sourceContainerUrl = new Uri(Environment.GetEnvironmentVariable("AZURE_SOURCE_CONTAINER_URL"));
            var targetContainerUrl = new Uri(Environment.GetEnvironmentVariable("AZURE_TARGET_CONTAINER_URL"));

            var documentTranslationClient = new DocumentTranslationClient(endpoint, new AzureKeyCredential(key));

            var jobRequest = new List<DocumentTranslationInput>()
            {
                new DocumentTranslationInput(
                    source: new TranslationSource(sourceContainerUrl),
                    targets: new List<TranslationTarget>()
                        {
                            new TranslationTarget(targetUri: targetContainerUrl, languageCode: "es")
                        }
                    )
            };

            // Submit the translation job and wait for it to finish
            var jobResult = await documentTranslationClient.StartTranslationAsync(jobRequest).ConfigureAwait(false);
            await jobResult.WaitForCompletionAsync().ConfigureAwait(false);

            Console.WriteLine($"Job status: {jobResult.Status}");
            Console.WriteLine($"Job created on: {jobResult.CreatedOn}");
            Console.WriteLine($"Job last updated on: {jobResult.LastModified}");
            Console.WriteLine($"Total number of translations on documents: {jobResult.DocumentsTotal}");
            Console.WriteLine("\nOf total documents...");
            Console.WriteLine($"{jobResult.DocumentsFailed} failed");
            Console.WriteLine($"{jobResult.DocumentsSucceeded} succeeded");

            await foreach (var document in jobResult.GetAllDocumentStatusesAsync())
            {
                if (document.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document at {document.SourceDocumentUri} was translated to {document.TranslateTo} language.You can find translated document at {document.TranslatedDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"Document ID: {document.DocumentId}, Error Code: {document.Error.ErrorCode}, Message: {document.Error.Message}");
                }
            }
        }
    }
}
