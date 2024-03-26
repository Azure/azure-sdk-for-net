// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Translator.Document.Tests
{
    public class DocumentTranslationTestEnvironment : TestEnvironment
    {
        /// <summary>The name of the environment variable from which the Document Translator resource's endpoint will be extracted for the live tests.</summary>
        private const string EndpointEnvironmentVariableName = "DOCUMENT_TRANSLATOR_CUSTOM_ENDPOINT";

        /// <summary>The name of the environment variable from which the Document Translator resource's API key will be extracted for the live tests.</summary>
        private const string ApiKeyEnvironmentVariableName = "DOCUMENT_TRANSLATOR_API_KEY";

        public DocumentTranslationTestEnvironment()
        {
        }

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            string endpoint = GetOptionalVariable(EndpointEnvironmentVariableName);
            var client = new SingleDocumentTranslationClient(new Uri(endpoint), Credential);
            try
            {
                string filePath = Path.Combine("TestData", "test-input.txt");
                using Stream fileStream = File.OpenRead(filePath);

                var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), BinaryData.FromStream(fileStream), "text/html");
                var response = await client.DocumentTranslateAsync("hi", sourceDocument).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }
            return true;
        }
    }
}
