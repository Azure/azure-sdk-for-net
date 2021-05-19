// <copyright file="SampleListAllSubmittedJobs.cs" company="Microsoft Corporation">
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
FILE: SampleListAllSubmittedJobs.cs
DESCRIPTION:
    This sample demonstrates how to list all the submitted translation jobs for the resource and
    wait until done on any jobs that are still running.
USAGE:
    Set the environment variables with your own values before running the sample:
    1) AZURE_DOCUMENT_TRANSLATION_ENDPOINT - the endpoint to your Document Translation resource.
    2) AZURE_DOCUMENT_TRANSLATION_KEY - your Document Translation API key.
**/

namespace DocumentTranslatorSamples
{
    class SampleListAllSubmittedJobs
    {
        public async static Task RunSampleAsync()
        {
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_ENDPOINT"));
            var key = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_KEY");

            var documentTranslationClient = new DocumentTranslationClient(endpoint, new AzureKeyCredential(key));

            await foreach (var jobStatus in documentTranslationClient.GetTranslationsAsync())
            {
                if (jobStatus.Status == TranslationStatus.Running)
                {
                    DocumentTranslationOperation operation = new DocumentTranslationOperation(jobStatus.TranslationId, documentTranslationClient);
                    await operation.WaitForCompletionAsync();
                }

                Console.WriteLine($"Job ID: {jobStatus.TranslationId}");
                Console.WriteLine($"Job status: {jobStatus.Status}");
                Console.WriteLine($"Job created on: {jobStatus.CreatedOn}");
                Console.WriteLine($"Job last updated on: {jobStatus.LastModified}");
                Console.WriteLine($"Total number of translations on documents: {jobStatus.DocumentsTotal}");
                Console.WriteLine($"Total number of characters charged: {jobStatus.TotalCharactersCharged}");
                Console.WriteLine("\nOf total documents...");
                Console.WriteLine($"{jobStatus.DocumentsFailed} failed");
                Console.WriteLine($"{jobStatus.DocumentsSucceeded} succeeded");
                Console.WriteLine($"{jobStatus.DocumentsCancelled} cancelled");
            }
        }
    }
}
