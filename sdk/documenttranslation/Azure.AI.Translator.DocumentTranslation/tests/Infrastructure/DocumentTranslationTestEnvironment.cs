// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Translator.DocumentTranslation.Tests
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

        /// <summary>The name of the environment variable from which the Document Translator Storage Primary key will be extracted for the live tests.</summary>
        private const string StorageConnectionStringEnvironmentVariableName = "DOCUMENT_TRANSLATION_CONNECTION_STRING";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string StorageConnectionString => GetRecordedVariable(StorageConnectionStringEnvironmentVariableName, options => options.HasSecretConnectionStringParameter("AccountKey", SanitizedValue.Base64));
        public string StorageAccountName => GetRecordedVariable(StorageAccountNameEnvironmentVariableName);
    }
}
