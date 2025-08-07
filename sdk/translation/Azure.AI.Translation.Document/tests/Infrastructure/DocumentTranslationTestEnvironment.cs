// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Translation.Document.Tests
{
    public class DocumentTranslationTestEnvironment : TestEnvironment
    {
        public DocumentTranslationTestEnvironment()
        {
        }

        /// <summary>The name of the environment variable from which the Document Translator resource's endpoint will be extracted for the live tests.</summary>
        private const string EndpointEnvironmentVariableName = "DOCUMENT_TRANSLATION_ENDPOINT";

        /// <summary>The name of the environment variable from which the Document Translator resource's API key will be extracted for the live tests.</summary>
        private const string ApiKeyEnvironmentVariableName = "DOCUMENT_TRANSLATION_API_KEY";

        /// <summary>The name of the environment variable from which the Document Translator Storage Account Name will be extracted for the live tests.</summary>
        private const string StorageAccountNameEnvironmentVariableName = "DOCUMENT_TRANSLATION_STORAGE_NAME";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string StorageAccountName => GetRecordedVariable(StorageAccountNameEnvironmentVariableName);

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            string endpoint = GetOptionalVariable(EndpointEnvironmentVariableName);
            var client = new DocumentTranslationClient(new Uri(endpoint), Credential);
            try
            {
                await client.GetSupportedFormatsAsync("document");
                await client.GetSupportedFormatsAsync("glossary");
                client.GetTranslationStatuses().Take(2);
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }
            return true;
        }
    }
}
