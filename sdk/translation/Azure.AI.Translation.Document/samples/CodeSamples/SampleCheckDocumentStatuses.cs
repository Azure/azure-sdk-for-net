// <copyright file="SampleCheckDocumentStatuses.cs" company="Microsoft Corporation">
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
FILE: SampleCheckDocumentStatuses.cs
DESCRIPTION:
    This sample demonstrates how to create a translation job and then monitor each document's status
    and progress within the job.
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
    class SampleCheckDocumentStatuses
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

            // Submit the translation job request
            var jobResult = await documentTranslationClient.StartTranslationAsync(jobRequest).ConfigureAwait(false);

            HashSet<string> completedDocuments = new HashSet<string>();

            while (!jobResult.HasCompleted)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                await jobResult.UpdateStatusAsync().ConfigureAwait(false);
                await foreach (var document in jobResult.GetAllDocumentStatusesAsync())
                {
                    if (!completedDocuments.Contains(document.DocumentId))
                    {
                        if (document.Status == TranslationStatus.Succeeded)
                        {
                            Console.WriteLine($"Document at {document.SourceDocumentUri} was translated to {document.TranslateTo} language.You can find translated document at {document.TranslatedDocumentUri}");
                            completedDocuments.Add(document.DocumentId);
                        }
                        else if (document.Status == TranslationStatus.Failed)
                        {
                            Console.WriteLine($"Document ID: {document.DocumentId}, Error Code: {document.Error.ErrorCode}, Message: {document.Error.Message}");
                            completedDocuments.Add(document.DocumentId);
                        }
                        else if (document.Status == TranslationStatus.Running)
                        {
                            Console.WriteLine($"Document ID: {document.DocumentId}, translation progress is {document.TranslationProgressPercentage} percent");
                        }
                    }
                }
            }
        }
    }
}
