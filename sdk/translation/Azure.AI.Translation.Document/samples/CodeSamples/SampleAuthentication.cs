// <copyright file="SampleAuthentication.cs" company="Microsoft Corporation">
// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>
using Azure;
using Azure.AI.Translation.Document;
using System;
using System.Threading.Tasks;

/**
FILE: SampleAuthentication.cs
DESCRIPTION:
    This sample demonstrates how to authenticate to the Document Translation service.
    1) Use a Document Translation API key with AzureKeyCredential from azure.core.credentials
    Note: the endpoint must be formatted to use the custom domain name for your resource:
    https://<NAME-OF-YOUR-RESOURCE>.cognitiveservices.azure.com/
USAGE:
Set the environment variables with your own values before running the sample:
    1) AZURE_DOCUMENT_TRANSLATION_ENDPOINT - the endpoint to your Document Translation resource.
    2) AZURE_DOCUMENT_TRANSLATION_KEY - your Document Translation API key
**/

namespace DocumentTranslatorSamples
{
    public class SampleAuthentication
    {
        public async static Task RunSampleAsync()
        {
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_ENDPOINT"));
            var key = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_KEY");

            var documentTranslationClient = new DocumentTranslationClient(endpoint, new AzureKeyCredential(key));

            // Make calls with authenticated client
            var result = await documentTranslationClient.GetDocumentFormatsAsync().ConfigureAwait(false);
        }
    }
}
