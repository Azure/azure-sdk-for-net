// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using System.Threading;

namespace Azure.AI.TextTranslator.Tests
{
    public class TextTranslatorTestEnvironment : TestEnvironment
    {
        public TextTranslatorTestEnvironment()
        {
        }

        /// <summary>The name of the environment variable from which the Text Translator resource's endpoint will be extracted for the live tests.</summary>
        private const string EndpointEnvironmentVariableName = "TEXT_TRANSLATION_ENDPOINT";

        /// <summary>The name of the environment variable from which the Text Translator resource's endpoint will be extracted for the live tests.</summary>
        private const string CustomEndpointEnvironmentVariableName = "TEXT_TRANSLATION_CUSTOM_ENDPOINT";

        /// <summary>The name of the environment variable from which the Text Translator resource's API key will be extracted for the live tests.</summary>
        private const string ApiKeyEnvironmentVariableName = "TEXT_TRANSLATION_API_KEY";

        /// <summary>The name of the environment variable from which the Text Translator resource's API key will be extracted for the live tests.</summary>
        private const string RegionEnvironmentVariableName = "TEXT_TRANSLATION_REGION";

        public string ApiKeyForTokenGeneration => GetVariable(ApiKeyEnvironmentVariableName);
        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string CustomEndpoint => GetRecordedVariable(CustomEndpointEnvironmentVariableName);
        public string Region => GetRecordedVariable(RegionEnvironmentVariableName);

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            string endpoint = GetOptionalVariable(EndpointEnvironmentVariableName);
            var client = new TranslatorClient(new Uri(endpoint), Credential);
            try
            {
                await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }
            return true;
        }
    }
}
