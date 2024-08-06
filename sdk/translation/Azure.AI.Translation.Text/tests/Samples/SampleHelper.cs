// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Translation.Text.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.Translation.Text.Samples
{
    internal class SampleHelper : SamplesBase<TextTranslationTestEnvironment>
    {
        public TextTranslationClient CreateTextTranslationClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;

            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);

            return client;
        }
    }
}
